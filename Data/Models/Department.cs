using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class Department
{
    public Guid RowUniqueId { get; set; }

    /// <summary>
    /// Mã phòng ban
    /// </summary>
    [DisplayName("Mã phòng ban")]
    public string DepartmentId { get; set; } = null!;

    /// <summary>
    /// Tên phòng ban
    /// </summary>
    [DisplayName("Tên phòng ban")]
    public string DepartmentName { get; set; } = null!;

    /// <summary>
    /// Tên phòng ban
    /// </summary>
    [DisplayName("Tên phòng ban")]
    public string? DepartmentName2 { get; set; }

    public bool IsSystem { get; set; }

    public bool IsAdmin { get; set; }

    /// <summary>
    /// Phong Kinh doanh
    /// </summary>
    [DisplayName("Phong Kinh doanh")]
    public bool IsSales { get; set; }

    /// <summary>
    /// Phong Trien khai
    /// </summary>
    [DisplayName("Phong Trien khai")]
    public bool IsInstall { get; set; }

    /// <summary>
    /// Phong Lap trinh
    /// </summary>
    [DisplayName("Phong Lap trinh")]
    public bool IsDeveloper { get; set; }

    /// <summary>
    /// Phong Ke toan
    /// </summary>
    [DisplayName("Phong Ke toan")]
    public bool IsAccounting { get; set; }

    public string? Notes { get; set; }

    /// <summary>
    /// Ngày tạo
    /// </summary>
    [DisplayName("Ngày tạo")]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Mã người tạo
    /// </summary>
    [DisplayName("Mã người tạo")]
    public string CreatedUserId { get; set; } = null!;

    /// <summary>
    /// Ngày chỉnh sửa cuối cùng
    /// </summary>
    [DisplayName("Ngày chỉnh sửa cuối cùng")]
    public DateTime LastModifiedDate { get; set; }

    /// <summary>
    /// Mã người chỉnh sửa cuối cùng
    /// </summary>
    [DisplayName("Mã người chỉnh sửa cuối cùng")]
    public string LastModifiedUserId { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
