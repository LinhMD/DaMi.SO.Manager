using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Keyless]
public partial class ViwCustomer
{
    [Column("CustomerID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CustomerId { get; set; } = null!;

    [StringLength(250)]
    public string CustomerName { get; set; } = null!;

    [StringLength(40)]
    public string TradeName { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? TaxCode { get; set; }

    public bool JustMeTaxCode { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? Mobile { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Fax { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? Website { get; set; }

    [StringLength(250)]
    public string Address1 { get; set; } = null!;

    [StringLength(200)]
    public string? Address2 { get; set; }

    [StringLength(250)]
    public string? TradeAddress { get; set; }

    [StringLength(200)]
    public string? TranAddress { get; set; }

    [StringLength(60)]
    public string ContactPerson { get; set; } = null!;

    [StringLength(60)]
    public string? ContactPersonPos { get; set; }

    public long SortOrder { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("CreatedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CreatedUserId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime LastModifiedDate { get; set; }

    [Column("LastModifiedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string LastModifiedUserId { get; set; } = null!;
}
