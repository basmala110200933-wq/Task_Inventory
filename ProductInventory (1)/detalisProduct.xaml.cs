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
using System.Xml.Linq;
using ProductInventory.Data;
using ProductInventory.Model;

namespace ProductInventory
{
    /// <summary>
    /// Interaction logic for detalisProduct.xaml
    /// </summary>
    public partial class detalisProduct : Window
    {  
            Prodcontext db = new Prodcontext();
            private int? productId; 
        public detalisProduct(int ?id)
        {
            InitializeComponent();
            productId = id;
            LoadSuppliers();

            if (productId.HasValue)
            {
                LoadProductData();
            }
        } 
            public void LoadSuppliers()
            {
                cmbSupplier.ItemsSource = db.Supplier.ToList();
            }
            public void LoadProductData()
            {
                var product = db.Product.FirstOrDefault(p => p.ProductID == productId);
                if (product != null)
                {
                    txtName.Text = product.PName;
                    txtDesc.Text = product.PDescription;
                    txtQty.Text = product.Quantity.ToString();
                    txtPrice.Text = product.Price.ToString();
                    cmbSupplier.SelectedValue = product.SupplierID;
                }
            }
            private void btnSave_Click(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtQty.Text))
                {
                    MessageBox.Show("Please fill all required fields");
                    return;
                }

                if (productId.HasValue)
                {
                    var product = db.Product.FirstOrDefault(p => p.ProductID == productId);
                    if (product != null)
                    {
                        product.PName = txtName.Text;
                        product.PDescription = txtDesc.Text;
                        product.Quantity = int.Parse(txtQty.Text);
                        product.Price = decimal.Parse(txtPrice.Text);
                        product.SupplierID = (int)cmbSupplier.SelectedValue;
                    }
                }
                else
                {
                    Product p = new Product
                    {
                        PName = txtName.Text,
                        PDescription = txtDesc.Text,
                        Quantity = int.Parse(txtQty.Text),
                        Price = decimal.Parse(txtPrice.Text),
                        SupplierID = (int)cmbSupplier.SelectedValue
                    };
                    db.Product.Add(p);
                }

                db.SaveChanges();
                MessageBox.Show("Saved successfully!");
                this.Close();
            }
        }
    }