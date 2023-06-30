using Project_PP.Classes;
using Project_PP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для IssueEquipmentPage.xaml
    /// </summary>
    public partial class IssueEquipmentPage : Page
    {
        List<CostOfWork> list = new List<CostOfWork>();
        OrderTable order;

        public IssueEquipmentPage()
        {
            InitializeComponent();
            list.Add(new CostOfWork());
            listWork.ItemsSource = list;
        }
        private void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            list.Add(new CostOfWork());
            listWork.ItemsSource = null;
            listWork.ItemsSource = list;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(CheckFieldsClass.CheckIssueEquipment(order, tbProblem.Text, list))
            {
                try
                {
                    order.TypeOrder = 2;
                    Model.IssueEquipment issue = new Model.IssueEquipment()
                    {
                        Date = DateTime.Now,
                        ID = order.ID,
                        OrderTable = order,
                        Problem = tbProblem.Text
                    };
                    int sum = 0;
                    foreach(CostOfWork work in list)
                    {
                        sum += work.Cost;
                        work.IdIssueEquipment = issue.ID;
                        DataBaseClass.connect.CostOfWork.Add(work);
                    }
                    issue.SumCost = sum;
                    DataBaseClass.connect.IssueEquipment.Add(issue);
                    DataBaseClass.connect.SaveChanges();
                    MessageBox.Show("Оборудование успешно выдано!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameClass.frmMenu.Navigate(new IssueEquipmentPrint(order.ID));
                }
                catch (Exception ex)
                {
                    DebugClass.WriteDebug(ex.Message);
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            if(list.Count > 0)
            {
                list.Remove(list[list.Count-1]);
                listWork.ItemsSource = null;
                listWork.ItemsSource = list;
            }
        }
        private void grdOrder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            List<OrderTable> list = new List<OrderTable>();
            SearchOrderWindow search = new SearchOrderWindow(list);
            search.ShowDialog();
            if (list.Count > 0)
            {
                order = list[0];
                tbOrder.Text = order.OrderString;
            }
        }

        private void tbCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (Regex.IsMatch(tb.Text, "^\\d+$"))
            {
                btnSave.Visibility = Visibility.Visible;
            }
            else
            {
                btnSave.Visibility = Visibility.Collapsed;
            }
        }
    }
}
