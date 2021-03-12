using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestMVVM
{
   
    public partial class MainPage : ContentPage
    {
        //AppViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();

           // viewModel = new AppViewModel();
           BindingContext = new AppViewModel();

          

        }
    }
}
