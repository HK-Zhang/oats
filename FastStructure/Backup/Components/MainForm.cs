using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FastStructure.LAF;
using FastStructure.LAF.LAFComponents;
using FastStructure.LAF.Exceptions;
using FastStructure.LAF.Core.Validation;
using FastStructure.FastStructureContext;

namespace FastStructure.GUI
{

    public partial class MainForm :LAFForm
    {
        private string nData = string.Empty;

        public MainForm()
        {
#if DESIGNTIME
  InitializeComponent();        
#endif
        }

        public override void DataThread()
        {
            nData = "Loaded";
            //Load necessary data
            base.DataThread();
        }

        public override void RefreshForm()
        {
            lblData.Text = nData;
            //base.RefreshForm();
        }

        private void btnExceptionFm_Click(object sender, EventArgs e)
        {
            throw new Exception("Show Exception Form!");
        }

        private void btnExceptionLog_Click(object sender, EventArgs e)
        {
            throw new FastStructureException("Log Exception");
        }

        private void btnMsgParm_Click(object sender, EventArgs e)
        {
            ValidateMessage validMsg = ValidateMessageFactory.CreateValidateMessage("error.required", "VARIABLE_NAME");
            MessageBox.Show(validMsg.GetMessage(this.MessageManager));
        }

        private void btnMsg_Click(object sender, EventArgs e)
        {
            ValidateMessage validMsg = ValidateMessageFactory.CreateValidateMessage("error.fileName");
            MessageBox.Show(validMsg.GetMessage(this.MessageManager));
        }

        private void btnUsualForm_Click(object sender, EventArgs e)
        {
            RequestGlobalAction("LOAD-USUAL-FORM-ACTION");
            
        }

        private void btnDialogForm_Click(object sender, EventArgs e)
        {
            RequestAction();
            StepContext ctx = FASTContextFactory.CreateStepContext(Context);
            lblActionL.Text = ctx.Result;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            LoggerManager.GetLogger("MainForm").Error("Log Myself!");
        }

        private void btnEqqForm_Click(object sender, EventArgs e)
        {
            RequestGlobalAction("LOAD-REQUEST-FORM-ACTION");
        }

        private void btnProForm1_Click(object sender, EventArgs e)
        {
            RequestGlobalAction("LOAD-PROTOTYPE-FORM-ACTION");
        }

        private void btnProForm2_Click(object sender, EventArgs e)
        {
            RequestGlobalAction("LOAD-PROTOTYPE-FORM-ACTION");
        }


        public override LAFForm Clone()
        {
            return new MainForm();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            RequestGlobalAction("LOAD-VALIDATE-FORM-ACTION");
        }

        private void btnParmListener_Click(object sender, EventArgs e)
        {
            RequestGlobalAction("CACULATE-MODE-ACTION");

            CaculateModeContext ctx = FASTContextFactory.CreateCaculateModeContext(Context);
            CaculateContext ctx1 = FASTContextFactory.CreateCaculateContext(Context);

            lblParmListener.Text = ctx.Result + "  " + ctx1.Result;
        }

        private void btnActListener_Click(object sender, EventArgs e)
        {
            BeforeActionContext bctx = FASTContextFactory.CreateBeforeActionContext(Context);
            bctx.Result = "before";
            AfterActionContext actx = FASTContextFactory.CreateAfterActionContext(Context);
            actx.Result = "after";

            RequestGlobalAction("STEP-ACTION");
            StepContext ctx = FASTContextFactory.CreateStepContext(Context);
            lblActionL.Text = ctx.Result;
        }
    }
}