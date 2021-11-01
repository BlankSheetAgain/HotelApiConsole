using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API
{
 [Serializable]
    class Room
    {
       public Guid ID { get; set; }
       public int Number { get; set; }
        public Guid CategoryID { get; set; }
    }
}
