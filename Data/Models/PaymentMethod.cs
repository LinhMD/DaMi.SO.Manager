using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class PaymentMethod
{
    [DisplayName("Mã hình thức thanh toán")]
    public string PaymentMethodId { get; set; } = null!;

    [DisplayName("Tên hình thức thanh toán")]
    public string PaymentMethodName { get; set; } = null!;

    [DisplayName("Tài khoản đối ứng (111, 112, 131, ...)")]
    public string? PayAcctId { get; set; }

    [DisplayName("Hình thức trả chậm")]
    public bool IsDebit { get; set; }

    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
