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
    
    public partial class Vehicles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicles()
        {
            this.Reports = new HashSet<Reports>();
        }
    
        public string VIN { get; set; }
        public Nullable<int> Driver { get; set; }
        public Nullable<int> Characteristic { get; set; }
        public Nullable<int> Parking_number { get; set; }
    
        public virtual Characteristics Characteristics { get; set; }
        public virtual Drivers Drivers { get; set; }
        public virtual Parking Parking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reports> Reports { get; set; }
    }
}
