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
using System.IO;

namespace practika11._10._22
{
    /// <summary>
    /// Логика взаимодействия для data.xaml
    /// </summary>
    public partial class data : Window
    {
        user user;
        DateTime startSessionTime;
        DateTime endSessionTime;
        public data(user newuser)
        {
            InitializeComponent();
            user = newuser;
            spisok_ListView.ItemsSource = Instances.db.products_users_table.Take(1000).ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddData addData = new AddData();
            addData.Show();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (spisok_ListView.SelectedItem != null)
            {
                delete delete = new delete(spisok_ListView);
                delete.Show();
                spisok_ListView.ItemsSource=Instances.db.products_users_table.Take(100).ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            pechat pechat = new pechat();
            pechat.Show();
          
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            endSessionTime = DateTime.Now;
            using (StreamWriter streamWriter = new StreamWriter("C:/UsersProfile/pr10gulko/Documents/Payments/" + user.login + ".csv"))
            {
                streamWriter.WriteLine("Session Start " + startSessionTime);
                streamWriter.WriteLine("Session End " + endSessionTime);

                streamWriter.WriteLine("А здесь должно быть 'Сколько записей было добавлено за сеанс'");
                streamWriter.WriteLine("А здесь должно быть 'Сколько записей было изменено за сеанс'");
                streamWriter.WriteLine("А здесь должно быть 'Сколько записей было удалено за сеанс'");
                streamWriter.WriteLine("А здесь должно быть 'Общее кол-во затронутых за сеанс записей для данного пользователя'");
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
        }
    }
}
