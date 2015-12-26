using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MexicanArmyCipherBreaker.Library
{
    public class CryptoWheel<T>
    {
        public CryptoWheel(int size)
        {
            _size = size;
            WheelArrayPositions = new T[size];
        }
        public int Id { get; set; }
        public string Name { get; set; }
        
        private int _size;

        public T[] WheelArrayPositions { get; set; } 
        
        public virtual Wheelmark<T>[] WheelMarks { get; set; }
        private T[] wheelArrayPositionsPrevious { get; set; }

        public void SetTopPosition(T setPosition)
        {
            wheelArrayPositionsPrevious = WheelArrayPositions;
            WheelArrayPositions = new T[wheelArrayPositionsPrevious.Length];

            var previousTopIndex = Array.FindIndex(wheelArrayPositionsPrevious, t => t.Equals(setPosition));

            for (var i = 0; i < WheelArrayPositions.Length; i++)
            {
                var iWithOffset = i;
                if (previousTopIndex + iWithOffset >= WheelArrayPositions.Length)
                {
                    iWithOffset = i - WheelArrayPositions.Length;
                }
                WheelArrayPositions[i] = wheelArrayPositionsPrevious[previousTopIndex+iWithOffset];
            }
        }

        public void AddWheelMark(int i, T mark)
        {
            WheelArrayPositions[i] = mark;
        }
    }
}
