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
using Project_PP.Classes;

namespace Project_PP.Pages
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccountPage.xaml
    /// </summary>
    public partial class PersonalAccountPage : Page
    {
        LoginedTable loginedTable, user;
        int index;
        public PersonalAccountPage(LoginedTable logined, LoginedTable user, int index)
        {
            InitializeComponent();
            loginedTable = logined;
            this.user = user;
            this.index = index;
            tbSurname.Text = loginedTable.UserTable.SurnameUser;
            tbName.Text = loginedTable.UserTable.NameUser;
            tbLogin.Text = loginedTable.LoginUser;
            cbRole.ItemsSource = DataBaseClass.connect.RoleTable.ToList();
            cbRole.SelectedValuePath = "ID";
            cbRole.DisplayMemberPath = "NameRole";
            cbRole.SelectedValue = loginedTable.IdRole;
            if(index != 0)
            {
                cbRole.IsEnabled = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFieldsClass.CheckUpdateUser(tbSurname.Text, tbName.Text, tbLogin.Text))
            {
                if (CheckFieldsClass.CheckLogin(tbLogin.Text, loginedTable))
                {
                    try
                    {
                        loginedTable.UserTable.SurnameUser = tbSurname.Text;//записываем в объект фамилию пользователя
                        loginedTable.UserTable.NameUser = tbName.Text;//записываем в объект имя пользователя
                        loginedTable.LoginUser = tbLogin.Text;//записываем в поле объект пользователя
                        loginedTable.IdRole = (int)cbRole.SelectedValue;
                        DataBaseClass.connect.SaveChanges();//сохраняем изменения в базе данных
                        MessageBox.Show("Успешное изменение данных!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        if(loginedTable == user)
                        {
                            DebugClass.WriteDebug("Переход на страницу главного меню");
                            FrameClass.frmMain.Navigate(new MenuPage(user));//переход на страницу меню
                        }
                        else
                        {
                            DebugClass.WriteDebug("Переход на страницу главного меню");
                            FrameClass.frmMenu.Navigate(new UsersPage(user));//переход на страницу меню
                        }
                    }
                    catch (Exception ex)
                    {
                        DebugClass.WriteDebug(ex.Message);
                        MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (index != 0)
            {
                DebugClass.WriteDebug("Переход на страницу пользователей");
                FrameClass.frmMenu.Navigate(new UsersPage(user));
            }
            else
            {
                DebugClass.WriteDebug("Переход в главное меню");
                FrameClass.frmMain.Navigate(new MenuPage(user));
            }
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу смены пароля");
            if (index != 0)
            {
                FrameClass.frmMenu.Navigate(new ChangePasswordPage(loginedTable, user, index));
            }
            else
            {
                FrameClass.frmMenu.Navigate(new ChangePasswordPage(loginedTable, user, index));
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show($"Вы точно хотите удалить пользователя {loginedTable.UserTable.SurnameUser} {loginedTable.UserTable.NameUser}?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBox == MessageBoxResult.Yes)
            {
                DataBaseClass.connect.LoginedTable.Remove(loginedTable);
                DataBaseClass.connect.SaveChanges();
                MessageBox.Show("Пользователь удален!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                if (index == 0 || loginedTable == user)
                {
                    FrameClass.frmMain.Navigate(new AuthorizationPage());
                }
                else
                {
                    FrameClass.frmMenu.Navigate(new UsersPage(user));
                }
            }
        }
    }
}
