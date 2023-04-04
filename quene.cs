using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prack14zad3_4
{
    public class Queue
    {
        private List<int> items;

        public Queue(int n)
        {
            items = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                items.Add(i);
            }
        }

        public int Dequeue()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Очередь пуста");
            }
            int item = items[0];
            items.RemoveAt(0);
            return item;
        }

        public bool IsEmpty()
        {
            return items.Count == 0;
        }


        
    }
}