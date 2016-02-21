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
    public partial class ExceptionForm : LAFForm
    {
        private const string EXCEPTION_PARAMETER = "LAF.System.Exception";

        public ExceptionForm()
        {
#if DESIGNTIME
  InitializeComponent();        
#endif
        }

        private void ExceptionForm_Load(object sender, EventArgs e)
        {
            //lblMessage.Text = string.Empty;  
        }

        public override void RefreshForm()
        {
            base.RefreshForm();
            string message = (string)Context.GetParameter(EXCEPTION_PARAMETER);
            this.lblMessage.Text = message;
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        public override LAFForm Clone()
        {
            return new ExceptionForm();
        }
    }
}