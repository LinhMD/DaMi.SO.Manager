using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblTaxCodeList")]
public partial class TaxCode
{
    [DisplayName("MST")]
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    [Column("TaxCode")]
    public string TaxCodeId { get; set; } = null!;

    [DisplayName("Tên công ty")]
    [StringLength(400)]
    public string? TaxCodeName { get; set; }

    [DisplayName("Địa chỉ")]
    [StringLength(400)]
    public string? TaxCodeAddr { get; set; }

    [DisplayName("Mã KH")]
    [Column("CustomerID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CustomerId { get; set; } = null!;

    [InverseProperty("TaxCodeNavigation")]
    public virtual ICollection<ComputerItemMap> ComputerItemMaps { get; set; } = new List<ComputerItemMap>();
}
