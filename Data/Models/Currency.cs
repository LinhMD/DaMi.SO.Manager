using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblCurrencyList")]
public partial class Currency
{
    [DisplayName("Loại tiền")]
    [Key]
    [Column("CurrencyID")]
    [StringLength(3)]
    [Unicode(false)]
    public string CurrencyId { get; set; } = null!;

    [DisplayName("Tên loại tiền")]
    [StringLength(50)]
    public string CurrencyName { get; set; } = null!;

    [DisplayName("Tên loại tiền")]
    [StringLength(50)]
    public string? CurrencyName2 { get; set; }

    public int SortOrder { get; set; }

    [DisplayName("Mã định dạng đơn giá")]
    [StringLength(15)]
    [Unicode(false)]
    public string PriceNumberFormat { get; set; } = null!;

    [DisplayName("Mã định dạng số tiền")]
    [StringLength(15)]
    [Unicode(false)]
    public string AmountNumberFormat { get; set; } = null!;

    public byte PriceDecimalPlaces { get; set; }

    public byte AmountDecimalPlaces { get; set; }

    [StringLength(30)]
    public string? UnitName { get; set; }
}
