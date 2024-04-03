using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblPermisionList")]
[Index("PermisionId", Name = "UK_tblPermisionList", IsUnique = true)]
public partial class Permision
{
    [Key]
    [Column("RowUniqueID")]
    public Guid RowUniqueId { get; set; }

    [Column("PermisionID")]
    [StringLength(20)]
    [Unicode(false)]
    public string PermisionId { get; set; } = null!;

    [DisplayName("Quyền xem danh sách")]
    [Column("ViewList")]
    public bool View { get; set; }

    [DisplayName("Quyền thêm danh sách")]

    [Column("AddNewList")]
    public bool AddNew { get; set; }

    [Column("DeleteList")]
    [DisplayName("Quyền xóa danh sách")]
    public bool Delete { get; set; }

    [Column("UpdateList")]
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
    [Column("CreatedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CreatedUserId { get; set; } = null!;

    [DisplayName("Ngày chỉnh sửa cuối cùng")]
    public DateTime LastModifiedDate { get; set; }

    [DisplayName("Mã người chỉnh sửa cuối cùng")]
    [Column("LastModifiedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string LastModifiedUserId { get; set; } = null!;

    [InverseProperty("Permision")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
