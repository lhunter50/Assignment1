using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Assignment1;

namespace Assignment1
{
    public class LinkedList<T> where T : IComparable<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Size { get; set; }

        public LinkedList()
        {
            Clear();
        }

        public int CompareTo(T current, T element)
        {
            return element.CompareTo(current);
        }

        public void AddFirst(T element)
        {
            Node<T> newNode = new Node<T>(element);

            if (IsEmpty())
            {
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;

                Head.Previous = newNode;
               
            }

            Head = newNode;
            Size++;

        }

        public T RemoveFirst()
        {
            return RemoveNode(Head);
        }


        public void AddLast(T element)
        {                
            Node<T> newNode = new Node<T>(element, Tail, null);

            if(IsEmpty())
            {
                Head = newNode;
            }
            else
            {
               // newNode.Previous = Tail;

                Tail.Next = newNode;
            }


            Tail = newNode;
            Size++;

        }

        public T RemoveLast()
        {
            return RemoveNode(Tail);
        }

        public T SetFirst(T element)
        {
            //return Set(element, 1);

            if (IsEmpty())
            {
                throw new ApplicationException();
            }
            // we want to return the previous head
            T previousHeader = Head.Element;

            //setting the head to our new element
            Head.Element = element;

            //returning the old head
            return previousHeader;
        }

        public T SetLast(T element)
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            T previousTail = Tail.Element;

            Tail.Element = element;

            return previousTail;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }


        public T GetFirst()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            return Head.Element;
        }

        public T GetLast()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            return Tail.Element;
        }


        public T Get(int position)
        {
            return GetNodeByPosition(position).Element;
        }

        public T Get(T element)
        {
            return GetNodeByElement(element).Element;
        }

        private Node<T> GetNodeByElement(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            Node<T> current = Head;

            while(current != null)
            {
                if(CompareTo(current.Element, element) == 0 )
                {
                    return current;
                }
                current = current.Next;
            }
            throw new ApplicationException();
        }

        private Node<T> GetNodeByPosition(int position)
        {
            if (IsEmpty() ||  position < 1 || position > Size)
            {
                throw new ApplicationException();
            }

            int count = 1;

            Node<T> newNode = Head;

            while (count < position)
            {
                newNode = newNode.Next;
                count++;
            }

            return newNode;
        }

        public T Remove(int position)
        {
            return RemoveNodeByPosition(GetNodeByPosition(position));
        }

        private T RemoveNodeByPosition(Node<T> newNode)
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            if (Size == 1)
            {
                Clear();
            }
            else
            {
                if (newNode.Next != null)
                {
                    newNode.Next.Previous = newNode.Previous;
                }
                else
                {
                    Tail = newNode.Previous;
                }

                if (newNode.Previous != null)
                {
                    newNode.Previous.Next = newNode.Next;

                }
                else
                {
                    Head = newNode.Next;
                }
                --Size;
            }

            return newNode.Element;
        }


        public T Remove(T element)
        {
            return RemoveNode(GetNodeByElement(element));
        }

        private T RemoveNode(Node<T> newNode)
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            if (Size == 1)
            {
                Clear();
            }
            else
            {
                if (newNode.Next != null)
                {
                    newNode.Next.Previous = newNode.Previous;
                }
                else
                {
                    Tail = newNode.Previous;
                }

                if (newNode.Previous != null)
                {
                    newNode.Previous.Next = newNode.Next;

                }
                else
                {
                    Head = newNode.Next;
                }
                --Size;
            }

            return newNode.Element;
        }

        public T Set(T element, int position)
        {
            Node<T> current = GetNodeByPosition(position);
            T oldElement = current.Element;
            current.Element = element;
            return oldElement;
        }


        public T Set(T element, T oldElement)
        {
            Node<T> selectedNode = GetNodeByElement(oldElement);

            element = selectedNode.Element;

            return oldElement;
        }

        public void AddAfter(T element, T oldElement)
        {
            Node<T> selected = GetNodeByElement(oldElement);
            After(selected, element);
        }

        public void AddAfter(T element, int position)
        {
            Node<T> selected = GetNodeByPosition(position);
            After(selected, element, position);
        }

        private void After(Node<T> selectedNode, T element, int position = -1)
        {
            Node<T> selected = selectedNode;
            Node<T> nextNode = selected.Next;

            Node<T> newNode = new Node<T>(element, selected, nextNode);
            selected.Next = newNode;

            if (newNode.Next == null || position == Size)
            {
                Tail = newNode;
            }
            else
            {
                nextNode.Previous = newNode;
            }

            Size++;
        }


        public void AddBefore(T element, T oldElement)
        {
            Node<T> selectedNode = GetNodeByElement(oldElement);
            Before(selectedNode, element);
        }

        public void AddBefore(T element, int position)
        {
            Before(GetNodeByPosition(position), element, position);
        }


        private void Before(Node<T> selectedNode, T element, int position = -1)
        {
            Node<T> selected = selectedNode;
            Node<T> nextNode = selected.Previous;

            Node<T> newNode = new Node<T>(element, nextNode, selected);
            selected.Previous = newNode;

            if (newNode.Previous == null || position == 1)
            {
                Head = newNode;
            }
            else
            {
                nextNode.Next = newNode;
            }
            Size++;
        }

        public void SortAscending()
        {
            Node<T> node = Head;
            Clear();
            while (node != null)
            {
                Insert(node.Element);
                node = node.Next;
            }

            //Node<T> current = Head;
            //Node<T> index;
            //T tempElement;

            //if(Head == null)
            //{
            //    return;
            //}
            //else
            //{
            //    bool isSorted = false;
            //    while (current != null && !isSorted)
            //    {
            //        index = current.Next;
            //        isSorted = true;
            //        while (index != null)
            //        {
            //            if (current.Element.CompareTo(index.Element) > 0)
            //            {
            //                tempElement = current.Element;
            //                current.Element = index.Element;
            //                index.Element = tempElement;
            //                isSorted = false;
            //            }

            //            index = index.Next;
            //        }
            //        current = current.Next;
            //    }
            //}
        }

        public void Insert(T element)
        {
            Node<T> current = Head;

            while (current != null && element.CompareTo(current.Element) > 0) 
            {
                current = current.Next;
            }

            if (current == null)
            { // empty or element is largest in the list:
                AddLast(element);
            }
            else
            {
                Before(current, element);
            }


            //Node<T> current = Head;
            //Node<T> newNode = new Node<T>(element);

            //if (IsEmpty())
            //{
            //    Head = newNode;
            //    Tail = newNode;
            //    Size++;
            //}
            //else if (current.Element.CompareTo(element) <= -1)
            //{
            //    while (current.Next != null && current.Next.Element.CompareTo(element) <= -1)
            //    {
            //        current = current.Next;
            //    }
            //    AddAfter(element, current.Element);
            //}
            //else if (current.Element.CompareTo(element) == 1)
            //{
            //    AddBefore(element, current.Element);
            //}
        }
    }

}
