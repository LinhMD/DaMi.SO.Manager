using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class TaxCode
{
    [DisplayName("MST")]
    public string TaxCodeId { get; set; } = null!;

    [DisplayName("Tên công ty")]
    public string? TaxCodeName { get; set; }

    [DisplayName("Địa chỉ")]
    public string? TaxCodeAddr { get; set; }

    [DisplayName("Mã KH")]
    public string CustomerId { get; set; } = null!;

    public virtual ICollection<ComputerItemMap> ComputerItemMaps { get; set; } = new List<ComputerItemMap>();
}
