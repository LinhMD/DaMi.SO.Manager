using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class WhItemGroupLink
{
    /// <summary>
    /// Mã nhóm sản phẩm
    /// </summary>
    [DisplayName("Mã nhóm sản phẩm")]
    public string ItemGroupId { get; set; } = null!;

    /// <summary>
    /// Tên nhóm sản phẩm
    /// </summary>
    [DisplayName("Tên nhóm sản phẩm")]
    public string ItemGroupName { get; set; } = null!;

    /// <summary>
    /// Mã loại sản phẩm
    /// </summary>
    [DisplayName("Mã loại sản phẩm")]
    public string ItemTypeId { get; set; } = null!;

    /// <summary>
    /// Cho phép sửa lại tên hàng
    /// </summary>
    [DisplayName("Cho phép sửa lại tên hàng")]
    public bool AllowEditItemName { get; set; }

    /// <summary>
    /// Cho phép sửa lại thành tiền
    /// </summary>
    [DisplayName("Cho phép sửa lại thành tiền")]
    public bool AllowEditItemAmount { get; set; }

    public int SortOrder { get; set; }

    public virtual WhItemTypeLink ItemType { get; set; } = null!;

    public virtual ICollection<WhItemLink> WhItemLinks { get; set; } = new List<WhItemLink>();
}
