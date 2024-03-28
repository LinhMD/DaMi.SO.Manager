using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class CustomerLink
{
    /// <summary>
    /// Mã khách hàng
    /// </summary>
    [DisplayName("Mã khách hàng")]
    public string CustomerId { get; set; } = null!;

    /// <summary>
    /// Tên khách hàng
    /// </summary>
    [DisplayName("Tên khách hàng")]
    public string CustomerName { get; set; } = null!;

    /// <summary>
    /// Tên rút gọn
    /// </summary>
    [DisplayName("Tên rút gọn")]
    public string TradeName { get; set; } = null!;

    /// <summary>
    /// Mã số thuế
    /// </summary>
    [DisplayName("Mã số thuế")]
    public string? TaxCode { get; set; }

    /// <summary>
    /// Mã nhóm khách hàng
    /// </summary>
    [DisplayName("Mã nhóm khách hàng")]
    public string? CustomerGroupId { get; set; }

    /// <summary>
    /// Là khách hàng
    /// </summary>
    [DisplayName("Là khách hàng")]
    public bool IsCustomer { get; set; }

    /// <summary>
    /// Là người bán
    /// </summary>
    [DisplayName("Là người bán")]
    public bool IsVendor { get; set; }

    /// <summary>
    /// Là cá nhân
    /// </summary>
    [DisplayName("Là cá nhân")]
    public bool IsPersonal { get; set; }

    /// <summary>
    /// Số điện thoại
    /// </summary>
    [DisplayName("Số điện thoại")]
    public string? Phone { get; set; }

    /// <summary>
    /// Di động
    /// </summary>
    [DisplayName("Di động")]
    public string? Mobile { get; set; }

    /// <summary>
    /// Fax
    /// </summary>
    [DisplayName("Fax")]
    public string? Fax { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [DisplayName("Email")]
    public string? Email { get; set; }

    /// <summary>
    /// Website
    /// </summary>
    [DisplayName("Website")]
    public string? Website { get; set; }

    /// <summary>
    /// Địa chỉ 1
    /// </summary>
    [DisplayName("Địa chỉ 1")]
    public string Address1 { get; set; } = null!;

    /// <summary>
    /// Địa chỉ 2
    /// </summary>
    [DisplayName("Địa chỉ 2")]
    public string? Address2 { get; set; }

    /// <summary>
    /// Địa chỉ rút gọn
    /// </summary>
    [DisplayName("Địa chỉ rút gọn")]
    public string? TradeAddress { get; set; }

    public string? TranAddress { get; set; }

    /// <summary>
    /// Người liên hệ
    /// </summary>
    [DisplayName("Người liên hệ")]
    public string ContactPerson { get; set; } = null!;

    /// <summary>
    /// Chức vụ người liên hệ
    /// </summary>
    [DisplayName("Chức vụ người liên hệ")]
    public string? ContactPersonPos { get; set; }

    /// <summary>
    /// Thứ tự sắp xếp
    /// </summary>
    [DisplayName("Thứ tự sắp xếp")]
    public long SortOrder { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    public string LastModifiedUserId { get; set; } = null!;

    public virtual ICollection<CustomerUser> CustomerUsers { get; set; } = new List<CustomerUser>();

    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();

    public virtual ICollection<TaxCode> TaxCodes { get; set; } = new List<TaxCode>();
}
