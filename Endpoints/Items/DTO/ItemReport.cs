

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

    [DisplayName("Là trả tiền 1 lần")]
    public bool IsPayFull { get; set; }

    [DisplayName("Là trả tiền theo năm")]
    public bool IsPayYear { get; set; }

    [DisplayName("Số lượng mã số thuế (mặc định)")]
    public int DefNumOfTaxCode { get; set; }

    [DisplayName("Số lượng hệ thống (mặc định)")]
    public int DefNumOfData { get; set; }

    [DisplayName("Số lượng hóa đơn (mặc định)")]
    public int DefNumOfInv { get; set; }

    [DisplayName("Số lượng User (mặc định)")]
    public int DefNumOfUser { get; set; }

    [DisplayName("Số lượng máy tính (mặc định)")]
    public int DefNumOfPc { get; set; }

    [DisplayName("Dung lượng lưu trữ iCloud (GB) (mặc định)")]
    public int DefiCloudDataSize { get; set; }

    [DisplayName("Số lượng tháng (mặc định)")]
    public int DefNumOfMonth { get; set; }


    [DisplayName("Thuế suất (%)")]
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