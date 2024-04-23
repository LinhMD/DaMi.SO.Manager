using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblNotifications")]
public class Notification
{
    [Key]
    [Column("RowUniqueID")]
    public Guid RowUniqueId { get; set; }

    public string? Message { get; set; }

    [Column("TargetEmployeeID")]
    [StringLength(20)]
    [Unicode(false)]
    public string TargetEmployeeId { get; set; } = null!;

    public bool HasSeen { get; set; }

    [StringLength(150)]
    public string? RedirectLink { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string MessageType { get; set; } = null!;

    [DisplayName("Ngày tạo")]
    public DateTime CreatedDate { get; set; }

    [DisplayName("Mã người tạo")]
    [Column("CreatedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CreatedUserId { get; set; } = null!;
}
