//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChilliSoftMeetingManagement.Repository.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meeting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meeting()
        {
            this.MeetingTypeItems = new HashSet<MeetingTypeItem>();
        }
    
        public System.Guid MeetingId { get; set; }
        public System.Guid MeetingTypeId { get; set; }
        public System.DateTime MeetingDate { get; set; }
        public string MeetingName { get; set; }
    
        public virtual MeetingType MeetingType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeetingTypeItem> MeetingTypeItems { get; set; }
    }
}
