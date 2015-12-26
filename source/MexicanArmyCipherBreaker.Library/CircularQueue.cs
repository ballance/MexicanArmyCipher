//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MexicanArmyCipherBreaker.Library
//{
//    public class CircularQueue<T>
//    {
//        private CircularQueueNode<T> _head;

//        public CircularQueue()
//        {
//        }

//        public void Add(T value)
//        {
//            if (_head == null)
//            {
//                _head = new CircularQueueNode<T> { NextNode = _head, PrevNode = _head};
//            }
//        }
//    }

//    public class CircularQueueNode<T>
//    {
//        private int? PositionId = null;
//        T Value { get; set; }
//        public T NextNode { get; set; }
//        public T PrevNode { get; set; }
//    }
//}
