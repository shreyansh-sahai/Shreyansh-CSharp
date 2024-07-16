namespace Shreyansh_CSharp;

public class EventOrganiser
{
    private string _name;
    private List<Event> _event;

    public EventOrganiser(string name)
    {
        _name = name;
        _event = new List<Event>();
    }

    public override bool Equals(object? obj)
    {
        return obj is EventOrganiser && this._name.Equals(((EventOrganiser)obj)._name);    
    }

    public void Add(Event createdEvent)
    {
        _event.Add(createdEvent);
    }
}

