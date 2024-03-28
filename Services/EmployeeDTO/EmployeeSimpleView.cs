using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.View;
using DaMi.SO.Manager.Data.Models;

namespace DaMi.SO.Manager.Services.EmployeeDTO;
public class EmployeeSimpleView : IView<Employee>
{
    public Guid RowUniqueId { get; set; }

    /// <summary>
    /// Mã nhân viên
    /// </summary>
    [DisplayName("Mã nhân viên")]
    public string EmployeeId { get; set; } = null!;

    /// <summary>
    /// Tên nhân viên
    /// </summary>
    [DisplayName("Tên nhân viên")]
    public string EmployeeName { get; set; } = null!;

    /// <summary>
    /// Tên nhân viên
    /// </summary>
    [DisplayName("Tên nhân viên")]
    public string? EmployeeName2 { get; set; }

    /// <summary>
    /// Tên nhân viên rút gọn
    /// </summary>
    [DisplayName("Tên nhân viên rút gọn")]
    public string? EmployeeBriefName { get; set; }

    /// <summary>
    /// Tên nhân viên rút gọn 2
    /// </summary>
    [DisplayName("Tên nhân viên rút gọn 2")]
    public string? EmployeeBriefName2 { get; set; }

    /// <summary>
    /// Mã phòng ban
    /// </summary>
    [DisplayName("Mã phòng ban")]
    public string DepartmentId { get; set; } = null!;

    /// <summary>
    /// Điện thoại cơ quan
    /// </summary>
    [DisplayName("Điện thoại cơ quan")]
    public string? OfficePhone { get; set; }

    /// <summary>
    /// Điện thoại nhà riêng
    /// </summary>
    [DataType(DataType.PhoneNumber)]
    [DisplayName("Điện thoại nhà riêng")]
    public string? HomePhone { get; set; }

    /// <summary>
    /// Địa chỉ nhà riêng
    /// </summary>
    [DisplayName("Địa chỉ nhà riêng")]
    public string? HomeAddress { get; set; }

    public string? Email { get; set; }

    public string? EmployeePassword { get; set; }

    /// <summary>
    /// Thứ tự sắp xếp
    /// </summary>
    [DisplayName("Thứ tự sắp xếp")]
    public int SortOrder { get; set; }

    /// <summary>
    /// Hình chữ ký
    /// </summary>
    [DisplayName("Hình chữ ký")]
    public byte[]? SignPicture { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [DisplayName("Ghi chú")]
    public string? Notes { get; set; }

    public bool InActive { get; set; }

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
}