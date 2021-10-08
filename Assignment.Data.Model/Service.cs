using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentApp.Data.Model
{
    public class Service
    {
        public int Id { get; set; }
        public string SDESC { get; set; }
        public decimal Amount { get; set; }
        public DateTime ServiceDate { get; set; }
        public Room Room { get; set; }
    }
}
