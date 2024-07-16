namespace Shreyansh_CSharp;

public class ReturnType
{
    public string name;
    public int totalCost;
    public int gstCost;
    public int quantity;

    public ReturnType(string name, int totalCost, int gstCost, int quantity)
    {
        this.name = name;
        this.totalCost = totalCost;
        this.gstCost = gstCost;
        this.quantity = quantity;
    }

    public ReturnType()
    {
    }
}