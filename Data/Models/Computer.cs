using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblComputerList")]
public partial class Computer
{
    [DisplayName("Mã máy tính")]
    [Key]
    [Column("ComputerID")]
    [StringLength(100)]
    [Unicode(false)]
    public string ComputerId { get; set; } = null!;

    [DisplayName("Tên máy tính")]
    [StringLength(60)]
    public string ComputerName { get; set; } = null!;

    [DisplayName("Địa chỉ IP máy tính")]
    [Column("IPAddr")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Ipaddr { get; set; }

    [DisplayName("Hệ điều hành")]
    [StringLength(100)]
    public string? OperatingSystem { get; set; }

    [DisplayName("Thông tin phần cứng")]
    [StringLength(200)]
    public string? HardwareInfo { get; set; }

    [DisplayName("Mã khách hàng")]
    [Column("CustomerID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CustomerId { get; set; } = null!;

    [InverseProperty("Computer")]
    public virtual IEnumerable<ComputerItemMap> ComputerItemMaps { get; set; } = new List<ComputerItemMap>();
}
