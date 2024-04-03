using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using DaMi.SO.Manager.Data.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Endpoints.OrderStatuses.DTO
{
    public class OrderStatusSView : IView<OrderStatus>, IDto
    {
        [DisplayName("Mã trạng thái đơn hàng")]
        [StringLength(20)]
        public string OrderStatusId { get; set; } = null!;

        [DisplayName("Tên trạng thái đơn hàng")]
        [StringLength(100)]
        public string OrderStatusName { get; set; } = null!;

        [DisplayName("Là trạng thái Đã duyệt")]
        public bool IsAcceptStatus { get; set; }

        [DisplayName("Là trạng thái Hủy")]
        public bool IsCancelStatus { get; set; }

        [DisplayName("Là trạng thái treo")]
        public bool IsSuspendStatus { get; set; }

        [DisplayName("Là trạng thái có thể thay đổi bởi NV Sales")]
        public bool CanChangeStatus { get; set; }

        public static void InitMapper()
        {
            TypeAdapterConfig<OrderStatus, OrderStatusSView>.NewConfig();
        }
    }
}