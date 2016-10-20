using System;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace WinWebSolution.Module {
    public class Order : BaseObject {
        public Order(Session session) : base(session) { }
        private string _Description;
        public string Description {
            get { return _Description; }
            set { SetPropertyValue("Description", ref _Description, value); }
        }
        private decimal _Total;
        public decimal Total {
            get { return _Total; }
            set {
                SetPropertyValue("Total", ref _Total, value);
                if(!IsLoading && !IsSaving && Product != null) {
                    Product.UpdateOrdersTotal(true);
                }
            }
        }
        private Product _ProductTotal;
        [Association("Product-Orders")]
        public Product Product {
            get { return _ProductTotal; }
            set {
                Product oldProduct = _ProductTotal;
                SetPropertyValue("Product", ref _ProductTotal, value);
                if (!IsLoading && !IsSaving && oldProduct != _ProductTotal) {
                    oldProduct = oldProduct ?? _ProductTotal;                    
                    oldProduct.UpdateOrdersTotal(true);
                }
            }
        }
    }
}