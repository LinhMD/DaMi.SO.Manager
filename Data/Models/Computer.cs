using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class Computer
{
    [DisplayName("Mã máy tính")]
    public string ComputerId { get; set; } = null!;

    [DisplayName("Tên máy tính")]
    public string ComputerName { get; set; } = null!;

    [DisplayName("Địa chỉ IP máy tính")]
    public string? Ipaddr { get; set; }

    [DisplayName("Hệ điều hành")]
    public string? OperatingSystem { get; set; }

    [DisplayName("Thông tin phần cứng")]
    public string? HardwareInfo { get; set; }

    [DisplayName("Mã khách hàng")]
    public string CustomerId { get; set; } = null!;

    public virtual ICollection<ComputerItemMap> ComputerItemMaps { get; set; } = new List<ComputerItemMap>();
}
