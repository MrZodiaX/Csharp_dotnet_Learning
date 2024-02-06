namespace Essentials2.Library
{
    public static class CollectionSamples
    {
        public static void Queue_lol()
        {
            //System.Collections.Specialized.NameValueCollection
            var q = new System.Collections.Queue();
            q.Enqueue("firstItem");
            q.Enqueue("secondItem");

            string? item = null;

            Console.WriteLine("Using a Queue");
            while ((item = (string?)q.Dequeue()) != null)
            {
                Console.WriteLine(item);
                if (q.Count <= 0)
                    break;
            }
        }

        public static void Stack_lol()
        {
            var stk = new System.Collections.Stack();
            stk.Push("firstItem");
            stk.Push("secondItem");

            string? stkItem = null;
            Console.WriteLine();
            Console.WriteLine("Using a stack");

            while ((stkItem = (string?)stk.Pop()) != null)
            {
                Console.WriteLine(stkItem);
                if (stk.Count <= 0)
                    break;
            }

            //using generic type, MORE COMMON, better performance than normal 
            var stk2 = new System.Collections.Generic.Stack<string>();
            while ((stkItem = stk2.Pop()) != null)  //not required to cast to string here 
            {
                Console.WriteLine(stkItem);
                if (stk.Count <= 0)
                    break;
            }
        }
    }
}