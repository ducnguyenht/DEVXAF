using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Editors;
using NamolyOnPremises.Module.Web.Editors.Base;
using NamolyOnPremises.Module.BusinessObjects.Operational.Hotel.Nomeclature.Configuration;

[PropertyEditor(typeof(String), false)]
public class SpecialRequestPropertyEditor : SerializedListPropertyEditor<HotelSpecialRequest>
{
    public SpecialRequestPropertyEditor(Type objectType, IModelMemberViewItem info)
        : base(objectType, info) { }

    protected override string GetDisplayText(HotelSpecialRequest obj)
    {
        return String.Format("{0}", obj.Name);
    }

    protected override string GetValue(HotelSpecialRequest obj)
    {
        return obj.Name;
    }
}

