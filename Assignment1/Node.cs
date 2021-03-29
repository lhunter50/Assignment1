using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Node<T>
    {
        public T Element { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }

        public Node()
        {

        }

        public Node(T element)
        {
            this.Element = element;
        }

        public Node(T element, Node<T> previousNode, Node<T> nextNode)
        {
            this.Element = element;
            this.Previous = previousNode;
            this.Next = nextNode;
        }

    }
}
