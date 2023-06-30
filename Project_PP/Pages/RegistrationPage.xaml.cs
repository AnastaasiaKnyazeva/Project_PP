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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_PP.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        LoginedTable loginedTable;
        public RegistrationPage(LoginedTable logined)
        {
            InitializeComponent();
            loginedTable = logined;
            cbRole.ItemsSource = DataBaseClass.connect.RoleTable.ToList();
            cbRole.SelectedValuePath = "ID";
            cbRole.DisplayMemberPath = "NameRole";
            if (logined != null)
            {
                tbOr.Visibility = Visibility.Collapsed;
                btnAuthorization.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFieldsClass.CheckUser(tbSurname.Text, tbName.Text, tbLogin.Text, pswPassword.Password))
            {
                if (CheckFieldsClass.CheckLogin(tbLogin.Text, null))
                {
                    if ((loginedTable != null && cbRole.SelectedIndex != -1) || loginedTable == null)
                    {
                        try //обработка исключения
                        {
                            int role = (int)cbRole.SelectedValue;
                            LoginedTable logined = new LoginedTable()//создаем новый объект класса для входа
                            {
                                LoginUser = tbLogin.Text,
                                IdRole = role,
                                PasswordUser = pswPassword.Password.GetHashCode()//пароль берется из поля для ввода, а метод шифрует его
                            };
                            UserTable user = new UserTable()//создаем новый объект класса пользователя
                            {
                                ID = logined.ID,
                                SurnameUser = tbSurname.Text,
                                NameUser = tbName.Text
                            };
                            DataBaseClass.connect.LoginedTable.Add(logined);//добавляем новый объект в базу данных
                            DataBaseClass.connect.UserTable.Add(user);//добавляем новый объект в базу данных
                            DataBaseClass.connect.SaveChanges();//сохраняем изменения в базе данных
                            MessageBox.Show("Пользователь успешно зарегистрирован!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            if (loginedTable == null)
                            {
                                DebugClass.WriteDebug("Успешная регистрация\nПереход на страницу авторизации");
                                FrameClass.frmMain.Navigate(new AuthorizationPage());//переходим на страницу авторизации
                            }
                            else
                            {
                                DebugClass.WriteDebug("Успешная регистрация\nПереход на страницу пользователей");
                                FrameClass.frmMenu.Navigate(new UsersPage(loginedTable));//переходим на страницу пользователей
                            }
                        }
                        catch (Exception ex)
                        {
                            DebugClass.WriteDebug(ex.Message);
                            MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите роль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу авторизации");
            FrameClass.frmMain.Navigate(new AuthorizationPage());//переходим на страницу авторизации
        }
    }
}
