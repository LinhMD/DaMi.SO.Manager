using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class ViwOrderMasterDetail
{
    public string? OrderNo { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? BeginExecDate { get; set; }

    public DateTime? EndExecDate { get; set; }

    public DateOnly? OverDate { get; set; }

    public string OrderTypeId { get; set; } = null!;

    public string? OrderTypeName { get; set; }

    public string OrderFormId { get; set; } = null!;

    public string? Description { get; set; }

    public string CustomerId { get; set; } = null!;

    public string? CustomerName { get; set; }

    public string? TradeName { get; set; }

    public string? TaxCode { get; set; }

    public string? Address1 { get; set; }

    public string? RefPerson { get; set; }

    public string? RefPos { get; set; }

    public string? ContractNo { get; set; }

    public DateOnly? ContractDate { get; set; }

    public string? SalesManName { get; set; }

    public string? Executor { get; set; }

    public int LineNumber { get; set; }

    public string ItemId { get; set; } = null!;

    public string? ItemName { get; set; }

    public string? UnitName { get; set; }

    public int NumOfTaxCode { get; set; }

    public int NumOfData { get; set; }

    public int NumOfInv { get; set; }

    public int NumOfUser { get; set; }

    public int NumOfPc { get; set; }

    public int ICloudDataSize { get; set; }

    public int NumOfMonth { get; set; }

    public DateTime? StartDate { get; set; }

    public string CurrencyId { get; set; } = null!;

    public decimal ExchangeRate { get; set; }

    public double Quantity { get; set; }

    public double ConvertPrice { get; set; }

    public double OriginalPrice { get; set; }

    public decimal ConvertAmount { get; set; }

    public decimal TaxRate { get; set; }

    public decimal ConvertTaxAmount { get; set; }

    public decimal ConvertTotalAmount { get; set; }

    public decimal CnvPaymentAmount { get; set; }

    public decimal OriginalAmount { get; set; }

    public decimal OriginalTaxAmount { get; set; }

    public decimal OriginalTotalAmount { get; set; }

    public decimal OrgPaymentAmount { get; set; }

    public double DiscountPercent { get; set; }

    public decimal ConvertDiscAmount { get; set; }

    public decimal OriginalDiscAmount { get; set; }

    public bool HasInvoiceVat { get; set; }

    public bool IsPriceAfterTax { get; set; }

    public bool HasDiscount { get; set; }

    public string PaymentMethodName { get; set; } = null!;

    public string? PaymentTerms { get; set; }

    public string? OrderStatusName { get; set; }

    public bool? IsAcceptStatus { get; set; }

    public bool? IsCancelStatus { get; set; }

    public bool? IsSuspendStatus { get; set; }

    public bool? CanChangeStatus { get; set; }

    public bool PublishedInvoice { get; set; }

    public bool Paymented { get; set; }

    public bool Accepted { get; set; }

    public string? AccepterId { get; set; }

    public DateTime? AcceptedDate { get; set; }

    public bool IsCancel { get; set; }

    public DateTime? CancelOrderDate { get; set; }

    public bool IsExecuting { get; set; }

    public bool FinishOk { get; set; }

    public string? Notes { get; set; }

    public string SubCompanyId { get; set; } = null!;

    public int? TranYear { get; set; }

    public int? TranMonth { get; set; }

    public Guid OrderId { get; set; }

    public Guid OrderDetailId { get; set; }
}
