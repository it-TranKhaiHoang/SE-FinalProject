using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_FinalProject.Classes
{
    internal class Received
    {
        public String NoteID { get; set; }
        public String ReceivedReason { get; set; }
        public String AccountantID { get; set; }
        public DateTime ReceivedDate { get; set; }
        public float TotalAmount { get; set; }
    }
}
