using System;
using System.Collections.Generic;

namespace WpfApp1.bos;

public partial class Station
{
    public int StationId { get; set; }

    public string Location { get; set; } = null!;

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}
