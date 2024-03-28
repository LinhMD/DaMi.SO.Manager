using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class ViwFullItem
{
    public Guid RowUniqueId { get; set; }

    public string ItemId { get; set; } = null!;

    public string ItemName { get; set; } = null!;

    public string? InvUnitOfMeasr { get; set; }

    public string UnitName { get; set; } = null!;

    public string ItemGroupId { get; set; } = null!;

    public string ItemGroupName { get; set; } = null!;

    public bool AllowEditItemName { get; set; }

    public bool AllowEditItemAmount { get; set; }

    public string ItemTypeId { get; set; } = null!;

    public string ItemTypeName { get; set; } = null!;

    public string OrderFormId { get; set; } = null!;

    public string OrderFormName { get; set; } = null!;

    public bool HasByTime { get; set; }

    public bool HasByTaxCode { get; set; }

    public bool HasByQtyInvc { get; set; }

    public bool HasByDiskSize { get; set; }

    public bool HasByPc { get; set; }

    public bool HasByUser { get; set; }

    public string? Language { get; set; }

    public bool IsPayFull { get; set; }

    public bool IsPayYear { get; set; }

    public int DefNumOfTaxCode { get; set; }

    public int DefNumOfData { get; set; }

    public int DefNumOfInv { get; set; }

    public int DefNumOfUser { get; set; }

    public int DefNumOfPc { get; set; }

    public int DefiCloudDataSize { get; set; }

    public int DefNumOfMonth { get; set; }

    public decimal TaxRate { get; set; }

    public string AccountId { get; set; } = null!;

    public int SortOrder { get; set; }

    public double ConvertPrice { get; set; }

    public double OriginalPrice { get; set; }

    public string? Notes { get; set; }

    public bool InActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    public string LastModifiedUserId { get; set; } = null!;
}
