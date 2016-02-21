/*
 * Description:This file contains a class LAFConfigurationLoader to impelment interface ILAFConfigurationDAO.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using FastStructure.LAF.GenericType;
using FastStructure.LAF.Exceptions;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to implemente the interface ILAFConfigurationDAO
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class LAFConfigurationDAO : ILAFConfigurationDAO
    {
        #region Set the value of const variable
        private const string DIVIDE = "\\";
        private const string SUBSTRING = "\\conf\\";
        private const string SCHEMA_FOLDER = "Schema";
        private const string XML_FOLDER = "XML";
        private const string LAF_FOLDER = "LAF";
        private const string ROOT_ELEMENT = "Laf_conf";
        private const string ATTRIBUTE_VERSION = "version";
        private const string ATTRIBUTE_SCOPE = "scope";
        private const string ATTRIBUTE_FORMTYPE = "form-type";
        private const string ATTRIBUTE_LISTENERTYPE = "listener-type";
        private const string ATTRIBUTE_ACTIONTYPE = "action-type";
        private const string ATTRIBUTE_FORMDATATYPE = "form-data-type";
        private const string ATTRIBUTE_FORMID = "form-id";
        private const string ATTRIBUTE_ACTIONID = "action-id";
        private const string ATTRIBUTE_OCCASION = "occasion-type";
        private const string ELEMENT_FORMS = "forms";
        private const string ELEMENT_ACTION = "action";
        private const string ELEMENT_LISTENERS = "listeners";
        private const string ELEMENT_FORMS_FORM = "form";
        private const string ELEMENT_FORMDEF = "form-def";
        private const string ELEMENT_ACTIONDEF = "action-def";
        private const string ELEMENT_DATADEF = "data-def";
        private const string ELEMENT_FORMS_EXCEPTIONFORM = "exception-form";
        private const string ELEMENT_GLOBALACTIONS = "global-actions";
        private const string ELEMENT_LISTENERS_PARAMETERLISTENER = "parameter-listener";
        private const string ELEMENT_LISTENERS_ACTIONLISTENER = "action-listener";
        private const string ERROR_CONFIG_FILE_NOT_FIND = "This laf configuration file cann't find";
        private const string ERROR_CONFIG_SAVE = "There is a exception occur saving config file";
        private const string ERROR_CONFIG_LOAD = "There is a exception occur loading config file";
        #endregion

        protected string needPath;
        protected string m_LafConfigFilePath;
        protected LAFConfiguration lafconfig;

        /// <summary>
        /// Initial all LAF related directorys and files
        /// </summary>
        public LAFConfigurationDAO()
        {

        }

        #region implement the following method is used to impelment the interface ILAFConfigurationDAO
        private void LoadExceptionFormItem()
        {
            new ExceptionFormItem();
        }

        private void LoadActionItemSet()
        {
            new ActionItemSet();
        }

        private void LoadParameterListenerItemSet()
        {
            new ParameterListenerItemSet();
        }

        private void LoadFormItemSet()
        {
            new FormItemSet();
        }

        private void LoadActionListenerItemSet()
        {
            new ActionListenerItemSet();
        }
        #endregion

        /// <summary>
        /// Create some necessary folders under the LAF project
        /// </summary>
        private void CreateDirectorys()
        {

        }

        /// <summary>
        /// Create some necessary files under the LAF project
        /// </summary>
        private void CreateFiles()
        {
            if (!File.Exists(m_LafConfigFilePath))
            {
                File.Create(m_LafConfigFilePath);
            }
        }

        /// <summary>
        /// Initial LAF directory and set current directory to application.
        /// </summary>
        private void InitialLAFRoot()
        {
            lafconfig = new LAFConfiguration();
            m_LafConfigFilePath = lafconfig.LAFConfigFilePath;
            CreateDirectorys();
            CreateFiles();
        }

        /// <summary>
        /// Save LAF configuration file
        /// </summary>
        /// <param name="lafConfig">the instance of LAFConfiguration</param>
        public void SaveLAFConfiguration(LAFConfiguration lafConfig)
        {
            InitialLAFRoot();
            try
            {
                XmlTextWriter writer = new XmlTextWriter(m_LafConfigFilePath, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                //Set ROOT_ELEMENT is root element of this xml file
                writer.WriteStartElement(ROOT_ELEMENT);
                writer.WriteAttributeString(ATTRIBUTE_VERSION, lafConfig.Version.ToString());
                //fill form item set information into under the first element ELEMENT_FORMS
                writer.WriteStartElement(ELEMENT_FORMS);
                for (int i = 0; i < lafConfig.FormItemSet.FormItems.Count; i++)
                {
                    writer.WriteStartElement(ELEMENT_FORMS_FORM);
                    writer.WriteAttributeString(ATTRIBUTE_FORMID, lafConfig.FormItemSet.FormItems[i].FormId);

                    writer.WriteStartElement(ELEMENT_FORMDEF);
                    writer.WriteAttributeString(ATTRIBUTE_FORMTYPE, lafConfig.FormItemSet.FormItems[i].FormDef.FormType);
                    if (lafConfig.FormItemSet.FormItems[i].FormDef.Scope != null)
                    {
                        writer.WriteAttributeString(ATTRIBUTE_SCOPE, lafConfig.FormItemSet.FormItems[i].FormDef.Scope.ToString());
                    }
                    writer.WriteEndElement();
                    if (lafConfig.FormItemSet.FormItems[i].DataDef != null)
                    {
                        writer.WriteStartElement(ELEMENT_DATADEF);
                        writer.WriteAttributeString(ATTRIBUTE_FORMDATATYPE, lafConfig.FormItemSet.FormItems[i].DataDef.FormDataType);
                        if (lafConfig.FormItemSet.FormItems[i].DataDef.Scope != null)
                        {
                            writer.WriteAttributeString(ATTRIBUTE_SCOPE, lafConfig.FormItemSet.FormItems[i].DataDef.Scope.ToString());
                        }
                        writer.WriteEndElement();
                    }
                    if (lafConfig.FormItemSet.FormItems[i].ActionDef != null)
                    {
                        writer.WriteStartElement(ELEMENT_ACTIONDEF);
                        writer.WriteAttributeString(ATTRIBUTE_ACTIONTYPE, lafConfig.FormItemSet.FormItems[i].ActionDef.ActionType);
                        if (lafConfig.FormItemSet.FormItems[i].ActionDef.Scope != null)
                        {
                            writer.WriteAttributeString(ATTRIBUTE_SCOPE, lafConfig.FormItemSet.FormItems[i].ActionDef.Scope.ToString());
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                //fill exception form item information into under the first element ELEMENT_FORMS_EXCEPTIONFORM
                writer.WriteStartElement(ELEMENT_FORMS_EXCEPTIONFORM);
                writer.WriteStartElement(ELEMENT_FORMDEF);
                writer.WriteAttributeString(ATTRIBUTE_FORMTYPE, lafConfig.ExceptionFormItem.FormDef.FormType);
                if (lafConfig.ExceptionFormItem.FormDef.Scope != null)
                {
                    writer.WriteAttributeString(ATTRIBUTE_SCOPE, lafConfig.ExceptionFormItem.FormDef.Scope.ToString());
                }
                writer.WriteEndElement();
                if (lafConfig.ExceptionFormItem.ActionDef != null)
                {
                    writer.WriteStartElement(ELEMENT_ACTIONDEF);
                    writer.WriteAttributeString(ATTRIBUTE_ACTIONTYPE, lafConfig.ExceptionFormItem.ActionDef.ActionType);
                    if (lafConfig.ExceptionFormItem.ActionDef.Scope != null)
                    {
                        writer.WriteAttributeString(ATTRIBUTE_SCOPE, lafConfig.ExceptionFormItem.ActionDef.Scope.ToString());
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                //fill action item set information into under the first element ELEMENT_GLOBALACTIONS
                writer.WriteStartElement(ELEMENT_GLOBALACTIONS);
                for (int n = 0; n < lafConfig.ActionItemSet.ActionItems.Count; n++)
                {
                    writer.WriteStartElement(ELEMENT_ACTION);
                    writer.WriteAttributeString(ATTRIBUTE_ACTIONID, lafConfig.ActionItemSet.ActionItems[n].ActionId);
                    writer.WriteAttributeString(ATTRIBUTE_ACTIONTYPE, lafConfig.ActionItemSet.ActionItems[n].ActionType);
                    if (lafConfig.ActionItemSet.ActionItems[n].Scope != null)
                    {
                        writer.WriteAttributeString(ATTRIBUTE_SCOPE, lafConfig.ActionItemSet.ActionItems[n].Scope.ToString());
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                //fill parameter listener action item set information into under the first element ELEMENT_GLOBALACTIONS
                writer.WriteStartElement(ELEMENT_LISTENERS);
                ArrayList<ParameterListenerItem> parahash = lafConfig.ParameterListenerItemSet.ParameterListeners;
                for (int m = 0; m < parahash.Count; m++)
                {
                    writer.WriteStartElement(ELEMENT_LISTENERS_PARAMETERLISTENER);
                    writer.WriteAttributeString(ATTRIBUTE_LISTENERTYPE, parahash[m].ListenerType);
                    if (parahash[m].Scope != null)
                    {
                        writer.WriteAttributeString(ATTRIBUTE_SCOPE, parahash[m].Scope.ToString());
                    }
                    writer.WriteEndElement();
                }
                //fill action listener item set information into under the first element ELEMENT_GLOBALACTIONS
                foreach (ActionListenerItem item in lafConfig.ActionListenerItemSet.ActionListenerItems)
                {
                    writer.WriteStartElement(ELEMENT_LISTENERS_ACTIONLISTENER);
                    writer.WriteAttributeString(ATTRIBUTE_ACTIONID, item.ActionId);
                    writer.WriteAttributeString(ATTRIBUTE_OCCASION, item.Occasion.ToString());
                    writer.WriteAttributeString(ATTRIBUTE_LISTENERTYPE, item.ListenerType);
                    if (item.Scope != null)
                    {
                        writer.WriteAttributeString(ATTRIBUTE_SCOPE, item.Scope.ToString());
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            catch
            {
                throw new ConfigurationSaveException(ERROR_CONFIG_SAVE);
            }
        }

        /// <summary>
        /// Create a object of ILAFConfiguration according to laf config file
        /// </summary>
        /// <param name="filePath">the path and name of laf config file</param>
        /// <returns>A object of ILAFConfiguration</returns>
        public ILAFConfiguration LoadLAFConfiguration(string filePath)
        {
            needPath = filePath.Substring(0, filePath.LastIndexOf(SUBSTRING));
            if (!File.Exists(filePath))
            {
                throw new ConfigurationNotValidException(ERROR_CONFIG_FILE_NOT_FIND);
            }
            try
            {
                ILAFConfiguration config = new LAFConfiguration();
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {
                    //declare a instance formset of FormItemSet to collect form item
                    FormItemSet formset = new FormItemSet();
                    //declare a instance actionset of ActionItemSet to collect action item
                    ActionItemSet actionset = new ActionItemSet();
                    //declare a instance actionlistenerset of ActionListenerItemSet to collect action listener item
                    ActionListenerItemSet actionlistenerset = new ActionListenerItemSet();
                    //declare a instance parameterlistenerset of ParameterListenerItemSet to collect parameter listener item
                    ParameterListenerItemSet parameterlistenerset = new ParameterListenerItemSet();
                    //declare a instance exception of ExceptionFormItem to record exception item information
                    ExceptionFormItem exception = new ExceptionFormItem();
                    LogItem logItem = new LogItem();
                    ArrayList<FormItem> formitemlist = new ArrayList<FormItem>();
                    ArrayList<ActionItem> actionitemlist = new ArrayList<ActionItem>();
                    ArrayList<ParameterListenerItem> paralistenerlist = new ArrayList<ParameterListenerItem>();
                    ArrayList<ActionListenerItem> actionlistenerlist = new ArrayList<ActionListenerItem>();
                    foreach (XmlNode node in root.ChildNodes[0].ChildNodes)
                    {
                        if (!node.Equals(root.ChildNodes[0].LastChild))
                        {
                            //add a item of FormItem to the FormItem set formset                     
                            formitemlist.Add(GetFormItem(node));//get form item by calling GetFormItem method
                        }
                        else
                        {
                            //get exception form item into exception from xml file
                            if (node.ChildNodes.Count > 0)
                            {
                                //get form def into exception of ExceptionFormItem from xml file
                                FormDef formdef = new FormDef();
                                formdef.FormType = node.ChildNodes[0].Attributes[0].Value + "," + needPath;
                                if (node.ChildNodes[0].Attributes[1] != null)
                                {
                                    formdef.Scope = ToScope(node.ChildNodes[0].Attributes[1].Value);
                                }
                                //set the value of property FormDef is formdef
                                exception.FormDef = formdef;
                                if (node.ChildNodes.Count >= 2)
                                {
                                    //get action def into exception of ExceptionFormItem from xml file
                                    ActionDef actiondef = new ActionDef();
                                    actiondef.ActionType = node.ChildNodes[1].Attributes[0].Value + "," + needPath;
                                    if (node.ChildNodes[1].Attributes[1] != null)
                                    {
                                        actiondef.Scope = ToScope(node.ChildNodes[1].Attributes[1].Value);
                                    }
                                    //set the value of property ActionDef is actiondef
                                    exception.ActionDef = actiondef;
                                }
                            }
                        }
                    }
                    //get item of ActionItem into actionset from xml file
                    foreach (XmlNode node in root.ChildNodes[1].ChildNodes)
                    {
                        ActionItem item = new ActionItem();
                        item.ActionId = node.Attributes[0].Value;
                        item.ActionType = node.Attributes[1].Value + "," + needPath;
                        if (node.Attributes[2] != null)
                        {
                            item.Scope = ToScope(node.Attributes[2].Value);
                        }
                        //add a item of ActionItem to the ActionItem set actionset
                        actionitemlist.Add(item);
                    }
                    foreach (XmlNode node in root.ChildNodes[2].ChildNodes)
                    {
                        //get item of ParameterListenerItem into parameterlistenerset from xml file
                        if (node.Name == "parameter-listener")
                        {
                            ParameterListenerItem item = new ParameterListenerItem();
                            //item.ListenerType = node.Attributes[0].Value + "," + needPath;
                            item.ListenerType = node.Attributes["listener-type"].Value + "," + needPath;

                            if (node.Attributes.Count > 1)
                            {
                                if (node.Attributes["scope"] != null)
                                {
                                    item.Scope = ToScope(node.Attributes["scope"].Value);

                                }
                            }


                            paralistenerlist.Add(item);
                        }
                        else
                        {
                            //get item of ActionListenerItem into parameterlistenerset from xml file
                            ActionListenerItem item = new ActionListenerItem();
                            item.ActionId = node.Attributes[0].Value;
                            if (node.Attributes[1].Value.Equals(EnumActionListenerOccasion.AFTER.ToString()))
                            {
                                item.Occasion = EnumActionListenerOccasion.AFTER;
                            }
                            else
                            {
                                item.Occasion = EnumActionListenerOccasion.BEFORE;
                            }
                            item.ListenerType = node.Attributes[2].Value + "," + needPath;
                            if (node.Attributes[3] != null)
                            {
                                item.Scope = ToScope(node.Attributes[3].Value);
                            }
                            //add a item of ActionListenerItem to the ActionListenerItem set actionlistenerset
                            actionlistenerlist.Add(item);
                        }
                    }
                    //get the information of logdef from xml file
                    XmlNode logNode = root.ChildNodes[3].ChildNodes[0];
                    LogDef logDef = new LogDef();
                    logDef.LogType = logNode.Attributes[0].Value + "," + needPath;
                    logDef.LogPath = logNode.Attributes[1].Value;
                    logDef.Scope = ToScope(logNode.Attributes[2].Value);

                    logItem.LogDef = logDef;
                    formset.FormItems = formitemlist;
                    actionset.ActionItems = actionitemlist;
                    parameterlistenerset.ParameterListeners = paralistenerlist;
                    actionlistenerset.ActionListenerItems = actionlistenerlist;

                    //set the value logItem of property LogItem of LAFConfiguration
                    config.LogItem = logItem;
                    //set the value formset of property FormItemSet of LAFConfiguration
                    config.FormItemSet = formset;
                    //set the value actionset of property ActionItemSet of LAFConfiguration
                    config.ActionItemSet = actionset;
                    //set the value exception of property ExceptionFormItem of LAFConfiguration
                    config.ExceptionFormItem = exception;
                    //set the value parameterlistenerset of property ParameterListenerItemSet of LAFConfiguration
                    config.ParameterListenerItemSet = parameterlistenerset;
                    //set the value actionlistenerset of property ActionListenerItemSet of LAFConfiguration
                    config.ActionListenerItemSet = actionlistenerset;
                }
                return config;
            }
            catch
            {
                throw new ConfigurationLoadException(ERROR_CONFIG_LOAD);
            }
        }

        /// <summary>
        /// translate string type to enum type
        /// </summary>
        /// <param name="scope">the value of scope</param>
        /// <returns>the scope of enum type</returns>
        private EnumInstanceScope ToScope(string scope)
        {
            if (EnumInstanceScope.SINGLETON.ToString().Equals(scope))
            {
                return EnumInstanceScope.SINGLETON;
            }
            else if (EnumInstanceScope.PROTOTYPE.ToString().Equals(scope))
            {
                return EnumInstanceScope.PROTOTYPE;
            }
            else
            {
                return EnumInstanceScope.REQUEST;
            }
        }

        /// <summary>
        /// get form item by xml node
        /// </summary>
        /// <param name="node">the node of xml</param>
        /// <returns>the item of FormItem</returns>
        private FormItem GetFormItem(XmlNode node)
        {
            //get form item into formset from xml file
            FormItem item = new FormItem();
            item.FormId = node.Attributes[0].Value;

            XmlNode formNode = node.ChildNodes[0];
            FormDef fdef = new FormDef();
            fdef.FormType = formNode.Attributes[ATTRIBUTE_FORMTYPE].Value + "," + needPath;
            fdef.Scope = ToScope(formNode.Attributes[ATTRIBUTE_SCOPE].Value);

            item.FormDef = fdef;
            if (formNode.NextSibling != null)
            {
                if (formNode.NextSibling.Name.Equals(ELEMENT_DATADEF))
                {
                    XmlNode dataNode = formNode.NextSibling;
                    DataDef ddef = new DataDef();
                    ddef.FormDataType = dataNode.Attributes[ATTRIBUTE_FORMDATATYPE].Value + "," + needPath;
                    ddef.Scope = ToScope(dataNode.Attributes[ATTRIBUTE_SCOPE].Value);
                    item.DataDef = ddef;
                    if (dataNode.NextSibling != null)
                    {
                        XmlNode actionNode = dataNode.NextSibling;
                        ActionDef adef = new ActionDef();
                        adef.ActionType = actionNode.Attributes[ATTRIBUTE_ACTIONTYPE].Value + "," + needPath;
                        adef.Scope = ToScope(actionNode.Attributes[ATTRIBUTE_SCOPE].Value);
                        item.ActionDef = adef;
                    }
                }
                else
                {
                    XmlNode actionNode = formNode.NextSibling;
                    ActionDef adef = new ActionDef();
                    adef.ActionType = actionNode.Attributes[ATTRIBUTE_ACTIONTYPE].Value + "," + needPath;
                    adef.Scope = ToScope(actionNode.Attributes[ATTRIBUTE_SCOPE].Value);

                    item.ActionDef = adef;
                }
            }
            return item;
        }
    }
}
