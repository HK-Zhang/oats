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
    public partial class DialogForm :LAFForm
    {
        public DialogForm()
        {
#if DESIGNTIME
  InitializeComponent();        
#endif
        }

        public override LAFForm Clone()
        {
            return new DialogForm();
        }
    }
}