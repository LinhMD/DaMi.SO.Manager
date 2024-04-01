using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Keyless]
public partial class ViwItemType
{
    [Column("ItemTypeID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemTypeId { get; set; } = null!;

    [StringLength(150)]
    public string ItemTypeName { get; set; } = null!;

    [Column("OrderFormID")]
    [StringLength(20)]
    [Unicode(false)]
    public string OrderFormId { get; set; } = null!;

    public int SortOrder { get; set; }
}
