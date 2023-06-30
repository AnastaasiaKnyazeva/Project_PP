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
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            if(dtStart.SelectedDate != null && dtEnd.SelectedDate != null)
            {
                if(dtStart.SelectedDate < dtEnd.SelectedDate)
                {
                    List<Model.AcceptEquipment> listAccept = DataBaseClass.connect.AcceptEquipment.Where(x => x.Date >= (DateTime)dtStart.SelectedDate && x.Date <= (DateTime)dtEnd.SelectedDate).ToList();
                    List<Model.IssueEquipment> listIssue = DataBaseClass.connect.IssueEquipment.Where(x => x.Date >= (DateTime)dtStart.SelectedDate && x.Date <= (DateTime)dtEnd.SelectedDate).ToList();
                    if (listAccept.Count != 0 && listIssue.Count != 0)
                    {
                        grid.Visibility = Visibility.Visible;
                        btnPrintPeport.Visibility = Visibility.Visible;
                        tbHeader.Text += $"c {Convert.ToDateTime(dtStart.SelectedDate).ToString("dd.MM.yyyy")} по {Convert.ToDateTime(dtEnd.SelectedDate).ToString("dd.MM.yyyy")}";
                        tbDate.Text += DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                        tbDateNow.Text += DateTime.Now.ToString("dd.MM.yyyy");
                        tbAccept.Text += listAccept.Count.ToString();
                        tbIssue.Text += listIssue.Count.ToString();
                        tbHeader1.Text += $"c {Convert.ToDateTime(dtStart.SelectedDate).ToString("dd.MM.yyyy")} по {Convert.ToDateTime(dtEnd.SelectedDate).ToString("dd.MM.yyyy")}";
                        tbDate1.Text += DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                        tbDateNow1.Text += DateTime.Now.ToString("dd.MM.yyyy");
                        tbAccept1.Text += listAccept.Count.ToString();
                        tbIssue1.Text += listIssue.Count.ToString();
                        int sum = 0;
                        foreach (Model.IssueEquipment issue in listIssue)
                        {
                            sum += issue.SumCost;
                        }
                        tbCost.Text += sum.ToString();
                        tbCost1.Text += sum.ToString();
                    }
                    else
                    {
                        MessageBox.Show("В выбранный период нет данных для отчета!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Неверный период формирования отчета!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите период формирования отчета!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPrintPeport_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(grdReport, "Отчет");
            }
        }
    }
}
