using System.Collections;

namespace MexicanArmyCipherBreaker.Library
{
    public class Wheelmark<T> : IEnumerable
    {
        public int? Position { get; set; }
        public T Value { get; set; }

        public void Add(T wheelMarkvalue)
        {
            Value = wheelMarkvalue;
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void Add(int wheelMarkvalue)
        {
            throw new System.NotImplementedException();
        }
    }
}