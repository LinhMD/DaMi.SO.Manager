using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class Permision
{
    public Guid RowUniqueId { get; set; }

    [DisplayName("Mã phòng ban")]
    public string DepartmentId { get; set; } = null!;

    [DisplayName("Quyền xem danh sách")]
    public bool View { get; set; }

    [DisplayName("Quyền thêm danh sách")]
    public bool AddNew { get; set; }

    [DisplayName("Quyền xóa danh sách")]
    public bool Delete { get; set; }

    [DisplayName("Quyền sửa danh sách")]
    public bool Update { get; set; }

    [DisplayName("Quyền xem có giới hạn Đơn hàng")]
    public bool ViewLimitOrder { get; set; }

    [DisplayName("Quyền xem đầy đủ Đơn hàng")]
    public bool ViewFullOrder { get; set; }

    [DisplayName("Quyền thêm Đơn hàng")]
    public bool AddNewOrder { get; set; }

    [DisplayName("Quyền xóa Đơn hàng")]
    public bool DeleteOrder { get; set; }

    [DisplayName("Quyền sửa Đơn hàng")]
    public bool UpdateOrder { get; set; }

    [DisplayName("Quyền duyệt Đơn hàng")]
    public bool AcceptOrder { get; set; }

    [DisplayName("Quyền hủy Đơn hàng")]
    public bool CancelOrder { get; set; }

    [DisplayName("Quyền treo Đơn hàng")]
    public bool SuspendOrder { get; set; }

    [DisplayName("Quyền thay đổi trạng thái khác Đơn hàng")]
    public bool ChangeStatusOrder { get; set; }

    [DisplayName("Ngày tạo")]
    public DateTime CreatedDate { get; set; }

    [DisplayName("Mã người tạo")]
    public string CreatedUserId { get; set; } = null!;

    [DisplayName("Ngày chỉnh sửa cuối cùng")]
    public DateTime LastModifiedDate { get; set; }

    [DisplayName("Mã người chỉnh sửa cuối cùng")]
    public string LastModifiedUserId { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;
}
