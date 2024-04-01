using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class Department
{
    public Guid RowUniqueId { get; set; }

    [DisplayName("Mã phòng ban")]
    public string DepartmentId { get; set; } = null!;

    [DisplayName("Tên phòng ban")]
    public string DepartmentName { get; set; } = null!;

    [DisplayName("Tên phòng ban 2")]
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

    public string? Notes { get; set; }

    [DisplayName("Ngày tạo")]
    public DateTime CreatedDate { get; set; }

    [DisplayName("Mã người tạo")]
    public string CreatedUserId { get; set; } = null!;

    [DisplayName("Ngày chỉnh sửa cuối cùng")]
    public DateTime LastModifiedDate { get; set; }

    [DisplayName("Mã người chỉnh sửa cuối cùng")]
    public string LastModifiedUserId { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Permision? Permision { get; set; }
}
