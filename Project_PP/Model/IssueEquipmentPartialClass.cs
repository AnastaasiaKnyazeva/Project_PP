using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PP.Model
{
    public partial class IssueEquipment
    {
        /// <summary>
        /// Работы записанные в одну строку
        /// </summary>
        public string Works
        {
            get
            {
                List<CostOfWork> works = CostOfWork.ToList();
                string str = "";
                foreach (CostOfWork work in works)
                {
                    str += work.Name + " - " + work.Cost + " руб.\n";
                }
                return str;
            }
        }
    }
}
