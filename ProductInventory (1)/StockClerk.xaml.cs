using Microsoft.EntityFrameworkCore;
using ProductInventory.Data;
using ProductInventory.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ProductInventory
{
    /// <summary>
    /// Interaction logic for Stock.xaml
    /// </summary>
    public partial class StockClerk : Window
    {
        Prodcontext p=new Prodcontext();
        public StockClerk()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            using (var db = new Prodcontext())
            {
                var products = p.Product.Include(p => p.supplier).ToList();
                dgInStock.ItemsSource = products.Where(p => p.Quantity >= 10).ToList();
                dgLowStock.ItemsSource = products.Where(p => p.Quantity < 10).ToList();
            }
        }
        private void ShipStock_Click(object sender, RoutedEventArgs e)
        {
            if (dgInStock.SelectedItem is Product select && select.Quantity >= 5)
            {
                select.Quantity -= 5;
                p.SaveChanges();
                LoadData();
            }
        }
        private void ReceiveStock_Click(object sender, RoutedEventArgs e)
        {
            if (dgLowStock.SelectedItem is Product select)
            {
                select.Quantity += 5;
                p.SaveChanges();
                LoadData();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}

