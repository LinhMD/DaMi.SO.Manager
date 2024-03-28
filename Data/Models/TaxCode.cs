using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class TaxCode
{
    /// <summary>
    /// MST
    /// </summary>
    [DisplayName("MST")]
    public string TaxCodeId { get; set; } = null!;

    /// <summary>
    /// Tên công ty
    /// </summary>
    [DisplayName("Tên công ty")]
    public string? TaxCodeName { get; set; }

    /// <summary>
    /// Địa chỉ
    /// </summary>
    [DisplayName("Địa chỉ")]
    public string? TaxCodeAddr { get; set; }

    /// <summary>
    /// Mã KH
    /// </summary>
    [DisplayName("Mã KH")]
    public string CustomerId { get; set; } = null!;

    public virtual CustomerLink Customer { get; set; } = null!;

    public virtual ICollection<ComputerItemMap> ComputerItemMaps { get; set; } = new List<ComputerItemMap>();
}
