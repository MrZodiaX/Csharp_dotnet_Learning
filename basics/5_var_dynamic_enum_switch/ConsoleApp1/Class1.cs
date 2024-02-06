using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public class a
    {
        public int a1;

        public a() { a1 = 1; }
    }

    public class b : a
    {
        public int b1;
        public b() { b1 = 2; }
    }

}

[Flags]
public enum days
{
    sunday = 1,
    munday = 2,
    tuesday = 3,
    wednesday = 4
}