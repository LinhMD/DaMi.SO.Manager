using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Keyless]
public partial class ViwItem
{
    [Column("RowUniqueID")]
    public Guid RowUniqueId { get; set; }

    [Column("ItemID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemId { get; set; } = null!;

    [StringLength(250)]
    public string ItemName { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? InvUnitOfMeasr { get; set; }

    [Column("ItemGroupID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemGroupId { get; set; } = null!;

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

    [Column("Account632ID")]
    [StringLength(20)]
    [Unicode(false)]
    public string Account632Id { get; set; } = null!;

    [Column("Account511ID")]
    [StringLength(20)]
    [Unicode(false)]
    public string Account511Id { get; set; } = null!;

    [Column("Account133ID")]
    [StringLength(20)]
    [Unicode(false)]
    public string Account133Id { get; set; } = null!;

    [Column("Account3331ID")]
    [StringLength(20)]
    [Unicode(false)]
    public string Account3331Id { get; set; } = null!;

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
}
