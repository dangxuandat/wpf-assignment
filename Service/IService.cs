using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Assignment_Version2.Model;

namespace WPF_Assignment_Version2.Service
{
    public interface IService
    {
        ObservableCollection<OrderDetail> GetOrderDetails();
        ObservableCollection<Person> GetCustomers();
        ObservableCollection<Person> GetSalesPersons();
    }
}
