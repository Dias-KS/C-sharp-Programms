//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PastryShopApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderRegister
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderRegister()
        {
            this.ClientAndOrder = new HashSet<ClientAndOrder>();
        }
    
        public int ID { get; set; }
        public string NameProduct { get; set; }
        public string Count { get; set; }
        public string Price { get; set; }
        public byte[] Picture { get; set; }
        public int IDTypeProduct { get; set; }
        public int IDStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientAndOrder> ClientAndOrder { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
    }
}