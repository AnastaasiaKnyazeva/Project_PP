using Project_PP.Classes;
using Project_PP.Model;
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

namespace Project_PP.Pages
{
    /// <summary>
    /// Логика взаимодействия для FindOrderBySerialNumberPage.xaml
    /// </summary>
    public partial class FindOrderBySerialNumberPage : Page
    {
        LoginedTable loginedTable;
        public FindOrderBySerialNumberPage(LoginedTable logined)
        {
            InitializeComponent();
            loginedTable = logined;
            listOrders.ItemsSource = DataBaseClass.connect.OrderTable.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на главную страницу");
            FrameClass.frmMain.Navigate(new MenuPage(loginedTable));
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                List<OrderTable> orders = DataBaseClass.connect.OrderTable.ToList();
                orders = orders.Where(x => x.EquipmentTable.SerialNumber.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
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

        private void listOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderTable order = listOrders.SelectedItem as OrderTable;
            if (order.TypeOrder == 2)
            {
                FrameClass.frmMenu.Navigate(new IssueEquipmentPrint(order.ID));
            }
            else
            {
                FrameClass.frmMenu.Navigate(new AcceptEquipmentPrint(order.ID));
            }

        }
    }
}
