using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ConfirmOrderViewModel
    {
        public decimal OverallPrice { get; set; }
        public string PhoneNumber { get; set; }
        public int PostNumber { get; set; }
    }
}
