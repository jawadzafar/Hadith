using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hadith.Models;
using System.Web.Mvc;

namespace Hadith.Models
{
    
    public class NarratorsHadithViewModel
    {
        public List<FullHadith> Hadiths;
        public SelectList NarratorsList { get; set; }
    }
}