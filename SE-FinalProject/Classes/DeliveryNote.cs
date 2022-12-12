using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_FinalProject.Classes
{
    public class DeliveryNote
    {
        public String NoteID { get; set; }
        public String AgencyID { get; set; }
        [Display(Name = "Agency Name")]   
        
        public String AccountantID { get; set; }
        public DateTime Delivery_Date { get; set; }
        public decimal Total_amount { get; set; }
    }
}
