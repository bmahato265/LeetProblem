class Employee
{
    public int Id { get; set; }
    public string? Department { get; set; }
    public decimal Salary { get; set; }
}
class Program
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Department = "IT", Salary = 60000 },
            new Employee { Id = 2, Department = "HR", Salary = 45000 },
            new Employee { Id = 3, Department = "IT", Salary = 75000 },
            new Employee { Id = 4, Department = "Finance", Salary = 50000 },
            new Employee { Id = 5, Department = "HR", Salary = 48000 }
        };
        //Write a LINQ query to get the average salary per department.
        var avgSalaryByDept = employees.GroupBy(x=>x.Department)
        .Select(g => new
        {
            Department = g.Key,
            AverageSalary = g.Average(e => e.Salary)
        }).ToList();
        foreach(var item in avgSalaryByDept)
        {
            Console.WriteLine($"Department : {item.Department}, Average Salary: {item.AverageSalary}");
            
        }
        
    }
    
}


