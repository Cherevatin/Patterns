

var user = new User();
var product = new Product();
var order = new Order();

user.Start();
Console.WriteLine();

product.Start();
Console.WriteLine();

order.Start();

public abstract class Base
{
    public void Start()
    {
        Get();
        if (Validate())
        {
            FormSaveRequest();
            FormResponse();
        }
    }

    public virtual void Get() 
    {
        Console.WriteLine("Get obj");
    }

    public virtual bool Validate() 
    {
        Console.WriteLine("Validation success");
        return true;
    }

    public virtual void FormSaveRequest() 
    {
        Console.WriteLine("Save request");
    }

    public virtual void FormResponse() 
    {
        Console.WriteLine("Form response");
    }
}

public class Product : Base
{
    public override bool Validate()
    {
        Console.WriteLine("Product validation failed");
        return false;
    }
}

public class User : Base
{
    public override bool Validate() 
    {
        Console.WriteLine("Email cannot be changed!");
        return false;
    }
}

public class Order : Base
{
    public override void FormResponse()
    {
        Console.WriteLine("200 OK", this);
    }
}
