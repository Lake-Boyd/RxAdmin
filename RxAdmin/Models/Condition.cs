using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RxAdmin.Models
{
    public enum Status
    {
        Excellent, Good, Stable, Serious, Critical
    }

    public class Condition
    {
        public int ConditionID { get; set; }
        public int PatientID { get; set; }
        public Status? Status { get; set; }

        public Patient Patient { get; set; }

    }
}
