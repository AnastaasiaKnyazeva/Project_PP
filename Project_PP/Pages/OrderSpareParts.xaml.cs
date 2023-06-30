using Project_PP.Classes;
using Project_PP.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для OrderSpareParts.xaml
    /// </summary>
    public partial class OrderSpareParts : Page
    {
        LoginedTable loginedTable;
        public OrderSpareParts(LoginedTable logined)
        {
            InitializeComponent();
            loginedTable = logined;
            List<Model.OrderSpareParts> list = DataBaseClass.connect.OrderSpareParts.OrderByDescending(x => x.Date).ToList();
            foreach(Model.OrderSpareParts part in list)
            {
                part.Role = logined.IdRole;
            }
            listEquipment.ItemsSource = list;       
            if(logined.IdRole == 1)
            {
                btnAdd.Visibility = Visibility.Collapsed;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на главную страницу");
            FrameClass.frmMain.Navigate(new MenuPage(loginedTable));
        }

        private void tbLink_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TextBlock tb = sender as TextBlock;
                Process.Start(tb.Uid.ToString());
            }
            catch(Exception ex)
            {
                DebugClass.WriteDebug(ex.Message);
                MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrderSparePartsWindow addOrder = new AddOrderSparePartsWindow();
            addOrder.ShowDialog();
            FrameClass.frmMenu.Navigate(new OrderSpareParts(loginedTable));
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int id = Convert.ToInt32(button.Uid);
            Model.OrderSpareParts orderSpare = DataBaseClass.connect.OrderSpareParts.FirstOrDefault(x => x.ID == id);
            UpdateStatusOrderSparePartsWindow update = new UpdateStatusOrderSparePartsWindow(orderSpare);
            update.ShowDialog();
            FrameClass.frmMenu.Navigate(new OrderSpareParts(loginedTable));
        }
    }
}
