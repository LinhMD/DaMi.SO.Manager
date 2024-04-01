using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Keyless]
public partial class ViwUnitOfMeasr
{
    [Column("UnitID")]
    [StringLength(20)]
    [Unicode(false)]
    public string UnitId { get; set; } = null!;

    [StringLength(50)]
    public string? UnitName { get; set; }
}
