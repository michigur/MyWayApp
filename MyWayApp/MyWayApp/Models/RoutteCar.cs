using System;
using System.Collections.Generic;


namespace MyWayApp.Models
{
    public partial class RoutteCar
    {
        public int RouteCarId { get; set; }
        public int? CarId { get; set; }
        public int? ClientId { get; set; }
        public DateTime RouteDeputureTime { get; set; }
        public DateTime RouteArrivalTime { get; set; }
        public int? CarRoutteTypeId { get; set; }

        public virtual Car Car { get; set; }
        public virtual CarRoutteType CarRoutteType { get; set; }
        public virtual Client Client { get; set; }
    }
}
