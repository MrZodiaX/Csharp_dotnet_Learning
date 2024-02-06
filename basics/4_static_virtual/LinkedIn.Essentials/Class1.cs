namespace LinkedIn.Essentials
{
    static class Class1
    {
        private static string username;
        public static readonly string key = "LOLOLOLOL";
        public const string password = "password";
        //public Class1() //cannot create constructor of static class, bcs instance cannot be created 
        //can create static const
        static Class1()
        {
            Console.WriteLine("class static const");
            username = "lolol";  //to initialize static member of class
        }

        //public int getKey()  //cannot declare instance member in static class
        public static int getKey()  //deault is protected
        {
            return 0;
        }

        /*
        
        difference bwteen const and static readonly : 

        Mutability : const are implicitly Static, compile time constants, literals, cannot be chnaged at runtime. 
        readonly variables initialized in runtime (static constructor), then cannot be chaged. 

        usage : const : maths value such as pi, never changing. readonly, value fetched at runtime 


        */
    }
}
