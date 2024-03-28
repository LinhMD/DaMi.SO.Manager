using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class OrderForm
{
    public string OrderFormId { get; set; } = null!;

    public string OrderFormName { get; set; } = null!;

    public bool HasByTime { get; set; }

    public bool HasByTaxCode { get; set; }

    public bool HasByQtyInvc { get; set; }

    public bool HasByDiskSize { get; set; }

    public bool HasByPc { get; set; }

    public bool HasByUser { get; set; }

    public int SortOrder { get; set; }

    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = [];

    public virtual ICollection<WhItemTypeLink> WhItemTypeLinks { get; set; } = [];
}
