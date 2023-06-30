using Project_PP.Classes;
using Project_PP.Model;
using Project_PP.Pages;
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
    /// Логика взаимодействия для CreateEquipment.xaml
    /// </summary>
    public partial class CreateEquipment : Window
    {
        List<EquipmentTable> equipment;
        public CreateEquipment(List<EquipmentTable> equipment)
        {
            InitializeComponent();
            this.equipment = equipment;
            List<EquipmentTable> equipments = DataBaseClass.connect.EquipmentTable.ToList();
            listEquipment.ItemsSource = equipments;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<EquipmentTable> equipments = DataBaseClass.connect.EquipmentTable.ToList();
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                equipments = equipments.Where(x => x.SerialNumber.ToLower().Contains(tbSearch.Text.ToLower()) || x.NameEquipment.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }
            if (equipments.Count > 0)
            {
                listEquipment.ItemsSource = equipments;
                tbEmpty.Visibility = Visibility.Collapsed;
                listEquipment.Visibility = Visibility.Visible;
            }
            else
            {
                listEquipment.ItemsSource = null;
                tbEmpty.Visibility = Visibility.Visible;
                listEquipment.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFieldsClass.CheckEquipment(tbSerialNumber.Text, tbName.Text, tbModel.Text))
            {
                try
                {
                    EquipmentTable equipment = new EquipmentTable()
                    {
                        SerialNumber = tbSerialNumber.Text,
                        NameEquipment = tbName.Text,
                        Model = tbModel.Text,
                    };
                    DataBaseClass.connect.EquipmentTable.Add(equipment);
                    DataBaseClass.connect.SaveChanges();
                    this.equipment.Add(equipment);
                    MessageBox.Show("Оборудование успешно добавлено!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DebugClass.WriteDebug(ex.Message);
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (listEquipment.SelectedItem != null)
            {
                equipment.Add(listEquipment.SelectedItem as EquipmentTable);
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите оборудование из списка или добавьте!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
