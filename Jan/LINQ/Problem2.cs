using Microsoft.VisualBasic;

class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
}

class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = String.Empty;
}
public class Program
{
     static List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, CustomerId = 1, Amount = 500 },
            new Order { OrderId = 2, CustomerId = 2, Amount = 1500 },
            new Order { OrderId = 3, CustomerId = 1, Amount = 800 },
            new Order { OrderId = 4, CustomerId = 3, Amount = 1200 }
        };
     static List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "Ram" },
            new Customer { CustomerId = 2, Name = "Shyam" },
            new Customer { CustomerId = 3, Name = "Hari" },
            new Customer { CustomerId =4, Name = "Krishna"}
        };

        static List<int> numbers = new List<int> { 10, 20, 30, 40, 40, 50, 50 };

    public static void Main(String[] args)
    {
    // CustomerHaveMoreOrders();
    // LeftJoinLINQ();
    var maxNumbers = numbers
                        .Distinct()
                        .OrderByDescending(x => x)
                        .Where(x => x > 30).ToList();
    Console.WriteLine($"Output: {String.Join(",", maxNumbers)}");

    }
    public static void CustomerHaveMoreOrders()
    {
        /*
        Question: Find customers who have placed more than one order and their total order amount.
        Approach:
        GroupBy Customers and count the orders first.
        filter the customers having count>1
        Sum the order amount
        */
        // var resultset = orders
        //                 .Join(customers,
        //                 o => o.CustomerId,
        //                 c => c.CustomerId,
        //                 (o,c) => new {c.Name, o.Amount}
        //                 )
        //                 .GroupBy(e => e.Name)
        //                 .Select(g => new
        //                 {
        //                     Name = g.Key,
        //                     TotalAmount = g.Sum(e => e.Amount),
        //                     TotalOrders = g.Count()
        //                 })
        //                 .Where(x=>x.TotalOrders > 1)
        //                 .ToList();
        //Senior Level Answer
        var resultset = customers
                        .GroupJoin(orders,
                        c => c.CustomerId,
                        o => o.CustomerId,
                        (c,os) => new
                        {
                            Name =  c.Name,
                            TotalOrders = os.Count(),
                            TotalAmount = os.Sum(e => e.Amount)
                        }
                        )
                        .Where(e => e.TotalOrders > 1)
                        .ToList();
        foreach(var item in resultset)
        {
            Console.WriteLine($"{item.Name}: {item.TotalAmount} => {item.TotalOrders} items");
        }
        
        
    }
    public static void TotalOrderPerCustomer()
    {
         // Write a LINQ query to get:
        // Customer Name, Total Order Amount per customer
        var resultSet = orders
                        .Join(customers,
                        o => o.CustomerId,
                        c => c.CustomerId,
                        (o,c) => new
                        {
                            c.Name, o.Amount
                        }
                        ).GroupBy(e => e.Name)
                        .Select(g => new
                        {
                            CustomerName = g.Key,
                            TotalOrder = g.Sum(e => e.Amount)
                        })
                        .ToList();
        foreach(var item in resultSet)
        {
            Console.WriteLine($"{item.CustomerName} = {item.TotalOrder}");
            //Output:
            // Ram = 1300
            // Shyam = 1500
            // Hari = 1200
        }
        
    }
    public static void LeftJoinLINQ()
    {
        //Return all customers, even if they have no orders, along with total order amount.
        var resultset = customers
                        .SelectMany(
                            c => orders.Where(o => o.CustomerId == c.CustomerId)
                            .DefaultIfEmpty(),
                            (c, o) => new
                            {
                                CustomerName = c.Name,
                                Amount = o?.Amount??0
                            }
                        )
                        .GroupBy(e => e.CustomerName)
                        .Select(g => new
                        {
                            CustomerName = g.Key,
                            TotalAmount = g.Sum(e=>e.Amount)
                        })
                        .ToList();
        foreach(var item in resultset)
        {
            Console.WriteLine($"{item.CustomerName} = {item.TotalAmount}");
        }
    }
}


