/*
 * Description:This file contains a interface ILAFBuilder to build ApplicationFramework.
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using FastStructure.LAF.Context;
using FastStructure.LAF.Core.Config;
using FastStructure.LAF.Messages;
using FastStructure.LAF.LAFLog;
using System.Threading;
using System.ComponentModel;

namespace FastStructure.LAF.LAFComponents
{
    //public delegate void FormClose();
    /// <summary>
    /// This class is designed for extending. This form provides some useful properties and
    /// methods to communicate with the LAF.
    /// </summary>
    public abstract class LAFForm : Form, IContextAware
    {
        //public event FormClose FormClosed;
        public ManualResetEvent threadRunning = new ManualResetEvent(false);

        private IContext m_Context;
        private string m_FormId;
        //private object m_Data;
        private MessageManager m_MessageManager;

        /// <summary>
        /// Application Context
        /// </summary>
        public IContext Context
        {
            get
            {
                return m_Context;
            }
            set
            {
                m_Context = value;
            }
        }

        private ILoggerManager m_loggerManager;
        public ILoggerManager LoggerManager
        {
            get
            {
                return m_loggerManager;
            }
            set
            {
                m_loggerManager = value;
            }
        }

        private EnumInstanceScope scope = EnumInstanceScope.REQUEST;

        public EnumInstanceScope Scope
        {
            get { return scope; }
            set { scope = value; }
        }
	

        /// <summary>
        /// Form ID, configured in the configuration file.
        /// </summary>
        public string FormId
        {
            get
            {
                return m_FormId;
            }
            set
            {
                m_FormId = value;
            }
        }

        /// <summary>
        /// Returns the form context
        /// </summary>
        /// <returns></returns>
        public FormContext GetFormContext()
        {
            if (!string.IsNullOrEmpty(m_FormId))
            {
                return FormContextFactory.GetFormContext(Context, m_FormId);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Message manager
        /// </summary>
        public MessageManager MessageManager
        {
            get
            {
                return m_MessageManager;
            }
            set
            {
                m_MessageManager = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public LAFForm()
        {
            this.Closing += new System.ComponentModel.CancelEventHandler(Form1_Closing);

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void Form1_Closing(Object sender, CancelEventArgs args)
        {
            if (!scope.Equals(EnumInstanceScope.REQUEST)) 
            {
                this.Visible = false;
                args.Cancel = true;
            }

            //FormClosed();
        }

        public void LoadData()
        {
            Thread workerThread = new Thread(new ThreadStart(DataThread));

            // set out synchronization object
            threadRunning.Reset();

            // start the thread
            workerThread.Start();
        }

        public virtual void DataThread()
        {
            // overload this method if you need to load data but
            // you MUST call this base method to set this event
            threadRunning.Set();
        }

        public abstract void InitializeComponent();
        public abstract LAFForm Clone();

        /// <summary>
        /// Ask LAF to get a global action and execute it. Before the request, save the data.
        /// </summary>
        /// <param name="actionId"></param>
        public void RequestGlobalAction(string actionId)
        {
            //SaveFormData();
            LAF.Core.LAFManager.GetInstance().RequestGlobalAction(actionId);
        }

        /// <summary>
        /// Ask LAF to get a form and show it. Before the request, save the data.
        /// </summary>
        /// <param name="formId"></param>
        public void RequestForm(string formId)
        {
            //SaveFormData();
            LAF.Core.LAFManager.GetInstance().RequestForm(formId);
        }

        /// <summary>
        /// Ask LAF to get a form and show it as a dialog. Before the request, save the data.
        /// </summary>
        /// <param name="formId"></param>
        public DialogResult RequestDialog(string formId)
        {
            //SaveFormData();
            return LAF.Core.LAFManager.GetInstance().RequestDialog(formId);
        }

        /// <summary>
        /// Request the action that assigned to this form.
        /// </summary>
        public void RequestAction()
        {
            LAF.Core.LAFManager.GetInstance().RequestFormAction(FormId);
        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        new virtual protected void Dispose(bool disposing)
        {
            this.Dispose(disposing);
            //base.Dispose(disposing);
        }

        /// <summary>
        /// This method will be called by LAF automatically.
        /// </summary>
        virtual public void RefreshForm() { }

        /// <summary>
        /// This method is preserved
        /// </summary>
        virtual public void ResetForm() { }
    }
}