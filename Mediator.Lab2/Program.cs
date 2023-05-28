#region ClientCode

var deliveryDate = new DeliveryDate();
var recipientCheckbox = new RecipientCheckbox();
var deliveryOptions = new DeliveryOptions();

var mediator = new Mediator();
mediator.SetComponents(deliveryDate, recipientCheckbox, deliveryOptions);

// Setting the initial values of the components
deliveryDate.SetDate(DateTime.Now);
recipientCheckbox.ToggleCheckbox(false);
deliveryOptions.SelectDeliveryOption(true);

// Interaction with components through midator
deliveryDate.SetDate(DateTime.Now.AddDays(2));
recipientCheckbox.ToggleCheckbox(true);
deliveryOptions.SelectDeliveryOption(false);

#endregion

#region ClassStructure

// Component representing the elements of the checkout page
public abstract class Component
{
    protected Mediator mediator;

    public void SetMediator(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public abstract void Update();
}

public class DeliveryDate : Component
{
    public DateTime SelectedDate { get; private set; }

    public void SetDate(DateTime date)
    {
        SelectedDate = date;
        mediator.Notify(this);
    }

    public override void Update()
    {
        // Update available time slots depending on the selected date
    }
}

public class RecipientCheckbox : Component
{
    public bool IsOtherPerson { get; private set; }

    public void ToggleCheckbox(bool isChecked)
    {
        IsOtherPerson = isChecked;
        mediator.Notify(this);
    }

    public override void Update()
    {
        // Activate or deactivate the Name and Phone fields depending on the state of the checkbox
    }
}

public class DeliveryOptions : Component
{
    public bool IsPickupSelected { get; private set; }

    public void SelectDeliveryOption(bool isPickup)
    {
        IsPickupSelected = isPickup;
        mediator.Notify(this);
    }

    public override void Update()
    {
        // Activate or deactivate form elements responsible for delivery,
        // depending on the selected delivery option
    }
}

public class Mediator
{
    private DeliveryDate deliveryDate;
    private RecipientCheckbox recipientCheckbox;
    private DeliveryOptions deliveryOptions;

    public void SetComponents(DeliveryDate deliveryDate, RecipientCheckbox recipientCheckbox, DeliveryOptions deliveryOptions)
    {
        this.deliveryDate = deliveryDate;
        this.recipientCheckbox = recipientCheckbox;
        this.deliveryOptions = deliveryOptions;
    }

    public void Notify(Component component)
    {
        if (component == deliveryDate)
        {
            deliveryOptions.Update();
        }
        else if (component == recipientCheckbox)
        {
            recipientCheckbox.Update();
        }
    }
}

#endregion