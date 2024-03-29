using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using CrudApiTemplate.View;
using DaMi.SO.Manager.Data.Models;

namespace DaMi.SO.Manager.Services.OrderMasterDTO
{
    public class OrderMasterUpdate : IUpdateRequest<OrderMaster>, IView<OrderMaster>
    {
        public Guid RowUniqueId { get; set; }

        [DisplayName("Kiểu đơn hàng")]
        public string OrderFormId { get; set; } = null!;
        [DisplayName("Loại đơn hàng")]
        public string OrderTypeId { get; set; } = null!;
        [DisplayName("Số đơn hàng")]
        public string? OrderNo { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Trạng thái ĐH")]
        public string OrderStatusId { get; set; } = null!;

        [DisplayName("Mã khách hàng")]
        public string CustomerId { get; set; } = null!;
        [DisplayName("MST/CCCD")]
        public string TaxCode { get; set; } = null!;
        [DisplayName("Điện thoại")]
        public string Phone { get; set; }
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
        [DisplayName("Ghi chú")]
        public string? Notes { get; set; }


        [DisplayName("Loại tiền")]
        public string CurrencyId { get; set; } = null!;
        [DisplayName("Tỷ giá")]
        public long ExchangeRate { get; set; }
        [DisplayName("Cộng thành tiền")]
        public long ConvertTotalAmount { get; set; }
        [DisplayName("Cộng tiền thuế VAT")]
        public long ConvertTaxAmount { get; set; }
        [DisplayName("Cộng tiền CK")]
        public long ConvertDiscAmount { get; set; }
        //Tổng tiền thanh toán = ConvertTotalAmount + ConvertTaxAmount - ConvertDiscAmount
        [DisplayName("Tổng số tiền")]
        public long TotalAmount { get; set; }
        [DisplayName("Hạn thanh toán")]
        public DateOnly? OverDate { get; set; }

        [DisplayName("Có hóa đơn GTGT")]
        public bool HasInvoiceVat { get; set; }

        [DisplayName("Hình thức thanh toán")]
        public string? PaymentMethodId { get; set; }
        [DisplayName("Điều khoản thanh toán")]
        public string? PaymentTerms { get; set; }

        [DisplayName("Diễn giải")]
        public string? Description { get; set; }

    }
}