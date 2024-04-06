using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblDepartmentList")]
[Index("DepartmentId", Name = "UK_tblDepartmentList", IsUnique = true)]
public partial class Department
{
    [Key]
    [Column("RowUniqueID")]
    public Guid RowUniqueId { get; set; }

    [DisplayName("Mã phòng ban")]
    [Column("DepartmentID")]
    [StringLength(20)]
    [Unicode(false)]
    public string DepartmentId { get; set; } = null!;

    [DisplayName("Tên phòng ban")]
    [StringLength(100)]
    public string DepartmentName { get; set; } = null!;

    [DisplayName("Tên phòng ban 2")]
    [StringLength(100)]
    public string? DepartmentName2 { get; set; }

    public bool IsSystem { get; set; }

    public bool IsAdmin { get; set; }

    [DisplayName("Phong Kinh doanh")]
    public bool IsSales { get; set; }

    [DisplayName("Phong Trien khai")]
    public bool IsInstall { get; set; }

    [DisplayName("Phong Lap trinh")]
    public bool IsDeveloper { get; set; }

    [DisplayName("Phong Ke toan")]
    public bool IsAccounting { get; set; }

    [Column("PermisionID")]
    [StringLength(20)]
    [Unicode(false)]
    public string PermisionId { get; set; } = null!;

    [StringLength(100)]
    public string? Notes { get; set; }

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

    [ForeignKey("PermisionId")]
    [InverseProperty("Departments")]
    public virtual Permision Permision { get; set; } = null!;

    [InverseProperty("Department")]
    public virtual IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
}
