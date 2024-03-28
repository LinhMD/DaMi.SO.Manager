using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class ViwItemType
{
    public string ItemTypeId { get; set; } = null!;

    public string ItemTypeName { get; set; } = null!;

    public string OrderFormId { get; set; } = null!;
}
