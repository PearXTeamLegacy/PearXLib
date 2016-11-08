using System;
using System.Collections;
using System.Drawing;

namespace PearXLib.Engine
{
    /// <summary>
    /// Class for form's boxes.
    /// </summary>
    /// <seealso cref="IEnumerator" />
    /// <seealso cref="System.Collections.IEnumerable" />
    public class FormBoxes : IEnumerator, IEnumerable
    {

        private int pos = -1;

        /// <summary>
        /// The close box.
        /// </summary>
        public virtual FormBox CloseBox { get; set; } = new FormBox();

        /// <summary>
        /// The maximize box.
        /// </summary>
        public virtual FormBox MaximizeBox { get; set; } = new FormBox();

        /// <summary>
        /// The to tray box.
        /// </summary>
        public virtual FormBox ToTrayBox { get; set; } = new FormBox();

        /// <summary>
        /// <see cref="IEnumerator.MoveNext"/>
        /// </summary>
        public bool MoveNext()
        {
            if (pos == 2)
            {
                Reset();
                return false;
            }
            pos++;
            return true;
        }

        /// <summary>
        /// <see cref="IEnumerator.Reset"/>
        /// </summary>
        public void Reset()
        {
            pos = -1;
        }

        /// <summary>
        /// <see cref="IEnumerator.Current"/>
        /// </summary>
        public object Current
        {
            get
            {
                switch (pos)
                {
                    case 0:
                        return CloseBox;
                    case 1:
                        return MaximizeBox;
                    case 2:
                        return ToTrayBox;
                }
                return null;
            }
        }

        /// <summary>
        /// <see cref="IEnumerable.GetEnumerator"/>
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        /// <summary>
        /// Gets the <see cref="FormBox"/>. 0 - CloseBox, 1 - MaximizeBox, 2 - ToTrayBox.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <exception cref="IndexOutOfRangeException">You can use only 0-2 indexes.</exception>
        public FormBox this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return CloseBox;
                    case 1:
                        return MaximizeBox;
                    case 2:
                        return ToTrayBox;
                }
                throw new IndexOutOfRangeException("You can use only 0-2 indexes.");
            }
        }

        /// <summary>
        /// Returns count of the boxes in this class.
        /// </summary>
        public int Count => 3;
    }

    /// <summary>
    /// Form Box
    /// </summary>
    public class FormBox
    {
        /// <summary>
        /// Is this box enabled?
        /// </summary>
        public virtual bool Enabled { get; set; } = true;

        /// <summary>
        /// Box's rectangle. Set this in <see cref="XFormBase.UpdateRectangles"/>
        /// </summary>
        public virtual Rectangle Rectangle { get; set; } = Rectangle.Empty;

        /// <summary>
        /// Is this box focused?
        /// </summary>
        public virtual bool Focused { get; set; }
    }

    /// <summary>
    /// A handler for <see cref="XFormBase.BoxFocused"/>
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="index">The index.</param>
    public delegate void FormBoxHandler(object sender, int index);
}
