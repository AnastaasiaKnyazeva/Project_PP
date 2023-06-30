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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            Classes.DebugClass.WriteDebug("Переход на страницу регистрации");
            Classes.FrameClass.frmMain.Navigate(new RegistrationPage(null));
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.CheckFieldsClass.CheckAuthorization(tbLogin.Text, pswPassword.Password))
            {
                try
                {
                    int password = pswPassword.Password.GetHashCode();//шифруем строку с паролем из поля для ввода
                    LoginedTable logined = Classes.DataBaseClass.connect.LoginedTable.FirstOrDefault(x => x.LoginUser == tbLogin.Text && x.PasswordUser == password);//строка для поиска объекта в базе данных по логину и паролю
                    if (logined != null)//если объект не нулевой то авторизация успешна
                    {
                        MessageBox.Show("Успешная авторизация", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        Classes.DebugClass.WriteDebug("Переход на страницу меню");
                        Classes.FrameClass.frmMain.Navigate(new MenuPage(logined));
                    }
                    else
                    {
                        Classes.DebugClass.WriteDebug("Ошибка входа");
                        MessageBox.Show("Такого пользователя не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    Classes.DebugClass.WriteDebug(ex.Message);
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
