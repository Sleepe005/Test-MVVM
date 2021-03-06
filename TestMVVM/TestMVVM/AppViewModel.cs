using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestMVVM
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Customer> customers;

        public AppViewModel()
        {
            customers = new ObservableCollection<Customer>()
            {
                new Customer("Купить корм собаке", new DateTime(2020, 5, 12, 13, 10, 0), 3), // Year, day, mont, hour, minute, seconds
                new Customer("Заменить проездной", 3),
                new Customer("Купить корм собаке", 2),
                new Customer("Купить корм собаке", 1),
                new Customer("Купить корм собаке", 2)
            };
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return this.customers;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
