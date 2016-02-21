using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FastStructure.LAF.LAFComponents;
using FastStructure.Data.FormData;
using FastStructure.LAF.Core.Validation;

namespace FastStructure.GUI
{
    public partial class ValidateForm : LAFForm
    {
        public ValidateForm()
        {
#if DESIGNTIME
  InitializeComponent();        
#endif
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            ValidateFormData frmData = (ValidateFormData)GetFormContext().FormData;
            frmData.RangeInt = int.Parse(txtInt.Text.Trim());
            frmData.RequireStr = txtStr.Text.Trim();

            ValidateMessage msg = frmData.Validate();

            if (msg != ValidateMessage.PassedMessage) 
            {
                string text = msg.GetMessage(MessageManager);
                string caption = MessageManager.GetMessage("caption");
                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override LAFForm Clone()
        {
            return new ValidateForm();
        }

        private void btnCA_Click(object sender, EventArgs e)
        {
            ValidateFormData frmData = (ValidateFormData)GetFormContext().FormData;
            frmData.RangeInt = int.Parse(txtInt.Text.Trim());
            frmData.RequireStr = txtStr.Text.Trim();
            RequestGlobalAction("CACULATE-ACTION");
        }
    }
}