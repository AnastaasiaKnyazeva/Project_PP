using Project_PP.Classes;
using Project_PP.Model;
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

namespace Project_PP.Pages
{
    /// <summary>
    /// Логика взаимодействия для IssueEquipment.xaml
    /// </summary>
    public partial class IssueEquipment : Page
    {
        LoginedTable loginedTable;
        public IssueEquipment(LoginedTable logined)
        {
            InitializeComponent();
            loginedTable = logined;
            List<OrderTable> list = DataBaseClass.connect.OrderTable.Where(x=> x.TypeOrder == 2).OrderByDescending(x=> x.IssueEquipment.Date).ToList();
            if (list.Count > 0)
            {
                listEquipment.ItemsSource = list;
                listEquipment.Visibility = Visibility.Visible;
                tbEmpty.Visibility = Visibility.Collapsed;

            }
            else
            {
                listEquipment.Visibility = Visibility.Collapsed;
                tbEmpty.Visibility = Visibility.Visible;
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на главную страницу");
            FrameClass.frmMain.Navigate(new MenuPage(loginedTable));
        }

        private void listEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderTable order = listEquipment.SelectedItem as OrderTable;
            FrameClass.frmMenu.Navigate(new IssueEquipmentPrint(order.ID));
        }
    }
}
