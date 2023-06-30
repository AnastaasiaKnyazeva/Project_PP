using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Project_PP.Model
{
    /// <summary>
    /// Заказ записанный в строку
    /// </summary>
    public partial class OrderTable
    {
        public string OrderString
        {
            get => $"Заказ №{ID} от {DateOrder.ToString("dd.MM.yyyy")}\nЗаказчик: {ClientTable.FioShort}";
        }

        /// <summary>
        /// Цветовое оформление статуса заказа
        /// </summary>
        public SolidColorBrush BackgroundStatus
        {
            get
            {
                switch (TypeOrder)
                {
                    case 1:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#99BDDE");
                    case 2:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#82DB7A");
                    case 3:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#D3D191");
                    default:
                        return Brushes.White;
                }
            }
        }

        /// <summary>
        /// Цветовое оформление текста статуса заказа
        /// </summary>
        public SolidColorBrush ForegroundStatus
        {
            get
            {
                switch (TypeOrder)
                {
                    case 1:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#426788");
                    case 2:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#267F1F");
                    case 3:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#6D6B2B");
                    default:
                        return Brushes.White;
                }
            }
        }

        /// <summary>
        /// Вывод наименования статуса заказа
        /// </summary>
        public string StatusName
        {
            get => TypeOrderTable.Name.ToString();
        }

    }
}
