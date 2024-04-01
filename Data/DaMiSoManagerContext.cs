using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComputerItemMap>(entity =>
        {
            entity.HasKey(e => e.RowUniqueId);

            entity.ToTable("tblComputerItemMap");

            entity.HasIndex(e => new { e.ComputerId, e.ItemId, e.TaxCode }, "UK_tblComputerItemMap").IsUnique();

            entity.Property(e => e.RowUniqueId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RowUniqueID");
            entity.Property(e => e.Actived).HasComment("Có hiệu lực");
            entity.Property(e => e.ComputerId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Mã máy tính")
                .HasColumnName("ComputerID");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CreatedUserID");
            entity.Property(e => e.EndDate).HasComment("Ngày kết thúc");
            entity.Property(e => e.ItemId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã Vật tư sản phẩm hàng hóa")
                .HasColumnName("ItemID");
            entity.Property(e => e.OrderDetailId)
                .HasComment("Mã đơn đặt hàng chi tiết")
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.StartDate).HasComment("Ngày bắt đầu");
            entity.Property(e => e.TaxCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã số thuế");

            entity.HasOne(d => d.Computer).WithMany(p => p.ComputerItemMaps)
                .HasForeignKey(d => d.ComputerId)
                .HasConstraintName("FK_tblComputerItemMap_tblComputerList");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.ComputerItemMaps)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK_tblComputerItemMap_tblOrderDetail");

            entity.HasOne(d => d.TaxCodeNavigation).WithMany(p => p.ComputerItemMaps)
                .HasForeignKey(d => d.TaxCode)
                .HasConstraintName("FK_tblComputerItemMap_tblTaxCodeList");
        });

        modelBuilder.Entity<Computer>(entity =>
        {
            entity.HasKey(e => e.ComputerId);

            entity.ToTable("tblComputerList");

            entity.Property(e => e.ComputerId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Mã máy tính")
                .HasColumnName("ComputerID");
            entity.Property(e => e.ComputerName)
                .HasMaxLength(60)
                .HasComment("Tên máy tính");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã khách hàng")
                .HasColumnName("CustomerID");
            entity.Property(e => e.HardwareInfo)
                .HasMaxLength(200)
                .HasComment("Thông tin phần cứng");
            entity.Property(e => e.Ipaddr)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Địa chỉ IP máy tính")
                .HasColumnName("IPAddr");
            entity.Property(e => e.OperatingSystem)
                .HasMaxLength(100)
                .HasComment("Hệ điều hành");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.CurrencyId);

            entity.ToTable("tblCurrencyList");

            entity.Property(e => e.CurrencyId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("VND")
                .HasComment("Loại tiền")
                .HasColumnName("CurrencyID");
            entity.Property(e => e.AmountDecimalPlaces).HasDefaultValue((byte)2);
            entity.Property(e => e.AmountNumberFormat)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("#,##0.00")
                .HasComment("Mã định dạng số tiền");
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(50)
                .HasComment("Tên loại tiền");
            entity.Property(e => e.CurrencyName2)
                .HasMaxLength(50)
                .HasComment("Tên loại tiền");
            entity.Property(e => e.PriceDecimalPlaces).HasDefaultValue((byte)2);
            entity.Property(e => e.PriceNumberFormat)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("#,##0.00")
                .HasComment("Mã định dạng đơn giá");
            entity.Property(e => e.UnitName).HasMaxLength(30);
        });

        modelBuilder.Entity<CustomerUser>(entity =>
        {
            entity.HasKey(e => e.RowUniqueId);

            entity.ToTable("tblCustomerUserList");

            entity.HasIndex(e => new { e.CustomerId, e.ItemTypeId, e.CustomerUserId }, "UK_tblCustomerUserList").IsUnique();

            entity.Property(e => e.RowUniqueId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RowUniqueID");
            entity.Property(e => e.Actived).HasComment("Có hiệu lực");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày cập nhật");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasColumnName("CreatedUserID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã khách hàng")
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã User KH")
                .HasColumnName("CustomerUserID");
            entity.Property(e => e.CustomerUserName)
                .HasMaxLength(100)
                .HasComment("Tên User KH");
            entity.Property(e => e.CustomerUserPassword)
                .HasMaxLength(50)
                .HasComment("Mật khẩu User KH");
            entity.Property(e => e.ItemTypeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã loại sản phẩm")
                .HasColumnName("ItemTypeID");
            entity.Property(e => e.LastModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LastModifiedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasColumnName("LastModifiedUserID");
            entity.Property(e => e.OrderDetailId)
                .HasComment("Mã đơn đặt hàng chi tiết")
                .HasColumnName("OrderDetailID");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.CustomerUsers)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK_tblCustomerUserList_tblOrderDetail");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.RowUniqueId);

            entity.ToTable("tblDepartmentList");

            entity.HasIndex(e => e.DepartmentId, "UK_tblDepartmentList").IsUnique();

            entity.Property(e => e.RowUniqueId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RowUniqueID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày tạo");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người tạo")
                .HasColumnName("CreatedUserID");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã phòng ban")
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .HasComment("Tên phòng ban");
            entity.Property(e => e.DepartmentName2)
                .HasMaxLength(100)
                .HasComment("Tên phòng ban 2");
            entity.Property(e => e.IsAccounting).HasComment("Phong Ke toan");
            entity.Property(e => e.IsDeveloper).HasComment("Phong Lap trinh");
            entity.Property(e => e.IsInstall).HasComment("Phong Trien khai");
            entity.Property(e => e.IsSales).HasComment("Phong Kinh doanh");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày chỉnh sửa cuối cùng");
            entity.Property(e => e.LastModifiedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người chỉnh sửa cuối cùng")
                .HasColumnName("LastModifiedUserID");
            entity.Property(e => e.Notes).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.RowUniqueId);

            entity.ToTable("tblEmployeeList");

            entity.HasIndex(e => e.EmployeeId, "UK_tblEmployeeList").IsUnique();

            entity.Property(e => e.RowUniqueId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RowUniqueID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày tạo");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người tạo")
                .HasColumnName("CreatedUserID");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã phòng ban")
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.EmployeeBriefName)
                .HasMaxLength(40)
                .HasComment("Tên nhân viên rút gọn");
            entity.Property(e => e.EmployeeBriefName2)
                .HasMaxLength(40)
                .HasComment("Tên nhân viên rút gọn 2");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã nhân viên")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .HasComment("Tên nhân viên");
            entity.Property(e => e.EmployeeName2)
                .HasMaxLength(100)
                .HasComment("Tên nhân viên");
            entity.Property(e => e.EmployeePassword).HasMaxLength(130);
            entity.Property(e => e.HomeAddress)
                .HasMaxLength(250)
                .HasComment("Địa chỉ nhà riêng");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Điện thoại nhà riêng");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày chỉnh sửa cuối cùng");
            entity.Property(e => e.LastModifiedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người chỉnh sửa cuối cùng")
                .HasColumnName("LastModifiedUserID");
            entity.Property(e => e.Notes)
                .HasMaxLength(100)
                .HasComment("Ghi chú");
            entity.Property(e => e.OfficePhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Điện thoại cơ quan");
            entity.Property(e => e.SignPicture).HasComment("Hình chữ ký");
            entity.Property(e => e.SortOrder).HasComment("Thứ tự sắp xếp");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasPrincipalKey(p => p.DepartmentId)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_tblEmployeeList_tblDepartmentList");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.RowUniqueId);

            entity.ToTable("tblOrderDetail");

            entity.HasIndex(e => new { e.OrderId, e.ItemId }, "UK_tblOrderDetail").IsUnique();

            entity.Property(e => e.RowUniqueId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RowUniqueID");
            entity.Property(e => e.CnvPaymentAmount)
                .HasComment("Số tiền đã thanh toán")
                .HasColumnType("money");
            entity.Property(e => e.ConvertAmount)
                .HasComment("Số tiền VND")
                .HasColumnType("money");
            entity.Property(e => e.ConvertDiscAmount)
                .HasComment("Chiết khấu VND")
                .HasColumnType("money");
            entity.Property(e => e.ConvertPrice).HasComment("Đơn giá quy đổi (VND)");
            entity.Property(e => e.ConvertTaxAmount)
                .HasComment("Tiền thuế")
                .HasColumnType("money");
            entity.Property(e => e.ConvertTotalAmount)
                .HasComment("Tổng số tiền")
                .HasColumnType("money");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày tạo");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người tạo")
                .HasColumnName("CreatedUserID");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("VND")
                .HasComment("Loại tiền")
                .HasColumnName("CurrencyID");
            entity.Property(e => e.DiscountPercent).HasComment("Phần trăm chiết khấu");
            entity.Property(e => e.ExchangeRate)
                .HasDefaultValue(1m)
                .HasComment("Tỷ giá")
                .HasColumnType("smallmoney");
            entity.Property(e => e.ICloudDataSize)
                .HasComment("Dung lượng lưu trữ iCloud (GB)")
                .HasColumnName("iCloudDataSize");
            entity.Property(e => e.ItemId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã Vật tư sản phẩm hàng hóa")
                .HasColumnName("ItemID");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày chỉnh sửa cuối cùng");
            entity.Property(e => e.LastModifiedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người chỉnh sửa cuối cùng")
                .HasColumnName("LastModifiedUserID");
            entity.Property(e => e.LineNumber).HasComment("Thứ tự dòng");
            entity.Property(e => e.TaxCode)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("Danh sách Mã số thuế sử dụng");
            entity.Property(e => e.NumOfData).HasComment("Số lượng hệ thống");
            entity.Property(e => e.NumOfInv).HasComment("Số lượng hóa đơn");
            entity.Property(e => e.NumOfMonth).HasComment("Số lượng tháng");
            entity.Property(e => e.NumOfPc)
                .HasComment("Số lượng máy tính")
                .HasColumnName("NumOfPC");
            entity.Property(e => e.NumOfTaxCode).HasComment("Số lượng mã số thuế");
            entity.Property(e => e.NumOfUser).HasComment("Số lượng User");
            entity.Property(e => e.OrderId)
                .HasComment("Mã đơn đặt hàng")
                .HasColumnName("OrderID");
            entity.Property(e => e.OrgPaymentAmount)
                .HasComment("Số tiền đã thanh toán USD")
                .HasColumnType("money");
            entity.Property(e => e.OriginalAmount)
                .HasComment("Thành tiền nguyên tệ")
                .HasColumnType("money");
            entity.Property(e => e.OriginalDiscAmount)
                .HasComment("Chiết khấu nguyên tệ")
                .HasColumnType("money");
            entity.Property(e => e.OriginalPrice).HasComment("Đơn giá nguyên tệ");
            entity.Property(e => e.OriginalTaxAmount)
                .HasComment("Tiền thuế nguyên tệ")
                .HasColumnType("money");
            entity.Property(e => e.OriginalTotalAmount)
                .HasComment("Tổng số tiền USD")
                .HasColumnType("money");
            entity.Property(e => e.Quantity).HasComment("Số lượng");
            entity.Property(e => e.RowVersionId)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("RowVersionID");
            entity.Property(e => e.StartDate).HasComment("Ngày bắt đầu sử dụng");
            entity.Property(e => e.TaxRate)
                .HasComment("Thuế suất")
                .HasColumnType("smallmoney");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_tblOrderDetail_tblOrderMaster");
        });

        modelBuilder.Entity<OrderForm>(entity =>
        {
            entity.HasKey(e => e.OrderFormId);

            entity.ToTable("tblOrderFormList");

            entity.Property(e => e.OrderFormId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã kiểu đơn hàng")
                .HasColumnName("OrderFormID");
            entity.Property(e => e.HasByDiskSize).HasComment("Có tính theo dung lượng (GB)");
            entity.Property(e => e.HasByNumData).HasComment("Có tính theo số Data");
            entity.Property(e => e.HasByPc)
                .HasComment("Có tính theo máy tính")
                .HasColumnName("HasByPC");
            entity.Property(e => e.HasByQtyInvc).HasComment("Có tính theo số lượng HĐ");
            entity.Property(e => e.HasByTaxCode).HasComment("Có tính theo MST");
            entity.Property(e => e.HasByTime).HasComment("Có tính theo thời gian");
            entity.Property(e => e.HasByUser).HasComment("Có tính theo User");
            entity.Property(e => e.OrderFormName)
                .HasMaxLength(150)
                .HasComment("Tên kiểu đơn hàng");
            entity.Property(e => e.SortOrder).HasComment("Thứ tự sắp xếp");
        });

        modelBuilder.Entity<OrderMaster>(entity =>
        {
            entity.HasKey(e => e.RowUniqueId);

            entity.ToTable("tblOrderMaster");

            entity.HasIndex(e => new { e.TranYear, e.TranMonth, e.SubCompanyId, e.SeqInMonth }, "UK_tblOrderMaster").IsUnique();

            entity.Property(e => e.RowUniqueId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RowUniqueID");
            entity.Property(e => e.Accepted).HasComment("Đã duyệt");
            entity.Property(e => e.AcceptedDate).HasComment("Ngày duyệt");
            entity.Property(e => e.AccepterId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Người duyệt")
                .HasColumnName("AccepterID");
            entity.Property(e => e.BeginExecDate).HasComment("Ngày bắt đầu triển khai");
            entity.Property(e => e.CancelOrderDate).HasComment("Ngày hủy đơn hàng");
            entity.Property(e => e.ContractDate).HasComment("Ngày hợp đồng");
            entity.Property(e => e.ContractNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Số hợp đồng");
            entity.Property(e => e.ConvertDiscAmount)
                .HasComment("Chiết khấu VND")
                .HasColumnType("money");
            entity.Property(e => e.ConvertTaxAmount)
                .HasComment("Tiền thuế quy đổi VND")
                .HasColumnType("money");
            entity.Property(e => e.ConvertTotalAmount)
                .HasComment("Tổng số tiền")
                .HasColumnType("money");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày tạo");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người tạo")
                .HasColumnName("CreatedUserID");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("VND")
                .HasComment("Loại tiền")
                .HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã khách hàng")
                .HasColumnName("CustomerID");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("Diễn giải");
            entity.Property(e => e.DiscountPercent).HasComment("Phần trăm chiết khấu (hoặc đơn giá chiết khấu)");
            entity.Property(e => e.EndExecDate).HasComment("Ngày kết thúc triển khai");
            entity.Property(e => e.ExchangeRate)
                .HasDefaultValue(1m)
                .HasComment("Tỷ giá")
                .HasColumnType("smallmoney");
            entity.Property(e => e.ExecutorId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã nhân viên triển khai")
                .HasColumnName("ExecutorID");
            entity.Property(e => e.FinishOk).HasComment("Đã hoàn thành");
            entity.Property(e => e.HasDiscount).HasComment("Có chiết khấu");
            entity.Property(e => e.HasInvoiceVat)
                .HasComment("Có xuất đơn GTGT")
                .HasColumnName("HasInvoiceVAT");
            entity.Property(e => e.IsCancel).HasComment("Đã bị hủy");
            entity.Property(e => e.IsExecuting).HasComment("Đang triển khai");
            entity.Property(e => e.IsPriceAfterTax).HasComment("Giá sau thuế");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày giờ hiệu chỉnh cuối cùng");
            entity.Property(e => e.LastModifiedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("người hiệu chỉnh cuối cùng")
                .HasColumnName("LastModifiedUserID");
            entity.Property(e => e.Notes)
                .HasMaxLength(250)
                .HasComment("Ghi chú");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày đặt hàng");
            entity.Property(e => e.OrderFormId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã kiểu đơn hàng")
                .HasColumnName("OrderFormID");
            entity.Property(e => e.OrderNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComputedColumnSql("([dbo].[ufnGetOrderNo]([OrderDate],[SeqInMonth],'SO'))", false)
                .HasComment("Số đơn đặt hàng");
            entity.Property(e => e.OrderStatusId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Trạng thái đơn đặt hàng")
                .HasColumnName("OrderStatusID");
            entity.Property(e => e.OrderTypeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã loại đơn hàng")
                .HasColumnName("OrderTypeID");
            entity.Property(e => e.OriginalDiscAmount)
                .HasComment("Chiết khấu nguyên tệ")
                .HasColumnType("money");
            entity.Property(e => e.OriginalTaxAmount)
                .HasComment("Tiền thuế nguyên tệ")
                .HasColumnType("money");
            entity.Property(e => e.OriginalTotalAmount)
                .HasComment("Tổng số tiền")
                .HasColumnType("money");
            entity.Property(e => e.OverDate).HasComment("Hạn thanh toán");
            entity.Property(e => e.PaymentMethodId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã hình thức thanh toán")
                .HasColumnName("PaymentMethodID");
            entity.Property(e => e.PaymentTerms)
                .HasMaxLength(150)
                .HasComment("Điều khoản thanh toán");
            entity.Property(e => e.Paymented).HasComment("Đã thanh toán");
            entity.Property(e => e.PublishedInvoice).HasComment("Đã xuất Hóa đơn");
            entity.Property(e => e.RefPerson)
                .HasMaxLength(60)
                .HasComment("Người đại diện");
            entity.Property(e => e.RefPos)
                .HasMaxLength(40)
                .HasComment("Chức vụ");
            entity.Property(e => e.RowVersionId)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("RowVersionID");
            entity.Property(e => e.SalesManId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã nhân viên bán hàng")
                .HasColumnName("SalesManID");
            entity.Property(e => e.SeqInMonth).HasComment("Số thứ tự trong tháng");
            entity.Property(e => e.SeqInYear).HasComment("Số thứ tự trong năm");
            entity.Property(e => e.SubCompanyId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("MAIN")
                .HasColumnName("SubCompanyID");
            entity.Property(e => e.TaxRate)
                .HasComment("Thuế suất")
                .HasColumnType("smallmoney");
            entity.Property(e => e.TranMonth).HasComputedColumnSql("(datepart(month,[OrderDate]))", false);
            entity.Property(e => e.TranYear).HasComputedColumnSql("(datepart(year,[OrderDate]))", false);

            entity.HasOne(d => d.Executor).WithMany(p => p.OrderMasterExecutors)
                .HasPrincipalKey(p => p.EmployeeId)
                .HasForeignKey(d => d.ExecutorId)
                .HasConstraintName("FK_tblOrderMaster_tblEmployeeList");

            entity.HasOne(d => d.OrderForm).WithMany(p => p.OrderMasters)
                .HasForeignKey(d => d.OrderFormId)
                .HasConstraintName("FK_tblOrderMaster_tblOrderFormList");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.OrderMasters)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblOrderMaster_tblOrderStatusList");

            entity.HasOne(d => d.OrderType).WithMany(p => p.OrderMasters)
                .HasForeignKey(d => d.OrderTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblOrderMaster_tblOrderTypeList");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.OrderMasters)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK_tblOrderMaster_tblPaymentMethodList");

            entity.HasOne(d => d.SalesMan).WithMany(p => p.OrderMasterSalesMen)
                .HasPrincipalKey(p => p.EmployeeId)
                .HasForeignKey(d => d.SalesManId)
                .HasConstraintName("FK_tblOrderMaster_tblEmployeeList2");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId);

            entity.ToTable("tblOrderStatusList");

            entity.Property(e => e.OrderStatusId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã trạng thái đơn hàng")
                .HasColumnName("OrderStatusID");
            entity.Property(e => e.CanChangeStatus).HasComment("Là trạng thái có thể thay đổi bởi NV Sales");
            entity.Property(e => e.IsAcceptStatus).HasComment("Là trạng thái Đã duyệt");
            entity.Property(e => e.IsCancelStatus).HasComment("Là trạng thái Hủy");
            entity.Property(e => e.IsSuspendStatus).HasComment("Là trạng thái treo");
            entity.Property(e => e.OrderStatusName)
                .HasMaxLength(100)
                .HasComment("Tên trạng thái đơn hàng");
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity.HasKey(e => e.OrderTypeId);

            entity.ToTable("tblOrderTypeList");

            entity.Property(e => e.OrderTypeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã loại đơn hàng")
                .HasColumnName("OrderTypeID");
            entity.Property(e => e.OrderTypeName)
                .HasMaxLength(100)
                .HasComment("Tên loại đơn hàng");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId);

            entity.ToTable("tblPaymentMethodList");

            entity.Property(e => e.PaymentMethodId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã hình thức thanh toán")
                .HasColumnName("PaymentMethodID");
            entity.Property(e => e.IsDebit).HasComment("Hình thức trả chậm");
            entity.Property(e => e.PayAcctId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Tài khoản đối ứng (111, 112, 131, ...)")
                .HasColumnName("PayAcctID");
            entity.Property(e => e.PaymentMethodName)
                .HasMaxLength(100)
                .HasComment("Tên hình thức thanh toán");
        });

        modelBuilder.Entity<Permision>(entity =>
        {
            entity.HasKey(e => e.RowUniqueId);

            entity.ToTable("tblPermisionList");

            entity.HasIndex(e => e.DepartmentId, "UK_tblPermisionList").IsUnique();

            entity.Property(e => e.RowUniqueId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RowUniqueID");
            entity.Property(e => e.AcceptOrder).HasComment("Quyền duyệt Đơn hàng");
            entity.Property(e => e.AddNew).HasComment("Quyền thêm danh sách");
            entity.Property(e => e.AddNewOrder).HasComment("Quyền thêm Đơn hàng");
            entity.Property(e => e.CancelOrder).HasComment("Quyền hủy Đơn hàng");
            entity.Property(e => e.ChangeStatusOrder).HasComment("Quyền thay đổi trạng thái khác Đơn hàng");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày tạo");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người tạo")
                .HasColumnName("CreatedUserID");
            entity.Property(e => e.Delete).HasComment("Quyền xóa danh sách");
            entity.Property(e => e.DeleteOrder).HasComment("Quyền xóa Đơn hàng");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã phòng ban")
                .HasColumnName("DepartmentID");
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Ngày chỉnh sửa cuối cùng");
            entity.Property(e => e.LastModifiedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DAMIADMIN")
                .HasComment("Mã người chỉnh sửa cuối cùng")
                .HasColumnName("LastModifiedUserID");
            entity.Property(e => e.SuspendOrder).HasComment("Quyền treo Đơn hàng");
            entity.Property(e => e.Update).HasComment("Quyền sửa danh sách");
            entity.Property(e => e.UpdateOrder).HasComment("Quyền sửa Đơn hàng");
            entity.Property(e => e.ViewFullOrder).HasComment("Quyền xem đầy đủ Đơn hàng");
            entity.Property(e => e.ViewLimitOrder).HasComment("Quyền xem có giới hạn Đơn hàng");
            entity.Property(e => e.View).HasComment("Quyền xem danh sách");

            entity.HasOne(d => d.Department).WithOne(p => p.Permision)
                .HasPrincipalKey<Department>(p => p.DepartmentId)
                .HasForeignKey<Permision>(d => d.DepartmentId)
                .HasConstraintName("FK_tblPermisionList_tblDepartmentList");
        });

        modelBuilder.Entity<TaxCode>(entity =>
        {
            entity.HasKey(e => e.TaxCodeId);

            entity.ToTable("tblTaxCodeList");

            entity.Property(e => e.TaxCodeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("MST")
                .HasColumnName("TaxCode");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã KH")
                .HasColumnName("CustomerID");
            entity.Property(e => e.TaxCodeAddr)
                .HasMaxLength(400)
                .HasComment("Địa chỉ");
            entity.Property(e => e.TaxCodeName)
                .HasMaxLength(400)
                .HasComment("Tên công ty");
        });

        modelBuilder.Entity<ViwCustomer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viwCustomerList");

            entity.Property(e => e.Address1).HasMaxLength(250);
            entity.Property(e => e.Address2).HasMaxLength(200);
            entity.Property(e => e.ContactPerson).HasMaxLength(60);
            entity.Property(e => e.ContactPersonPos).HasMaxLength(60);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CreatedUserID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName).HasMaxLength(250);
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LastModifiedUserID");
            entity.Property(e => e.Mobile)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.TaxCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TradeAddress).HasMaxLength(250);
            entity.Property(e => e.TradeName).HasMaxLength(40);
            entity.Property(e => e.TranAddress).HasMaxLength(200);
            entity.Property(e => e.Website)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ViwFullItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viwFullItemList");

            entity.Property(e => e.AccountId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.AllowEditNumOfPc).HasColumnName("AllowEditNumOfPC");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CreatedUserID");
            entity.Property(e => e.DefNumOfPc).HasColumnName("DefNumOfPC");
            entity.Property(e => e.HasByPc).HasColumnName("HasByPC");
            entity.Property(e => e.InvUnitOfMeasr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IsPayFull).HasColumnName("isPayFull");
            entity.Property(e => e.IsPayYear).HasColumnName("isPayYear");
            entity.Property(e => e.ItemGroupId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ItemGroupID");
            entity.Property(e => e.ItemGroupName).HasMaxLength(150);
            entity.Property(e => e.ItemId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(250);
            entity.Property(e => e.ItemTypeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ItemTypeID");
            entity.Property(e => e.ItemTypeName).HasMaxLength(150);
            entity.Property(e => e.Language).HasMaxLength(40);
            entity.Property(e => e.LastModifiedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LastModifiedUserID");
            entity.Property(e => e.Notes).HasMaxLength(100);
            entity.Property(e => e.OrderFormId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OrderFormID");
            entity.Property(e => e.OrderFormName).HasMaxLength(150);
            entity.Property(e => e.RowUniqueId).HasColumnName("RowUniqueID");
            entity.Property(e => e.TaxRate).HasColumnType("smallmoney");
            entity.Property(e => e.UnitName).HasMaxLength(50);
        });

        modelBuilder.Entity<ViwItemGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viwItemGroupList");

            entity.Property(e => e.AllowEditNumOfPc).HasColumnName("AllowEditNumOfPC");
            entity.Property(e => e.ItemGroupId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ItemGroupID");
            entity.Property(e => e.ItemGroupName).HasMaxLength(150);
            entity.Property(e => e.ItemTypeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ItemTypeID");
        });

        modelBuilder.Entity<ViwItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viwItemList");

            entity.Property(e => e.Account133Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Account133ID");
            entity.Property(e => e.Account3331Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Account3331ID");
            entity.Property(e => e.Account511Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Account511ID");
            entity.Property(e => e.Account632Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Account632ID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CreatedUserID");
            entity.Property(e => e.DefNumOfPc).HasColumnName("DefNumOfPC");
            entity.Property(e => e.InvUnitOfMeasr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IsPayFull).HasColumnName("isPayFull");
            entity.Property(e => e.IsPayYear).HasColumnName("isPayYear");
            entity.Property(e => e.ItemGroupId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ItemGroupID");
            entity.Property(e => e.ItemId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(250);
            entity.Property(e => e.Language).HasMaxLength(40);
            entity.Property(e => e.LastModifiedUserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LastModifiedUserID");
            entity.Property(e => e.Notes).HasMaxLength(100);
            entity.Property(e => e.RowUniqueId).HasColumnName("RowUniqueID");
            entity.Property(e => e.TaxRate).HasColumnType("smallmoney");
        });

        modelBuilder.Entity<ViwItemType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viwItemTypeList");

            entity.Property(e => e.ItemTypeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ItemTypeID");
            entity.Property(e => e.ItemTypeName).HasMaxLength(150);
            entity.Property(e => e.OrderFormId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OrderFormID");
        });

        modelBuilder.Entity<ViwOrderMasterDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viwOrderMasterDetail");

            entity.Property(e => e.AccepterId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AccepterID");
            entity.Property(e => e.Address1).HasMaxLength(250);
            entity.Property(e => e.CnvPaymentAmount).HasColumnType("money");
            entity.Property(e => e.ContractNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ConvertAmount).HasColumnType("money");
            entity.Property(e => e.ConvertDiscAmount).HasColumnType("money");
            entity.Property(e => e.ConvertTaxAmount).HasColumnType("money");
            entity.Property(e => e.ConvertTotalAmount).HasColumnType("money");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName).HasMaxLength(250);
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.ExchangeRate).HasColumnType("smallmoney");
            entity.Property(e => e.Executor).HasMaxLength(40);
            entity.Property(e => e.HasInvoiceVat).HasColumnName("HasInvoiceVAT");
            entity.Property(e => e.ICloudDataSize).HasColumnName("iCloudDataSize");
            entity.Property(e => e.ItemId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(250);
            entity.Property(e => e.TaxCode)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(250);
            entity.Property(e => e.NumOfPc).HasColumnName("NumOfPC");
            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderFormId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OrderFormID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OrderStatusName).HasMaxLength(100);
            entity.Property(e => e.OrderTypeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OrderTypeID");
            entity.Property(e => e.OrderTypeName).HasMaxLength(100);
            entity.Property(e => e.OrgPaymentAmount).HasColumnType("money");
            entity.Property(e => e.OriginalAmount).HasColumnType("money");
            entity.Property(e => e.OriginalDiscAmount).HasColumnType("money");
            entity.Property(e => e.OriginalTaxAmount).HasColumnType("money");
            entity.Property(e => e.OriginalTotalAmount).HasColumnType("money");
            entity.Property(e => e.PaymentMethodName).HasMaxLength(100);
            entity.Property(e => e.PaymentTerms).HasMaxLength(150);
            entity.Property(e => e.RefPerson).HasMaxLength(60);
            entity.Property(e => e.RefPos).HasMaxLength(40);
            entity.Property(e => e.SalesManName).HasMaxLength(40);
            entity.Property(e => e.SubCompanyId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SubCompanyID");
            entity.Property(e => e.TaxCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TaxRate).HasColumnType("smallmoney");
            entity.Property(e => e.TradeName).HasMaxLength(40);
            entity.Property(e => e.UnitName).HasMaxLength(50);
        });

        modelBuilder.Entity<ViwUnitOfMeasr>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viwUnitOfMeasrList");

            entity.Property(e => e.UnitId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UnitID");
            entity.Property(e => e.UnitName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
