using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp2
{
    class Counter
    {
        public object[] field;

        public delegate void LowBorder();
        public delegate void HighBorder();

        public event LowBorder EventBottomDecrement;
        public event HighBorder EventTopincrement;

        private int lengthOfCount { get { return this.field.Length; } }
        private object currentValue { get { return this.field[index]; } }
        private int index = 0;

        private void Print()
        {
            Console.Clear();
            Console.Write("{0}\r", currentValue);
            Thread.Sleep(500);
        }

        private void PrintEmpty()
        {
            Console.WriteLine("Массив пуст!");
        }

        private bool LengthOfCounters()
        {
            if (lengthOfCount > 0)
                return true;
            else return false;
        }

        public void CleanMessage()
        {
            Console.Clear();
            Thread.Sleep(100);
        }

        public void Increment()
        {
            if (LengthOfCounters())
            {
                Print();
                this.index++;
                if (index == (lengthOfCount))
                {
                    EventTopincrement();
                    this.index = 0;
                }
            }
            else PrintEmpty();
        }

        public void Decrement()
        {
            if (LengthOfCounters())
            {
                if (index == 0)
                {
                    EventBottomDecrement();
                    this.index = (lengthOfCount);
                }
                this.index--;
                Print();
            }
            else PrintEmpty();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Counter count = new Counter();
            Counter count1 = new Counter();
            Counter count2 = new Counter();
            count.field = new object[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            count1.field = new object[5] { "one", "two", "three", "four", "five" };
            count2.field = new object[3] { "plus one", "plus two", "plus three" };
            count.EventBottomDecrement += count.CleanMessage;
            count.EventBottomDecrement += count1.Decrement;
            count.EventTopincrement += count1.Increment;
            count1.EventTopincrement += count2.Increment;
            count1.EventBottomDecrement += count2.Decrement;
            count2.EventTopincrement += count2.CleanMessage;
            count2.EventBottomDecrement += count2.CleanMessage;
            while (true)
            {
                count.Increment();
            }
        }
    }
}
