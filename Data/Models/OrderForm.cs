using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class OrderForm
{
    [DisplayName("Mã kiểu đơn hàng")]
    public string OrderFormId { get; set; } = null!;

    [DisplayName("Tên kiểu đơn hàng")]
    public string OrderFormName { get; set; } = null!;

    [DisplayName("Có tính theo thời gian")]
    public bool HasByTime { get; set; }

    [DisplayName("Có tính theo MST")]
    public bool HasByTaxCode { get; set; }

    [DisplayName("Có tính theo số Data")]
    public bool HasByNumData { get; set; }

    [DisplayName("Có tính theo số lượng HĐ")]
    public bool HasByQtyInvc { get; set; }

    [DisplayName("Có tính theo dung lượng (GB)")]
    public bool HasByDiskSize { get; set; }

    [DisplayName("Có tính theo máy tính")]
    public bool HasByPc { get; set; }

    [DisplayName("Có tính theo User")]
    public bool HasByUser { get; set; }

    [DisplayName("Thứ tự sắp xếp")]
    public int SortOrder { get; set; }

    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
