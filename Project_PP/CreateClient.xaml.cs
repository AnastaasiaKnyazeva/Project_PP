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
using System.Windows.Shapes;

namespace Project_PP
{
    /// <summary>
    /// Логика взаимодействия для CreateClient.xaml
    /// </summary>
    public partial class CreateClient : Window
    {
        List<ClientTable> clientTable;
        public CreateClient(List<ClientTable> client)
        {
            InitializeComponent();
            clientTable = client;
            List<ClientTable> clients = DataBaseClass.connect.ClientTable.ToList();
            listUsers.ItemsSource = clients;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<ClientTable> clients = DataBaseClass.connect.ClientTable.ToList();
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                clients = clients.Where(x => x.Fio.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }
            if (clients.Count > 0)
            {
                listUsers.ItemsSource = clients;
                tbEmpty.Visibility = Visibility.Collapsed;
                listUsers.Visibility = Visibility.Visible;
            }
            else
            {
                listUsers.ItemsSource = null;
                tbEmpty.Visibility = Visibility.Visible;
                listUsers.Visibility = Visibility.Collapsed;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (listUsers.SelectedItem != null)
            {
                clientTable.Add(listUsers.SelectedItem as ClientTable);
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите клиента из списка или добавьте!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(CheckFieldsClass.CheckClient(tbSurname.Text, tbName.Text, tbPatronymic.Text,tbAdress.Text, tbPhone.Text))
            {
                try
                {
                    ClientTable client = new ClientTable()
                    {
                        SurnameClient = tbSurname.Text,
                        NameClient = tbName.Text,
                        PatronymicClient = tbPatronymic.Text,
                        Adress = tbAdress.Text,
                        Phone = tbPhone.Text
                    };
                    DataBaseClass.connect.ClientTable.Add(client);
                    DataBaseClass.connect.SaveChanges();
                    MessageBox.Show("Клиент успешно добавлен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    clientTable.Add(client);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DebugClass.WriteDebug(ex.Message);
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
