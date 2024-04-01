using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class ComputerItemMap
{
    public Guid RowUniqueId { get; set; }

    [DisplayName("Mã máy tính")]
    public string ComputerId { get; set; } = null!;

    [DisplayName("Mã Vật tư sản phẩm hàng hóa")]
    public string ItemId { get; set; } = null!;

    [DisplayName("Mã số thuế")]
    public string TaxCode { get; set; } = null!;

    [DisplayName("Ngày bắt đầu")]
    public DateTime? StartDate { get; set; }

    [DisplayName("Ngày kết thúc")]
    public DateTime? EndDate { get; set; }

    [DisplayName("Mã đơn đặt hàng chi tiết")]
    public Guid? OrderDetailId { get; set; }

    [DisplayName("Có hiệu lực")]
    public bool Actived { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public virtual Computer Computer { get; set; } = null!;

    public virtual OrderDetail? OrderDetail { get; set; }

    public virtual TaxCode TaxCodeNavigation { get; set; } = null!;
}
