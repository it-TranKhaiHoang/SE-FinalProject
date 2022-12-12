using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_FinalProject.Classes
{
    public class DeliveryDetail
    {
        public String NoteID { get; set; }
        public String GoodsID { get; set; }
        [Display(Name ="Product Name")]
        public String Unit { get; set; }
        public decimal Price { get; set; } 
        public int Quantity { get; set; }
        public decimal Into_money {
            get
            {
                return Price * Quantity;
            }
        }
    }
}
