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
    /// Логика взаимодействия для AcceptEquipmentPage.xaml
    /// </summary>
    public partial class AcceptEquipmentPage : Page
    {
        EquipmentTable equipment;
        ClientTable client;

        public AcceptEquipmentPage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(CheckFieldsClass.CheckAcceptEquipment(equipment, tbDamage.Text, tbPicking.Text, client))
            {
                try
                {
                    string str;
                    if (string.IsNullOrWhiteSpace(tbDescription.Text))
                    {
                        str = null;
                    }
                    else
                    {
                        str = tbDescription.Text;
                    }
                    OrderTable order = new OrderTable()
                    {
                        ClientTable = client,
                        IdClient = client.ID,
                        DateOrder = DateTime.Now,
                        TypeOrder = 1,
                        Damage = tbDamage.Text,
                        EquipmentTable = equipment,
                        IdEquipment = equipment.ID,
                    };
                    Model.AcceptEquipment accept = new Model.AcceptEquipment()
                    {
                        ID = equipment.ID,
                        Date = DateTime.Now,
                        Picking = tbPicking.Text,
                        Description = str,
                        OrderTable = order
                    };
                    DataBaseClass.connect.OrderTable.Add(order);
                    DataBaseClass.connect.AcceptEquipment.Add(accept);
                    DataBaseClass.connect.SaveChanges();
                    MessageBox.Show("Прием оборудования успешно завершен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameClass.frmMenu.Navigate(new AcceptEquipmentPrint(order.ID));
                }
                catch (Exception ex) 
                {
                    DebugClass.WriteDebug(ex.Message);
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void grdEquipment_MouseDown(object sender, MouseButtonEventArgs e)
        {
            List<EquipmentTable> equipments = new List<EquipmentTable>();
            CreateEquipment createEquipment = new CreateEquipment(equipments);
            createEquipment.ShowDialog();
            if (equipments.Count > 0)
            {
                equipment = equipments[0];
                if (equipment.ID != 0)
                {
                    tbEquipment.Text = equipment.NameEquipment + " " + equipment.Model + "\n" + equipment.SerialNumber;
                }
            }
        }

        private void grdClient_MouseDown(object sender, MouseButtonEventArgs e)
        {
            List<ClientTable> clients = new List<ClientTable>();
            CreateClient createClient = new CreateClient(clients);
            createClient.ShowDialog();
            if (clients.Count > 0)
            {
                client = clients[0];
                if (clients[0].ID != 0)
                {
                    tbClient.Text = client.Fio;
                }
            }
        }
    }
}
