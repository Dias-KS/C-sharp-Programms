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
    
    public partial class SignIn
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public byte[] PictureUA { get; set; }
        public string RoleID { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
