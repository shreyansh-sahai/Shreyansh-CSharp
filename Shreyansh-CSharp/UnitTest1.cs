namespace Shreyansh_CSharp;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EventOrganiserA_ShouldBeEqualTo_EventOrganiserA()
    {
        EventOrganiser eventOrganiserA = new EventOrganiser("A");
        EventOrganiser otherEventOrganiserA = new EventOrganiser("A");

        Assert.That(eventOrganiserA, Is.EqualTo( otherEventOrganiserA));

    }

    [Test]
    public void GSTShouldBe_7260_2Open3Cabin35HoursConference5Meals()
    {
        EventOrganiser eventOrganiser = new EventOrganiser("A");
        Seating openSeating = new Seating("Open Seating", 2, 5, 5000);
        Seating cabinSeating = new Seating("Cabin Seating", 3, 10, 10000);
        Event orgEvent = new Event(5, 35, new List<Seating> { openSeating, cabinSeating });
        var res = orgEvent.PrintInvoice();
        Assert.That("2 Open Seating : 11800 \n3 Cabin Seating : 35400 \n35 Conference : 0 \n5 Meal : 560 \nTotal : 47760 \nTotal GST : 7260", Is.EqualTo(res));
    }
    [Test]
    public void GSTShouldBe_3360_1Cabin50HoursConference10Meals()
    {
        EventOrganiser eventOrganiser = new EventOrganiser("A");
        Seating cabinSeating = new Seating("Cabin Seating", 1, 10, 10000);
        Event orgEvent = new Event(10, 50, new List<Seating> { cabinSeating });
        var res = orgEvent.PrintInvoice();
        Assert.That("1 Cabin Seating : 11800 \n50 Conference : 9440 \n10 Meal : 1120 \nTotal : 22360 \nTotal GST : 3360", Is.EqualTo(res));
    }
}
