using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class Computer
{
    public string ComputerId { get; set; } = null!;

    public string ComputerName { get; set; } = null!;

    public string? Ipaddr { get; set; }

    public string? OperatingSystem { get; set; }

    public string? HardwareInfo { get; set; }

    public string CustomerId { get; set; } = null!;

    public virtual ICollection<ComputerItemMap> ComputerItemMaps { get; set; } = new List<ComputerItemMap>();
}
