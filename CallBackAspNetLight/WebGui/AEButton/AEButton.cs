using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using AttributeCollection = System.Web.UI.AttributeCollection;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace WebGui.AEButton
{



    /// <summary>
    /// Represents a AEButton control
    /// </summary>
    [
    DataBindingHandler("System.Web.UI.Design.TextDataBindingHandler"),
    DefaultEvent("Click"),
    Designer("WebGui.AEButton.AEButtonDesigner"),
    DefaultProperty("Text"),
    ]
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class AEButton : WebControl, ICallbackEventHandler, IButtonControl
    {
       


        private static readonly object EventClick = new object();

        #region  Members
        /// <summary>
        /// Text Property
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? "AE Button" : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        /// <summary>
        /// the string value for viewstate 
        /// </summary>
        string _viewstate = string.Empty;
        internal string _ViewState
        {
            get
            {
                return _viewstate;
            }

            set
            {
                _viewstate = value;
            }
        }

        /// <summary>
        /// Control render
        /// </summary>
        string _result = string.Empty;
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        /// <summary>
        /// When is  a true the control render is generated
        /// </summary>
        bool _IsRenderControl = false;
        [Category("WebGui Properties")]
        [Localizable(false)]
        [PersistenceMode(PersistenceMode.Attribute)]
        public bool IsRenderControl
        {
            get { return _IsRenderControl; }
            set { _IsRenderControl = value; }
        }

        /// <summary>
        /// ValidationGroup
        /// </summary>
        [
        DefaultValue(""),
        Themeable(false),
        ]
        public virtual string ValidationGroup
        {
            get
            {
                string s = (string)ViewState["ValidationGroup"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["ValidationGroup"] = value;
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the AEButton class.
        /// </summary>
        public AEButton()
            : base(HtmlTextWriterTag.Input)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param
        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);


            string postCommandFunctionName = string.Format("PostCommand_{0}", base.ClientID);

            //Call Server
            string eventReference = this.Page.ClientScript.GetCallbackEventReference(this, "arg", "GetReponse", "context", true);

            //Post Command
            string postCommandScript = "\r\nfunction " + postCommandFunctionName + "(arg,context) {\r\n   __theFormPostCollection.length = 0;__theFormPostData =\"\";  WebForm_InitCallback();" + eventReference + ";} \r\n";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), postCommandFunctionName, postCommandScript, true);
        }


        #region ViewState

        /// <summary>
        ///  Saves the view state for the control.
        /// </summary>
        /// <returns></returns>
        protected override object SaveViewState()
        {
            return base.SaveViewState();
        }


        /// <summary>
        /// Starts view state tracking.
        /// </summary>
        protected override void TrackViewState()
        {
            base.TrackViewState();
        }

        /// <summary>
        /// Loads the view state for the control. 
        /// </summary>
        /// <param name="savedState"></param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                base.LoadViewState(savedState);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the AEButton is clicked
        /// </summary>

        public event EventHandler Click
        {
            add
            {
                Events.AddHandler(EventClick, value);
            }
            remove
            {
                Events.RemoveHandler(EventClick, value);
            }
        }



        /// <summary>
        ///  Raises the  Click event of the AEButton    controls
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventClick];
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region Rendering Methods
        /// <summary>
        /// Get the Render of AEButton control
        /// </summary>
        /// <returns></returns>
        public string GetRender()
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);
            this.RenderButton(tw);
            return string.Format("{0}|{1}", this.ClientID, sw.ToString());
        }
        /// <summary>
        /// This method must be invoked after  any updating of another controls properties (backcolor,width...)
        /// </summary>
        /// <param name="control"></param>
        public void UpdateControl(Control control) 
        {
            
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            System.Reflection.MethodInfo mi = typeof(Control).GetMethod("Render", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            mi.Invoke(control, new object[] { tw });

            this._result = string.Format("{0}|{1}", control.ClientID , sw.ToString()); 
        }

        /// <summary>
        /// Displays the Button on the client
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            this.RenderButton(writer);

        }

        /// <summary>
        /// User By Control Designer
        /// </summary>
        /// <param name="writer"></param>
        public void RenderButton(HtmlTextWriter writer)
        {
            AddAttributesToRender(writer);

            // Make sure we are in a form tag with runat=server. 
            if (Page != null)
            {
                Page.VerifyRenderingInServerForm(this);
            }

            bool renderWrapper = false;

            // On wrapper, render the style,
            if (ControlStyleCreated)
            {
                Style controlStyle = ControlStyle;
                if (!controlStyle.IsEmpty)
                {
                    controlStyle.AddAttributesToRender(writer, this);
                    renderWrapper = true;
                }
            }
            // And Enabled 
            if (!IsEnabled)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
                renderWrapper = true;
            }
            // And ToolTip 
            string toolTip = ToolTip;
            if (toolTip.Length > 0)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Title, toolTip);
                renderWrapper = true;
            }

            string onClick = string.Format("PostCommand_{0}()", ClientID);
            // And other attributes
            if (HasAttributes)
            {
                AttributeCollection attribs = Attributes;

                // remove value from the attribute collection so it's not on the wrapper
                string val = attribs["value"];
                if (val != null)
                    attribs.Remove("value");

                // remove and save onclick from the attribute collection so we can move it to the input tag
                onClick = attribs["onclick"];
                if (onClick != null)
                {
                    attribs.Remove("onclick");
                }

                if (attribs.Count != 0)
                {
                    attribs.AddAttributes(writer);
                    renderWrapper = true;
                }

                if (val != null)
                    attribs["value"] = val;
            }

            string text = Text;
            string clientID = base.ClientID; //ClientID;

            RenderInputTag(writer, clientID, onClick, text);

        }


        /// <summary>
        /// Render Input Tag
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="clientID"></param>
        /// <param name="onClick"></param>
        /// <param name="text"></param>
        internal virtual void RenderInputTag(HtmlTextWriter writer, string clientID, string onClick, string text)
        {

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");

            if (UniqueID != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
            }
            if (Text != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Value, Text);
            }
            if (!IsEnabled)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            }
            if (Page != null && !Page.IsCallback && !Page.IsPostBack)
            {
                Page.ClientScript.RegisterForEventValidation(this.UniqueID);
            }
            if (onClick != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, onClick);
            }

            string s = AccessKey;
            if (s.Length > 0)
                writer.AddAttribute(HtmlTextWriterAttribute.Accesskey, s);

            int i = TabIndex;
            if (i != 0)
                writer.AddAttribute(HtmlTextWriterAttribute.Tabindex, i.ToString(NumberFormatInfo.InvariantInfo));

            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
        }




        #endregion

        #region ICallbackEventHandler Members

        public string GetCallbackResult()
        {
            if (this._IsRenderControl)
            {
                // Save All  controls State of the page
                System.Reflection.MethodInfo mi = typeof(Page).GetMethod("SaveAllState", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                mi.Invoke(this.Page, null);


                //Get serialized viewstate from Page's ClientState

                System.Reflection.PropertyInfo stateProp = typeof(Page).GetProperty("ClientState", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                this._ViewState = stateProp.GetValue(this.Page, null).ToString();

                this._result = string.Format("{0}§{1}", this._ViewState, this._result);// GetRender());
            }

            return this._result;
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            this.OnClick(new EventArgs());
        }


        #endregion

        #region IButtonControl Members

        [
         DefaultValue(false),
         Themeable(false),
         ]
        public virtual bool CausesValidation
        {
            get
            {
                object b = ViewState["CausesValidation"];
                return ((b == null) ? false : (bool)b);
            }
            set
            {
                ViewState["CausesValidation"] = value;
            }
        }

        public event CommandEventHandler Command;

        public virtual string CommandArgument
        {
            get
            {
                object b = ViewState["CommandArgument"];
                return ((b == null) ? string.Empty : (string)b);
            }
            set
            {
                ViewState["CommandArgument"] = value;
            }
        }

        public virtual string CommandName
        {
            get
            {
                object b = ViewState["CommandName"];
                return ((b == null) ? string.Empty : (string)b);
            }
            set
            {
                ViewState["CommandName"] = value;
            }
        }

        public virtual string PostBackUrl
        {
            get
            {
                object b = ViewState["PostBackUrl"];
                return ((b == null) ? string.Empty : (string)b);
            }
            set
            {
                ViewState["PostBackUrl"] = value;
            }
        }

        #endregion




    }

}


