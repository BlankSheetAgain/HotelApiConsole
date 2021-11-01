using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API
{
    [Serializable]
    class Guest
    {
        public Guid ID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
       public string Middlename { get; set; }
        public string Passport { get; set; }
        public DateTime Birth { get; set; }
    }
}
