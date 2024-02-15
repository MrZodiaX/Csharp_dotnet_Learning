using Essentials2.Library;

void collectionBasics()
{
    string[] names = new string[2];
    names[0] = "zod";
    names[1] = "shan";

    var arrCol = new System.Collections.ArrayList(2);
    Console.WriteLine("Collection Size : " + arrCol.Count);

    arrCol.Add("First");
    arrCol.AddRange(new string[] { "second", "Third", "Fourth" });

    Console.WriteLine("Collection Size : " + arrCol.Count);

    Console.WriteLine("All items");

    foreach (var name in arrCol)
    {
        Console.WriteLine(name);
    }
}

collectionBasics();

//CollectionSamples.Queue_lol();
//CollectionSamples.Stack_lol();

//CollectionSamples.Indexing();
//CollectionSamples.Iterating();  //reverse sort inumerator 

//CollectionSamples.Dictionary();
//CollectionSamples.NameValueCollection();
//CollectionSamples.Concurent();

