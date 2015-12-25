using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MexicanArmyCipherBreaker.Library
{
    public class CryptoWheel<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public T topPosition { get; set; }

        public virtual List<T> WheelMarks { get; set; } 
    }
}
