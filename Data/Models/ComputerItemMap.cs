using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class ComputerItemMap
{
    public Guid RowUniqueId { get; set; }

    public string ComputerId { get; set; } = null!;

    /// <summary>
    /// Mã Vật tư sản phẩm hàng hóa
    /// </summary>
    [DisplayName("Mã Vật tư sản phẩm hàng hóa")]
    public string ItemId { get; set; } = null!;

    public string TaxCode { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Mã đơn đặt hàng chi tiết
    /// </summary>
    [DisplayName("Mã đơn đặt hàng chi tiết")]
    public Guid? OrderDetailId { get; set; }

    public bool Actived { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public virtual Computer Computer { get; set; } = null!;

    public virtual WhItemLink Item { get; set; } = null!;

    public virtual OrderDetail? OrderDetail { get; set; }

    public virtual TaxCode TaxCodeNavigation { get; set; } = null!;
}
