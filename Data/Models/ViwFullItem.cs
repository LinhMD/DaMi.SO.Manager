using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Keyless]
public partial class ViwFullItem
{
    [Column("ItemID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemId { get; set; } = null!;

    [StringLength(250)]
    public string ItemName { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? InvUnitOfMeasr { get; set; }

    [StringLength(50)]
    public string? UnitName { get; set; }

    [Column("ItemGroupID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemGroupId { get; set; } = null!;

    [StringLength(150)]
    public string ItemGroupName { get; set; } = null!;

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

    [Column("ItemTypeID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemTypeId { get; set; } = null!;

    [StringLength(150)]
    public string ItemTypeName { get; set; } = null!;

    [Column("OrderFormID")]
    [StringLength(20)]
    [Unicode(false)]
    public string OrderFormId { get; set; } = null!;

    [StringLength(150)]
    public string OrderFormName { get; set; } = null!;

    public bool HasByTime { get; set; }

    public bool HasByTaxCode { get; set; }

    public bool HasByNumData { get; set; }

    public bool HasByQtyInvc { get; set; }

    public bool HasByDiskSize { get; set; }

    [Column("HasByPC")]
    public bool HasByPc { get; set; }

    public bool HasByUser { get; set; }

    [StringLength(40)]
    public string? Language { get; set; }

    [Column("isPayFull")]
    public bool IsPayFull { get; set; }

    [Column("isPayYear")]
    public bool IsPayYear { get; set; }

    public int DefNumOfTaxCode { get; set; }

    public int DefNumOfData { get; set; }

    public int DefNumOfInv { get; set; }

    public int DefNumOfUser { get; set; }

    [Column("DefNumOfPC")]
    public int DefNumOfPc { get; set; }

    public int DefiCloudDataSize { get; set; }

    public int DefNumOfMonth { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal TaxRate { get; set; }

    [Column("AccountID")]
    [StringLength(20)]
    [Unicode(false)]
    public string AccountId { get; set; } = null!;

    public int SortOrder { get; set; }

    public double ConvertPrice { get; set; }

    public double OriginalPrice { get; set; }

    [StringLength(100)]
    public string? Notes { get; set; }

    public bool InActive { get; set; }

    public DateTime CreatedDate { get; set; }

    [Column("CreatedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CreatedUserId { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    [Column("LastModifiedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string LastModifiedUserId { get; set; } = null!;

    [Column("RowUniqueID")]
    public Guid RowUniqueId { get; set; }
}
