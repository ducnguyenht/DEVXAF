﻿using System;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web.Editors;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridLookup;
using DevExpress.Web.ASPxGridView;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering;
using System.Reflection;
using System.Collections;
using DevExpress.ExpressApp.Filtering;

namespace Solution4.Module.Web.Editors.ManagerAspxGridLookupPropertyEditors
{
    //[PropertyEditor(typeof(object), "CustomWebLookup", false)]
    [PropertyEditor(typeof(BaseObject), EditorAliases.LookupPropertyEditor, true)]
    public class ManagerAspxGridLookupPropertyEditor : ASPxObjectPropertyEditorBase
    {
        private WebLookupEditorHelper helper;
        ASPxGridLookup control = null;
        public ManagerAspxGridLookupPropertyEditor(Type objectType, IModelMemberViewItem info) : base(objectType, info) { }
        protected override WebControl CreateEditModeControlCore()
        {
            IModelListView modelListView = this.Model.View as IModelListView;
            if (modelListView == null)
            {
                modelListView = application.FindModelClass(MemberInfo.MemberTypeInfo.Type).DefaultLookupListView;
            }
            modelListView.UseServerMode = true;
            CollectionSource collectionSource = new CollectionSource(objectSpace, MemberInfo.MemberTypeInfo.Type, modelListView.UseServerMode);
            ListView tempListView = this.application.CreateListView(modelListView, collectionSource, false);
            tempListView.CreateControls();
            control = new ASPxGridLookup();
            control.KeyFieldName = MemberInfo.MemberTypeInfo.KeyMember.Name;
            control.IncrementalFilteringMode = IncrementalFilteringMode.Contains;
            control.IncrementalFilteringDelay = 800;
            control.GridView.AutoGenerateColumns = false;
            control.SelectionMode = GridLookupSelectionMode.Single;
            if (tempListView.Editor != null && tempListView.Editor is ASPxGridListEditor)
            {
                ASPxGridView tempGridView = ((ASPxGridListEditor)tempListView.Editor).Grid;

                foreach (GridViewColumn tempColumn in tempGridView.Columns)
                {
                    control.GridView.Columns.Add(tempColumn);
                }
                control.GridView.Settings.Assign(tempGridView.Settings);
                control.GridView.Settings.ShowHeaderFilterButton = false;
                control.GridView.Settings.ShowFilterBar = GridViewStatusBarMode.Hidden;
                if (control.Columns.Count > 1)
                {
                    string format = "";
                    for (int i = 0; i < control.Columns.Count; i++)
                    {
                        if (i == control.Columns.Count - 1)
                        {
                            format += string.Format("{{{0}}}", i);
                        }
                        else
                        {
                            format += "{" + i + "} |";
                        }
                    }
                    control.TextFormatString = format;// "{1} | {0}";
                }
                control.GridView.SettingsPager.PageSize = 10;
                control.GridView.Width = 300;

                if (!String.IsNullOrEmpty(Model.DataSourceProperty) || !String.IsNullOrEmpty(Model.DataSourceProperty) || !String.IsNullOrEmpty(Model.DataSourceCriteria))
                {
                    if (!String.IsNullOrEmpty(Model.DataSourceProperty))
                    {
                        if (CurrentObject != null)
                        {
                            PropertyInfo dataSourceProperty = ObjectType.GetProperty(Model.DataSourceProperty);
                            control.DataSource = dataSourceProperty.GetValue(this.CurrentObject, null) as IEnumerable;
                        }
                    }
                    if (!String.IsNullOrEmpty(Model.DataSourceCriteria))
                    {
                        control.DataSource = objectSpace.GetObjects(MemberInfo.MemberTypeInfo.Type, CriteriaOperator.Parse(Model.DataSourceCriteria));
                    }
                    if (!String.IsNullOrEmpty(Model.DataSourceCriteriaProperty))
                    {
                        if (CurrentObject != null)
                        {
                            PropertyInfo dataSourceCriteriaProperty = ObjectType.GetProperty(Model.DataSourceCriteriaProperty);
                            CriteriaOperator cri = dataSourceCriteriaProperty.GetValue(CurrentObject, null) as CriteriaOperator;
                            control.DataSource = objectSpace.GetObjects(GetUnderlyingType(), cri, false);
                        }
                    }
                }
                else
                {
                    control.DataSource = collectionSource.Collection;
                }
            }
            control.ValueChanged += EditValueChangedHandler;
            return control;
        }

        protected override void SetImmediatePostDataScript(string script)
        {
            control.ClientSideEvents.ValueChanged = script;
        }
        protected override void SetImmediatePostDataCompanionScript(string script)
        {
            control.SetClientSideEventHandler("ValueChanged", script);
        }
        protected override void ReadEditModeValueCore()
        {
            BaseObject obj = this.CurrentObject as BaseObject;
            var propertyValue = obj.GetMemberValue(this.propertyName) as BaseObject;
            if (propertyValue != null)
            {
                control.GridView.Selection.SelectRowByKey(propertyValue.Oid);
            }
            if (MemberInfo.GetValue(CurrentObject) == null) { this.control.Text = ""; }
        }

        protected override object GetControlValueCore()
        {
            if (ViewEditMode == ViewEditMode.Edit && Editor != null)
            {
                var editor = this.Editor as ASPxGridLookup;

                if (editor.Value != null)
                {   //get selected Obj
                    return objectSpace.GetObjectByKey(MemberInfo.MemberType, editor.Value);
                }
                return null;
            }
            return MemberInfo.GetValue(CurrentObject);
        }
        protected override void WriteValueCore()
        {
            base.WriteValueCore();
        }
        public override void Setup(DevExpress.ExpressApp.IObjectSpace objectSpace, DevExpress.ExpressApp.XafApplication application)
        {
            base.Setup(objectSpace, application);

            helper = new WebLookupEditorHelper(application, objectSpace, MemberInfo.MemberTypeInfo, Model);
        }
        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            base.BreakLinksToControl(unwireEventsOnly);
        }
    }
}
