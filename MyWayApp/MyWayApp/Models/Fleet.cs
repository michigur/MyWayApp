using System;
using System.Collections.Generic;



namespace MyWayApp.Models
{
    public partial class Fleet
    {
        public Fleet()
        {
            Cars = new HashSet<Car>();
        }

        public int FleetId { get; set; }
        public int? ManagerId { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
