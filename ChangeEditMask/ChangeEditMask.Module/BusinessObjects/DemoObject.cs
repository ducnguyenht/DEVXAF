﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace ChangeEditMask.Module.BusinessObjects {
    [DefaultClassOptions]
    public class DemoObject : BaseObject {
        public DemoObject(Session session) : base(session) { }
        private EditMask _Mask;
        [ImmediatePostData]
        public EditMask Mask {
            get { return _Mask; }
            set { SetPropertyValue("Mask", ref _Mask, value); }
        }
        private string _TestString;
        public string TestString {
            get { return _TestString; }
            set { SetPropertyValue("TestString", ref _TestString, value); }
        }
    }
    public enum EditMask {
        Date,
        Time,
        Numeric,
        String
    }
}
