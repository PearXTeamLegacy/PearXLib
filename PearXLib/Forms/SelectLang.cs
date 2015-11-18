using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
            string[] listoffiles = Directory.GetFiles(d.pxDir + PXL.s + appname + PXL.s + "langs" + PXL.s );
            listoflangs = new String[listoffiles.Length];
            string lang;
            int count = -1;
            foreach(string s in listoffiles)
            {
                if(Path.GetExtension(s) == ".lang")
                {
                    count++;
                    lang = Path.GetFileNameWithoutExtension(s);
                    string str = File.ReadAllText(d.pxDir + PXL.s + appname + PXL.s + "langs" + PXL.s + lang + ".langinfo");
                    listBoxLangs.Items.Add(str);
                    listoflangs[count] = lang;
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
