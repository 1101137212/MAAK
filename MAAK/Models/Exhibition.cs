//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MAAK.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exhibition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exhibition()
        {
            this.ExhibitionRecord = new HashSet<ExhibitionRecord>();
        }
    
        public int Exhibition_ID { get; set; }
        public string Exhibition_Title { get; set; }
        public Nullable<System.DateTime> Exhibition_Startdate { get; set; }
        public Nullable<System.DateTime> Exhibition_Enddate { get; set; }
        public Nullable<System.TimeSpan> Exhibition_Starttime { get; set; }
        public Nullable<System.TimeSpan> Exhibition_Endtime { get; set; }
        public string Exhibition_Place { get; set; }
        public string Exhibition_Detail { get; set; }
        public string Exhibition_Picture { get; set; }
        public string Exhibition_Otherpeople { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExhibitionRecord> ExhibitionRecord { get; set; }
    }
}
