using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine.Bases
{
	/// <summary>
	/// Checkbox state
	/// </summary>
	public enum CheckboxState
	{
		/// <summary>
		/// Mouse on checkbox.
		/// </summary>
		Focused,
		/// <summary>
		/// Mouse not on checkbox.
		/// </summary>
		None
	}

	/// <summary>
	/// An EventHandler for the checkboxes.
	/// </summary>
	/// <param name="sender">The sender</param>
	/// <param name="isChecked">Is checkbox checked?</param>
	public delegate void CheckboxHandler(object sender, bool isChecked);

	/// <summary>
	/// A base for checkboxes.
	/// </summary>
	public class XCheckboxBase : XTextControlBase
	{
		private string text;
		private bool chkd;

		/// <summary>
		/// Initializes a new instance of the <see cref="XCheckboxBase"/> class.
		/// </summary>
		public XCheckboxBase()
		{
			Size = new Size(160, 32);
			Click += ControlClick;
			MouseEnter += ControlMouseEnter;
			MouseLeave += ControlMouseLeave;
		}

		#region Params

		/// <summary>
		/// Performs on check/uncheck.
		/// </summary>
		public event CheckboxHandler CheckedChanged;

		/// <summary>
		/// The text on the checkbox.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
		public override string Text
		{
			get { return text; }
			set { text = value; Refresh(); }
		}

		/// <summary>
		/// Is checkbox checked?
		/// </summary>
		[DefaultValue(false)]
		public virtual bool Checked
		{
			get { return chkd; }
			set
			{
				chkd = value;
				Refresh();
				OnCheckedChanged(value);
			}
		}

		/// <summary>
		/// Checkbox's current state.
		/// </summary>
		public virtual CheckboxState State { get; private set; } = CheckboxState.None;

		[DefaultValue(typeof(Cursor), "Hand")]
		public override Cursor Cursor { get; set; } = Cursors.Hand;

		#endregion

		/// <summary>
		/// Calls the <see cref="CheckedChanged"/> event.
		/// </summary>
		/// <param name="isChecked">Is checkbox checked?</param>
		public virtual void OnCheckedChanged(bool isChecked)
		{
			CheckedChanged?.Invoke(this, isChecked);
		}

		/// <summary>
		/// Paints the base.
		/// </summary>
		/// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
		protected void PaintBase(PaintEventArgs e)
		{
			if (!string.IsNullOrEmpty(Text))
			{
				var pf = e.Graphics.MeasureString(Text, Font);
				DrawFancyText(e.Graphics, Text, Font, new SolidBrush(ForeColor), new PointF(Height, (Height - pf.Height) / 2));
			}
		}

		private void ControlClick(object sender, EventArgs e)
		{
			Checked = !Checked;
		}

		private void ControlMouseEnter(object sender, EventArgs e)
		{
			State = CheckboxState.Focused;
			Refresh();
		}


		private void ControlMouseLeave(object sender, EventArgs e)
		{
			State = CheckboxState.None;
			Refresh();
		}
	}
}
