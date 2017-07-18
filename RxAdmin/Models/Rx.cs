using System;
using System.Collections.Generic;

namespace RxAdmin.Models
{
    public class Rx
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public bool Email { get; set; }
        public DateTime FillDate { get; set; }
        public DateTime RefillDate { get; set; }
        public int RxDose { get; set; }
        public string RxName { get; set; }
        public bool Text { get; set; }


        public Patient Patient { get; set; }


    }
}
