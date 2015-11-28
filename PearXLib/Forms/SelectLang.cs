using System;
using System.IO;
using System.Windows.Forms;

namespace PearXLib.Forms
{
    /// <summary>
    /// A language selection form.
    /// </summary>
    public partial class SelectLang : Form
    {
        /// <summary>
        /// Selected language.
        /// </summary>
        public string Selected;

        private string[] listoflangs;
        private bool canClose = false;

        /// <summary>
        /// Initializates a new SelectLang component.
        /// </summary>
        /// <param name="appname">Application name.</param>
        public SelectLang(string appname)
        {
            InitializeComponent();
            string[] listoffiles = Directory.GetFiles(d.pxDir + PXL.s + appname + PXL.s + "langs" + PXL.s);
            listoflangs = new String[listoffiles.Length];
            string lang;
            int count = 0;
            foreach(string s in listoffiles)
            {
                if(Path.GetExtension(s) == ".lang")
                {
                    lang = Path.GetFileNameWithoutExtension(s);
                    string str = String.Empty;
                    bool errored = false;
                    try
                    {
                        str = File.ReadAllText(d.pxDir + PXL.s + appname + PXL.s + "langs" + PXL.s + lang + ".langinfo");
                    }
                    catch { errored = true; }
                    if (!errored)
                    {
                        listBoxLangs.Items.Add(str);
                        listoflangs[count] = lang;
                        count++;
                    }
                }
            }
        }

        private void listBoxLangs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected = listoflangs[listBoxLangs.SelectedIndex];
            canClose = true;
            this.Close();
        }

        private void SelectLang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose)
            {
                e.Cancel = true;
            }
        }
    }
}
