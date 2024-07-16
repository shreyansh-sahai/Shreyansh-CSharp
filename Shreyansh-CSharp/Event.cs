using System.Text;

namespace Shreyansh_CSharp;

public class Event
{
    private List<Seating> _seating;
    private int _mealCount;
    private int _conferenceHours;
    private const int HOURLYCOSTOFCONFERENCE = 200;
    private const int PERMEALCOST = 100;
    private const double _SEATINGGST = 0.18;
    private const double _MEALGST = 0.12;

    public Event(int mealCount, int conferenceHours, List<Seating> seating)
    {
        _seating = new List<Seating>(seating);
        _mealCount = mealCount;
        _conferenceHours = conferenceHours;
    }

    public Event()
    {
        _seating = new List<Seating>{
            new Seating("Demo", 0, 0, 5000)
        };
        _mealCount = 0;
        _conferenceHours = 0;
    }

    private IReadOnlyList<ReturnType> GetCost()
    {
        int totalCost = 0;
        int freeConnferenceHours = 0;
        List<ReturnType> returnval = new List<ReturnType>();
        ReturnType ret = new ReturnType();
        foreach (var seating in _seating)
        {
            ret = new ReturnType();
            ret.name = seating.name;
            ret.totalCost = seating.quantity * seating.costPerSeat;
            ret.gstCost = (int)(_SEATINGGST * ret.totalCost);
            ret.quantity = seating.quantity;
            freeConnferenceHours += seating.freeConferenceHours*seating.quantity;
            returnval.Add(ret);
        }

        ret = new ReturnType();
        ret.name = "Conference";
        var conferenceHours = this._conferenceHours > freeConnferenceHours
            ? this._conferenceHours - freeConnferenceHours
            : 0;
        ret.totalCost = conferenceHours * HOURLYCOSTOFCONFERENCE;
        ret.gstCost = (int)(_SEATINGGST * ret.totalCost);
        ret.quantity = this._conferenceHours;
        returnval.Add(ret);
        ret = new ReturnType();
        if (_mealCount < 0) return returnval;
        ret.name = "Meal";
        ret.totalCost = _mealCount * PERMEALCOST;
        ret.gstCost = (int)(_MEALGST * ret.totalCost);
        ret.quantity = _mealCount;
        returnval.Add(ret);
        return returnval;
    }

    public string PrintInvoice()
    {
        StringBuilder receipt = new StringBuilder();
        int totalCost = 0, gstCost = 0;
        IReadOnlyList<ReturnType> returns = GetCost();
        foreach (var returnVal in returns)
        {
            totalCost += returnVal.totalCost;
            totalCost += returnVal.gstCost;
            gstCost += returnVal.gstCost;
            int finalCost = returnVal.totalCost + returnVal.gstCost;
            receipt.Append($"{returnVal.quantity} {returnVal.name} : {finalCost} \n");
        }

        receipt.Append($"Total : {totalCost} \n");
        receipt.Append($"Total GST : {gstCost}");
        return receipt.ToString();
    }
}
