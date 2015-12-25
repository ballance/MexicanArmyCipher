using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MexicanArmyCipherBreaker.Library
{
    public class CryptoWheelSystem<T>
    {
        public CryptoWheelSystem()
        {
            _wheels = new List<CryptoWheel<T>>();
        }
        private readonly List<CryptoWheel<T>> _wheels;
        public int Count => _wheels.Count;

        public int AddWheel(CryptoWheel<T> wheel)
        {
            var addedWheelId = 0;
            if (_wheels.Any())
            {
                addedWheelId = _wheels.Max(w => w.Id) + 1;
            }
            _wheels.Add(wheel);
            return addedWheelId;
        }

        public void SetWheelPositionById(CryptoWheel<T> weel, T setPosition)
        {
            
        }
    }
}
