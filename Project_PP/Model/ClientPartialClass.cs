using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PP.Model
{
    public partial class ClientTable
    {
        /// <summary>
        /// Полное ФИО клиента
        /// </summary>
        public string Fio
        {
            get => SurnameClient + " " + NameClient + " " + PatronymicClient;
        }

        /// <summary>
        /// Короткое ФИО клиента
        /// </summary>
        public string FioShort
        {
            get => SurnameClient + " " + NameClient[0] + ". " + PatronymicClient[0] + ".";
        }
    }
}
