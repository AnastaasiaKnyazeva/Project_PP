using Project_PP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Project_PP.Classes
{
    public class CheckFieldsClass
    {
        /// <summary>
        /// Проверка полей при авторизации
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckAuthorization(string login, string password)
        {
            if (!string.IsNullOrWhiteSpace(login))
            {
                if (!string.IsNullOrWhiteSpace(password))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Заполните поле Пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Заполните поле Логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка наличия логина в базе данных
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckLogin(string login, LoginedTable loginedTable)
        {
            LoginedTable logined;
            //если мы задали пустой объект то просто ищем такой логин в базе, а если задали не пустой объект то ищем совпадаения с другими пользователями
            if (loginedTable == null)
            {
                logined = DataBaseClass.connect.LoginedTable.FirstOrDefault(x => x.LoginUser == login);//по логину ищем объект в базе данных
            }
            else
            {
                logined = DataBaseClass.connect.LoginedTable.FirstOrDefault(x => x.LoginUser == login && x.ID != loginedTable.ID);//по логину ищем объект в базе данных
            }
            if (logined == null)//если объект нулевой то возвращаем true
            {
                return true;
            }
            else
            {
                MessageBox.Show("Такой логин уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка полей для регистрации пользователя
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckUser(string surname, string name, string login, string password)
        {
            if (!string.IsNullOrWhiteSpace(surname))
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (!string.IsNullOrWhiteSpace(login))
                    {
                        if (!string.IsNullOrWhiteSpace(password))
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Заполните поле Пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните поле Логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поле Имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Заполните поле Фамилия!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка повтора пароля
        /// </summary>
        /// <param name="password">Новый пароль</param>
        /// <param name="repeat">Старый пароль</param>
        /// <returns>Пароли совпадают (true), пароли не совпадают (false)</returns>
        public static bool CheckRepeatePassword(string password, string repeat)
        {
            if (password == repeat)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка полей для изменения данных пользователя
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="login">Логин</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckUpdateUser(string surname, string name, string login)
        {
            if (!string.IsNullOrWhiteSpace(surname))
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (!string.IsNullOrWhiteSpace(login))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Заполните поле Логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поле Имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Заполните поле Фамилия!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка полей для смены пароля
        /// </summary>
        /// <param name="oldPassword">Старый пароль</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <param name="repeatePassword">Повтор пароля</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckUpdatePassword(string oldPassword, string newPassword, string repeatePassword)
        {
            if (!string.IsNullOrWhiteSpace(oldPassword))
            {
                if (!string.IsNullOrWhiteSpace(newPassword))
                {
                    if (!string.IsNullOrWhiteSpace(repeatePassword))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Повторите новый пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Введите новый пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введите старый пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка полей для смены пароля
        /// </summary>
        /// <param name="newPassword">Новый пароль</param>
        /// <param name="repeatePassword">Повтор пароля</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckAdminUpdatePassword(string newPassword, string repeatePassword)
        {
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                if (!string.IsNullOrWhiteSpace(repeatePassword))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Повторите новый пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введите новый пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    

        /// <summary>
        /// Проверка пароля в базе данных
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <param name="logined">Объект пользователя</param>
        /// <returns>Пароль совпадает (true), пароль не совпадает (false)</returns>
        public static bool CheckOldPassword(string password, LoginedTable logined)
        {
            int passw = password.GetHashCode();//шифрование введенного пароля
            if (passw == logined.PasswordUser)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Неверно введенный старый пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка полей для добавления клиента
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="adress">Адрес</param>
        /// <param name="phone">Телефон</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckClient(string surname, string name, string patronymic, string adress, string phone)
        {
            if (!string.IsNullOrWhiteSpace(surname))
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (!string.IsNullOrWhiteSpace(patronymic))
                    {
                        if (!string.IsNullOrWhiteSpace(adress))
                        {
                            if (!string.IsNullOrWhiteSpace(phone))
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Заполните поле Телефон!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Заполните поле Адрес!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните поле Отчество!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поле Имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Заполните поле Фамилия!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка полей для добавления оборудования
        /// </summary>
        /// <param name="serialNumber">Серийный номер</param>
        /// <param name="name">Наименование оборудования</param>
        /// <param name="model">Модель</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckEquipment(string serialNumber, string name, string model)
        {
            if (!string.IsNullOrWhiteSpace(serialNumber))
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (!string.IsNullOrWhiteSpace(model))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Введите модель!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Введите наименование оборудования!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введите серийный номер!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка полей для добавления заказа ЗИП
        /// </summary>
        /// <param name="order">Заказ</param>
        /// <param name="name">Наименование детали</param>
        /// <param name="link">Ссылка</param>
        /// <param name="quantity">Количество</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckSpareParts(OrderTable order, string name, string link, string quantity)
        {
            if (order != null)
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (!string.IsNullOrWhiteSpace(link))
                    {
                        if (Regex.IsMatch(quantity, "^\\d+$"))
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Введите количество корректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите ссылку на деталь!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Введите наименование детали!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка полей для добавления приема оборудования
        /// </summary>
        /// <param name="equipment">Оборудование</param>
        /// <param name="damage">Комплектация</param>
        /// <param name="picking">Механические повреждения</param>
        /// <param name="client">Клиент</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckAcceptEquipment(EquipmentTable equipment, string damage, string picking, ClientTable client)
        {
            if (equipment != null)
            {
                if (!string.IsNullOrWhiteSpace(damage))
                {
                    if (!string.IsNullOrWhiteSpace(picking))
                    {
                        if (client != null)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Выберите клиента!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите механические повреждения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Введите комплектацию оборудования!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Выберите оборудование!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка полей для выдачи оборудования
        /// </summary>
        /// <param name="order">Заказ</param>
        /// <param name="problem">Выявленные несправности</param>
        /// <param name="list">Наименование работ и стоимость</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckIssueEquipment(OrderTable order, string problem, List<CostOfWork> list)
        {
            if (order != null)
            {
                if (!string.IsNullOrWhiteSpace(problem))
                {
                    int k = 0;
                    foreach (CostOfWork work in list)
                    {
                        if (string.IsNullOrWhiteSpace(work.Name) || work.Cost == 0)
                        {
                            k++;
                        }
                    }
                    if (k == 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Введите работу и стоимость корректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Введите выявленные неисправности!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
