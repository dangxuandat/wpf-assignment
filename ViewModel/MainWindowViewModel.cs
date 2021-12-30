using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Assignment_Version2.Command;
using WPF_Assignment_Version2.Model;

namespace WPF_Assignment_Version2.ViewModel
{
    public class MainWindowViewModel : ViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Customer _customer;
        private Customer _billTo;
        private Customer _shipTo;
        private SalesPerson _salesPerson;
        private ObservableCollection<Person> _customers;
        private ObservableCollection<Person> _salesPersons;
        private OrderDetail _orderDetail;
        private ObservableCollection<OrderDetail> _orderDetails;
        private ICommand _deleteCommand;
        private ICommand _selectCommand;
        private PriceLevel _priceLevel;
        private bool _isEnalbe;
        private Order _order;
        private string _orderNumber;
        private string _currencyCode;
        private DateTime _date;
        private DateTime _dueBy;
        private DateTime _shippingDate;
        

        public MainWindowViewModel()
        {
            //_orderDetail = new OrderDetail();
            _customers = new ObservableCollection<Person>()
            {
                new Customer(){ Name = "Dang Xuan Dat"},
                new Customer(){ Name = "Nguyen Van A"},
                new Customer(){ Name = "Nguyen Van B"}
            };
            _salesPersons = new ObservableCollection<Person>()
            {
                new SalesPerson(){Id = "SE150688", Name = "Dang Xuan A"},
                new SalesPerson(){Id = "SE150677", Name = "Dang Xuan B"},
                new SalesPerson(){Id = "SE150612", Name = "Dang Xuan C"},
            };
            _orderDetails = new ObservableCollection<OrderDetail>()
            {
                new OrderDetail(1,"STK00001","APPLE IPAD CASTING - WHITE","PC",160.00F,0.00F,1,30,0.00F),
                new OrderDetail(2,"STK00001","SAMSUNG GALAXY TAB 10.1 CASTING - BLACK","PC",40.00F,0.00F,1,40,0.00F),
                new OrderDetail(3,"STK00001","SAMSUNG GALAXY TAB 10.1 CASING - WHITE","PC",30.00F,0.00F,1,50,0.00F),
            };
            _order = new Order() {Code = "INVI13030002",CurrencyCode = "USD"};
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
        public ICommand SelectCommand
        {
            get
            {
                if(_selectCommand == null)
                {
                    _selectCommand = new RelayCommand(SelectedCommand,CanSelectCommand);
                }
                return _selectCommand;
            }
        }
        public bool CanSelectCommand(object parameter)
        {
            return true;
        }
        public void SelectedCommand(object parameter)
        {
            _orderDetails.Add(new OrderDetail { Sequential = _orderDetails.Count + 1 });
            OnPropertyChanged("_orderDetails");
        }
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
                OnPropertyChanged();
            }
        }
        public string OrderNumber
        {
            get { return _orderNumber; }
            set {
                _orderNumber = value;
                ClearErrorsOfProperty(nameof(OrderNumber));
                if (_orderNumber.Length > 10)
                {
                    AddErrorOfPropertyInErrorsList(nameof(OrderNumber), "Order Number's length is required to be lower than 10 characters!!");
                }
                OnPropertyChanged();
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
            set { _orderDetail = value; OnPropertyChanged(); }
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

        //Caller Member Name will return name of method
        private void OnPropertyChanged([CallerMemberName]string parameter = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parameter)); 
        }

        private bool IsSavable(Order _order)
        {
            bool isSavable = false;
            if(_order.OrderNumber.Count() > 10)
            {
                AddErrorOfPropertyInErrorsList(_order.OrderNumber, "Order Number's length is required lower than 10 characters!");
            }
            return isSavable;
        }
    }
}
