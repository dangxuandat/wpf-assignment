using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Assignment_Version2.Model;

namespace WPF_Assignment_Version2.Service
{
    public class ServiceMock : IService
    {
        private ObservableCollection<OrderDetail> _orderDetails;
        private ObservableCollection<Person> _customers;
        private ObservableCollection<Person> _salesPersons;



        public ObservableCollection<Person> GetCustomers()
        {
            _customers = new ObservableCollection<Person>()
            {
                new Customer(){ Name = "Dang Xuan Dat"},
                new Customer(){ Name = "Nguyen Van A"},
                new Customer(){ Name = "Nguyen Van B"}
            };
            return _customers;
        }

        public ObservableCollection<OrderDetail> GetOrderDetails()
        {
            _orderDetails = new ObservableCollection<OrderDetail>()
            {
                new OrderDetail(1,"STK00001","APPLE IPAD CASTING - WHITE","PC",160.00F,0.00F,1,30,0.00F),
                new OrderDetail(2,"STK00001","SAMSUNG GALAXY TAB 10.1 CASTING - BLACK","PC",40.00F,0.00F,1,40,0.00F),
                new OrderDetail(3,"STK00001","SAMSUNG GALAXY TAB 10.1 CASING - WHITE","PC",30.00F,0.00F,1,50,0.00F),
            };
            return _orderDetails;
        }

        public ObservableCollection<Person> GetSalesPersons()
        {
            _salesPersons = new ObservableCollection<Person>()
            {
                new SalesPerson(){Id = "SE150688", Name = "Dang Xuan A"},
                new SalesPerson(){Id = "SE150677", Name = "Dang Xuan B"},
                new SalesPerson(){Id = "SE150612", Name = "Dang Xuan C"},
            };
            return _salesPersons;
        }
    }
}
