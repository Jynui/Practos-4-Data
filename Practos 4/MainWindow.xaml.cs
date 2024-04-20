using System;
using System.Collections.Generic;
using System.Data;
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


using Practos_4.yandex_storeDataSetTableAdapters;

namespace Practos_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Order_ProductsTableAdapter holo = new Order_ProductsTableAdapter();
        ProductsTableAdapter qq = new ProductsTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            holo1.ItemsSource = holo.wasd();
            FF.ItemsSource = qq.GetData();
            FF.DisplayMemberPath = "product_name";




        }
        private void TAG(object sender, RoutedEventArgs e)
        {
            holo1.Columns[0].Visibility = Visibility.Collapsed;
            holo1.Columns[1].Visibility = Visibility.Collapsed;
            holo1.Columns[2].Visibility = Visibility.Collapsed;
            holo1.Columns[3].Visibility = Visibility.Collapsed;




        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Txt.Text = "";
            holo1.ItemsSource = holo.wasd();
            TAG(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tag = Txt.Text;
            holo1.ItemsSource = holo.GetDataBy(tag);
            TAG(sender, e);
        }
        
        private void gg(object sender, NavigationEventArgs e)

        {
            holo1.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void FF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FF.SelectedItem != null) 
            {
                var Product_id = (int)(FF.SelectedItem as DataRowView).Row[0];
                holo1.ItemsSource = holo.SearchByID(Product_id);
                TAG(sender, e);
            }
        }
    }

    








    
}