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
    /// Логика взаимодействия для IssueEquipmentPrint.xaml
    /// </summary>
    public partial class IssueEquipmentPrint : Page
    {
        public IssueEquipmentPrint(int id)
        {
            InitializeComponent();
            OrderTable order = DataBaseClass.connect.OrderTable.FirstOrDefault(x => x.ID == id);
            tbNumber.Text += $"{id} от {order.IssueEquipment.Date.ToString("dd.MM.yyyy HH:mm")}";
            tbName.Text = order.EquipmentTable.NameEquipment;
            tbSerialNumber.Text = order.EquipmentTable.SerialNumber;
            tbDamage.Text = order.Damage;
            tbProblem.Text = order.IssueEquipment.Problem;
            tbWork.Text = order.IssueEquipment.Works;
            tbFio.Text = order.ClientTable.FioShort;
            tbAdress.Text = order.ClientTable.Adress;
            tbPhone.Text = order.ClientTable.Phone;
            tbDate.Text = order.IssueEquipment.Date.ToString("dd.MM.yyyy");

            tbNumber1.Text += $"{id} от {order.IssueEquipment.Date.ToString("dd.MM.yyyy HH:mm")}";
            tbName1.Text = order.EquipmentTable.NameEquipment;
            tbSerialNumber1.Text = order.EquipmentTable.SerialNumber;
            tbDamage1.Text = order.Damage;
            tbProblem1.Text = order.AcceptEquipment.Description;
            tbWork1.Text = order.IssueEquipment.Works;
            tbFio1.Text = order.ClientTable.FioShort;
            tbAdress1.Text = order.ClientTable.Adress;
            tbPhone1.Text = order.ClientTable.Phone;
            tbDate1.Text = order.IssueEquipment.Date.ToString("dd.MM.yyyy");

        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(grdReport, "Отчет");
            }
        }
    }
}
