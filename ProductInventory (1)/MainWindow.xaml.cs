using ProductInventory.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductInventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Prodcontext prodcontext=new Prodcontext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var username = txtboxuser.Text;
            var password = txtboxpass.Password;
            if(string.IsNullOrWhiteSpace(txtboxuser.Text)||(string.IsNullOrWhiteSpace(txtboxpass.Password)))
                {
                MessageBox.Show("fill Data ");
            }
            var user=prodcontext.Users.FirstOrDefault(u=>u.UName==username&& u.UPassword == password);
            if (user != null)
            {
                myTextBlock.Text = "Login Successfull";
                myTextBlock.Foreground = System.Windows.Media.Brushes.Green;
                if (user.URole == "Stock Clerk")
                {
                    StockClerk stock=new StockClerk();
                    stock.Show();
                    this.Close();
                }

            else if (user.URole == "Administrator")
                {
                    Administrator admin = new Administrator();
                    admin.Show();
                    this.Close();
                }
            }
            else
            {
                myTextBlock.Text = "Invalid username or password";
                myTextBlock.Foreground=System.Windows.Media.Brushes.Red;
            }
        }
    }
}