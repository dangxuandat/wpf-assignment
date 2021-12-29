using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Assignment_Version2.Model;

namespace WPF_Assignment_Version2.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Person> customers;
        private ObservableCollection<Person> salesPersons;
        private List<string> priceLevels;
        private List<string> paymentTerms;
        private ObservableCollection<OrderDetail> orderDetails;

        public ObservableCollection<Person> Customers
        {
            get
            {
                return customers;
            }
            set
            {
                customers = value;
            }
        }

        public ObservableCollection<Person> SalesPersons
        {
            get
            {
                return salesPersons;
            }
            set
            {
                salesPersons = value;
            }
        }
        public List<string> PriceLevels
        {
            get { return priceLevels; }
            set { 
                priceLevels = value;
                OnPropertyChanged();
            }
        }
        public List<string> PaymentTerms
        {
            get { return paymentTerms; }
            set { 
                paymentTerms = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<OrderDetail> OrderDetails
        {
            get { return orderDetails; }
            set { 
                orderDetails = value;
                OnPropertyChanged();
            }
        }
        public MainWindowViewModel()
        {
            customers = new ObservableCollection<Person>()
            {
                new Customer{Name = "dat dang"},
                new Customer{Name = "dang minh duc"},
                new Customer{Name = "Marry"},
                new Customer{Name = "Marry"},
            };
            salesPersons = new ObservableCollection<Person>()
            {
                new SalesPerson{Name = "Dang Xuan Dat", Id = "SE150699"},
                new SalesPerson{Name = "Dang Van A", Id = "SE150688"},
                new SalesPerson{Name = "Dang Van B", Id = "SE150612"}
            };
            priceLevels = new List<string>()
            {
                "1 - Regular Price",
                "2 - Wholesale Price",
                "3 - Internal Price"
            };
            paymentTerms = new List<string>()
            {
                "0 Days",
                "7 Days",
                "30 Days"
            };
            orderDetails = new ObservableCollection<OrderDetail>()
            {
               new OrderDetail("STK000001","APPLE IPAD CASTING WHITE","PC",160F,0.00F,1,30,0.00F),
               new OrderDetail("STK000002","SAMSUNG GALAXY TAB 10.1 CASTING BLACK","PC",160F,0.00F,1,30,0.00F),
               new OrderDetail("STK000003","SAMSUNG GALAXY TAB 10.1 CASTING WHITE","PC",160F,0.00F,1,30,0.00F)
            };
        }

        //Caller Member Name will return name of method
        private void OnPropertyChanged([CallerMemberName]string parameter = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parameter)); 
        }
    }
}
