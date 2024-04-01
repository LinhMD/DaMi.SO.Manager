using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Keyless]
public partial class ViwItemGroup
{
    [Column("ItemGroupID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemGroupId { get; set; } = null!;

    [StringLength(150)]
    public string ItemGroupName { get; set; } = null!;

    [Column("ItemTypeID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemTypeId { get; set; } = null!;

    public bool AllowEditItemName { get; set; }

    public bool AllowEditItemAmount { get; set; }

    public bool AllowEditNumOfTaxCode { get; set; }

    public bool AllowEditNumOfData { get; set; }

    public bool AllowEditNumOfInv { get; set; }

    public bool AllowEditNumOfUser { get; set; }

    [Column("AllowEditNumOfPC")]
    public bool AllowEditNumOfPc { get; set; }

    public bool AllowEditiCloudDataSize { get; set; }

    public bool AllowEditNumOfMonth { get; set; }

    public int SortOrder { get; set; }
}
