using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
    public record Employee
    {
        //Follow up: create constructor to initialize the first name
        private string fName;

        public int Id { get; set; }
        public string FirstName {
            get => fName; 
            init => fName = value;
        }
        public string LastName { get; set; }

        public override string ToString() => $"{FirstName}_{LastName}";
    }
}
