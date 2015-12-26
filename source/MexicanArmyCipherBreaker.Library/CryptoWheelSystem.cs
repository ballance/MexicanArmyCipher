using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MexicanArmyCipherBreaker.Library
{
    public class CryptoWheelSystem<T>
    {
        public CryptoWheelSystem(int numPositions)
        {
            _wheels = new List<CryptoWheel<T>>();
            _numPositions = numPositions;
        }

        private readonly List<CryptoWheel<T>> _wheels;
        private int _numPositions;

        public int Count => _wheels.Count;

        public int AddWheel(CryptoWheel<T> wheel)
        {
            if (wheel.WheelArrayPositions.Length != _numPositions)
                throw new ApplicationException($"Incorrect number of wheel marks.  Expected {_numPositions}");

            var addedWheelId = 0;
            if (_wheels.Any())
            {
                addedWheelId = _wheels.Count;
            }
            wheel.Id = addedWheelId;
            _wheels.Add(wheel);
            return addedWheelId;
        }

        public void SetWheelTopPositionById(int wheelId, T setPosition)
        {
            // Find id
            var foundWheel = _wheels.Where(w => w.Id.Equals(wheelId));

            if (foundWheel == null || !foundWheel.Any())
                throw new ApplicationException("Wheel not found");

            foundWheel.First().SetTopPosition(setPosition);
            // Set pointer to top for wheel found
            // Set other positions relative to top
        }

        public T Decode(string codeNumber)
        {
            foreach (var wheel in _wheels)
            {
                var codeNumberPosition = Array.IndexOf(wheel.WheelArrayPositions, codeNumber);
                if (codeNumberPosition > -1)
                {
                    return _wheels.First(w => w.Id.Equals(0)).WheelArrayPositions[codeNumberPosition];
                }
            }
            throw new ApplicationException("Code not found in any wheels.");
        }

        public void SetWheelPositions(T letterWheel, T numberWheel1, T numberWheel2, T numberWheel3, T numberWheel4)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SetWheelTopPositionById(0, letterWheel);
            SetWheelTopPositionById(1, numberWheel1);
            SetWheelTopPositionById(2, numberWheel2);
            SetWheelTopPositionById(3, numberWheel3);
            SetWheelTopPositionById(4, numberWheel4);
            sw.Stop();
            Console.WriteLine();
        }

        public string DecodeText(string[] textToDecode)
        {
            var sb = new StringBuilder();

            foreach (var code in textToDecode)
            {
                sb.Append(Decode(code));
            }
            return sb.ToString();
        }
    }
}
