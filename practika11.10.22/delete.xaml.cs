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

namespace practika11._10._22
{
    /// <summary>
    /// Логика взаимодействия для delete.xaml
    /// </summary>
    public partial class delete : Window
    {
        ListView ListView;
        public delete(ListView newListView)
        {
            InitializeComponent();
            ListView = newListView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var removedData = ListView.SelectedItems.Cast<products_users_table>().ToList();
            Instances.db.products_users_table.RemoveRange(removedData);
            Instances.db.SaveChanges();
            Instances.db.ChangeTracker.Entries().ToList().ForEach(q => q.Reload());
            this.Close();
        }
    }
}
