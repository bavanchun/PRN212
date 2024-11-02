using System;
using System.Collections.Generic;

namespace WpfApp1.BOs;

public partial class Route
{
    public int RouteId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Station> Stations { get; set; } = new List<Station>();
}
