using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Keyless]
public partial class ViwOrderMasterDetail
{
    [StringLength(20)]
    [Unicode(false)]
    public string? OrderNo { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? BeginExecDate { get; set; }

    public DateTime? EndExecDate { get; set; }

    public DateOnly? OverDate { get; set; }

    [Column("OrderTypeID")]
    [StringLength(20)]
    [Unicode(false)]
    public string OrderTypeId { get; set; } = null!;

    [StringLength(100)]
    public string? OrderTypeName { get; set; }

    [Column("OrderFormID")]
    [StringLength(20)]
    [Unicode(false)]
    public string OrderFormId { get; set; } = null!;

    [StringLength(400)]
    public string? Description { get; set; }

    [Column("CustomerID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CustomerId { get; set; } = null!;

    [StringLength(250)]
    public string? CustomerName { get; set; }

    [StringLength(40)]
    public string? TradeName { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? TaxCode { get; set; }

    [StringLength(250)]
    public string? Address1 { get; set; }

    [StringLength(60)]
    public string? RefPerson { get; set; }

    [StringLength(40)]
    public string? RefPos { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ContractNo { get; set; }

    public DateOnly? ContractDate { get; set; }

    [StringLength(40)]
    public string? SalesManName { get; set; }

    [StringLength(40)]
    public string? Executor { get; set; }

    public int LineNumber { get; set; }

    [Column("ItemID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemId { get; set; } = null!;

    [StringLength(250)]
    public string? ItemName { get; set; }

    [StringLength(50)]
    public string? UnitName { get; set; }

    public int NumOfTaxCode { get; set; }

    public int NumOfData { get; set; }

    public int NumOfInv { get; set; }

    public int NumOfUser { get; set; }

    [Column("NumOfPC")]
    public int NumOfPc { get; set; }

    [Column("iCloudDataSize")]
    public int ICloudDataSize { get; set; }

    public int NumOfMonth { get; set; }


    public DateTime? StartDate { get; set; }

    [Column("CurrencyID")]
    [StringLength(3)]
    [Unicode(false)]
    public string CurrencyId { get; set; } = null!;

    [Column(TypeName = "smallmoney")]
    public decimal ExchangeRate { get; set; }

    public double Quantity { get; set; }

    public double ConvertPrice { get; set; }

    public double OriginalPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal ConvertAmount { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal TaxRate { get; set; }

    [Column(TypeName = "money")]
    public decimal ConvertTaxAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal ConvertTotalAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal CnvPaymentAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal OriginalAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal OriginalTaxAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal OriginalTotalAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal OrgPaymentAmount { get; set; }

    public double DiscountPercent { get; set; }

    [Column(TypeName = "money")]
    public decimal ConvertDiscAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal OriginalDiscAmount { get; set; }

    [Column("HasInvoiceVAT")]
    public bool HasInvoiceVat { get; set; }

    public bool IsPriceAfterTax { get; set; }

    public bool HasDiscount { get; set; }

    [StringLength(100)]
    public string PaymentMethodName { get; set; } = null!;

    [StringLength(150)]
    public string? PaymentTerms { get; set; }

    [StringLength(100)]
    public string? OrderStatusName { get; set; }

    public bool? IsAcceptStatus { get; set; }

    public bool? IsCancelStatus { get; set; }

    public bool? IsSuspendStatus { get; set; }

    public bool? CanChangeStatus { get; set; }

    public bool PublishedInvoice { get; set; }

    public bool Paymented { get; set; }

    public bool Accepted { get; set; }

    [Column("AccepterID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? AccepterId { get; set; }

    public DateTime? AcceptedDate { get; set; }

    public bool IsCancel { get; set; }

    public DateTime? CancelOrderDate { get; set; }

    public bool IsExecuting { get; set; }

    public bool FinishOk { get; set; }

    [StringLength(250)]
    public string? Notes { get; set; }

    [Column("SubCompanyID")]
    [StringLength(20)]
    [Unicode(false)]
    public string SubCompanyId { get; set; } = null!;

    public int? TranYear { get; set; }

    public int? TranMonth { get; set; }

    [Column("OrderID")]
    public Guid OrderId { get; set; }

    [Column("OrderDetailID")]
    public Guid OrderDetailId { get; set; }
}
