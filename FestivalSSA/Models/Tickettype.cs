using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalSSA.Models
{
    public class Tickettype
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Available { get; set; }
    }
}