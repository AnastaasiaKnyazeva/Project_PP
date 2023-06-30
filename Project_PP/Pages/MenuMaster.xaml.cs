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
    /// Логика взаимодействия для MenuMaster.xaml
    /// </summary>
    public partial class MenuMaster : Page
    {
        LoginedTable loginedTable;
        public MenuMaster(LoginedTable logined)
        {
            InitializeComponent();
            loginedTable = logined;
        }

        private void btnAcceptEquipment_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу принятого оборудования");
            FrameClass.frmMenu.Navigate(new AcceptEquipment(loginedTable));
        }

        private void btnOrderSpareParts_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу заказа ЗИП");
            FrameClass.frmMenu.Navigate(new OrderSpareParts(loginedTable));
        }

        private void btnEquipmentInRepair_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу оборудования в ремонте");
            FrameClass.frmMenu.Navigate(new EquipmentInRepair(loginedTable));
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу формирования отчета");
            FrameClass.frmMenu.Navigate(new ReportPage());
        }

        private void btnIssue_Click(object sender, RoutedEventArgs e)
        {
            DebugClass.WriteDebug("Переход на страницу выдачи оборудования");
            FrameClass.frmMenu.Navigate(new IssueEquipmentPage());
        }
    }
}
