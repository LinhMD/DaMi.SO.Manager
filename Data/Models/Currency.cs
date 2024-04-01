using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class Currency
{
    [DisplayName("Loại tiền")]
    public string CurrencyId { get; set; } = null!;

    [DisplayName("Tên loại tiền")]
    public string CurrencyName { get; set; } = null!;

    [DisplayName("Tên loại tiền")]
    public string? CurrencyName2 { get; set; }

    public int SortOrder { get; set; }

    [DisplayName("Mã định dạng đơn giá")]
    public string PriceNumberFormat { get; set; } = null!;

    [DisplayName("Mã định dạng số tiền")]
    public string AmountNumberFormat { get; set; } = null!;

    public byte PriceDecimalPlaces { get; set; }

    public byte AmountDecimalPlaces { get; set; }

    public string? UnitName { get; set; }
}
