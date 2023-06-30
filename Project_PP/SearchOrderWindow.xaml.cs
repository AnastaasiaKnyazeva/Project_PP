using Project_PP.Classes;
using Project_PP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Project_PP
{
    /// <summary>
    /// Логика взаимодействия для SearchOrderWindow.xaml
    /// </summary>
    public partial class SearchOrderWindow : Window
    {
        List<OrderTable> list;
        public SearchOrderWindow(List<OrderTable> list)
        {
            InitializeComponent();
            this.list = list;
            listOrders.ItemsSource = DataBaseClass.connect.OrderTable.Where(x=>x.TypeOrder!=2).ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (listOrders.SelectedItem != null)
            {
                list.Add(listOrders.SelectedItem as OrderTable);
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите заказ из списка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                List<OrderTable> orders = DataBaseClass.connect.OrderTable.Where(x => x.TypeOrder != 2).ToList();
                orders = orders.Where(x => x.ClientTable.Fio.ToLower().Contains(tbSearch.Text.ToLower())||x.EquipmentTable.SerialNumber.ToLower().Contains(tbSearch.Text.ToLower())||x.ID.ToString()==tbSearch.Text).ToList();
                if (orders.Count > 0)
                {
                    listOrders.ItemsSource = orders;
                    tbEmpty.Visibility = Visibility.Collapsed;
                    listOrders.Visibility = Visibility.Visible;
                }
                else
                {
                    listOrders.ItemsSource = null;
                    tbEmpty.Visibility = Visibility.Visible;
                    listOrders.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
