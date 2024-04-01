using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblComputerItemMap")]
[Index("ComputerId", "ItemId", "TaxCode", Name = "UK_tblComputerItemMap", IsUnique = true)]
public partial class ComputerItemMap
{
    [Key]
    [Column("RowUniqueID")]
    public Guid RowUniqueId { get; set; }

    [DisplayName("Mã máy tính")]
    [Column("ComputerID")]
    [StringLength(100)]
    [Unicode(false)]
    public string ComputerId { get; set; } = null!;

    [DisplayName("Mã Vật tư sản phẩm hàng hóa")]
    [Column("ItemID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemId { get; set; } = null!;

    [DisplayName("Mã số thuế")]
    [StringLength(20)]
    [Unicode(false)]
    public string TaxCode { get; set; } = null!;

    [DisplayName("Ngày bắt đầu")]
    public DateTime? StartDate { get; set; }

    [DisplayName("Ngày kết thúc")]
    public DateTime? EndDate { get; set; }

    [DisplayName("Mã đơn đặt hàng chi tiết")]
    [Column("OrderDetailID")]
    public Guid? OrderDetailId { get; set; }

    [DisplayName("Có hiệu lực")]
    public bool Actived { get; set; }

    public DateTime CreatedDate { get; set; }

    [Column("CreatedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CreatedUserId { get; set; } = null!;

    [ForeignKey("ComputerId")]
    [InverseProperty("ComputerItemMaps")]
    public virtual Computer Computer { get; set; } = null!;

    [ForeignKey("OrderDetailId")]
    [InverseProperty("ComputerItemMaps")]
    public virtual OrderDetail? OrderDetail { get; set; }

    [ForeignKey("TaxCode")]
    [InverseProperty("ComputerItemMaps")]
    public virtual TaxCode TaxCodeNavigation { get; set; } = null!;
}
