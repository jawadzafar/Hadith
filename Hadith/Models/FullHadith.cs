//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hadith.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FullHadith
    {
        public int HadithID { get; set; }
        public string HadithWithArab { get; set; }
        public string HaddithWithoutArab { get; set; }
        public string NarratorsWithArab { get; set; }
        public string NarratorsWithoutArab { get; set; }
        public Nullable<int> HID { get; set; }
        public Nullable<int> CID { get; set; }
        public Nullable<int> BID { get; set; }
        public string NarratorID { get; set; }
        public string InHID { get; set; }
        public byte[] upsize_ts { get; set; }
    }
}
