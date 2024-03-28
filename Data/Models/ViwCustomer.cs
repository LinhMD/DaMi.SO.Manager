using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class ViwCustomer
{
    public string CustomerId { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string TradeName { get; set; } = null!;

    public string? TaxCode { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string? TradeAddress { get; set; }

    public string? TranAddress { get; set; }

    public string ContactPerson { get; set; } = null!;

    public string? ContactPersonPos { get; set; }

    public long SortOrder { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    public string LastModifiedUserId { get; set; } = null!;
}
