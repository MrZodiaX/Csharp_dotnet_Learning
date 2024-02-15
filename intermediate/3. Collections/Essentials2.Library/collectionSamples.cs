using System.Collections.Specialized;

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

            while (stk.Count > 0 && (stkItem = (string?)stk.Pop()) != null)
            {
                Console.WriteLine(stkItem);
            }

            //using generic type, MORE COMMON, better performance than normal 
            var stk2 = new System.Collections.Generic.Stack<string>();
            while (stk.Count>0 && (stkItem = stk2.Pop()) != null)  //not required to cast to string here 
            {
                Console.WriteLine(stkItem);
            }
        }

        private static List<Customer> customer_list;
        static CollectionSamples()  //Constructor 
        {
            customer_list = new List<Customer>();

            for(int i=1;i<6;i++)
            {
                customer_list.Add(new Customer
                {
                    Id = i,
                    FirstName = i.ToString(),
                    LastName = "Customer"
                });
            }
        }

        public static void Indexing()
        {
            var cusX = customer_list[2];

            string doesContain = customer_list.Contains(cusX) ? "does" : "doesnt";
            Console.WriteLine(doesContain);

            var custFind = customer_list.Find(cusFunction);

            if (custFind != null)
                Console.WriteLine($"cust id found: {custFind.Id}");
            else
                Console.WriteLine("Cust not found");
        }

        private static bool cusFunction(Customer C)
        {
            return C.Id == 2;
        }

        public static void Iterating()  //IEnumerator
		{
            customer_list.Reverse();

            IEnumerator<Customer> iter = customer_list.GetEnumerator();
            while (iter.MoveNext()) { 
                Customer customer = iter.Current;
                Console.WriteLine($"Customer Id : {customer.Id}");
            }


			//Sort based on our IComparable in customer class  
			customer_list.Sort();  


			Console.WriteLine($"\nSorted array");

			foreach (Customer customer in customer_list)
			{
				Console.WriteLine($"Customer Id : {customer.Id}");
			}
        }

        public static void Dictionary()
        {
            Dictionary<string, Customer> cusDic = new Dictionary<string, Customer>();

            Customer NewCus = new Customer
            {
                Id = 69,
                FirstName = "shan"
            };

			cusDic.Add("firstCus", NewCus);

            //cannot add same key in Dictionary 
            bool wasAdded = cusDic.TryAdd("aaa", NewCus);
            Console.WriteLine(wasAdded ? "Add Success" : "Add Failed");

            Customer? cc=null;

			bool keyFound = cusDic.ContainsKey("firstCus");           //method 1
			bool keyFound2 = cusDic.TryGetValue("firstCus", out cc);  //method 2

			if (keyFound2) Console.WriteLine("Key Found in Dict"); 
			
            if (keyFound)
            {
                cc = cusDic["firstCus"];
                Console.WriteLine($"Key Found : firstCus id : {cc.Id}");
            }

            foreach(var lol in cusDic)
            {
                Console.WriteLine($"Key : {lol.Key}, Value : {lol.Value} [Id : {lol.Value.Id}]");
            }
        }

        public static void NameValueCollection()  //dictionary that allows multiple keys 
        {
            var items = new NameValueCollection();
            items.Add("a", "firstAlpha ");
			items.Add("a", "firstAlpha ");
			items.Add("b", "secondAlpha ");

            foreach(var lol in items.AllKeys)
            {
                Console.WriteLine($"Key : {lol}, Value : {items[lol]}") ;
            }
		}

        public static void Concurent()  //used in multi-threaded scenarios to synchronize collection access across threads.
		{
            //it is unordered 
            var bag  = new System.Collections.Concurrent.ConcurrentBag<Customer>();
            
            bag.Add(new Customer
            {
                Id = 1,
                FirstName = "fname_concurrent"
            });

			foreach (var item in bag)
            {
                Console.WriteLine(item.FirstName);
            }
        }
	}
}