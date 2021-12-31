using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assignment_Version2.Model
{
    public class Order : INotifyPropertyChanged
    {
        private string _code;
        private string _orderNumber;
        private string _currencyCode;
        private PriceLevel _priceLevel;
        private DateTime _date;
        private DateTime _dueBy;
        private Person _shipTo;
        private DateTime _shippingDate;
        private string _shippingTerms;
        private Person _billTo;
        private Person _customer;
        private Person _salesPerson;
        private PaymentTerm _paymentTerm;
        private string _cheque;
        private ObservableCollection<OrderDetail> _orderDetails;
        private float _subTotal;
        private float _total;
        private float _vat;
        private float _discount;
        private float _shipping;
        private float _addDiscount;
        private float _tax;
        private string _note;
        private string _totalString;

        public string Code { get => _code; set { _code = value; OnPropertyChanged(); }}
        public string CurrencyCode { get => _currencyCode; set { _currencyCode = value; OnPropertyChanged(); }}
        public PriceLevel PriceLevel { get => _priceLevel; set { _priceLevel = value; OnPropertyChanged(); }}
        public DateTime Date { get => _date; set { _date = value; OnPropertyChanged(); } }
        public DateTime DueBy { get => _dueBy; set { _dueBy = value; OnPropertyChanged(); } }
        public Person ShipTo { get => _shipTo; set { _shipTo = value; OnPropertyChanged(); } }
        public DateTime ShippingDate { get => _shippingDate; set { _shippingDate = value; OnPropertyChanged(); } }
        public string ShippingTerms { get => _shippingTerms; set { _shippingTerms = value; OnPropertyChanged(); } }
        public Person BillTo { get => _billTo; set { _billTo = value; OnPropertyChanged(); } }
        public PaymentTerm PaymentTerm { get => _paymentTerm; set { _paymentTerm = value; OnPropertyChanged(); } }
        public string Cheque { get => _cheque; set { _cheque = value; OnPropertyChanged(); } }

        public string OrderNumber { get => _orderNumber; set { _orderNumber = value; OnPropertyChanged(); } }

        public ObservableCollection<OrderDetail> OrderDetails { get => _orderDetails; set { _orderDetails = value; OnPropertyChanged(); } }

        public Person Customer { get => _customer; set { _customer = value; OnPropertyChanged(); } }
        public Person SalesPerson { get => _salesPerson; set { _salesPerson = value; OnPropertyChanged(); }  }

        public float SubTotal { get => _subTotal ; set { _subTotal = value; OnPropertyChanged(); } }
        public float Total { get => _total; set { _total = value; OnPropertyChanged(); } }
        public float Vat { get => _vat; set { _vat = value; OnPropertyChanged(); } }
        public float Discount { get => _discount; set { _discount = value; OnPropertyChanged(); }  }
        public float Shipping { get => _shipping; set { _shipping = value; OnPropertyChanged(); }  }
        public float AddDiscount { get => _addDiscount; set { _addDiscount = value; OnPropertyChanged(); } }

        public float Tax { get => _tax; set { _tax = value; OnPropertyChanged(); } }

        public string Note { get => _note; set { _note = value; OnPropertyChanged(); } }
        public string TotalString { get => _totalString; set { _totalString = value;  OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            string output = $"Order: \n" +
                            $"   Customer: {_customer}\n" +
                            $"   SalesPerson: {_salesPerson}\n" +
                            $"   Date: {_date}\n" +
                            $"   Due Date: {_dueBy}\n" +
                            $"   Ship Date: {_shippingDate}\n" +
                            $"   Order Details: \n";
            return "s";
        }
    }
}
