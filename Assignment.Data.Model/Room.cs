using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentApp.Data.Model
{
    public class Room
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public RoomType RoomType { get; set; }
    }
}
