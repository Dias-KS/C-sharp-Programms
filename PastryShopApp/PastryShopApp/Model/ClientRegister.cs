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
    
    public partial class ClientRegister
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientRegister()
        {
            this.ClientAndOrder = new HashSet<ClientAndOrder>();
        }
    
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateRegistration { get; set; }
        public System.DateTime DateAccept { get; set; }
        public Nullable<System.DateTime> DateReadness { get; set; }
        public int IDClientMoreInfo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientAndOrder> ClientAndOrder { get; set; }
        public virtual ClientMoreInfo ClientMoreInfo { get; set; }
    }
}
