using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DaMi.SO.Manager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data;

public partial class DaMiSoManagerContext : DbContext
{
    public DaMiSoManagerContext()
    {
    }

    public DaMiSoManagerContext(DbContextOptions<DaMiSoManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ComputerItemMap> ComputerItemMaps { get; set; }

    public virtual DbSet<Computer> Computers { get; set; }

    public virtual DbSet<Currency> Currencys { get; set; }

    public virtual DbSet<CustomerUser> CustomerUsers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderForm> OrderForms { get; set; }

    public virtual DbSet<OrderMaster> OrderMasters { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuss { get; set; }

    public virtual DbSet<OrderType> OrderTypes { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Permision> Permisions { get; set; }

    public virtual DbSet<TaxCode> TaxCodes { get; set; }

    public virtual DbSet<ViwCustomer> ViwCustomers { get; set; }

    public virtual DbSet<ViwFullItem> ViwFullItems { get; set; }

    public virtual DbSet<ViwItemGroup> ViwItemGroups { get; set; }

    public virtual DbSet<ViwItem> ViwItems { get; set; }

    public virtual DbSet<ViwItemType> ViwItemTypes { get; set; }

    public virtual DbSet<ViwOrderMasterDetail> ViwOrderMasterDetails { get; set; }

    public virtual DbSet<ViwUnitOfMeasr> ViwUnitOfMeasrs { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Procedure>().HasNoKey();

        modelBuilder.Entity<ComputerItemMap>(entity =>
        {
            entity.Property(e => e.RowUniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Actived).HasComment("Có hiệu lực");
            entity.Property(e => e.ComputerId).HasComment("Mã máy tính");
            entity.Property(e => e.EndDate).HasComment("Ngày kết thúc");
            entity.Property(e => e.ItemId).HasComment("Mã Vật tư sản phẩm hàng hóa");
            entity.Property(e => e.OrderDetailId).HasComment("Mã đơn đặt hàng chi tiết");
            entity.Property(e => e.StartDate).HasComment("Ngày bắt đầu");
            entity.Property(e => e.TaxCode).HasComment("Mã số thuế");

            entity.HasOne(d => d.Computer).WithMany(p => p.ComputerItemMaps).HasConstraintName("FK_tblComputerItemMap_tblComputerList");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.ComputerItemMaps).HasConstraintName("FK_tblComputerItemMap_tblOrderDetail");

            entity.HasOne(d => d.TaxCodeNavigation).WithMany(p => p.ComputerItemMaps).HasConstraintName("FK_tblComputerItemMap_tblTaxCodeList");
        });

        modelBuilder.Entity<Computer>(entity =>
        {
            entity.Property(e => e.ComputerId).HasComment("Mã máy tính");
            entity.Property(e => e.ComputerName).HasComment("Tên máy tính");
            entity.Property(e => e.CustomerId).HasComment("Mã khách hàng");
            entity.Property(e => e.HardwareInfo).HasComment("Thông tin phần cứng");
            entity.Property(e => e.Ipaddr).HasComment("Địa chỉ IP máy tính");
            entity.Property(e => e.OperatingSystem).HasComment("Hệ điều hành");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.Property(e => e.CurrencyId)
                .HasDefaultValue("VND")
                .HasComment("Loại tiền");
            entity.Property(e => e.AmountDecimalPlaces).HasDefaultValue((byte)2);
            entity.Property(e => e.AmountNumberFormat)
                .HasDefaultValue("#,##0.00")
                .HasComment("Mã định dạng số tiền");
            entity.Property(e => e.CurrencyName).HasComment("Tên loại tiền");
            entity.Property(e => e.CurrencyName2).HasComment("Tên loại tiền");
            entity.Property(e => e.PriceDecimalPlaces).HasDefaultValue((byte)2);
            entity.Property(e => e.PriceNumberFormat)
                .HasDefaultValue("#,##0.00")
                .HasComment("Mã định dạng đơn giá");
        });

        modelBuilder.Entity<CustomerUser>(entity =>
        {
            entity.Property(e => e.RowUniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Actived).HasComment("Có hiệu lực");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày cập nhật");
            entity.Property(e => e.CreatedUserId).HasDefaultValue("DAMIADMIN");
            entity.Property(e => e.CustomerId).HasComment("Mã khách hàng");
            entity.Property(e => e.CustomerUserId).HasComment("Mã User KH");
            entity.Property(e => e.CustomerUserName).HasComment("Tên User KH");
            entity.Property(e => e.CustomerUserPassword).HasComment("Mật khẩu User KH");
            entity.Property(e => e.ItemTypeId).HasComment("Mã loại sản phẩm");
            entity.Property(e => e.LastModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LastModifiedUserId).HasDefaultValue("DAMIADMIN");
            entity.Property(e => e.OrderDetailId).HasComment("Mã đơn đặt hàng chi tiết");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.CustomerUsers).HasConstraintName("FK_tblCustomerUserList_tblOrderDetail");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.RowUniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày tạo");
            entity.Property(e => e.CreatedUserId)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người tạo");
            entity.Property(e => e.DepartmentId).HasComment("Mã phòng ban");
            entity.Property(e => e.DepartmentName).HasComment("Tên phòng ban");
            entity.Property(e => e.DepartmentName2).HasComment("Tên phòng ban 2");
            entity.Property(e => e.IsAccounting).HasComment("Phong Ke toan");
            entity.Property(e => e.IsDeveloper).HasComment("Phong Lap trinh");
            entity.Property(e => e.IsInstall).HasComment("Phong Trien khai");
            entity.Property(e => e.IsSales).HasComment("Phong Kinh doanh");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày chỉnh sửa cuối cùng");
            entity.Property(e => e.LastModifiedUserId)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người chỉnh sửa cuối cùng");

            entity.HasOne(d => d.Permision).WithMany(p => p.Departments)
                .HasPrincipalKey(p => p.PermisionId)
                .HasForeignKey(d => d.PermisionId)
                .HasConstraintName("FK_tblDepartmentList_tblPermisionList");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.RowUniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày tạo");
            entity.Property(e => e.CreatedUserId)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người tạo");
            entity.Property(e => e.DepartmentId).HasComment("Mã phòng ban");
            entity.Property(e => e.EmployeeBriefName).HasComment("Tên nhân viên rút gọn");
            entity.Property(e => e.EmployeeBriefName2).HasComment("Tên nhân viên rút gọn 2");
            entity.Property(e => e.EmployeeId).HasComment("Mã nhân viên");
            entity.Property(e => e.EmployeeName).HasComment("Tên nhân viên");
            entity.Property(e => e.EmployeeName2).HasComment("Tên nhân viên");
            entity.Property(e => e.HomeAddress).HasComment("Địa chỉ nhà riêng");
            entity.Property(e => e.HomePhone).HasComment("Điện thoại nhà riêng");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày chỉnh sửa cuối cùng");
            entity.Property(e => e.LastModifiedUserId)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người chỉnh sửa cuối cùng");
            entity.Property(e => e.Notes).HasComment("Ghi chú");
            entity.Property(e => e.OfficePhone).HasComment("Điện thoại cơ quan");
            entity.Property(e => e.SignPicture).HasComment("Hình chữ ký");
            entity.Property(e => e.SortOrder).HasComment("Thứ tự sắp xếp");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasPrincipalKey(p => p.DepartmentId)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_tblEmployeeList_tblDepartmentList");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.RowUniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CnvPaymentAmount).HasComment("Số tiền đã thanh toán");
            entity.Property(e => e.ConvertAmount).HasComment("Số tiền VND");
            entity.Property(e => e.ConvertDiscAmount).HasComment("Chiết khấu VND");
            entity.Property(e => e.ConvertPrice).HasComment("Đơn giá quy đổi (VND)");
            entity.Property(e => e.ConvertTaxAmount).HasComment("Tiền thuế");
            entity.Property(e => e.ConvertTotalAmount).HasComment("Tổng số tiền");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày tạo");
            entity.Property(e => e.CreatedUserId)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người tạo");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValue("VND")
                .HasComment("Loại tiền");
            entity.Property(e => e.DiscountPercent).HasComment("Phần trăm chiết khấu");
            entity.Property(e => e.ExchangeRate)
                .HasDefaultValue(1m)
                .HasComment("Tỷ giá");
            entity.Property(e => e.ICloudDataSize).HasComment("Dung lượng lưu trữ iCloud (GB)");
            entity.Property(e => e.ItemId).HasComment("Mã Vật tư sản phẩm hàng hóa");
            entity.Property(e => e.ItemName).HasComment("Tên sản phẩm");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày chỉnh sửa cuối cùng");
            entity.Property(e => e.LastModifiedUserId)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người chỉnh sửa cuối cùng");
            entity.Property(e => e.LineNumber).HasComment("Thứ tự dòng");
            entity.Property(e => e.TaxCode).HasComment("Danh sách Mã số thuế sử dụng");
            entity.Property(e => e.NumOfData).HasComment("Số lượng hệ thống");
            entity.Property(e => e.NumOfInv).HasComment("Số lượng hóa đơn");
            entity.Property(e => e.NumOfMonth).HasComment("Số lượng tháng");
            entity.Property(e => e.NumOfPc).HasComment("Số lượng máy tính");
            entity.Property(e => e.NumOfTaxCode).HasComment("Số lượng mã số thuế");
            entity.Property(e => e.NumOfUser).HasComment("Số lượng User");
            entity.Property(e => e.OrderId).HasComment("Mã đơn đặt hàng");
            entity.Property(e => e.OrgPaymentAmount).HasComment("Số tiền đã thanh toán USD");
            entity.Property(e => e.OriginalAmount).HasComment("Thành tiền nguyên tệ");
            entity.Property(e => e.OriginalDiscAmount).HasComment("Chiết khấu nguyên tệ");
            entity.Property(e => e.OriginalPrice).HasComment("Đơn giá nguyên tệ");
            entity.Property(e => e.OriginalTaxAmount).HasComment("Tiền thuế nguyên tệ");
            entity.Property(e => e.OriginalTotalAmount).HasComment("Tổng số tiền USD");
            entity.Property(e => e.Quantity).HasComment("Số lượng");
            entity.Property(e => e.RowVersionId)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StartDate).HasComment("Ngày bắt đầu sử dụng");
            entity.Property(e => e.TaxRate).HasComment("Thuế suất");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails).HasConstraintName("FK_tblOrderDetail_tblOrderMaster");
        });


        modelBuilder.Entity<OrderForm>(entity =>
        {
            entity.Property(e => e.OrderFormId).HasComment("Mã kiểu đơn hàng");
            entity.Property(e => e.HasByDiskSize).HasComment("Có tính theo dung lượng (GB)");
            entity.Property(e => e.HasByNumData).HasComment("Có tính theo số Data");
            entity.Property(e => e.HasByPc).HasComment("Có tính theo máy tính");
            entity.Property(e => e.HasByQtyInvc).HasComment("Có tính theo số lượng HĐ");
            entity.Property(e => e.HasByTaxCode).HasComment("Có tính theo MST");
            entity.Property(e => e.HasByTime).HasComment("Có tính theo thời gian");
            entity.Property(e => e.HasByUser).HasComment("Có tính theo User");
            entity.Property(e => e.OrderFormName).HasComment("Tên kiểu đơn hàng");
            entity.Property(e => e.SortOrder).HasComment("Thứ tự sắp xếp");
        });

        modelBuilder.Entity<OrderMaster>(entity =>
        {
            entity.Property(e => e.RowUniqueId).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Accepted).HasComment("Đã duyệt");
            entity.Property(e => e.AcceptedDate).HasComment("Ngày duyệt");
            entity.Property(e => e.AccepterId).HasComment("Người duyệt");
            entity.Property(e => e.BeginExecDate).HasComment("Ngày bắt đầu triển khai");
            entity.Property(e => e.CancelOrderDate).HasComment("Ngày hủy đơn hàng");
            entity.Property(e => e.ContractDate).HasComment("Ngày hợp đồng");
            entity.Property(e => e.ContractNo).HasComment("Số hợp đồng");
            entity.Property(e => e.ConvertDiscAmount).HasComment("Chiết khấu VND");
            entity.Property(e => e.ConvertTaxAmount).HasComment("Tiền thuế quy đổi VND");
            entity.Property(e => e.ConvertTotalAmount).HasComment("Tổng số tiền");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày tạo");
            entity.Property(e => e.CreatedUserId)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người tạo");
            entity.Property(e => e.CurrencyId)
                .HasDefaultValue("VND")
                .HasComment("Loại tiền");
            entity.Property(e => e.CustomerId).HasComment("Mã khách hàng");
            entity.Property(e => e.Description).HasComment("Diễn giải");
            entity.Property(e => e.DiscountPercent).HasComment("Phần trăm chiết khấu (hoặc đơn giá chiết khấu)");
            entity.Property(e => e.EndExecDate).HasComment("Ngày kết thúc triển khai");
            entity.Property(e => e.ExchangeRate)
                .HasDefaultValue(1m)
                .HasComment("Tỷ giá");
            entity.Property(e => e.ExecutorId).HasComment("Mã nhân viên triển khai");
            entity.Property(e => e.FinishOk).HasComment("Đã hoàn thành");
            entity.Property(e => e.HasDiscount).HasComment("Có chiết khấu");
            entity.Property(e => e.HasInvoiceVat).HasComment("Có xuất đơn GTGT");
            entity.Property(e => e.IsCancel).HasComment("Đã bị hủy");
            entity.Property(e => e.IsExecuting).HasComment("Đang triển khai");
            entity.Property(e => e.IsPriceAfterTax).HasComment("Giá sau thuế");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày giờ hiệu chỉnh cuối cùng");
            entity.Property(e => e.LastModifiedUserId)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("người hiệu chỉnh cuối cùng");
            entity.Property(e => e.Notes).HasComment("Ghi chú");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày đặt hàng");
            entity.Property(e => e.OrderFormId).HasComment("Mã kiểu đơn hàng");
            entity.Property(e => e.OrderNo)
                .HasComputedColumnSql("([dbo].[ufnGetOrderNo]([OrderDate],[SeqInMonth],'SO'))", false)
                .HasComment("Số đơn đặt hàng");
            entity.Property(e => e.OrderStatusId).HasComment("Trạng thái đơn đặt hàng");
            entity.Property(e => e.OrderTypeId).HasComment("Mã loại đơn hàng");
            entity.Property(e => e.OriginalDiscAmount).HasComment("Chiết khấu nguyên tệ");
            entity.Property(e => e.OriginalTaxAmount).HasComment("Tiền thuế nguyên tệ");
            entity.Property(e => e.OriginalTotalAmount).HasComment("Tổng số tiền");
            entity.Property(e => e.OverDate).HasComment("Hạn thanh toán");
            entity.Property(e => e.PaymentMethodId).HasComment("Mã hình thức thanh toán");
            entity.Property(e => e.PaymentTerms).HasComment("Điều khoản thanh toán");
            entity.Property(e => e.Paymented).HasComment("Đã thanh toán");
            entity.Property(e => e.PublishedInvoice).HasComment("Đã xuất Hóa đơn");
            entity.Property(e => e.RefPerson).HasComment("Người đại diện");
            entity.Property(e => e.RefPos).HasComment("Chức vụ");
            entity.Property(e => e.RowVersionId)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SalesManId).HasComment("Mã nhân viên bán hàng");
            entity.Property(e => e.SeqInMonth).HasComment("Số thứ tự trong tháng");
            entity.Property(e => e.SeqInYear).HasComment("Số thứ tự trong năm");
            entity.Property(e => e.SubCompanyId).HasDefaultValue("MAIN");
            entity.Property(e => e.TaxRate).HasComment("Thuế suất");
            entity.Property(e => e.TranMonth).HasComputedColumnSql("(datepart(month,[OrderDate]))", false);
            entity.Property(e => e.TranYear).HasComputedColumnSql("(datepart(year,[OrderDate]))", false);

            entity.HasOne(d => d.Executor).WithMany(p => p.OrderMasterExecutors)
                .HasPrincipalKey(p => p.EmployeeId)
                .HasForeignKey(d => d.ExecutorId)
                .HasConstraintName("FK_tblOrderMaster_tblEmployeeList");

            entity.HasOne(d => d.OrderForm).WithMany(p => p.OrderMasters).HasConstraintName("FK_tblOrderMaster_tblOrderFormList");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.OrderMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblOrderMaster_tblOrderStatusList");

            entity.HasOne(d => d.OrderType).WithMany(p => p.OrderMasters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblOrderMaster_tblOrderTypeList");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.OrderMasters).HasConstraintName("FK_tblOrderMaster_tblPaymentMethodList");

            entity.HasOne(d => d.SalesMan).WithMany(p => p.OrderMasterSalesMen)
                .HasPrincipalKey(p => p.EmployeeId)
                .HasForeignKey(d => d.SalesManId)
                .HasConstraintName("FK_tblOrderMaster_tblEmployeeList2");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.Property(e => e.OrderStatusId).HasComment("Mã trạng thái đơn hàng");
            entity.Property(e => e.CanChangeStatus).HasComment("Là trạng thái có thể thay đổi bởi NV Sales");
            entity.Property(e => e.IsAcceptStatus).HasComment("Là trạng thái Đã duyệt");
            entity.Property(e => e.IsCancelStatus).HasComment("Là trạng thái Hủy");
            entity.Property(e => e.IsSuspendStatus).HasComment("Là trạng thái treo");
            entity.Property(e => e.OrderStatusName).HasComment("Tên trạng thái đơn hàng");
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity.Property(e => e.OrderTypeId).HasComment("Mã loại đơn hàng");
            entity.Property(e => e.OrderTypeName).HasComment("Tên loại đơn hàng");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.Property(e => e.PaymentMethodId).HasComment("Mã hình thức thanh toán");
            entity.Property(e => e.IsDebit).HasComment("Hình thức trả chậm");
            entity.Property(e => e.PayAcctId).HasComment("Tài khoản đối ứng (111, 112, 131, ...)");
            entity.Property(e => e.PaymentMethodName).HasComment("Tên hình thức thanh toán");
        });

        modelBuilder.Entity<Permision>(entity =>
        {
            entity.Property(e => e.RowUniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AcceptOrder).HasComment("Quyền duyệt Đơn hàng");
            entity.Property(e => e.AddNew).HasComment("Quyền thêm danh sách");
            entity.Property(e => e.AddNewOrder).HasComment("Quyền thêm Đơn hàng");
            entity.Property(e => e.CancelOrder).HasComment("Quyền hủy Đơn hàng");
            entity.Property(e => e.ChangeStatusOrder).HasComment("Quyền thay đổi trạng thái khác Đơn hàng");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày tạo");
            entity.Property(e => e.CreatedUserId)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người tạo");
            entity.Property(e => e.Delete).HasComment("Quyền xóa danh sách");
            entity.Property(e => e.DeleteOrder).HasComment("Quyền xóa Đơn hàng");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày chỉnh sửa cuối cùng");
            entity.Property(e => e.LastModifiedUserId)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người chỉnh sửa cuối cùng");
            entity.Property(e => e.SuspendOrder).HasComment("Quyền treo Đơn hàng");
            entity.Property(e => e.Update).HasComment("Quyền sửa danh sách");
            entity.Property(e => e.UpdateOrder).HasComment("Quyền sửa Đơn hàng");
            entity.Property(e => e.ViewFullOrder).HasComment("Quyền xem đầy đủ Đơn hàng");
            entity.Property(e => e.ViewLimitOrder).HasComment("Quyền xem có giới hạn Đơn hàng");
            entity.Property(e => e.View).HasComment("Quyền xem danh sách");
        });

        modelBuilder.Entity<TaxCode>(entity =>
        {
            entity.Property(e => e.TaxCodeId).HasComment("MST");
            entity.Property(e => e.CustomerId).HasComment("Mã KH");
            entity.Property(e => e.TaxCodeAddr).HasComment("Địa chỉ");
            entity.Property(e => e.TaxCodeName).HasComment("Tên công ty");
        });

        modelBuilder.Entity<ViwCustomer>(entity =>
        {
            entity.ToView("viwCustomerList");
        });

        modelBuilder.Entity<ViwFullItem>(entity =>
        {
            entity.ToView("viwFullItemList");
        });

        modelBuilder.Entity<ViwItemGroup>(entity =>
        {
            entity.ToView("viwItemGroupList");
        });

        modelBuilder.Entity<ViwItem>(entity =>
        {
            entity.ToView("viwItemList");
        });

        modelBuilder.Entity<ViwItemType>(entity =>
        {
            entity.ToView("viwItemTypeList");
        });

        modelBuilder.Entity<ViwOrderMasterDetail>(entity =>
        {
            entity.ToView("viwOrderMasterDetail");
        });

        modelBuilder.Entity<ViwUnitOfMeasr>(entity =>
        {
            entity.ToView("viwUnitOfMeasrList");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
