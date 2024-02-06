using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials2.Library
{
    public class sorter<T> where T : class, IComparable<T>, new ()
    {
        public void Sort(T[] items)
        {
            //if (items[0] > items[1])  //cannot do since we dont know type 
            //using where we limit the type, so compiler knows 
            for(int i=1; i<items.Length; i++)
            {
                if (items[i].CompareTo(items[i-1]) <0 )
                {
                    //swap
                    T temp = items[i];
                    items[i] = items[i-1];
                    items[i-1] = temp;
                }
            }
        }
    }
}
