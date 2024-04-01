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

    public bool AllowEditNumOfTaxCode { get; set; }

    public bool AllowEditNumOfData { get; set; }

    public bool AllowEditNumOfInv { get; set; }

    public bool AllowEditNumOfUser { get; set; }

    public bool AllowEditNumOfPc { get; set; }

    public bool AllowEditiCloudDataSize { get; set; }

    public bool AllowEditNumOfMonth { get; set; }

    public int SortOrder { get; set; }
}
