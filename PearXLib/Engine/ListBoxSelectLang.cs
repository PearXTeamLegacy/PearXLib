using System;
using System.IO;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// EventArgs for the ListBoxSelectLang.
    /// </summary>
    public class LangEventArgs
    {
        /// <summary>
        /// Initializes a new LangEventArgs component.
        /// </summary>
        /// <param name="selected">Selected language name.</param>
        public LangEventArgs(string selected)
        {
            SelectedLang = selected;
        }

        /// <summary>
        /// Selected language name.
        /// </summary>
        public string SelectedLang { get; private set; }
    }

    /// <summary>
    /// A ListBox, made for easy language selection without crutches.
    /// </summary>
    public class ListBoxSelectLang : ListBox
    {
        /// <summary>
        /// Language Event Handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Args</param>
        public delegate void LangEventHandler(object sender, LangEventArgs e);

        /// <summary>
        /// Performs on language selected.
        /// </summary>
        public event LangEventHandler LanguageSelected;

        private string _Path = "";
        private string[] listoflangs;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBoxSelectLang"/> class.
        /// </summary>
        public ListBoxSelectLang()
        {
            SelectedIndexChanged += ControlSelectedIndexChanged;
        }

        /// <summary>
        /// Path to LangFiles (with slash)
        /// </summary>
        public string PathToLangs
        {
            get { return _Path; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Items.Clear();
                    string[] listoffiles = Directory.GetFiles(value);
                    listoflangs = new string[listoffiles.Length];
                    int count = 0;
                    foreach (string s in listoffiles)
                    {
                        if (Path.GetExtension(s) == ".lang")
                        {
                            string lang = Path.GetFileNameWithoutExtension(s);
                            try
                            {
                                string str = File.ReadAllText(value + lang + ".langinfo");
                                Items.Add(str);
                                listoflangs[count] = lang;
                                count++;
                            }
                            catch {}
                        }
                    }
                    _Path = value;
                }
            }
        }

        private void ControlSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndex != -1 && SelectedIndex <= listoflangs.Length)
            {
                LanguageSelected?.Invoke(this, new LangEventArgs(listoflangs[SelectedIndex]));
            }
        }
    }
}
