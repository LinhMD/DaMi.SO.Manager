using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class WhUnitOfMeasrLink
{
    /// <summary>
    /// Mã đơn vị tính
    /// </summary>
    [DisplayName("Mã đơn vị tính")]
    public string UnitId { get; set; } = null!;

    /// <summary>
    /// Tên đơn vị tính
    /// </summary>
    [DisplayName("Tên đơn vị tính")]
    public string UnitName { get; set; } = null!;

    public virtual ICollection<WhItemLink> WhItemLinks { get; set; } = new List<WhItemLink>();
}
