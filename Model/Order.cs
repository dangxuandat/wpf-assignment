using System;
using System.Collections.Generic;
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
        private string _currencyCode;
        private PriceLevel _priceLevel;
        private DateTime _date;
        private DateTime _dueBy;
        private Person _shipTo;
        private DateTime _shippingDate;
        private string _shippingTerms;
        private Person _billTo;
        private PaymentTerm _paymentTerm;
        private string _cheque;

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
