

var deliveryApp = new DeliveryApp(new Pickup());
Console.WriteLine(deliveryApp.Delivery.GetType() + " " + deliveryApp.Delivery.CalculatePrice());

deliveryApp.SetDelivery(new InternalDeliveryService());
Console.WriteLine(deliveryApp.Delivery.GetType() + " " + deliveryApp.Delivery.CalculatePrice());

deliveryApp.SetDelivery(new ExternalDeliveryService());
Console.WriteLine(deliveryApp.Delivery.GetType() + " " + deliveryApp.Delivery.CalculatePrice());

public class DeliveryApp
{
    public IDelivery Delivery { get; set; }

    public DeliveryApp(IDelivery delivery)
    {
        Delivery = delivery;
    }

    public void SetDelivery(IDelivery delivery)
    {
        Delivery = delivery;
    }
}

public interface IDelivery
{
    public int CalculatePrice();
}

public class Pickup : IDelivery
{
    public int CalculatePrice()
    {
        return 0;
    }
}

public class InternalDeliveryService : IDelivery
{
    public int CalculatePrice()
    {
        return 100;
    }
}

public class ExternalDeliveryService : IDelivery
{
    public int CalculatePrice()
    {
        return 150;
    }
}