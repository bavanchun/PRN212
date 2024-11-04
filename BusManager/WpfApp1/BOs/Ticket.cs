﻿using System;
using System.Collections.Generic;

namespace WpfApp1.BOs;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int? RouteId { get; set; }

    public int? OrderId { get; set; }

    public DateTime Date { get; set; }

    public decimal FinalPrice { get; set; }

    public string Status { get; set; } = "Pending";

    public virtual Order? Order { get; set; }

    public virtual Route? Route { get; set; }
}
