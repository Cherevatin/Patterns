
var account = new Account();
var caretaker = new Caretaker(account);

Console.WriteLine("Default prefs:\n");
account.ShowState();

caretaker.BackupData();

account.ChangeReceiveNews();
account.ChangeReceiveSecurity();
account.ChangeReceiveUpdates();
Console.WriteLine("New prefs:\n");
account.ShowState();

Console.WriteLine("Reverted prefs:\n");
caretaker.Restore();
account.ShowState();


public class State: ICloneable
{
    public bool ReceiveNews { get; set; }

    public bool ReceiveSecurity { get; set; }

    public bool ReceiveUpdates { get; set; }

    public State(bool receiveNews, bool receiveSecurity, bool receiveUpdates)
    {
        ReceiveNews = receiveNews;
        ReceiveSecurity = receiveSecurity;
        ReceiveUpdates = receiveUpdates;
    }

    public void ChangeReceiveNews()
    {
        ReceiveNews = !ReceiveNews;
    }

    public void ChangeReceiveSecurity()
    {
        ReceiveSecurity = !ReceiveSecurity;
    }

    public void ChangeReceiveUpdates()
    {
        ReceiveUpdates = !ReceiveUpdates;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}

public class Memento
{
    public State State { get; private set; }

    public Memento(State state)
    {
        this.State = state;
    }
}

public class Caretaker
{
    public Memento Memento { get; set; }

    private Account Originator { get; set; }

    public Caretaker(Account originator)
    {
        Originator = originator;
    }

    public void BackupData()
    {
        Memento = Originator.SaveState();
    }

    public void Restore()
    {
        Originator.Restore(Memento);
    }

}

public class Account
{
    public State State { get; set; }

    public Account(bool receiveNews = false, bool receiveSecurity = true, bool receiveUpdates = false)
    {
        State = new State(receiveNews,receiveSecurity,receiveUpdates);
    }

    public void ChangeReceiveNews()
    {
        State.ChangeReceiveNews();
    }

    public void ChangeReceiveSecurity()
    {
        State.ChangeReceiveSecurity();
    }

    public void ChangeReceiveUpdates()
    {
        State.ChangeReceiveUpdates();
    }

    public void ShowState()
    {
        Console.WriteLine(String.Format("|{0,20}|{1,20}|{2,20}|", "ReceiveNews", "ReceiveSecurity", "ReceiveUpdates"));
        Console.WriteLine(String.Format("|{0,20}|{1,20}|{2,20}|", State.ReceiveNews.ToString(), State.ReceiveSecurity.ToString(), State.ReceiveUpdates.ToString()));
    }

    public Memento SaveState()
    {
        return new Memento((State)State.Clone());
    }

    public void Restore(Memento memento)
    {
        State = memento.State;
    }
}