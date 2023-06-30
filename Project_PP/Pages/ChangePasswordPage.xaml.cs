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
    /// Логика взаимодействия для ChangePasswordPage.xaml
    /// </summary>
    public partial class ChangePasswordPage : Page
    {
        LoginedTable loginedTable, user;
        int index;
        public ChangePasswordPage(LoginedTable logined, LoginedTable user, int index)
        {
            InitializeComponent();
            loginedTable = logined;
            this.index = index;
            this.user = user;
            if (index != 0)
            {
                tbOldPassword.Visibility = Visibility.Collapsed;
                oldPassword.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if ((index == 0 && CheckFieldsClass.CheckUpdatePassword(oldPassword.Password, pswPassword.Password, pswRepeate.Password))||(index != 0 && CheckFieldsClass.CheckAdminUpdatePassword(pswPassword.Password, pswRepeate.Password)))
            {
                if ((index == 0 && CheckFieldsClass.CheckOldPassword(oldPassword.Password, loginedTable)||(index != 0)))
                {
                    if (CheckFieldsClass.CheckRepeatePassword(pswPassword.Password, pswRepeate.Password))
                    {
                        try
                        {
                            int password = pswPassword.Password.GetHashCode();//шифрование пароля
                            loginedTable.PasswordUser = password;//запись нового пароля
                            DataBaseClass.connect.SaveChanges();//сохранение изменений
                            if (index == 0 || loginedTable == user)
                            {
                                MessageBox.Show("Успешная смена пароля. Войдите еще раз", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                                DebugClass.WriteDebug("Переход на страницу авторизации");
                                FrameClass.frmMain.Navigate(new AuthorizationPage());//переход на страницу авторизации
                            }
                            else
                            {
                                MessageBox.Show("Успешная смена пароля", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                                DebugClass.WriteDebug("Переход на страницу пользователей");
                                FrameClass.frmMenu.Navigate(new UsersPage(user));//переход на страницу пользователей
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
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу личного кабинета");
            FrameClass.frmMenu.Navigate(new PersonalAccountPage(loginedTable, user, index));
        }
    }
}
