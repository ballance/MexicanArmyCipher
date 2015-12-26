using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MexicanArmyCipherBreaker.Library
{
    public class CryptoWheelSystem<T>
    {
        private Dictionary<string, T> _mappedCache = new Dictionary<string, T>();
        public CryptoWheelSystem(int numPositions)
        {
            _wheels = new List<CryptoWheel<T>>();
            _numPositions = numPositions;
        }

        private readonly List<CryptoWheel<T>> _wheels;
        private readonly int _numPositions;

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
            var foundWheel = _wheels.Where(w => w.Id.Equals(wheelId));

            if (foundWheel == null || !foundWheel.Any())
                throw new ApplicationException("Wheel not found");

            foundWheel.First().SetTopPosition(setPosition);
        }

        // TODO: Add ShiftLeft and ShiftArbitrary
        public void ShiftWheelTopPositionRight(int wheelId)
        {
            var foundWheel = _wheels.Single(w => w.Id.Equals(wheelId));
            foundWheel.ShiftWheelRight();
        }

        /// <summary>
        /// Decodes from a ciphertext character input to a plaintext character output
        /// Simple key / value cache added to improve performance for large ciphertext inputs
        /// </summary>
        /// <param name="codeNumber"></param>
        /// <returns></returns>
        // TODO: Simplify this logic.  this is used fequently and could be faster
        public T Decode(string codeNumber)
        {
            if (_mappedCache.ContainsKey(codeNumber))
            {
                return _mappedCache[codeNumber];
            }

            foreach (var wheel in _wheels.ToList())
            {
                var codeNumberPosition = Array.IndexOf(wheel.WheelArrayPositions, codeNumber);
                if (codeNumberPosition <= -1) continue;
                T result = _wheels.First(w => w.Id.Equals(0)).WheelArrayPositions[codeNumberPosition];
                _mappedCache.Add(codeNumber, result);
                return result;
            }
            return default(T);
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
            Console.WriteLine($"Setting Wheel Positions took {sw.ElapsedMilliseconds} ms.");
        }

        public string EncodeText(string[] textToDecode)
        {
            var sb = new StringBuilder();

            foreach (var code in textToDecode)
            {
                sb.Append(Decode(code));
            }
            return sb.ToString();
        }

        public string WriteConfigToString()
        {
            var configStringBuilder = new StringBuilder();
            foreach (var wheel in _wheels)
            {
                configStringBuilder.Append($"{wheel.WheelArrayPositions[wheel.CurrentTopIndex]}_");
            }
            return configStringBuilder.ToString();
        }

        /// <summary>
        /// Clear cache after changing any wheel configuration
        /// </summary>
        public void ClearCache()
        {
            _mappedCache = new Dictionary<string, T>();
        }
    }
}
