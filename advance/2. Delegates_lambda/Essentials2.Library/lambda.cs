using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
    public class lambda
    {    
        public string fname
        {
            get => fname;
            init => fname = value;
        }
        public string lname;

        public override string ToString() => $"{fname}__{lname}";

    }
}
