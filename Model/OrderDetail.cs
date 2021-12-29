using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assignment_Version2.Model
{
    public class OrderDetail : INotifyPropertyChanged
    {
        private int? _sequential;
        private string _itemCode;
        private string _description;
        private string _uom;
        private float _unitPrice;
        private float _discPercent;
        private float _tax;
        private int _quantity;
        private float _discAmount;
        private float _amount;
        public int? Sequential
        {
            get { return _sequential; }
            set { 
                _sequential = value;
                OnPropertyChanged();
            }
        }
        public string ItemCode { 
            get { 
                return _itemCode;
            } 
            set {
                _itemCode = value;
                OnPropertyChanged();
            } 
        }
        public string Description {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        public string UOM {
            get
            {
                return _uom;
            }
            set
            {
                _uom = value;
                OnPropertyChanged();
            }
        }
        public float UnitPrice {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
            }
        }
        public int Quantity {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Amount));
            }
        }
        public float Amount {
            get
            {
                return _amount = UnitPrice * Quantity;
            }
            set
            {
                _amount = UnitPrice * Quantity;
                OnPropertyChanged();
            }
        }
        public float DiscPercent {
            get
            {
                return _discPercent;
            }
            set
            {
                _discPercent = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FinalAmount));
            }
        }
        public float DiscAmount {
            get
            {
                return _discAmount;
            }
            set
            {
                _discAmount = value;
                OnPropertyChanged();
            }
        }
        public float FinalAmount {
            get
            {
                return Amount - (Amount * DiscPercent/100);
            }
        }
        public float Tax {
            get
            {
                return _tax;
            }
            set
            {
                _tax = value;
                OnPropertyChanged();
            }
        }
        public float TaxAmount { 
            get {
                return FinalAmount * Tax * 5 / 100;
            }
        }

        

        public OrderDetail()
        {

        }
        public OrderDetail(int sequential,string itemCode, string description, string uom, float unitPrice, float discPercent, float tax, int quantity, float discAmount)
        {
            _sequential = sequential;
            _itemCode = itemCode;
            _description = description;
            _uom = uom;
            _unitPrice = unitPrice;
            _discPercent = discPercent;
            _tax = tax;
            _quantity = quantity;
            _discAmount = discAmount;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }

    }
}
