using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API
{
    class Checkin
    {
        public Guid ID {get; set;}
        public Guid RoomID { get; set; }
        public Guid GuestID { get; set; }
        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set; }
        public bool IsReservation { get; set; }
    }
}
