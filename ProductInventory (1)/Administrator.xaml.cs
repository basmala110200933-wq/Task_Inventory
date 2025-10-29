using Microsoft.EntityFrameworkCore;
using ProductInventory.Data;
using ProductInventory.Model;
using System.Linq;
using System.Windows;

namespace ProductInventory
{
    public partial class Administrator : Window
    {
        Prodcontext db = new Prodcontext();

        public Administrator()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgProducts.ItemsSource = db.Product.Include(p => p.supplier).ToList();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            detalisProduct window = new detalisProduct(null);
            window.ShowDialog();
            LoadProducts();
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selected)
            {
                detalisProduct window = new detalisProduct(selected.ProductID);
                window.ShowDialog();
                LoadProducts();
            }
            else
            {
                MessageBox.Show("Please select a product to edit.");
            }
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selected)
            {
                var result = MessageBox.Show($"Delete {selected.PName}?", "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    db.Product.Remove(selected);
                    db.SaveChanges();
                    LoadProducts();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            Suppliers window = new Suppliers();
            window.ShowDialog();
        }
    }
}
