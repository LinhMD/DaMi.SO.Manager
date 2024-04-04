using System.ComponentModel;
using CrudApiTemplate.Request;
using CrudApiTemplate.View;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Endpoints.OrderDetails.DTO;
using DaMi.SO.Manager.Endpoints.OrderStatuses.DTO;
using Mapster;

namespace DaMi.SO.Manager.Endpoints.OrderMasters.DTO
{
    public class OrderMasterDetailView : IView<OrderMaster>, IUpdateRequest<OrderMaster>, ICreateRequest<OrderMaster>
    {
        public Guid? RowUniqueId { get; set; }

        [DisplayName("Kiểu đơn hàng")]
        public string? OrderFormId { get; set; } = null!;
        [DisplayName("Loại đơn hàng")]
        public string? OrderTypeId { get; set; } = null!;
        [DisplayName("Số đơn hàng")]
        public string? OrderNo { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime? OrderDate { get; set; }
        [DisplayName("Trạng thái ĐH")]
        public string? OrderStatusId { get; set; } = null!;
        public OrderStatusSView? OrderStatus { get; set; } = null!;

        [DisplayName("Mã khách hàng")]
        public string? CustomerId { get; set; } = null!;
        [DisplayName("MST/CCCD")]
        [AdaptIgnore]
        public string? TaxCode { get; set; } = null!;
        [DisplayName("Điện thoại")]

        [AdaptIgnore]
        public string? Phone { get; set; }
        [DisplayName("Người đại diện")]
        public string? RefPerson { get; set; }
        [DisplayName("Chức vụ")]
        public string? RefPos { get; set; }
        [DisplayName("Số hợp đồng")]
        public string? ContractNo { get; set; }
        [DisplayName("Ngày hợp đồng")]
        public DateOnly? ContractDate { get; set; }

        [DisplayName("Nhân viên triển khai")]
        public string? ExecutorId { get; set; }
        [DisplayName("Ngày BĐ triển khai")]
        public DateTime? BeginExecDate { get; set; }
        [DisplayName("Ngày KT triển khai")]
        public DateTime? EndExecDate { get; set; }
        [DisplayName("Nhân viên bán hàng")]
        public string? SalesManId { get; set; }

        [DisplayName("Loại tiền")]
        public string? CurrencyId { get; set; } = null!;
        [DisplayName("Tỷ giá")]
        public decimal? ExchangeRate { get; set; }
        [DisplayName("Cộng thành tiền")]
        public decimal? ConvertTotalAmount { get; set; }
        [DisplayName("Cộng tiền thuế VAT")]
        public decimal? ConvertTaxAmount { get; set; }
        [DisplayName("Cộng tiền CK")]
        public decimal? ConvertDiscAmount { get; set; }
        //Tổng tiền thanh toán = ConvertTotalAmount + ConvertTaxAmount - ConvertDiscAmount
        [DisplayName("Tổng số tiền")]
        public decimal? TotalAmount { get; set; }
        [DisplayName("Hạn thanh toán")]
        public DateOnly? OverDate { get; set; }
        [DisplayName("Có hóa đơn GTGT")]
        public bool HasInvoiceVat { get; set; } = false;
        [DisplayName("Hình thức thanh toán")]
        public string? PaymentMethodId { get; set; }
        [DisplayName("Điều khoản thanh toán")]
        public string? PaymentTerms { get; set; }

        [DisplayName("Diễn giải")]
        public string? Description { get; set; }

        [DisplayName("Ghi chú")]
        public string? Notes { get; set; }

        public IEnumerable<OrderDetailSimpleView> OrderDetails { get; set; } = [];

        public static void InitMapper()
        {
            TypeAdapterConfig<OrderMaster, OrderMasterDetailView>.NewConfig();

            TypeAdapterConfig<OrderMasterDetailView, OrderMaster>.NewConfig();
        }
    }
}