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
using System.Drawing.Design;
using System.Drawing;


namespace WebGui.AETextBox
{



    /// <summary>
    /// Represents a AETextBox control
    /// </summary>
    [ParseChildren(true, "Text")]
    [ControlBuilder(typeof(TextBoxControlBuilder))]
    [ControlValueProperty("Text")]
    [DataBindingHandler("System.Web.UI.Design.TextDataBindingHandler")]
    [DefaultProperty("Text")]
    [ValidationProperty("Text")]
    [DefaultEvent("TextChanged")]
    [Designer("WebGui.AETextBox.AETextBoxDesigner")]
   // [ToolboxBitmapAttribute(typeof(AETextBox), "WebGui.AETextBox.AETextBox.bmp")]
    public class AETextBox : WebControl, ICallbackEventHandler, IEditableTextControl, ITextControl
    {
        private string _valueAttribute = null;
        private bool _isLast = true;

        private static readonly object EventTextChanged = new object();

        #region  Members
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
        /// 
        /// </summary>
        string _eventArg = string.Empty;
        [Category("WebGui Properties")]
        [Localizable(false)]
        [PersistenceMode(PersistenceMode.Attribute)]
        public string EventArg
        {
            get { return _eventArg; }
            set { _eventArg = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        string _result = string.Empty;

        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }
        /// <summary>
        /// 
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


        #region TextBox Members

        [Themeable(false)]
        public virtual AutoCompleteType AutoCompleteType
        {
            get
            {
                object b = ViewState["AutoCompleteType"];
                return ((b == null) ? AutoCompleteType.None : (AutoCompleteType)b);
            }
            set
            {
                ViewState["AutoCompleteType"] = value;
            }
        }


        [Themeable(false)]
        [Bindable(true)]
        [DefaultValue(false)]
        public virtual bool ReadOnly
        {
            get
            {
                object b = ViewState["ReadOnly"];
                return ((b == null) ? false : (bool)b);
            }
            set
            {
                ViewState["ReadOnly"] = value;
            }
        }

        [Localizable(true)]
        [Editor("System.ComponentModel.Design.MultilineStringEditor,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DefaultValue("")]
        public virtual string Text
        {
            get
            {
                string s = (string)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        [DefaultValue("")]
        [Themeable(false)]
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
        //
        // Summary:
        //     Gets or sets a value indicating whether the text content wraps within a multiline
        //     text box.
        //
        // Returns:
        //     true if the text content wraps within a multiline text box; otherwise, false.
        //     The default is true.
        [DefaultValue(true)]
        public virtual bool Wrap
        {
            get
            {
                object b = ViewState["Wrap"];
                return ((b == null) ? true : (bool)b);
            }
            set
            {
                ViewState["Wrap"] = value;
            }
        }
        #endregion
        #endregion

        /// <summary>
        /// Initializes a new instance of the AETextBox class.
        /// </summary>
        public AETextBox()
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
            string eventReference = this.Page.ClientScript.GetCallbackEventReference(this, string.Format("document.getElementById(\'{0}\').value", ClientID), "GetReponse", "context", true);

            //Post Command
            string postCommandScript = "\r\nfunction " + postCommandFunctionName + "(arg,context) {\r\n   __theFormPostCollection.length = 0;__theFormPostData =\"\";  WebForm_InitCallback();" + eventReference + ";} \r\n";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), postCommandFunctionName, postCommandScript, true);

        }


        #region ViewState


        /// <summary>
        /// Saves the view state for the control.
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
        ///  Loads the view state for the control. 
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
        /// Occurs when the Text property is changed.
        /// </summary>
        public event EventHandler TextChanged
        {
            add
            {
                Events.AddHandler(EventTextChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventTextChanged, value);
            }
        }


        protected virtual void OnTextChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventTextChanged];
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region Rendering Methods
        /// <summary>
        /// Get the Render of AETextBox control
        /// </summary>
        /// <returns></returns>
        public string GetRender()
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);
            this.RenderTextBox(tw);
            return sw.ToString();
        }
        /// <summary>
        /// This method must be invoke after a any updating of controls properties
        /// </summary>
        /// <param name="control"></param>
        public void UpdateControl(Control control)
        {
           
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            System.Reflection.MethodInfo mi = typeof(Control).GetMethod("Render", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            mi.Invoke(control, new object[] { tw });

            this._result = string.Format("{0}|{1}", control.ClientID, sw.ToString());
        }

        /// <summary>
        /// Displays the AETextBox on the client
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {

            this.RenderTextBox(writer);

        }

        /// <summary>
        /// User By Control Designer
        /// </summary>
        /// <param name="writer"></param>
        public void RenderTextBox(HtmlTextWriter writer)
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

            string onTextChanged = string.Format("PostCommand_{0}()", ClientID);
            // And other attributes
            if (HasAttributes)
            {
                AttributeCollection attribs = Attributes;

                // remove value from the attribute collection so it's not on the wrapper
                string val = attribs["value"];
                if (val != null)
                    attribs.Remove("value");

                // remove and save onkeyup from the attribute collection so we can move it to the input tag
                onTextChanged = attribs["onkeyup"];
                if (onTextChanged != null)
                {
                    // onkeyup = System.Web.UI.Design.Util.EnsureEndWithSemiColon(onkeyup);
                    attribs.Remove("onkeyup");
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
            string clientID = ClientID;

            RenderInputTag(writer, clientID, onTextChanged);

        }


        internal virtual void RenderInputTag(HtmlTextWriter writer, string clientID, string onkeyup)
        {
            if (clientID != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Id, clientID);
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "input");

            if (UniqueID != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
            }


            if (this.Text != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Value, this.Text);
            }

            if (this.ReadOnly)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.ReadOnly , Boolean.TrueString);
            }




            if (!IsEnabled)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            }


            if (Page != null && !Page.IsCallback && !Page.IsPostBack)
            {
                Page.ClientScript.RegisterForEventValidation(this.UniqueID);
            }

            if (onkeyup != null)
            {
                writer.AddAttribute("onkeyup", onkeyup);
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

                System.Reflection.MethodInfo mi = typeof(Page).GetMethod("SaveAllState", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                mi.Invoke(this.Page, null);


                //Get serialized viewstate from Page's ClientState

                System.Reflection.PropertyInfo stateProp = typeof(Page).GetProperty("ClientState", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                this._ViewState = stateProp.GetValue(this.Page, null).ToString();

                this._result = string.Format("{0}§{1}", this._ViewState, this._result);
            }

            return this._result;
        }


        public void RaiseCallbackEvent(string eventArgument)
        {
            this.Text = eventArgument;
            this.OnTextChanged(new EventArgs());
        }
        #endregion
    }

}


