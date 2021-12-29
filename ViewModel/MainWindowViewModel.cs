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
    public class MainWindowViewModel : INotifyPropertyChanged
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
        private Order _order;
        private bool _isEnable; //Disable Payment info if Price Level is Interal


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
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set { _isEnable = value; OnPropertyChanged(); }
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
    }
}
