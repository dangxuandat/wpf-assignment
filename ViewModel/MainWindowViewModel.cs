using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WPF_Assignment_Version2.Command;
using WPF_Assignment_Version2.Model;
using WPF_Assignment_Version2.Service;

namespace WPF_Assignment_Version2.ViewModel
{
    public class MainWindowViewModel : ViewModel
    {

        private Customer _customer;
        private Customer _billTo;
        private Customer _shipTo;
        private SalesPerson _salesPerson;
        private ObservableCollection<Person> _customers;
        private ObservableCollection<Person> _salesPersons;
        private OrderDetail _orderDetail;
        private ObservableCollection<OrderDetail> _orderDetails;
        private ICommand _deleteCommand;
        //private ICommand _selectCommand;
        private ICommand _showMessageCommand;
        private ICommand _saveCommand;
        private PriceLevel _priceLevel;
        private bool _isEnalbe;
        private Order _order;
        private string _orderNumber;
        private string _currencyCode;
        private string _shippingTerms;
        private string _cheque;
        private PaymentTerm _paymentTerm;
        private DateTime _date;
        private DateTime _dueBy;
        private DateTime _shippingDate;
        private bool _isSavable;
        private float _subTotal;
        private float _total;
        private float _vat;
        private float _discount;
        private float _shipping;
        private float _addDiscount;
        private float _tax;
        private string _note;
        private string _totalString;



        public MainWindowViewModel()
        {
            Mock<IService> mockService = new Mock<IService>();
            ServiceMock service = new ServiceMock();
            mockService.Setup(x => x.GetCustomers()).Returns(service.GetCustomers());
            mockService.Setup(x => x.GetOrderDetails()).Returns(service.GetOrderDetails());
            mockService.Setup(x => x.GetSalesPersons()).Returns(service.GetSalesPersons());
            //_orderDetail = new OrderDetail();
            _customers = mockService.Object.GetCustomers();
            _salesPersons = mockService.Object.GetSalesPersons();
            _orderDetails = mockService.Object.GetOrderDetails();
            _order = new Order() {Code = "INVI13030002"};
            _date = DateTime.Today;
            _dueBy = DateTime.Today;
            _shippingDate = DateTime.Today;
        }

            
        public PriceLevel PriceLevel
        {
            get { return _priceLevel; }
            set { 
                _priceLevel = value;
                _order.PriceLevel = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsEnable)); //disable payment info
            }
        }
        public ICommand ShowMessageCommand
        {
            get
            {
                if(_showMessageCommand == null)
                {
                    _showMessageCommand = new RelayCommand(ShowedMessageCommand, CanShowMessageCommand);
                }
                return _showMessageCommand;
            }
        }
        public bool CanShowMessageCommand(object parameter)
        {
           if(_orderDetail != null)
            {
                return true;
            }// end if there is order detail selected to showed
            else
            {
                return false;
            }
        }
        public void ShowedMessageCommand(object parameter)
        {
            MessageBox.Show(OrderDetail.ToString());
        }

        //public ICommand SelectCommand
        //{
        //    get
        //    {
        //        if(_selectCommand == null)
        //        {
        //            _selectCommand = new RelayCommand(SelectedCommand,CanSelectCommand);
        //        }
        //        return _selectCommand;
        //    }
        //}
        //public bool CanSelectCommand(object parameter)
        //{
        //    return true;
        //}
        //public void SelectedCommand(object parameter)
        //{
        //    _orderDetails.Add(new OrderDetail { Sequential = _orderDetails.Count + 1 });
        //    OnPropertyChanged("_orderDetails");
        //}
        public ICommand DeleteCommand
        {
            get 
            { 
                if(_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(DeletedCommand, CanDeleteCommand);
                }
                return _deleteCommand;
            }
        }

        public bool CanDeleteCommand(object parameter)
        {
            return true;
        }
        public void DeletedCommand(object parameter)
        {
            _orderDetails.Remove(_orderDetail);
            OnPropertyChanged("OrderDetails");
        }
        
        public ICommand SaveCommand
        {
            get
            {
                if(_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(SavedCommand,CanSaveCommand);
                }
                return _saveCommand;
            }
        }

        public bool CanSaveCommand(object parameter)
        {
            if (!_isSavable)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SavedCommand(object parameter)
        {
            _order.OrderNumber = _orderNumber;
            _order.CurrencyCode = _currencyCode;
            _order.PriceLevel = _priceLevel;
            _order.Date = _date;
            _order.DueBy = _dueBy;
            _order.ShipTo = _shipTo;
            _order.ShippingDate = _shippingDate;
            _order.ShippingTerms = _shippingTerms;
            _order.BillTo = _billTo;
            _order.PaymentTerm = _paymentTerm;
            _order.Cheque = _cheque;
            _order.OrderDetails = _orderDetails;
            _order.Vat = _vat;
            _order.Discount = _discount;
            _order.SubTotal = _subTotal;
            _order.AddDiscount = _addDiscount;
            _order.Shipping = _shipping;
            _order.Tax = _tax;
            _order.Total = _total;
            _order.Note = _note;
            _order.TotalString = _totalString;
            MessageBox.Show(_order.ToString());
        }

        public DateTime Date
        {
            get { return _date; }
            set 
            { 
                _date = value;
                ClearErrorsOfProperty(nameof(DueBy));
                if (_dueBy < _date)
                {
                    AddErrorOfPropertyInErrorsList(nameof(DueBy), "Due By must be greater than Date");
                }
                ClearErrorsOfProperty(nameof(ShippingDate));
                if (_shippingDate < _date)
                {
                    AddErrorOfPropertyInErrorsList(nameof(ShippingDate), "Shipping Date must be greater than Date");
                }
                OnPropertyChanged();
            }
        }

        public DateTime DueBy
        {
            get 
            { 
                return _dueBy;
            }
            set 
            { 
                _dueBy = value;
                ClearErrorsOfProperty(nameof(DueBy));
                if(_dueBy < _date)
                {
                    AddErrorOfPropertyInErrorsList(nameof(DueBy), "Due By must be greater than Date");
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSavable));
            }
        }
        public DateTime ShippingDate
        {
            get
            {
                return _shippingDate;
            }
            set
            {
                _shippingDate = value;
                ClearErrorsOfProperty(nameof(ShippingDate));
                if(_shippingDate < _date)
                {
                    AddErrorOfPropertyInErrorsList(nameof(ShippingDate), "Shipping Date must be greater than Date");
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSavable));
            }
        }
        public string CurrencyCode
        {
            get 
            { return _currencyCode; }
            set 
            {
                _currencyCode = value;
                ClearErrorsOfProperty(nameof(CurrencyCode));
                if(_currencyCode.ToCharArray().Length != 3)
                {
                    AddErrorOfPropertyInErrorsList(nameof(CurrencyCode), "Currency must be equal 3 characters");
                }
                if (string.IsNullOrWhiteSpace(_currencyCode))
                {
                    AddErrorOfPropertyInErrorsList(nameof(CurrencyCode), "Currency is empty");
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSavable));
            }
        }

        [Required(ErrorMessage = "Order number is not empty")]
        [MaxLength(10, ErrorMessage = "Order Number's length is required to be lower than 10 characters!!")]
        public string OrderNumber
        {
            get { return _orderNumber; }
            set {
                _orderNumber = value;
                //ClearErrorsOfProperty(nameof(OrderNumber));
                //if (_orderNumber.Length > 10)
                //{
                //    AddErrorOfPropertyInErrorsList(nameof(OrderNumber), "Order Number's length is required to be lower than 10 characters!!");
                //}
                //if (string.IsNullOrWhiteSpace(_orderNumber))
                //{
                //    AddErrorOfPropertyInErrorsList(nameof(OrderNumber), "Order Number is empty");
                //}
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSavable));
                ValidateByAnnotation(value);
                
            }
        }
        public Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        //Disable Payment info
        public bool IsEnable
        {
            get 
            {
                if (_priceLevel == PriceLevel.Internal_Price)
                {
                    return _isEnalbe = false;
                }
                else
                {
                    return _isEnalbe = true;
                }
            }
            set { _isEnalbe = value; OnPropertyChanged(); }
        }

        public bool IsSavable
        {
            get
            {
                if (HasErrors)
                {
                    _isSavable = false;
                }
                else
                {
                    _isSavable = true;
                }
                return _isSavable;
            }
            set
            {
                _isSavable = value;
                OnPropertyChanged();
            }
        }
        public SalesPerson SalesPerson
        {
            get { return _salesPerson; }
            set { _salesPerson = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Person> Customers
        {
            get { return _customers; }
            set { _customers = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Person> SalesPersons
        {
            get { return _salesPersons; }
            set { _salesPersons = value; OnPropertyChanged(); }
        }

        public OrderDetail OrderDetail
        {
            get { return _orderDetail; }
            set { 
                _orderDetail = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Vat));
                OnPropertyChanged(nameof(SubTotal));
                OnPropertyChanged(nameof(Discount));
                OnPropertyChanged(nameof(Total));
            }
        }

        public ObservableCollection<OrderDetail> OrderDetails{
            get { return _orderDetails; }
            set { _orderDetails = value; OnPropertyChanged();}
        }

        public Order Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }

        public Customer BillTo
        {
            get { return _billTo; }
            set { _billTo = value; OnPropertyChanged(); }
        }

        public Customer ShipTo
        {
            get { return _shipTo; }
            set { _shipTo = value; OnPropertyChanged();}
        }

        public string ShippingTerms { get => _shippingTerms; set { _shippingTerms = value; OnPropertyChanged(); } }
        public string Cheque { get => _cheque; set { _cheque = value; OnPropertyChanged(); } }
        public PaymentTerm PaymentTerm { get => _paymentTerm; set { _paymentTerm = value; OnPropertyChanged(); }  }

        public float SubTotal 
        { 
            get
            {
                _subTotal = 0;
                foreach (OrderDetail item in _orderDetails)
                {
                    _subTotal += item.FinalAmount;
                }
                return _subTotal;
            }
            set
            {
                _subTotal = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }
        public float Total 
        { 
            get
            {
                _total = (_subTotal + _vat + _shipping);
                _total = _total + (_total * _tax / 100) - (_total * _discount / 100) - (_total * _addDiscount/100);
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }
        public float Vat 
        { 
            get
            {
                _vat = 0;
                foreach (OrderDetail item in _orderDetails)
                {
                    _vat += item.TaxAmount;
                }
                return _vat;
            }
            set
            {
                _vat = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }
        public float Discount 
        { 
            get => _discount;
            set
            {
                _discount = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }
        public float Shipping 
        { 
            get => _shipping; 
            set
            {
                _shipping = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }
        public float AddDiscount 
        {
            get => _addDiscount; 
            set
            {
                _addDiscount = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }
        public float Tax 
        { 
            get => _tax; 
            set
            {
                _tax = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        public string Note { get => _note; set { _note = value;  OnPropertyChanged(); } }
        public string TotalString { get => _totalString; set { _totalString = value; OnPropertyChanged(); } }

        //validate based on attribute
        private void ValidateByAnnotation(object value,[CallerMemberName] string property = null)
        {
            ClearErrorsOfProperty(property);
            ValidationContext context = new ValidationContext(this) { MemberName = property};
            List<ValidationResult> results = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(value, context, results))
            {
                _errorsOnProperty[property] = results.Select(x => x.ErrorMessage).ToList();
            }
            OnErrorChanged(property);
        }    
    }
}
