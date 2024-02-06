using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
    //An interface is a completely "abstract class",
    //which can only contain abstract methods and properties(with empty bodies) 
    public interface Imapper<S,T>
    {
        T Map(S source);
    }
}
