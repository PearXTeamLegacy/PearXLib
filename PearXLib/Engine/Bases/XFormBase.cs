using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine.Bases
{
	/// <summary>
	/// Base for all PearXLib's forms.
	/// </summary>
	/// <seealso cref="Form" />
	public class XFormBase : Form
	{
		private bool _DrawTitle = true;
		private FormBoxes _Boxes = new FormBoxes();

		/// <summary>
		/// Initializes a new instance of the <see cref="XFormBase"/> class.
		/// </summary>
		public XFormBase()
		{
			MouseDown += ControlMouseDown;
			MouseUp += ControlMouseUp;
			MouseMove += ControlMouseMove;
			MouseLeave += ControlMouseLeave;
			Paint += ControlPaint;
			DoubleBuffered = true;
			FormBorderStyle = FormBorderStyle.None;
			ResizeRedraw = true;
		}

		#region Params        
		/// <summary>
		/// Occurs when form minimized.
		/// </summary>
		public event EventHandler Minimized;

		/// <summary>
		/// Occurs when form maximized.
		/// </summary>
		public event EventHandler Maximized;

		/// <summary>
		/// Occurs when form turned to tray.
		/// </summary>
		public event EventHandler TurnedToTray;

		/// <summary>
		/// Occurs when form expanded from tray.
		/// </summary>
		public event EventHandler ExpandedFromTray;

		/// <summary>
		/// Occurs when any box focused.
		/// </summary>
		public event FormBoxHandler BoxFocused;

		/// <summary>
		/// Can move form?
		/// </summary>
		[DefaultValue(true)]
		public virtual bool CanMove { get; set; } = true;

		/// <summary>
		/// Draw form's title?
		/// </summary>
		[DefaultValue(true)]
		public virtual bool DrawTitle
		{
			get { return _DrawTitle; }
			set { _DrawTitle = value; Refresh(); }
		}

		/// <summary>
		/// Gets the move rectangle.
		/// </summary>
		public virtual Rectangle MoveRectangle => new Rectangle(0, 0, Width, Height);

		/// <summary>
		/// Form's boxes.
		/// </summary>
		public virtual FormBoxes Boxes
		{
			get { return _Boxes; }
			set { _Boxes = value; Refresh(); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:PearXLib.Engine.Bases.XFormBase"/> can be resized.
		/// </summary>
		/// <value><c>true</c> if can resized; otherwise, <c>false</c>.</value>
		public virtual bool CanResize { get; set; } = false;

		public virtual short ResizeWidth { get; set; } = 2;

		/// <summary>
		/// Current form state.
		/// </summary>
		public FormState State = FormState.None;

		/// <summary>
		/// Is form maximized?
		/// </summary>
		public bool IsMaximized;
		#endregion

		#region Ons        
		/// <summary>
		/// Calls <see cref="BoxFocused"/> event.
		/// </summary>
		public virtual void OnBoxFocused(int index)
		{
			BoxFocused?.Invoke(this, index);
		}

		/// <summary>
		/// Calls <see cref="Maximized"/> event.
		/// </summary>
		public virtual void OnMaximized()
		{
			Maximized?.Invoke(this, new EventArgs());
		}

		/// <summary>
		/// Calls <see cref="Minimized"/> event.
		/// </summary>
		public virtual void OnMinimized()
		{
			Minimized?.Invoke(this, new EventArgs());
		}

		/// <summary>
		/// Calls <see cref="ExpandedFromTray"/> event.
		/// </summary>
		public virtual void OnExpandedFromTray()
		{
			ExpandedFromTray?.Invoke(this, new EventArgs());
		}

		/// <summary>
		/// Calls <see cref="TurnedToTray"/> event.
		/// </summary>
		public virtual void OnTurnedToTray()
		{
			TurnedToTray?.Invoke(this, new EventArgs());
		}
		#endregion

		#region Methods
		private void UpdateState()
		{
			if (Clicked)
			{
				if (MoveRectangle.Contains(PointToClient(Cursor.Position)))
				{
					State = FormState.Move;
					return;
				}
			}
			State = FormState.None;
		}

		private void ResetBar()
		{
			Cursor = Cursors.Default;
		}

		/// <summary>
		/// Occurs when form repainted.
		/// </summary>
		public virtual void UpdateRectangles()
		{
			
		}
		#endregion

		private Size lastSize;
		private Point lastLocation;
		private bool Clicked;
		private Point lastPoint;

		private void ControlMouseDown(object sender, MouseEventArgs e)
		{
			Clicked = true;
			UpdateState();
			lastPoint = new Point(e.X, e.Y);
		}

		private void ControlMouseUp(object sender, MouseEventArgs e)
		{
			Clicked = false;
			UpdateState();
			lastPoint = Point.Empty;

			for (int i = 0; i < Boxes.Count; i++)
			{
				FormBox box = Boxes[i];
				if (box.Enabled)
				{
					if (box.Focused)
					{
						switch (i)
						{
							case 0:
								Close();
								break;
							case 1:
								if (IsMaximized)
								{
									Size = lastSize;
									Location = lastLocation;
									OnMinimized();
								}
								else
								{
									lastLocation = Location;
									lastSize = Size;
									Location = Point.Empty;
									Size = Screen.FromControl(this).WorkingArea.Size;
									OnMaximized();
								}
								IsMaximized = !IsMaximized;
								break;
							case 2:
								switch (WindowState)
								{
									case FormWindowState.Minimized:
										WindowState = FormWindowState.Maximized;
										OnExpandedFromTray();
										break;
									default:
										WindowState = FormWindowState.Minimized;
										OnTurnedToTray();
										break;
								}
								break;
						}
					}
				}
			}
		}

		private void ControlMouseMove(object sender, MouseEventArgs e)
		{
			if (CanMove)
			{
				if (State == FormState.Move)
					Location = new Point(Location.X + (e.X - lastPoint.X), Location.Y + (e.Y - lastPoint.Y));
			}

			bool isInBox = false;
			for (int i = 0; i < Boxes.Count; i++)
			{
				FormBox box = Boxes[i];
				if (box.Enabled)
				{
					if (box.Rectangle.Contains(PointToClient(Cursor.Position)))
					{
						isInBox = true;
						if (!box.Focused)
						{
							box.Focused = true;
							Cursor = Cursors.Hand;
							OnBoxFocused(i);
							Refresh();
						}
					}
					else if (box.Focused)
					{
						box.Focused = false;
						Refresh();
					}
				}
			}
			if (!isInBox)
				ResetBar();
		}

		private void ControlMouseLeave(object sender, EventArgs e)
		{
			ResetBar();
		}

		private void ControlPaint(object sender, PaintEventArgs e)
		{
			UpdateRectangles();
		}
	}

	/// <summary>
	/// Form manipulation state.
	/// </summary>
	public enum FormState
	{
		/// <summary>
		/// Move this form.
		/// </summary>
		Move,
		/// <summary>
		/// 
		/// </summary>
		None,

		/// <summary>
		///  *##
		/// ###
		/// ###
		/// </summary>
		ResizeTL,
		/// <summary>
		/// ###
		/// *##
		/// ###
		/// </summary>
		ResizeL,
		/// <summary>
		/// ###
		/// ###
		/// *##
		/// </summary>
		ResizeBL,
		/// <summary>
		/// #*#
		/// ###
		/// ###
		/// </summary>
		ResizeT,
		/// <summary>
		/// ###
		/// ###
		/// #*#
		/// </summary>
		ResizeB,
		/// <summary>
		/// ##*
		/// ###
		/// ###
		/// </summary>
		ResizeTR,
		/// <summary>
		/// ###
		/// ##*
		/// ###
		/// </summary>
		ResizeR,
		/// <summary>
		/// ###
		/// ###
		/// ##*
		/// </summary>
		ResizeBR
	}
}
