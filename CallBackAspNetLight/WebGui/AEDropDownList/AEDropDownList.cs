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
using System.Drawing;

namespace WebGui.AEDropDownList
{


    // Summary:
    //     Represents a control that allows the user to select a single item from a
    //     drop-down list.
    [DataBindingHandler("System.Web.UI.Design.WebControls.ListControlDataBindingHandler, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DefaultEvent("SelectedIndexChanged")]
    [ParseChildren(true, "Items")]
    [Designer("WebGui.AEDropDownList.AEDropDownListDesigner")]
    [ControlValueProperty("SelectedValue")]
    [ValidationProperty("SelectedItem")]
   // [ToolboxBitmapAttribute(typeof(AEDropDownList), "WebGui.AEDropDownList.AEDropDownList.bmp")]
    public class AEDropDownList : ListControl, ICallbackEventHandler
    {


        private AttributeCollection _optionAttributes;
        private StateBag _optionAttributesState;
        private string _valueAttribute = null;
        private bool _isLast = true;
        private ListItem _selectedItem = null;

        private static readonly object EventSelectedIndexChanged = new object();


        #region  Members


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
        #region Web Members
        /// <summary>
        /// Selected a current Item
        /// </summary>
        public virtual ListItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
            }
        }


/// <summary>
        /// Attribute collection for the rendered Option element
/// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public AttributeCollection OptionAttributes
        {
            get
            {
                if (_optionAttributes == null)
                {

                    if (_optionAttributesState == null)
                    {
                        _optionAttributesState = new StateBag(true);
                        if (IsTrackingViewState)
                            ((IStateManager)_optionAttributesState).TrackViewState();
                    }

                    _optionAttributes = new AttributeCollection(_optionAttributesState);
                }
                return _optionAttributes;
            }
        }
        // Summary:
        //     Gets or sets the border color of the control.
        //
        // Returns:
        //     A System.Drawing.Color that represents the border color of the control.
        [Browsable(false)]
        public override Color BorderColor
        {
            get
            {
                object s = (object)ViewState["BorderColor"];
                return ((s == null) ? Color.Transparent : (Color)s);
            }

            set
            {
                ViewState["BorderColor"] = value;
            }
        }
        //
        // Summary:
        //     Gets or sets the border style of the control.
        //
        // Returns:
        //     One of the System.Web.UI.WebControls.BorderStyle values.
        [Browsable(false)]
        public override BorderStyle BorderStyle
        {
            get
            {
                object s = (object)ViewState["BorderStyle"];
                return ((s == null) ? BorderStyle.Solid : (BorderStyle)s);
            }

            set
            {
                ViewState["BorderStyle"] = value;
            }
        }
        //
        // Summary:
        //     Gets or sets the border width for the control.
        //
        // Returns:
        //     A System.Web.UI.WebControls.Unit that represents the border width for the
        //     control.
        [Browsable(false)]
        public override Unit BorderWidth
        {
            get
            {
                object s = (object)ViewState["BorderWidth"];
                return ((s == null) ? new Unit(100) : (Unit)s);
            }

            set
            {
                ViewState["BorderWidth"] = value;
            }
        }
        //
        // Summary:
        //     Gets or sets the index of the selected item in the AEDropDownList
        //     control.
        
        [DefaultValue(0)]
        [DesignerSerializationVisibility(0)]
        public override int SelectedIndex
        {
            get
            {
                object s = (object)ViewState["SelectedIndex"];
                return ((s == null) ? 0 : (int)s);
            }

            set
            {
                ViewState["SelectedIndex"] = value;
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// Initializes a new instance of the AEDropDownList class
        /// </summary>
        public AEDropDownList()
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
        /// Occurs when a ListItem is Selected from AEDropDownList
        /// </summary>

        public event EventHandler SelectedIndexChanged
        {
            add
            {
                Events.AddHandler(EventSelectedIndexChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventSelectedIndexChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventSelectedIndexChanged];
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region Rendering Methods
        /// <summary>
        /// Get the Render of AEDropDownList control
        /// </summary>
        /// <returns></returns>
        public string GetRender()
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);
            this.RenderDropDownList(tw);
            return string.Format("{0}|{1}", "span_" + this.ClientID, sw.ToString());
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
        /// Displays the AEDropDownList on the client.
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            this.RenderDropDownList(writer);

        }
        /// <summary>
        /// User By Control Designer
        /// </summary>
        /// <param name="writer"></param>
        public void RenderDropDownList(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "span_" + this.ClientID);
            // render begin tag of wrapper SPAN 
            writer.RenderBeginTag(HtmlTextWriterTag.Span);


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

            string onSelectedIndexChanged = string.Format("PostCommand_{0}()", base.ClientID);
            // And other attributes
            if (HasAttributes)
            {
                AttributeCollection attribs = Attributes;

                // remove value from the attribute collection so it's not on the wrapper
                string val = attribs["value"];
                if (val != null)
                    attribs.Remove("value");

                // remove and save onclick from the attribute collection so we can move it to the input tag
                onSelectedIndexChanged = attribs["onchange"];
                if (onSelectedIndexChanged != null)
                {
                    // onClick = System.Web.UI.Design.Util.EnsureEndWithSemiColon(onClick);
                    attribs.Remove("onchange");
                }

                if (attribs.Count != 0)
                {
                    attribs.AddAttributes(writer);
                    renderWrapper = true;
                }

                if (val != null)
                    attribs["value"] = val;
            }


            string clientID = base.ClientID; //ClientID;

            RenderSelectTag(writer, clientID, onSelectedIndexChanged);



            // render end tag of wrapper SPAN
            writer.RenderEndTag();




        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="clientID"></param>
        /// <param name="onSelectedIndexChanged"></param>
        internal virtual void RenderSelectTag(HtmlTextWriter writer, string clientID, string onSelectedIndexChanged)
        {

            if (UniqueID != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
            }


            if (!IsEnabled)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            }


            if (Page != null && !Page.IsCallback && !Page.IsPostBack)
            {
                Page.ClientScript.RegisterForEventValidation(this.UniqueID);
            }

            if (onSelectedIndexChanged != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Onchange, onSelectedIndexChanged);
            }


            string s = AccessKey;
            if (s.Length > 0)
                writer.AddAttribute(HtmlTextWriterAttribute.Accesskey, s);

            int i = TabIndex;
            if (i != 0)
                writer.AddAttribute(HtmlTextWriterAttribute.Tabindex, i.ToString(NumberFormatInfo.InvariantInfo));

          

            // render begin tag of wrapper SELECT 
            writer.RenderBeginTag(HtmlTextWriterTag.Select);

            //render  tag of wrapper Option
            foreach (ListItem item in this.Items)
            {
                this.RenderOption(writer, item);
            }

            // render end tag of wrapper SELECT
            writer.RenderEndTag();




        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="text"></param>
        /// <param name="clientID"></param>
        private void RenderOption(HtmlTextWriter writer, ListItem item)
        {

            //<option selected="selected" value="2">fifo</option>

            if (item == null)
                return;

            writer.AddAttribute(HtmlTextWriterAttribute.Selected, item.Selected.ToString());
            writer.AddAttribute(HtmlTextWriterAttribute.Value, item.Value);

            if (_optionAttributes != null && _optionAttributes.Count != 0)
            {
                _optionAttributes.AddAttributes(writer);
            }

            writer.RenderBeginTag(HtmlTextWriterTag.Option);
            writer.Write(item.Text);
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
            ListItem item = null;

            if (eventArgument == null || eventArgument.Equals(string.Empty) || eventArgument.Equals("undefined"))
                return;

            foreach (ListItem it in this.Items)
            {
                if (it.Value.Equals(eventArgument))
                {
                    item = it;
                    item.Selected = true;
                    break;
                }
                else
                    it.Selected = false;
            }


            if (item == null)
                return;

            this.SelectedItem = item;
            this.OnSelectedIndexChanged(new EventArgs());
        }

        #endregion
    }

}


