using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class PaymentMethod
{
    /// <summary>
    /// Mã hình thức thanh toán
    /// </summary>
    [DisplayName("Mã hình thức thanh toán")]
    public string PaymentMethodId { get; set; } = null!;

    /// <summary>
    /// Tên hình thức thanh toán
    /// </summary>
    [DisplayName("Tên hình thức thanh toán")]
    public string PaymentMethodName { get; set; } = null!;

    /// <summary>
    /// Tài khoản đối ứng (111, 112, 131, ...)
    /// </summary>
    [DisplayName("Tài khoản đối ứng (111, 112, 131, ...)")]
    public string? PayAcctId { get; set; }

    /// <summary>
    /// Hình thức trả chậm
    /// </summary>
    [DisplayName("Hình thức trả chậm")]
    public bool IsDebit { get; set; }

    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
