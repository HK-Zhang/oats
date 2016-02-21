using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FastStructure.LAF;
using FastStructure.LAF.LAFComponents;

namespace FastStructure.GUI
{
    public partial class PropertyForm : LAFForm
    {
        private string hint = string.Empty;
        private string data = string.Empty;
        public PropertyForm()
        {
#if DESIGNTIME
  InitializeComponent();        
#endif
        }

        public override void DataThread()
        {
            hint = "Hint";
            base.DataThread();
        }

        public override void RefreshForm()
        {
            lblHint.Text = hint + data;
        }

        public override LAFForm Clone()
        {
            PropertyForm result = new PropertyForm();
            result.data = this.data;
            return result;
        }

        private void btnChg_Click(object sender, EventArgs e)
        {
            data = "Hinted";
            lblHint.Text = hint + data;
        }
    }
}