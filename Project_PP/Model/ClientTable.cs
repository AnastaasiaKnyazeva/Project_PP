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
    
    public partial class ClientTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientTable()
        {
            this.OrderTable = new HashSet<OrderTable>();
        }
    
        public int ID { get; set; }
        public string SurnameClient { get; set; }
        public string NameClient { get; set; }
        public string PatronymicClient { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTable> OrderTable { get; set; }
    }
}