var room = new Room(3);
room.RoomSoldOutEvent += OnRoomSoldOut;
room.ReserveSeats();
room.ReserveSeats();
room.ReserveSeats();
room.ReserveSeats();

static void OnRoomSoldOut(object sender, EventArgs e)
{
    Console.WriteLine("Sala lotada!");
}

public class Room
{
    private int seetsInUse = 0;
    public int Seats { get; set; }
    public Room(int seats)
    {
        Seats = seats;
        seetsInUse = 0;
    }

    public void ReserveSeats()
    {
        seetsInUse++;
        if (seetsInUse >= Seats)
        {
            OnRoomSoldOut(EventArgs.Empty);
        }
        else
        {
            Console.WriteLine("Assento reservado!");
        }
    }

    public event EventHandler RoomSoldOutEvent;

    public virtual void OnRoomSoldOut(EventArgs e)
    {
        EventHandler handler = RoomSoldOutEvent;
        handler?.Invoke(this, e);
    }
}