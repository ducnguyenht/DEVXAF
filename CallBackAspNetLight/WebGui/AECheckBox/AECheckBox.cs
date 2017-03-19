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
using System.Drawing;

namespace WebGui.AECheckBox
{



    /// <summary>
    /// Represents a AECheckBox control
    /// </summary>
    [
    ControlValueProperty("Checked"),
    DataBindingHandler("System.Web.UI.Design.TextDataBindingHandler"),
    DefaultEvent("CheckedChanged"),
    Designer("WebGui.AECheckBox.AECheckBoxDesigner"),
    DefaultProperty("Text"),
    ]
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class AECheckBox : WebControl, ICallbackEventHandler, ICheckBoxControl
    {
        internal AttributeCollection _inputAttributes;
        private StateBag _inputAttributesState;
        private AttributeCollection _labelAttributes;
        private StateBag _labelAttributesState;
        private string _valueAttribute = null;
        private string iclientID = null;

        private static readonly object EventCheckedChanged = new object();


        #region Members
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
        /// <summary>
        /// 
        /// </summary>
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


        /// <summary>
        /// Gets or sets a value indicating the checked state of the AECheckBox
        /// </summary>
        [
        Bindable(true, BindingDirection.TwoWay),
        DefaultValue(false),
        Themeable(false),
        ]
        public virtual bool Checked
        {
            get
            {
                object b = ViewState["Checked"];
                return ((b == null) ? false : (bool)b);
            }
            set
            {
                ViewState["Checked"] = value;
            }
        }


        /// <summary>
        /// Gets or sets the text label associated with the AECheckBox
        /// </summary>
        [
        Bindable(true),
        Localizable(true),
        DefaultValue("[AECheckBox]")
        ]
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


        /// <summary>
        /// Gets or sets the alignment of the Text associated with the AECheckBox/>
        /// </summary>
        [
        DefaultValue(TextAlign.Right)
        ]
        public virtual TextAlign TextAlign
        {
            get
            {
                object align = ViewState["TextAlign"];
                return ((align == null) ? TextAlign.Right : (TextAlign)align);
            }
            set
            {
                if (value < TextAlign.Left || value > TextAlign.Right)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                ViewState["TextAlign"] = value;
            }
        }


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
        /// Initializes a new instance of the AECheckBox class.
        /// </summary>
        public AECheckBox()
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

            iclientID = base.ClientID + "_chk";

            string postCommandFunctionName = string.Format("PostCommand_{0}", iclientID);

            //Call Server
            string eventReference = this.Page.ClientScript.GetCallbackEventReference(this, string.Format("document.getElementById(\'{0}\').checked", iclientID), "GetReponse", "context", true);


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
            return base.SaveViewState(); ;
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
        /// Occurs when the AECheckBox is clicked
        /// </summary>

        public event EventHandler CheckedChanged
        {
            add
            {
                Events.AddHandler(EventCheckedChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventCheckedChanged, value);
            }
        }

        /// <summary>
        /// Raises the CheckedChanged event of the AECheckBox controls.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventCheckedChanged];
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
            this.RenderCheckBox(tw);
            return string.Format("{0}|{1}", ClientID, sw.ToString());
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
        /// Displays the AECheckBox on the client
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            this.RenderCheckBox(writer);

        }

        /// <summary>
        /// User By Control Designer
        /// </summary>
        /// <param name="writer"></param>
        public void RenderCheckBox(HtmlTextWriter writer)
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

            string onClick = string.Format("PostCommand_{0}()", iclientID);
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
                    // onClick = System.Web.UI.Design.Util.EnsureEndWithSemiColon(onClick);
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


            writer.RenderBeginTag(HtmlTextWriterTag.Span);


            string text = Text;
            string clientID = iclientID; //ClientID;


            if (text.Length != 0)
            {
                if (TextAlign == TextAlign.Left)
                {
                    // render label to left of checkbox 
                    RenderLabel(writer, text, clientID);
                    RenderInputTag(writer, clientID, onClick);
                }
                else
                {
                    // render label to right of checkbox
                    RenderInputTag(writer, clientID, onClick);
                    RenderLabel(writer, text, clientID);
                }
            }
            else
                RenderInputTag(writer, clientID, onClick);


            writer.RenderEndTag();

        }

        private void RenderLabel(HtmlTextWriter writer, string text, string clientID)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.For, clientID);

            if (_labelAttributes != null && _labelAttributes.Count != 0)
            {
                _labelAttributes.AddAttributes(writer);
            }

            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write(text);
            writer.RenderEndTag();
        }

        internal virtual void RenderInputTag(HtmlTextWriter writer, string clientID, string onClick)
        {
            if (clientID != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Id, clientID);
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "checkbox");

            if (UniqueID != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
            }


            if (_valueAttribute != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Value, _valueAttribute);
            }

            if (Checked)
                writer.AddAttribute(HtmlTextWriterAttribute.Checked, "checked");


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

            if (_inputAttributes != null && _inputAttributes.Count != 0)
            {
                _inputAttributes.AddAttributes(writer);
            }

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
            this._eventArg = eventArgument;
            bool _isChecked;
            Boolean.TryParse(eventArgument, out _isChecked);
            this.Checked = _isChecked;


            this.OnCheckedChanged(new EventArgs());
        }


        #endregion
    }
}

