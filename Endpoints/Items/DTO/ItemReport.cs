

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using DaMi.SO.Manager.Data.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace DaMi.SO.Manager.Endpoints.Items.DTO;

public class ItemReport : IView<ViwItem>, IDto
{
    [DisplayName("Mã sản phẩm")]
    public string ItemId { get; set; } = null!;

    [DisplayName("Tên sản phẩm")]
    public string ItemName { get; set; } = null!;

    [DisplayName("Mã đơn vị tính")]
    public string? InvUnitOfMeasr { get; set; }

    [DisplayName("Mã nhóm sản phẩm")]
    public string ItemGroupId { get; set; } = null!;

    [DisplayName("Ngôn ngữ")]
    public string? Language { get; set; }

    [DisplayName("Trả 1 lần")]
    public bool IsPayFull { get; set; }

    [DisplayName("Trả theo năm")]
    public bool IsPayYear { get; set; }

    [DisplayName("Số MST")]
    public int DefNumOfTaxCode { get; set; }

    [DisplayName("Số Data")]
    public int DefNumOfData { get; set; }

    [DisplayName("Số HĐ")]
    public int DefNumOfInv { get; set; }

    [DisplayName("Số User")]
    public int DefNumOfUser { get; set; }

    [DisplayName("Số Máy")]
    public int DefNumOfPc { get; set; }

    [DisplayName("iCloud (GB)")]
    public int DefiCloudDataSize { get; set; }

    [DisplayName("Số tháng SD")]
    public int DefNumOfMonth { get; set; }

    [DisplayName("VAT (%)")]
    [DataType(DataType.Currency)]
    public decimal TaxRate { get; set; }

    [DisplayName("Đơn giá VND")]
    [DataType(DataType.Currency)]
    public double ConvertPrice { get; set; }

    [DisplayName("Đơn giá USD")]
    [DataType(DataType.Currency)]
    public double OriginalPrice { get; set; }

    [DisplayName("Ghi chú")]
    public string? Notes { get; set; }

    [DisplayName("Có hiệu lực")]
    public bool InActive { get; set; }

    [HiddenInput]
    public int SortOrder { get; set; }

    public static void InitMapper()
    {
        TypeAdapterConfig<ViwItem, ItemReport>.NewConfig();
    }
}