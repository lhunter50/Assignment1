using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedElement = list.RemoveLast();

            if (list.Head != first)
            {
                Console.WriteLine("1 This is Wrong");
            }
            if (first.Previous != null)
            {
                Console.WriteLine("2 This is Wrong");
            }
            if (first.Next != second)
            {
                Console.WriteLine("3 This is Wrong");
            }
            if (second.Previous != first)
            {
                Console.WriteLine("4 This is Wrong");
            }
            if (second.Next != null)
            {
                Console.WriteLine("5 This is Wrong");
            }
            if (list.Tail != second)
            {
                Console.WriteLine("6 This is Wrong");
            }
            if (list.Size != 2)
            {
                Console.WriteLine("7 This is Wrong");
            }

            Console.ReadLine();
        }
    }
}
