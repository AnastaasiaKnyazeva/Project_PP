//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_PP.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class IssueEquipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IssueEquipment()
        {
            this.CostOfWork = new HashSet<CostOfWork>();
        }
    
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Problem { get; set; }
        public int SumCost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CostOfWork> CostOfWork { get; set; }
        public virtual OrderTable OrderTable { get; set; }
    }
}
