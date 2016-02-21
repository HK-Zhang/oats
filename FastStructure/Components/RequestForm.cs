using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FastStructure.LAF;
using FastStructure.LAF.LAFComponents;
using FastStructure.FastStructureContext;

namespace FastStructure.GUI
{
    public partial class RequestForm : LAFForm
    {
        public RequestForm()
        {
#if DESIGNTIME
  InitializeComponent();        
#endif
        }

        public override LAFForm Clone()
        {
            return new RequestForm();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            CaculateContext ctx = FASTContextFactory.CreateCaculateContext(Context);
            lblHint.Text = ctx.Result;
        }
    }
}