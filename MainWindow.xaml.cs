using MVVM.Model;
using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM
{
    public partial class MainWindow : Window
    {
        private TradeViewModel tradeViewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void _connect_Click(object sender, RoutedEventArgs e)
        {
            if (tradeViewModel == null)
            {
                tradeViewModel = new TradeViewModel();
                DataContext = tradeViewModel;
            }

            tradeViewModel.StartExchangeServer();
        }


        private void _disconnect_Click(object sender, RoutedEventArgs e)
        {
            if (tradeViewModel == null) return;

            tradeViewModel.StopExchangeServer();
        }

    }
}
