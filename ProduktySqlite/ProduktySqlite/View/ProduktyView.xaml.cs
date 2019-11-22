using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProduktySqlite.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProduktyView : ContentPage
    {
        private readonly ViewModel.ProduktyViewModel viewModel;

        public ProduktyView(string connectionString)
        {
            InitializeComponent();

            BindingContext = viewModel = new ViewModel.ProduktyViewModel(connectionString);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.NactiProdukty();

        }
    }
}