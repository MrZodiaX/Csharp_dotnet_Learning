using Essentials2.Library;

var c1 = new Customer
{
    Id = 7,
    FirstName = "customer1",
    LastName = "first1",
    CreateDate = new DateOnly(2022, 1, 17)
};

var c2= new Customer
{
    Id = 10,
    FirstName = "customer2",
    LastName = "first2",
    CreateDate = new DateOnly(2022, 1, 17)
};

var sorter = new sorter<Customer>();
var cus = new Customer[] { c1, c2 };

sorter.Sort(cus);

foreach (var customer in cus)
{
    Console.WriteLine(customer.Id);
}