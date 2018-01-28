using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NaoSeRepita
{
    public partial class TagSelection : WindowBase
    {
        public List<string> TagList = new List<string>();

        public TagSelection()
        {
            InitializeComponent();
        }

        public TagSelection(List<string> tags)
        {
            InitializeComponent();
            lstTags.DataSource = tags;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (string tag in lstTags.SelectedItems)
                TagList.Add(tag);
            this.Close();
        }
    }
}