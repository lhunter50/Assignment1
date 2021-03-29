using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Employee : IComparable<Employee>
    {
        private int employeeId;
        private string firstName;
        private string lastName;

        public Employee(int employeeId)
        {
            this.employeeId = employeeId;
            firstName = null;
            lastName = null;
        }

        public Employee(int employeeId, string firstName, string lastName)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int EmployeeID
        {
            get { return this.employeeId; }        
        }

        public string FirstName
        {
            get { return this.firstName; }
        }

        public string LastName
        {
            get { return this.lastName; }
        }

        public int CompareTo(Employee obj)
        {
            //if (obj == null) return 1;

            return this.EmployeeID.CompareTo(obj.EmployeeID);
        }

        public override string ToString()
        {
            string fName = firstName;
            string lName = lastName;

            //if (firstName == null)
            //{
            //    fName = "null";
            //}

            ////ternary
            //fName = firstName == null ? "null" : firstName;

            // null coalescence
            fName = firstName ?? "null";
            lName = lastName ?? "null";

            return string.Format("{0} {1} {2}",EmployeeID, fName, lName);
        }
    }
}
