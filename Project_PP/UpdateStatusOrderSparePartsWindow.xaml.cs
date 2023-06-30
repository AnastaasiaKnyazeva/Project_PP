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
    /// Логика взаимодействия для UpdateStatusOrderSparePartsWindow.xaml
    /// </summary>
    public partial class UpdateStatusOrderSparePartsWindow : Window
    {
        OrderSpareParts order;
        public UpdateStatusOrderSparePartsWindow(OrderSpareParts orderSpare)
        {
            InitializeComponent();
            order = orderSpare;
            cbStatus.ItemsSource = DataBaseClass.connect.StatusTable.ToList();
            cbStatus.SelectedValuePath = "ID";
            cbStatus.DisplayMemberPath = "Name";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(cbStatus.SelectedIndex != -1)
            {
                try
                {
                    order.IdStatus = (int)cbStatus.SelectedValue;
                    DataBaseClass.connect.SaveChanges();
                    MessageBox.Show("Статус изменен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception ex) 
                {
                    DebugClass.WriteDebug(ex.Message);
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите статус!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
