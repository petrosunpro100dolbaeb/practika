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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace practika11._10._22
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string login = name.Text;
                string passwordFind = ConvertToHash(parol.Password);

                var user = Instances.db.users.FirstOrDefault(q => q.login.Contains(login) && q.password.Contains(passwordFind));
                if (user != null)
                {
                    //MessageBox.Show("YEEEES YEEEEEEES!!!!!!");
                    data data = new data(user);
                    data.Show();

                    parol.Password = "";
                    this.Hide();
                }
                else
                    MessageBox.Show("Bruh");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string ConvertToHash(string whoFind)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(whoFind);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                string findOut = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return findOut;
            }
            return "";
        }
    }
}
