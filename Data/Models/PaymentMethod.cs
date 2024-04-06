using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblPaymentMethodList")]
public partial class PaymentMethod
{
    [DisplayName("Mã hình thức thanh toán")]
    [Key]
    [Column("PaymentMethodID")]
    [StringLength(20)]
    [Unicode(false)]
    public string PaymentMethodId { get; set; } = null!;

    [DisplayName("Tên hình thức thanh toán")]
    [StringLength(100)]
    public string PaymentMethodName { get; set; } = null!;

    [DisplayName("Tài khoản đối ứng (111, 112, 131, ...)")]
    [Column("PayAcctID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PayAcctId { get; set; }

    [DisplayName("Hình thức trả chậm")]
    public bool IsDebit { get; set; }

    [InverseProperty("PaymentMethod")]
    public virtual IEnumerable<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
