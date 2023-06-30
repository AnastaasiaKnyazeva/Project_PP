using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Project_PP.Model
{
    public partial class OrderSpareParts
    {
        /// <summary>
        /// Цветовое оформление статуса заказа ЗИП
        /// </summary>
        public SolidColorBrush BackgroundStatus
        {
            get
            {
                switch (IdStatus)
                {
                    case 1:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#E28686");
                    case 2:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#D3D191");
                    case 3:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#82DB7A");
                    case 4:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#99BDDE");
                    default:
                        return Brushes.White;
                }
            }
        }

        /// <summary>
        /// Цветовое оформление текста статуса заказа ЗИП
        /// </summary>
        public SolidColorBrush ForegroundStatus
        {
            get
            {
                switch (IdStatus)
                {
                    case 1:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#741717");
                    case 2:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#6D6B2B");
                    case 3:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#267F1F");
                    case 4:
                        return (SolidColorBrush)new BrushConverter().ConvertFrom("#426788");
                    default:
                        return Brushes.White;
                }
            }
        }

        /// <summary>
        /// ID роли пользователя
        /// </summary>
        int role;

        /// <summary>
        /// Присвание роли
        /// </summary>
        public int Role
        {
            set => role = value;
        }

        /// <summary>
        /// Видимость кнопки изменения статуса заказа ЗИП
        /// </summary>
        public Visibility VisibleUpdate
        {
            get
            {
                if (role == 1)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }

        /// <summary>
        /// Вывод наименования статуса заказа ЗИП
        /// </summary>
        public string StatusName
        {
            get => StatusTable.Name.ToString();
        }
    }
}
