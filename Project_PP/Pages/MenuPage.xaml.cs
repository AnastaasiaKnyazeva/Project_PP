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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        LoginedTable loginedTable;
        public MenuPage(LoginedTable logined)
        {
            InitializeComponent();
            loginedTable = logined;
            FrameClass.frmMenu = frmMenu;
            tbRole.Text = loginedTable.RoleTable.NameRole;
            tbRoleHeader.Text = loginedTable.RoleTable.NameRole;
            tbName.Text = loginedTable.UserTable.SurnameUser + " " + loginedTable.UserTable.NameUser;
            switch (loginedTable.IdRole)
            {
                case 1:
                    FrameClass.frmMenu.Navigate(new MenuDirector(logined));
                    break;
                case 2:
                    FrameClass.frmMenu.Navigate(new MenuReceiver(logined));
                    btnOrder.Visibility = Visibility.Collapsed;
                    btnUsers.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    FrameClass.frmMenu.Navigate(new MenuMaster(logined));
                    btnAccept.Visibility = Visibility.Collapsed;
                    btnUsers.Visibility = Visibility.Collapsed;
                    break;
            }
            
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу пользователей");
            FrameClass.frmMenu.Navigate(new UsersPage(loginedTable));//переходим на страницу пользователей
        }

        private void imgExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Вы точно хотите выйти из программы?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBox == MessageBoxResult.Yes)
            {
                DebugClass.WriteDebug("Переход на страницу авторизации");
                FrameClass.frmMain.Navigate(new AuthorizationPage());//переходим на страницу авторизации
            }
        }

        private void btnPersonalAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу личного кабинета");
            FrameClass.frmMenu.Navigate(new PersonalAccountPage(loginedTable, loginedTable, 0));//переходим на страницу личного кабинета
        }

        private void btnAcceptEquipment_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу принятого оборудования");
            FrameClass.frmMenu.Navigate(new AcceptEquipment(loginedTable));
        }

        private void btnEquipmentInRepair_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу оборудования в ремонте");
            FrameClass.frmMenu.Navigate(new EquipmentInRepair(loginedTable));
        }

        private void btnIssueEquipment_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу выданного оборудования");
            FrameClass.frmMenu.Navigate(new IssueEquipment(loginedTable));
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу заказа ЗИП");
            FrameClass.frmMenu.Navigate(new OrderSpareParts(loginedTable));
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на главную страницу");
            FrameClass.frmMain.Navigate(new MenuPage(loginedTable));
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу приема оборудования");
            FrameClass.frmMenu.Navigate(new AcceptEquipmentPage());
        }

        private void btnIssue_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу выдачи оборудования");
            FrameClass.frmMenu.Navigate(new IssueEquipmentPage());
        }
    }
}
