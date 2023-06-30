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
    /// Логика взаимодействия для AcceptEquipment.xaml
    /// </summary>
    public partial class AcceptEquipment : Page
    {
        LoginedTable loginedTable;
        public AcceptEquipment(LoginedTable logined)
        {
            InitializeComponent();
            loginedTable = logined;
            FillList();
        }

        /// <summary>
        /// Заполнение списка
        /// </summary>
        void FillList()
        {
            List<OrderTable> list = DataBaseClass.connect.OrderTable.Where(x => x.TypeOrder == 1).OrderByDescending(x => x.AcceptEquipment.Date).ToList();
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

        private void btnInRepair_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.Uid);
            try
            {
                OrderTable order = DataBaseClass.connect.OrderTable.FirstOrDefault(x => x.ID == id);
                order.TypeOrder = 3;
                Model.EquipmentInRepair equipment = new Model.EquipmentInRepair()
                {
                    ID = order.ID,
                    Date = DateTime.Now,
                    OrderTable = order
                };
                DataBaseClass.connect.EquipmentInRepair.Add(equipment);
                DataBaseClass.connect.SaveChanges();
                MessageBox.Show("Оборудование в ремонте!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                listEquipment.ItemsSource = null;
                FillList();
            }
            catch (Exception ex)
            {
                DebugClass.WriteDebug(ex.Message);
                MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void listEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderTable order = listEquipment.SelectedItem as OrderTable;
            FrameClass.frmMenu.Navigate(new AcceptEquipmentPrint(order.ID));
        }
    }
}
