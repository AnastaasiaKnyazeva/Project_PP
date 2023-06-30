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
    /// Логика взаимодействия для AddOrderSparePartsWindow.xaml
    /// </summary>
    public partial class AddOrderSparePartsWindow : Window
    {
        OrderTable order;
        public AddOrderSparePartsWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(CheckFieldsClass.CheckSpareParts(order, tbName.Text, tbLink.Text, tbQuantity.Text))
            {
                try
                {
                    string str;
                    if (string.IsNullOrEmpty(tbDescription.Text))
                    {
                        str = null;
                    }
                    else
                    {
                        str = tbDescription.Text;
                    }
                    OrderSpareParts spareParts = new OrderSpareParts()
                    {
                        IdOrder = order.ID,
                        Name = tbName.Text,
                        OrderTable = order,
                        Link = tbLink.Text,
                        Description = str,
                        IdStatus = 1,
                        Date = DateTime.Now,
                        Quantity = Convert.ToInt32(tbQuantity.Text)
                    };
                    DataBaseClass.connect.OrderSpareParts.Add(spareParts);
                    DataBaseClass.connect.SaveChanges();
                    MessageBox.Show("Заказ успешно создан!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DebugClass.WriteDebug(ex.Message);
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
    }
}
