using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class WhItemTypeLink
{
    /// <summary>
    /// Mã loại sản phẩm
    /// </summary>
    [DisplayName("Mã loại sản phẩm")]
    public string ItemTypeId { get; set; } = null!;

    /// <summary>
    /// Tên loại sản phẩm
    /// </summary>
    [DisplayName("Tên loại sản phẩm")]
    public string ItemTypeName { get; set; } = null!;

    /// <summary>
    /// Mã giao diện nhập liệu
    /// </summary>
    [DisplayName("Mã giao diện nhập liệu")]
    public string OrderFormId { get; set; } = null!;

    public int SortOrder { get; set; }

    public virtual OrderForm OrderForm { get; set; } = null!;

    public virtual ICollection<WhItemGroupLink> WhItemGroupLinks { get; set; } = new List<WhItemGroupLink>();
}
