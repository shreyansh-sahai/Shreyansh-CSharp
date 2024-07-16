namespace Shreyansh_CSharp;

public class Seating
{
    public string name;
    public int quantity;
    public int costPerSeat;
    public int freeConferenceHours;

    public Seating(string name, int quantity, int freeConferenceHours, int costPerSeat)
    {
        this.name = name;
        this.quantity = quantity;
        this.freeConferenceHours = freeConferenceHours;
        this.costPerSeat = costPerSeat;
    }
}