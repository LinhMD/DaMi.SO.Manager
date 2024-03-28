using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class ViwItemGroup
{
    public string ItemGroupId { get; set; } = null!;

    public string ItemGroupName { get; set; } = null!;

    public string ItemTypeId { get; set; } = null!;

    public bool AllowEditItemName { get; set; }

    public bool AllowEditItemAmount { get; set; }
}
