using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Bus
{
    public int BusId { get; set; }

    public string? Model { get; set; }

    public int RouteId { get; set; }

    public string LicensePlate { get; set; } = null!;

    public int Seats { get; set; }

    public decimal BasePrice { get; set; }

    public virtual Route Route { get; set; } = null!;
}
