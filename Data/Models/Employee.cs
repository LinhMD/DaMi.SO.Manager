using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class Employee
{
    public Guid RowUniqueId { get; set; }

    [DisplayName("Mã nhân viên")]
    public string EmployeeId { get; set; } = null!;

    [DisplayName("Tên nhân viên")]
    public string EmployeeName { get; set; } = null!;

    [DisplayName("Tên nhân viên")]
    public string? EmployeeName2 { get; set; }

    [DisplayName("Tên nhân viên rút gọn")]
    public string? EmployeeBriefName { get; set; }

    [DisplayName("Tên nhân viên rút gọn 2")]
    public string? EmployeeBriefName2 { get; set; }

    [DisplayName("Mã phòng ban")]
    public string DepartmentId { get; set; } = null!;

    [DisplayName("Điện thoại cơ quan")]
    public string? OfficePhone { get; set; }

    [DisplayName("Điện thoại nhà riêng")]
    public string? HomePhone { get; set; }

    [DisplayName("Địa chỉ nhà riêng")]
    public string? HomeAddress { get; set; }

    public string? Email { get; set; }

    public string? EmployeePassword { get; set; }

    [DisplayName("Thứ tự sắp xếp")]
    public int SortOrder { get; set; }

    [DisplayName("Hình chữ ký")]
    public byte[]? SignPicture { get; set; }

    [DisplayName("Ghi chú")]
    public string? Notes { get; set; }

    public bool InActive { get; set; }

    [DisplayName("Ngày tạo")]
    public DateTime CreatedDate { get; set; }

    [DisplayName("Mã người tạo")]
    public string CreatedUserId { get; set; } = null!;

    [DisplayName("Ngày chỉnh sửa cuối cùng")]
    public DateTime LastModifiedDate { get; set; }

    [DisplayName("Mã người chỉnh sửa cuối cùng")]
    public string LastModifiedUserId { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<OrderMaster> OrderMasterExecutors { get; set; } = new List<OrderMaster>();

    public virtual ICollection<OrderMaster> OrderMasterSalesMen { get; set; } = new List<OrderMaster>();
}
