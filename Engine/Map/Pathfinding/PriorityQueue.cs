using System;
using System.Collections.Generic;

namespace Pokimon
{
    class PriorityQueue
    {
        Dictionary<Node, int> items;
        public bool IsEmpty { get { return items.Count == 0; } }

        public PriorityQueue()
        {
            items = new Dictionary<Node, int>();
        }

        public void Enqueue(Node node, int priority)
        {
            if(!items.ContainsKey(node))
            {
                items.Add(node, priority);
            }
        }

        public Node Dequeue()
        {
            Node node = null;
            int lowestPriority = int.MaxValue;

            foreach(Node item in items.Keys)
            {
                int currentPriority = items[item];

                if(currentPriority < lowestPriority)
                {
                    lowestPriority = currentPriority;
                    node = item;
                }
            }

            items.Remove(node);

            return node;
        }
    }
}
