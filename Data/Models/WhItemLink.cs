using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class WhItemLink
{
    public Guid RowUniqueId { get; set; }

    /// <summary>
    /// Mã sản phẩm
    /// </summary>
    [DisplayName("Mã sản phẩm")]
    public string ItemId { get; set; } = null!;

    /// <summary>
    /// Tên sản phẩm
    /// </summary>
    [DisplayName("Tên sản phẩm")]
    public string ItemName { get; set; } = null!;

    /// <summary>
    /// Mã đơn vị tính
    /// </summary>
    [DisplayName("Mã đơn vị tính")]
    public string? InvUnitOfMeasr { get; set; }

    /// <summary>
    /// Mã nhóm sản phẩm
    /// </summary>
    [DisplayName("Mã nhóm sản phẩm")]
    public string? ItemGroupId { get; set; }

    /// <summary>
    /// Ngôn ngữ
    /// </summary>
    [DisplayName("Ngôn ngữ")]
    public string? Language { get; set; }

    /// <summary>
    /// Là trả tiền 1 lần
    /// </summary>
    [DisplayName("Là trả tiền 1 lần")]
    public bool IsPayFull { get; set; }

    /// <summary>
    /// Là trả tiền theo năm
    /// </summary>
    [DisplayName("Là trả tiền theo năm")]
    public bool IsPayYear { get; set; }

    /// <summary>
    /// Số lượng mã số thuế (mặc định)
    /// </summary>
    [DisplayName("Số lượng mã số thuế (mặc định)")]
    public int DefNumOfTaxCode { get; set; }

    /// <summary>
    /// Số lượng hệ thống (mặc định)
    /// </summary>
    [DisplayName("Số lượng hệ thống (mặc định)")]
    public int DefNumOfData { get; set; }

    /// <summary>
    /// Số lượng hóa đơn (mặc định)
    /// </summary>
    [DisplayName("Số lượng hóa đơn (mặc định)")]
    public int DefNumOfInv { get; set; }

    /// <summary>
    /// Số lượng User (mặc định)
    /// </summary>
    [DisplayName("Số lượng User (mặc định)")]
    public int DefNumOfUser { get; set; }

    /// <summary>
    /// Số lượng máy tính (mặc định)
    /// </summary>
    [DisplayName("Số lượng máy tính (mặc định)")]
    public int DefNumOfPc { get; set; }

    /// <summary>
    /// Dung lượng lưu trữ iCloud (GB) (mặc định)
    /// </summary>
    [DisplayName("Dung lượng lưu trữ iCloud (GB) (mặc định)")]
    public int DefiCloudDataSize { get; set; }

    /// <summary>
    /// Số lượng tháng (mặc định)
    /// </summary>
    [DisplayName("Số lượng tháng (mặc định)")]
    public int DefNumOfMonth { get; set; }

    /// <summary>
    /// Thuế suất (%)
    /// </summary>
    [DisplayName("Thuế suất (%)")]
    public decimal TaxRate { get; set; }

    /// <summary>
    /// Mã TK
    /// </summary>
    [DisplayName("Mã TK")]
    public string AccountId { get; set; } = null!;

    /// <summary>
    /// TK632
    /// </summary>
    [DisplayName("TK632")]
    public string Account632Id { get; set; } = null!;

    /// <summary>
    /// TK511
    /// </summary>
    [DisplayName("TK511")]
    public string Account511Id { get; set; } = null!;

    /// <summary>
    /// TK133
    /// </summary>
    [DisplayName("TK133")]
    public string Account133Id { get; set; } = null!;

    /// <summary>
    /// TK3331
    /// </summary>
    [DisplayName("TK3331")]
    public string Account3331Id { get; set; } = null!;

    /// <summary>
    /// Thứ tự sắp xếp
    /// </summary>
    [DisplayName("Thứ tự sắp xếp")]
    public int SortOrder { get; set; }

    /// <summary>
    /// Đơn giá VND
    /// </summary>
    [DisplayName("Đơn giá VND")]
    public double ConvertPrice { get; set; }

    /// <summary>
    /// Đơn giá USD
    /// </summary>
    [DisplayName("Đơn giá USD")]
    public double OriginalPrice { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [DisplayName("Ghi chú")]
    public string? Notes { get; set; }

    /// <summary>
    /// Có hiệu lực
    /// </summary>
    [DisplayName("Có hiệu lực")]
    public bool InActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    public string LastModifiedUserId { get; set; } = null!;

    public virtual WhUnitOfMeasrLink? InvUnitOfMeasrNavigation { get; set; }

    public virtual WhItemGroupLink? ItemGroup { get; set; }

    public virtual ICollection<ComputerItemMap> ComputerItemMaps { get; set; } = new List<ComputerItemMap>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
