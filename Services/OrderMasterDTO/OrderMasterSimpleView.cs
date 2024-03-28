using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using DaMi.SO.Manager.Data.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace DaMi.SO.Manager;

public class OrderMasterSimpleView : IView<OrderMaster>, IDto
{

	[HiddenInput]
	public Guid RowUniqueId { get; set; }

	/// <summary>
	/// Số đơn đặt hàng
	/// </summary>
	[HiddenInput]
	[DisplayName("Số đơn hàng")]
	public string? OrderNo { get; set; }


	/// <summary>
	/// Ngày đặt hàng
	/// </summary>
	[DisplayName("Ngày đặt hàng")]
	public DateTime OrderDate { get; set; }

	/// <summary>
	/// Mã khách hàng
	/// </summary>
	[DisplayName("Khách hàng")]
	public string CustomerId { get; set; } = null!;

	/// <summary>
	/// Số hợp đồng
	/// </summary>
	[DisplayName("Số hợp đồng")]
	public string? ContractNo { get; set; }

	/// <summary>
	/// Trạng thái đơn đặt hàng
	/// </summary>
	[DisplayName("Trạng thái ĐH")]
	public string OrderStatus { get; set; } = null!;

	[DisplayName("Ngày triển khai")]
	public DateTime? BeginExecDate { get; set; }

	[DisplayName("Tên sản phẩm")]
	public string ItemNames { get; set; }
	[DisplayName("Số máy")]
	public int NumOfPC { get; set; }
	[DisplayName("Số hệ thống")]
	public int NumOfData { get; set; }
	[DisplayName("Số MST")]
	public int NumOfTaxCode { get; set; }
	[DisplayName("Số HĐ")]
	public int NumOfInv { get; set; }
	[DisplayName("Số User")]
	public int NumOfUser { get; set; }
	[DisplayName("Số iCloudData")]
	public int NoICloudData { get; set; }

	/// <summary>
	/// Tổng số tiền
	/// </summary>
	[DisplayName("Tổng số tiền")]
	public decimal OriginalTotalAmount { get; set; }

	/// <summary>
	/// Tổng số tiền
	/// </summary>
	[DisplayName("Số tiền đã thu")]
	public decimal CollectAmount { get; set; }
	/// <summary>
	/// Có hóa đơn GTGT
	/// </summary>
	[DisplayName("Có hóa đơn GTGT")]
	public bool HasInvoiceVat { get; set; }

	[DisplayName("Đã xuất Hóa đơn")]
	public bool PublishedInvoice { get; set; }

	public static void InitMapper()
	{
		TypeAdapterConfig<OrderMaster, OrderMasterSimpleView>.NewConfig()
			.Map(view => view.OrderStatus, order => order.OrderStatus.OrderStatusName)
			.Map(view => view.NumOfPC, order => order.OrderDetails.Sum(d => d.NumOfPc))
			.Map(view => view.NumOfData, order => order.OrderDetails.Sum(d => d.NumOfData))
			.Map(view => view.NumOfInv, order => order.OrderDetails.Sum(d => d.NumOfInv))
			.Map(view => view.NumOfTaxCode, order => order.OrderDetails.Sum(d => d.NumOfTaxCode))
			.Map(view => view.NumOfUser, order => order.OrderDetails.Sum(d => d.NumOfUser));
	}
}