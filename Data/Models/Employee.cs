using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblEmployeeList")]
[Index("EmployeeId", Name = "UK_tblEmployeeList", IsUnique = true)]
public partial class Employee
{
    [Key]
    [Column("RowUniqueID")]
    public Guid RowUniqueId { get; set; }

    [DisplayName("Mã nhân viên")]
    [Column("EmployeeID")]
    [StringLength(20)]
    [Unicode(false)]
    public string EmployeeId { get; set; } = null!;

    [DisplayName("Tên nhân viên")]
    [StringLength(100)]
    public string EmployeeName { get; set; } = null!;

    [DisplayName("Tên nhân viên")]
    [StringLength(100)]
    public string? EmployeeName2 { get; set; }

    [DisplayName("Tên nhân viên rút gọn")]
    [StringLength(40)]
    public string? EmployeeBriefName { get; set; }

    [DisplayName("Tên nhân viên rút gọn 2")]
    [StringLength(40)]
    public string? EmployeeBriefName2 { get; set; }

    [DisplayName("Mã phòng ban")]
    [Column("DepartmentID")]
    [StringLength(20)]
    [Unicode(false)]
    public string DepartmentId { get; set; } = null!;

    [DisplayName("Điện thoại cơ quan")]
    [StringLength(20)]
    [Unicode(false)]
    public string? OfficePhone { get; set; }

    [DisplayName("Điện thoại nhà riêng")]
    [StringLength(20)]
    [Unicode(false)]
    public string? HomePhone { get; set; }

    [DisplayName("Địa chỉ nhà riêng")]
    [StringLength(250)]
    public string? HomeAddress { get; set; }

    [StringLength(40)]
    public string? Email { get; set; }

    [StringLength(64)]
    public string? PwHash { get; set; }

    [StringLength(10)]
    public string? PwSalt { get; set; }

    [DisplayName("Thứ tự sắp xếp")]
    public int SortOrder { get; set; }

    [DisplayName("Hình chữ ký")]
    public byte[]? SignPicture { get; set; }

    [DisplayName("Ghi chú")]
    [StringLength(100)]
    public string? Notes { get; set; }

    public bool InActive { get; set; }

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

    [ForeignKey("DepartmentId")]
    [InverseProperty("Employees")]
    public virtual Department Department { get; set; } = null!;

    [InverseProperty("Executor")]
    public virtual IEnumerable<OrderMaster> OrderMasterExecutors { get; set; } = new List<OrderMaster>();

    [InverseProperty("SalesMan")]
    public virtual IEnumerable<OrderMaster> OrderMasterSalesMen { get; set; } = new List<OrderMaster>();
}
