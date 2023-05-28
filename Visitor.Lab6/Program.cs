#region ClientCode

var employees = new List<Employee>()
{
    new Employee("Manager", 5000),
    new Employee("Developer", 4000),
    new Employee("Designer", 3000)
};

var department = new Department(employees);
var departments = new List<Department>() { department };
var company = new Company(departments);

var reportVisitor = new SalaryReportVisitor();

company.Accept(reportVisitor);

department.Accept(reportVisitor);

#endregion

#region ClassStructure

public abstract class Entity
{
    public abstract void Accept(IVisitor visitor);
}

public class Company : Entity
{
    private List<Department> departments;

    public Company(List<Department> departments)
    {
        this.departments = departments;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.VisitCompany(this);
        foreach (var department in departments)
        {
            department.Accept(visitor);
        }
    }
}


public class Department : Entity
{
    private List<Employee> employees;

    public Department(List<Employee> employees)
    {
        this.employees = employees;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.VisitDepartment(this);
        foreach (var employee in employees)
        {
            employee.Accept(visitor);
        }
    }
}

public class Employee : Entity
{
    public string Position { get; }
    public decimal Salary { get; }

    public Employee(string position, decimal salary)
    {
        Position = position;
        Salary = salary;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.VisitEmployee(this);
    }
}

public interface IVisitor
{
    void VisitCompany(Company company);
    void VisitDepartment(Department department);
    void VisitEmployee(Employee employee);
}

public class SalaryReportVisitor : IVisitor
{
    public void VisitCompany(Company company)
    {
        Console.WriteLine("Salary Report for Company:");
    }

    public void VisitDepartment(Department department)
    {
        Console.WriteLine($"Salary Report for Department:");
    }

    public void VisitEmployee(Employee employee)
    {
        Console.WriteLine($"- {employee.Position}: {employee.Salary}");
    }
}

#endregion