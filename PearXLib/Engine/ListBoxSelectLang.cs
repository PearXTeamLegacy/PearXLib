using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// EventArgs for the ListBoxSelectLang.
    /// </summary>
    public class LangEventArgs
    {
        /// <summary>
        /// Initializates a new LangEventArgs component.
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
        /// Path to langfiles (with slash)
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
                    string lang;
                    int count = 0;
                    foreach (string s in listoffiles)
                    {
                        if (Path.GetExtension(s) == ".lang")
                        {
                            lang = Path.GetFileNameWithoutExtension(s);
                            string str = string.Empty;
                            bool errored = false;
                            try
                            {
                                str = File.ReadAllText(value + lang + ".langinfo");
                            }
                            catch { errored = true; }
                            if (!errored)
                            {
                                Items.Add(str);
                                listoflangs[count] = lang;
                                count++;
                            }
                        }
                    }
                    _Path = value;
                }
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (SelectedIndex != -1 && SelectedIndex <= listoflangs.Length)
            {
                LanguageSelected(this, new LangEventArgs(listoflangs[SelectedIndex]));
            }
        }
    }
}
