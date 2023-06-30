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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        LoginedTable loginedTable;
        public UsersPage(LoginedTable logined)
        {
            InitializeComponent();
            loginedTable = logined;
            listUsers.ItemsSource = DataBaseClass.connect.UserTable.ToList();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу регистрации");
            FrameClass.frmMenu.Navigate(new RegistrationPage(loginedTable));
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int id = Convert.ToInt32(btn.Uid);
            LoginedTable logined = DataBaseClass.connect.LoginedTable.FirstOrDefault(x => x.ID == id);
            FrameClass.frmMenu.Navigate(new PersonalAccountPage(logined, loginedTable, 1));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на главную страницу");
            FrameClass.frmMain.Navigate(new MenuPage(loginedTable));
        }
    }
}
