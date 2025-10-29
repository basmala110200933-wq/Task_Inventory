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
using ProductInventory.Data;
using ProductInventory.Model;

namespace ProductInventory
{
    /// <summary>
    /// Interaction logic for Suppliers.xaml
    /// </summary>
    public partial class Suppliers : Window
    {
            Prodcontext db = new Prodcontext();

        public Suppliers()
        {
            InitializeComponent();
                        LoadSuppliers();
            }

            private void LoadSuppliers()
            {
                SuppliersGrid.ItemsSource = db.Supplier.ToList();
            }

            private void Add_Click(object sender, RoutedEventArgs e)
            {
                detalisProduct window = new detalisProduct(null);
                window.ShowDialog();
                LoadSuppliers();
            }

            private void Edit_Click(object sender, RoutedEventArgs e)
            {
                if (SuppliersGrid.SelectedItem is Supplier selected)
                {
                    detalisProduct window = new detalisProduct(selected.supid);
                    window.ShowDialog();
                    LoadSuppliers();
                }
                else
                {
                    MessageBox.Show("Please select a supplier to edit.");
                }
            }

            private void Delete_Click(object sender, RoutedEventArgs e)
            {
                if (SuppliersGrid.SelectedItem is Supplier selected)
                {
                    var confirm = MessageBox.Show($"Delete {selected.SName}?", "Confirm Delete", MessageBoxButton.YesNo);
                    if (confirm == MessageBoxResult.Yes)
                    {
                        db.Supplier.Remove(selected);
                        db.SaveChanges();
                        LoadSuppliers();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a supplier to delete.");
                 }
            }
    }
}