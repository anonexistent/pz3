//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pz3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Characteristics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Characteristics()
        {
            this.Vehicles = new HashSet<Vehicles>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Brand { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
    
        public virtual Brands Brands { get; set; }
        public virtual Categories Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
