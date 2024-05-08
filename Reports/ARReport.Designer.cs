namespace DaMi.SO.Manager.Reports
{
    partial class ARReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter8 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARReport));
            this.TransactionYear = new DevExpress.XtraReports.Parameters.Parameter();
            this.TransactionMonth = new DevExpress.XtraReports.Parameters.Parameter();
            this.FromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.ToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.pageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblAccountId = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupAccountId = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.table2 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblRowNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblCustomerId = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblCustomerName = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblBeginDebit = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblBeginCredit = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblDebit = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblCredit = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblEndDebit = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblEndCredit = new DevExpress.XtraReports.UI.XRTableCell();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.table3 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.rowRowNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.rowCustomerId = new DevExpress.XtraReports.UI.XRTableCell();
            this.rowCustomerName = new DevExpress.XtraReports.UI.XRTableCell();
            this.rowBeginDebit = new DevExpress.XtraReports.UI.XRTableCell();
            this.rowBeginCredit = new DevExpress.XtraReports.UI.XRTableCell();
            this.rowDebit = new DevExpress.XtraReports.UI.XRTableCell();
            this.rowCredit = new DevExpress.XtraReports.UI.XRTableCell();
            this.rowEndDebit = new DevExpress.XtraReports.UI.XRTableCell();
            this.rowEndCredit = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.panel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.lblSumGroup = new DevExpress.XtraReports.UI.XRLabel();
            this.groupBeginDebit = new DevExpress.XtraReports.UI.XRLabel();
            this.groupBeginCredit = new DevExpress.XtraReports.UI.XRLabel();
            this.groupDebit = new DevExpress.XtraReports.UI.XRLabel();
            this.groupCredit = new DevExpress.XtraReports.UI.XRLabel();
            this.groupEndDebit = new DevExpress.XtraReports.UI.XRLabel();
            this.groupEndCredit = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.panel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.lblSumTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.totalBeginDebit = new DevExpress.XtraReports.UI.XRLabel();
            this.totalBeginCredit = new DevExpress.XtraReports.UI.XRLabel();
            this.totalDebit = new DevExpress.XtraReports.UI.XRLabel();
            this.totalCredit = new DevExpress.XtraReports.UI.XRLabel();
            this.totalEndDebit = new DevExpress.XtraReports.UI.XRLabel();
            this.totalEndCredit = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlDataSource = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupCaption1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupData1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupFooterBackground3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.TotalCaption1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.TotalData1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.TotalBackground1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GrandTotalCaption1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GrandTotalData1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GrandTotalBackground1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TransactionYear
            // 
            this.TransactionYear.Name = "TransactionYear";
            this.TransactionYear.Type = typeof(short);
            this.TransactionYear.ValueInfo = "0";
            // 
            // TransactionMonth
            // 
            this.TransactionMonth.Name = "TransactionMonth";
            this.TransactionMonth.Type = typeof(int);
            this.TransactionMonth.ValueInfo = "0";
            // 
            // FromDate
            // 
            this.FromDate.Name = "FromDate";
            this.FromDate.Type = typeof(global::System.DateTime);
            this.FromDate.ValueInfo = "2024-05-07";
            // 
            // ToDate
            // 
            this.ToDate.Name = "ToDate";
            this.ToDate.Type = typeof(global::System.DateTime);
            this.ToDate.ValueInfo = "2024-05-07";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 254F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pageInfo1,
            this.pageInfo2});
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 254F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // pageInfo1
            // 
            this.pageInfo1.Dpi = 254F;
            this.pageInfo1.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.pageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.pageInfo1.Name = "pageInfo1";
            this.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.pageInfo1.SizeF = new System.Drawing.SizeF(1846F, 58F);
            this.pageInfo1.StyleName = "PageInfo";
            this.pageInfo1.StylePriority.UseFont = false;
            // 
            // pageInfo2
            // 
            this.pageInfo2.Dpi = 254F;
            this.pageInfo2.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.pageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(1846F, 0F);
            this.pageInfo2.Name = "pageInfo2";
            this.pageInfo2.SizeF = new System.Drawing.SizeF(1846F, 58F);
            this.pageInfo2.StyleName = "PageInfo";
            this.pageInfo2.StylePriority.UseFont = false;
            this.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.pageInfo2.TextFormatString = "Page {0} of {1}";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.label1});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 152.4F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // label1
            // 
            this.label1.Dpi = 254F;
            this.label1.Font = new DevExpress.Drawing.DXFont("Times New Roman", 14.25F);
            this.label1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.label1.Name = "label1";
            this.label1.SizeF = new System.Drawing.SizeF(3692F, 61.45361F);
            this.label1.StyleName = "Title";
            this.label1.StylePriority.UseFont = false;
            this.label1.StylePriority.UseTextAlignment = false;
            this.label1.Text = "BÁO CÁO CÔNG NỢ";
            this.label1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table1});
            this.GroupHeader1.Dpi = 254F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("AccountID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader1.HeightF = 68.58F;
            this.GroupHeader1.Level = 1;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // table1
            // 
            this.table1.Dpi = 254F;
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5.08F);
            this.table1.Name = "table1";
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1});
            this.table1.SizeF = new System.Drawing.SizeF(3692F, 63.5F);
            // 
            // tableRow1
            // 
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblAccountId,
            this.GroupAccountId});
            this.tableRow1.Dpi = 254F;
            this.tableRow1.Name = "tableRow1";
            this.tableRow1.Weight = 1D;
            // 
            // lblAccountId
            // 
            this.lblAccountId.Dpi = 254F;
            this.lblAccountId.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.lblAccountId.Multiline = true;
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.StyleName = "GroupCaption1";
            this.lblAccountId.StylePriority.UseFont = false;
            this.lblAccountId.Text = "Mã TK\r\n";
            this.lblAccountId.Weight = 0.054901862841902675D;
            // 
            // GroupAccountId
            // 
            this.GroupAccountId.Dpi = 254F;
            this.GroupAccountId.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AccountID]")});
            this.GroupAccountId.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.GroupAccountId.Name = "GroupAccountId";
            this.GroupAccountId.StyleName = "GroupData1";
            this.GroupAccountId.StylePriority.UseFont = false;
            this.GroupAccountId.Weight = 0.9450981826203616D;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table2});
            this.GroupHeader2.Dpi = 254F;
            this.GroupHeader2.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader2.HeightF = 71.12F;
            this.GroupHeader2.Level = 2;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // table2
            // 
            this.table2.Dpi = 254F;
            this.table2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table2.Name = "table2";
            this.table2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow2});
            this.table2.SizeF = new System.Drawing.SizeF(3692F, 71.12F);
            // 
            // tableRow2
            // 
            this.tableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblRowNo,
            this.lblCustomerId,
            this.lblCustomerName,
            this.lblBeginDebit,
            this.lblBeginCredit,
            this.lblDebit,
            this.lblCredit,
            this.lblEndDebit,
            this.lblEndCredit});
            this.tableRow2.Dpi = 254F;
            this.tableRow2.Name = "tableRow2";
            this.tableRow2.Weight = 1D;
            // 
            // lblRowNo
            // 
            this.lblRowNo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblRowNo.Dpi = 254F;
            this.lblRowNo.Font = new DevExpress.Drawing.DXFont("Times New Roman", 8.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.lblRowNo.Name = "lblRowNo";
            this.lblRowNo.StyleName = "DetailCaption1";
            this.lblRowNo.StylePriority.UseBorders = false;
            this.lblRowNo.StylePriority.UseFont = false;
            this.lblRowNo.StylePriority.UseTextAlignment = false;
            this.lblRowNo.Text = "STT";
            this.lblRowNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblRowNo.Weight = 0.028386197629007921D;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.Dpi = 254F;
            this.lblCustomerId.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.StyleName = "DetailCaption1";
            this.lblCustomerId.StylePriority.UseFont = false;
            this.lblCustomerId.StylePriority.UseTextAlignment = false;
            this.lblCustomerId.Text = "Mã KH";
            this.lblCustomerId.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblCustomerId.Weight = 0.082139126579432D;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Dpi = 254F;
            this.lblCustomerName.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.StyleName = "DetailCaption1";
            this.lblCustomerName.StylePriority.UseFont = false;
            this.lblCustomerName.StylePriority.UseTextAlignment = false;
            this.lblCustomerName.Text = "Tên khách hàng";
            this.lblCustomerName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblCustomerName.Weight = 0.35776726229287326D;
            // 
            // lblBeginDebit
            // 
            this.lblBeginDebit.Dpi = 254F;
            this.lblBeginDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.lblBeginDebit.Name = "lblBeginDebit";
            this.lblBeginDebit.StyleName = "DetailCaption1";
            this.lblBeginDebit.StylePriority.UseFont = false;
            this.lblBeginDebit.StylePriority.UseTextAlignment = false;
            this.lblBeginDebit.Text = "Nợ đầu kỳ";
            this.lblBeginDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblBeginDebit.Weight = 0.073639007022852D;
            // 
            // lblBeginCredit
            // 
            this.lblBeginCredit.Dpi = 254F;
            this.lblBeginCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.lblBeginCredit.Name = "lblBeginCredit";
            this.lblBeginCredit.StyleName = "DetailCaption1";
            this.lblBeginCredit.StylePriority.UseFont = false;
            this.lblBeginCredit.StylePriority.UseTextAlignment = false;
            this.lblBeginCredit.Text = "Có đầu kỳ";
            this.lblBeginCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblBeginCredit.Weight = 0.073627549761899364D;
            // 
            // lblDebit
            // 
            this.lblDebit.Dpi = 254F;
            this.lblDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.lblDebit.Name = "lblDebit";
            this.lblDebit.StyleName = "DetailCaption1";
            this.lblDebit.StylePriority.UseFont = false;
            this.lblDebit.StylePriority.UseTextAlignment = false;
            this.lblDebit.Text = "Nợ phát sinh";
            this.lblDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblDebit.Weight = 0.0751611838434573D;
            // 
            // lblCredit
            // 
            this.lblCredit.Dpi = 254F;
            this.lblCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.StyleName = "DetailCaption1";
            this.lblCredit.StylePriority.UseFont = false;
            this.lblCredit.StylePriority.UseTextAlignment = false;
            this.lblCredit.Text = "Có phát sinh";
            this.lblCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblCredit.Weight = 0.07253170670497161D;
            // 
            // lblEndDebit
            // 
            this.lblEndDebit.Dpi = 254F;
            this.lblEndDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.lblEndDebit.Name = "lblEndDebit";
            this.lblEndDebit.StyleName = "DetailCaption1";
            this.lblEndDebit.StylePriority.UseFont = false;
            this.lblEndDebit.StylePriority.UseTextAlignment = false;
            this.lblEndDebit.Text = "Nợ cuối kỳ";
            this.lblEndDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblEndDebit.Weight = 0.0739058082038915D;
            // 
            // lblEndCredit
            // 
            this.lblEndCredit.Dpi = 254F;
            this.lblEndCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.lblEndCredit.Name = "lblEndCredit";
            this.lblEndCredit.StyleName = "DetailCaption1";
            this.lblEndCredit.StylePriority.UseFont = false;
            this.lblEndCredit.StylePriority.UseTextAlignment = false;
            this.lblEndCredit.Text = "Có cuối kỳ";
            this.lblEndCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblEndCredit.Weight = 0.072276357090487534D;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table3});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 63.42F;
            this.Detail.HierarchyPrintOptions.Indent = 50.8F;
            this.Detail.Name = "Detail";
            // 
            // table3
            // 
            this.table3.Dpi = 254F;
            this.table3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table3.Name = "table3";
            this.table3.OddStyleName = "DetailData3_Odd";
            this.table3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow3});
            this.table3.SizeF = new System.Drawing.SizeF(3692F, 63.42F);
            // 
            // tableRow3
            // 
            this.tableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.rowRowNo,
            this.rowCustomerId,
            this.rowCustomerName,
            this.rowBeginDebit,
            this.rowBeginCredit,
            this.rowDebit,
            this.rowCredit,
            this.rowEndDebit,
            this.rowEndCredit});
            this.tableRow3.Dpi = 254F;
            this.tableRow3.Name = "tableRow3";
            this.tableRow3.Weight = 11.683999633789062D;
            // 
            // rowRowNo
            // 
            this.rowRowNo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.rowRowNo.Dpi = 254F;
            this.rowRowNo.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[RowNumber]")});
            this.rowRowNo.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.rowRowNo.Name = "rowRowNo";
            this.rowRowNo.StyleName = "DetailData1";
            this.rowRowNo.StylePriority.UseBorders = false;
            this.rowRowNo.StylePriority.UseFont = false;
            this.rowRowNo.StylePriority.UseTextAlignment = false;
            this.rowRowNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.rowRowNo.Weight = 0.02838620326570648D;
            // 
            // rowCustomerId
            // 
            this.rowCustomerId.Dpi = 254F;
            this.rowCustomerId.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CustomerID]")});
            this.rowCustomerId.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.rowCustomerId.Name = "rowCustomerId";
            this.rowCustomerId.StyleName = "DetailData1";
            this.rowCustomerId.StylePriority.UseFont = false;
            this.rowCustomerId.Weight = 0.082139115303422175D;
            // 
            // rowCustomerName
            // 
            this.rowCustomerName.Dpi = 254F;
            this.rowCustomerName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CustomerName]")});
            this.rowCustomerName.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.rowCustomerName.Name = "rowCustomerName";
            this.rowCustomerName.StyleName = "DetailData1";
            this.rowCustomerName.StylePriority.UseFont = false;
            this.rowCustomerName.Weight = 0.36477520520085654D;
            // 
            // rowBeginDebit
            // 
            this.rowBeginDebit.Dpi = 254F;
            this.rowBeginDebit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CnvBegDebit]")});
            this.rowBeginDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.rowBeginDebit.Name = "rowBeginDebit";
            this.rowBeginDebit.StyleName = "DetailData1";
            this.rowBeginDebit.StylePriority.UseFont = false;
            this.rowBeginDebit.StylePriority.UseTextAlignment = false;
            this.rowBeginDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.rowBeginDebit.TextFormatString = "{0:N0}";
            this.rowBeginDebit.Weight = 0.074741052598751079D;
            // 
            // rowBeginCredit
            // 
            this.rowBeginCredit.Dpi = 254F;
            this.rowBeginCredit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CnvBegCredit]")});
            this.rowBeginCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.rowBeginCredit.Name = "rowBeginCredit";
            this.rowBeginCredit.StyleName = "DetailData1";
            this.rowBeginCredit.StylePriority.UseFont = false;
            this.rowBeginCredit.StylePriority.UseTextAlignment = false;
            this.rowBeginCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.rowBeginCredit.TextFormatString = "{0:N0}";
            this.rowBeginCredit.Weight = 0.074729387564606842D;
            // 
            // rowDebit
            // 
            this.rowDebit.Dpi = 254F;
            this.rowDebit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CnvDebit]")});
            this.rowDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.rowDebit.Name = "rowDebit";
            this.rowDebit.StyleName = "DetailData1";
            this.rowDebit.StylePriority.UseFont = false;
            this.rowDebit.StylePriority.UseTextAlignment = false;
            this.rowDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.rowDebit.TextFormatString = "{0:N0}";
            this.rowDebit.Weight = 0.076285909471444771D;
            // 
            // rowCredit
            // 
            this.rowCredit.Dpi = 254F;
            this.rowCredit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CnvCredit]")});
            this.rowCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.rowCredit.Name = "rowCredit";
            this.rowCredit.StyleName = "DetailData1";
            this.rowCredit.StylePriority.UseFont = false;
            this.rowCredit.StylePriority.UseTextAlignment = false;
            this.rowCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.rowCredit.TextFormatString = "{0:N0}";
            this.rowCredit.Weight = 0.073617090640862956D;
            // 
            // rowEndDebit
            // 
            this.rowEndDebit.Dpi = 254F;
            this.rowEndDebit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CnvEndDebit]")});
            this.rowEndDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.rowEndDebit.Name = "rowEndDebit";
            this.rowEndDebit.StyleName = "DetailData1";
            this.rowEndDebit.StylePriority.UseFont = false;
            this.rowEndDebit.StylePriority.UseTextAlignment = false;
            this.rowEndDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.rowEndDebit.TextFormatString = "{0:N0}";
            this.rowEndDebit.Weight = 0.0750118680445024D;
            // 
            // rowEndCredit
            // 
            this.rowEndCredit.Dpi = 254F;
            this.rowEndCredit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CnvEndCredit]")});
            this.rowEndCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.rowEndCredit.Name = "rowEndCredit";
            this.rowEndCredit.StyleName = "DetailData1";
            this.rowEndCredit.StylePriority.UseFont = false;
            this.rowEndCredit.StylePriority.UseTextAlignment = false;
            this.rowEndCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.rowEndCredit.TextFormatString = "{0:N0}";
            this.rowEndCredit.Weight = 0.073358019255979429D;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.label2});
            this.GroupFooter1.Dpi = 254F;
            this.GroupFooter1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.GroupFooter1.HeightF = 5.2832F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // label2
            // 
            this.label2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.label2.Dpi = 254F;
            this.label2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.label2.Name = "label2";
            this.label2.SizeF = new System.Drawing.SizeF(3692F, 5.2832F);
            this.label2.StyleName = "GroupFooterBackground3";
            this.label2.StylePriority.UseBorders = false;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.panel1});
            this.GroupFooter2.Dpi = 254F;
            this.GroupFooter2.Expanded = false;
            this.GroupFooter2.HeightF = 84.11719F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblSumGroup,
            this.groupBeginDebit,
            this.groupBeginCredit,
            this.groupDebit,
            this.groupCredit,
            this.groupEndDebit,
            this.groupEndCredit});
            this.panel1.Dpi = 254F;
            this.panel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.panel1.Name = "panel1";
            this.panel1.SizeF = new System.Drawing.SizeF(3692F, 84.11719F);
            this.panel1.StyleName = "TotalBackground1";
            // 
            // lblSumGroup
            // 
            this.lblSumGroup.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblSumGroup.Dpi = 254F;
            this.lblSumGroup.LocationFloat = new DevExpress.Utils.PointFloat(0F, 8.63602F);
            this.lblSumGroup.Multiline = true;
            this.lblSumGroup.Name = "lblSumGroup";
            this.lblSumGroup.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblSumGroup.SizeF = new System.Drawing.SizeF(1901.112F, 62.00001F);
            this.lblSumGroup.StylePriority.UseBorders = false;
            this.lblSumGroup.StylePriority.UseTextAlignment = false;
            this.lblSumGroup.Text = "Tổng theo nhóm";
            this.lblSumGroup.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // groupBeginDebit
            // 
            this.groupBeginDebit.CanGrow = false;
            this.groupBeginDebit.Dpi = 254F;
            this.groupBeginDebit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvBegDebit])")});
            this.groupBeginDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.groupBeginDebit.LocationFloat = new DevExpress.Utils.PointFloat(1901.112F, 8.63602F);
            this.groupBeginDebit.Name = "groupBeginDebit";
            this.groupBeginDebit.SizeF = new System.Drawing.SizeF(298.9502F, 62F);
            this.groupBeginDebit.StyleName = "TotalData1";
            this.groupBeginDebit.StylePriority.UseFont = false;
            this.groupBeginDebit.StylePriority.UseTextAlignment = false;
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.groupBeginDebit.Summary = xrSummary1;
            this.groupBeginDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.groupBeginDebit.TextFormatString = "{0:N0}";
            this.groupBeginDebit.WordWrap = false;
            // 
            // groupBeginCredit
            // 
            this.groupBeginCredit.CanGrow = false;
            this.groupBeginCredit.Dpi = 254F;
            this.groupBeginCredit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvBegCredit])")});
            this.groupBeginCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.groupBeginCredit.LocationFloat = new DevExpress.Utils.PointFloat(2200.062F, 8.63602F);
            this.groupBeginCredit.Name = "groupBeginCredit";
            this.groupBeginCredit.SizeF = new System.Drawing.SizeF(298.9033F, 62F);
            this.groupBeginCredit.StyleName = "TotalData1";
            this.groupBeginCredit.StylePriority.UseFont = false;
            this.groupBeginCredit.StylePriority.UseTextAlignment = false;
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.groupBeginCredit.Summary = xrSummary2;
            this.groupBeginCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.groupBeginCredit.TextFormatString = "{0:N0}";
            this.groupBeginCredit.WordWrap = false;
            // 
            // groupDebit
            // 
            this.groupDebit.CanGrow = false;
            this.groupDebit.Dpi = 254F;
            this.groupDebit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvDebit])")});
            this.groupDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.groupDebit.LocationFloat = new DevExpress.Utils.PointFloat(2498.965F, 8.63602F);
            this.groupDebit.Name = "groupDebit";
            this.groupDebit.SizeF = new System.Drawing.SizeF(305.1296F, 62F);
            this.groupDebit.StyleName = "TotalData1";
            this.groupDebit.StylePriority.UseFont = false;
            this.groupDebit.StylePriority.UseTextAlignment = false;
            xrSummary3.IgnoreNullValues = true;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.groupDebit.Summary = xrSummary3;
            this.groupDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.groupDebit.TextFormatString = "{0:N0}";
            this.groupDebit.WordWrap = false;
            // 
            // groupCredit
            // 
            this.groupCredit.CanGrow = false;
            this.groupCredit.Dpi = 254F;
            this.groupCredit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvCredit])")});
            this.groupCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.groupCredit.LocationFloat = new DevExpress.Utils.PointFloat(2804.095F, 8.63602F);
            this.groupCredit.Name = "groupCredit";
            this.groupCredit.SizeF = new System.Drawing.SizeF(294.4539F, 62F);
            this.groupCredit.StyleName = "TotalData1";
            this.groupCredit.StylePriority.UseFont = false;
            this.groupCredit.StylePriority.UseTextAlignment = false;
            xrSummary4.IgnoreNullValues = true;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.groupCredit.Summary = xrSummary4;
            this.groupCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.groupCredit.TextFormatString = "{0:N0}";
            this.groupCredit.WordWrap = false;
            // 
            // groupEndDebit
            // 
            this.groupEndDebit.CanGrow = false;
            this.groupEndDebit.Dpi = 254F;
            this.groupEndDebit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvEndDebit])")});
            this.groupEndDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.groupEndDebit.LocationFloat = new DevExpress.Utils.PointFloat(3098.549F, 8.63602F);
            this.groupEndDebit.Name = "groupEndDebit";
            this.groupEndDebit.SizeF = new System.Drawing.SizeF(300.0334F, 62F);
            this.groupEndDebit.StyleName = "TotalData1";
            this.groupEndDebit.StylePriority.UseFont = false;
            this.groupEndDebit.StylePriority.UseTextAlignment = false;
            xrSummary5.IgnoreNullValues = true;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.groupEndDebit.Summary = xrSummary5;
            this.groupEndDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.groupEndDebit.TextFormatString = "{0:N0}";
            this.groupEndDebit.WordWrap = false;
            // 
            // groupEndCredit
            // 
            this.groupEndCredit.CanGrow = false;
            this.groupEndCredit.Dpi = 254F;
            this.groupEndCredit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvEndCredit])")});
            this.groupEndCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.groupEndCredit.LocationFloat = new DevExpress.Utils.PointFloat(3398.582F, 8.63602F);
            this.groupEndCredit.Name = "groupEndCredit";
            this.groupEndCredit.SizeF = new System.Drawing.SizeF(293.418F, 62F);
            this.groupEndCredit.StyleName = "TotalData1";
            this.groupEndCredit.StylePriority.UseFont = false;
            this.groupEndCredit.StylePriority.UseTextAlignment = false;
            xrSummary6.IgnoreNullValues = true;
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.groupEndCredit.Summary = xrSummary6;
            this.groupEndCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.groupEndCredit.TextFormatString = "{0:N0}";
            this.groupEndCredit.WordWrap = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.panel2});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.HeightF = 125.4365F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // panel2
            // 
            this.panel2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblSumTotal,
            this.totalBeginDebit,
            this.totalBeginCredit,
            this.totalDebit,
            this.totalCredit,
            this.totalEndDebit,
            this.totalEndCredit});
            this.panel2.Dpi = 254F;
            this.panel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.panel2.Name = "panel2";
            this.panel2.SizeF = new System.Drawing.SizeF(3692F, 125.4365F);
            this.panel2.StyleName = "GrandTotalBackground1";
            // 
            // lblSumTotal
            // 
            this.lblSumTotal.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblSumTotal.Dpi = 254F;
            this.lblSumTotal.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.lblSumTotal.LocationFloat = new DevExpress.Utils.PointFloat(0F, 29.2101F);
            this.lblSumTotal.Multiline = true;
            this.lblSumTotal.Name = "lblSumTotal";
            this.lblSumTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblSumTotal.SizeF = new System.Drawing.SizeF(1901.112F, 61.99989F);
            this.lblSumTotal.StylePriority.UseBorders = false;
            this.lblSumTotal.StylePriority.UseFont = false;
            this.lblSumTotal.StylePriority.UseTextAlignment = false;
            this.lblSumTotal.Text = "Tổng cộng";
            this.lblSumTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // totalBeginDebit
            // 
            this.totalBeginDebit.CanGrow = false;
            this.totalBeginDebit.Dpi = 254F;
            this.totalBeginDebit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvBegDebit])")});
            this.totalBeginDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.totalBeginDebit.LocationFloat = new DevExpress.Utils.PointFloat(1901.112F, 29.2101F);
            this.totalBeginDebit.Name = "totalBeginDebit";
            this.totalBeginDebit.SizeF = new System.Drawing.SizeF(298.9502F, 62F);
            this.totalBeginDebit.StyleName = "GrandTotalData1";
            this.totalBeginDebit.StylePriority.UseFont = false;
            this.totalBeginDebit.StylePriority.UseTextAlignment = false;
            xrSummary7.IgnoreNullValues = true;
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.totalBeginDebit.Summary = xrSummary7;
            this.totalBeginDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.totalBeginDebit.TextFormatString = "{0:N0}";
            this.totalBeginDebit.WordWrap = false;
            // 
            // totalBeginCredit
            // 
            this.totalBeginCredit.CanGrow = false;
            this.totalBeginCredit.Dpi = 254F;
            this.totalBeginCredit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvBegCredit])")});
            this.totalBeginCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.totalBeginCredit.LocationFloat = new DevExpress.Utils.PointFloat(2200.062F, 29.2101F);
            this.totalBeginCredit.Name = "totalBeginCredit";
            this.totalBeginCredit.SizeF = new System.Drawing.SizeF(298.9033F, 62F);
            this.totalBeginCredit.StyleName = "GrandTotalData1";
            this.totalBeginCredit.StylePriority.UseFont = false;
            this.totalBeginCredit.StylePriority.UseTextAlignment = false;
            xrSummary8.IgnoreNullValues = true;
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.totalBeginCredit.Summary = xrSummary8;
            this.totalBeginCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.totalBeginCredit.TextFormatString = "{0:N0}";
            this.totalBeginCredit.WordWrap = false;
            // 
            // totalDebit
            // 
            this.totalDebit.CanGrow = false;
            this.totalDebit.Dpi = 254F;
            this.totalDebit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvDebit])")});
            this.totalDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.totalDebit.LocationFloat = new DevExpress.Utils.PointFloat(2498.965F, 29.2101F);
            this.totalDebit.Name = "totalDebit";
            this.totalDebit.SizeF = new System.Drawing.SizeF(305.1292F, 62F);
            this.totalDebit.StyleName = "GrandTotalData1";
            this.totalDebit.StylePriority.UseFont = false;
            this.totalDebit.StylePriority.UseTextAlignment = false;
            xrSummary9.IgnoreNullValues = true;
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.totalDebit.Summary = xrSummary9;
            this.totalDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.totalDebit.TextFormatString = "{0:N0}";
            this.totalDebit.WordWrap = false;
            // 
            // totalCredit
            // 
            this.totalCredit.CanGrow = false;
            this.totalCredit.Dpi = 254F;
            this.totalCredit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvCredit])")});
            this.totalCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.totalCredit.LocationFloat = new DevExpress.Utils.PointFloat(2804.095F, 29.2101F);
            this.totalCredit.Name = "totalCredit";
            this.totalCredit.SizeF = new System.Drawing.SizeF(294.4541F, 62F);
            this.totalCredit.StyleName = "GrandTotalData1";
            this.totalCredit.StylePriority.UseFont = false;
            this.totalCredit.StylePriority.UseTextAlignment = false;
            xrSummary10.IgnoreNullValues = true;
            xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.totalCredit.Summary = xrSummary10;
            this.totalCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.totalCredit.TextFormatString = "{0:N0}";
            this.totalCredit.WordWrap = false;
            // 
            // totalEndDebit
            // 
            this.totalEndDebit.CanGrow = false;
            this.totalEndDebit.Dpi = 254F;
            this.totalEndDebit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvEndDebit])")});
            this.totalEndDebit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.totalEndDebit.LocationFloat = new DevExpress.Utils.PointFloat(3098.549F, 29.2101F);
            this.totalEndDebit.Name = "totalEndDebit";
            this.totalEndDebit.SizeF = new System.Drawing.SizeF(300.033F, 62F);
            this.totalEndDebit.StyleName = "GrandTotalData1";
            this.totalEndDebit.StylePriority.UseFont = false;
            this.totalEndDebit.StylePriority.UseTextAlignment = false;
            xrSummary11.IgnoreNullValues = true;
            xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.totalEndDebit.Summary = xrSummary11;
            this.totalEndDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.totalEndDebit.TextFormatString = "{0:N0}";
            this.totalEndDebit.WordWrap = false;
            // 
            // totalEndCredit
            // 
            this.totalEndCredit.CanGrow = false;
            this.totalEndCredit.Dpi = 254F;
            this.totalEndCredit.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CnvEndCredit])")});
            this.totalEndCredit.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.totalEndCredit.LocationFloat = new DevExpress.Utils.PointFloat(3398.582F, 29.2101F);
            this.totalEndCredit.Name = "totalEndCredit";
            this.totalEndCredit.SizeF = new System.Drawing.SizeF(293.418F, 62F);
            this.totalEndCredit.StyleName = "GrandTotalData1";
            this.totalEndCredit.StylePriority.UseFont = false;
            this.totalEndCredit.StylePriority.UseTextAlignment = false;
            xrSummary12.IgnoreNullValues = true;
            xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.totalEndCredit.Summary = xrSummary12;
            this.totalEndCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.totalEndCredit.TextFormatString = "{0:N0}";
            this.totalEndCredit.WordWrap = false;
            // 
            // sqlDataSource
            // 
            this.sqlDataSource.ConnectionName = "main";
            this.sqlDataSource.Name = "sqlDataSource";
            storedProcQuery1.Name = "SL_spRptCustomerBalancebyDate";
            queryParameter1.Name = "@TranYear";
            queryParameter1.Type = typeof(global::DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("?TransactionYear", typeof(short));
            queryParameter2.Name = "@TranMonth";
            queryParameter2.Type = typeof(global::DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("?TransactionMonth", typeof(int));
            queryParameter3.Name = "@SubCompanyID";
            queryParameter3.Type = typeof(string);
            queryParameter3.ValueInfo = "DAMI";
            queryParameter4.Name = "@IsTotalCompany";
            queryParameter4.Type = typeof(bool);
            queryParameter4.ValueInfo = "False";
            queryParameter5.Name = "@AccountID";
            queryParameter5.Type = typeof(string);
            queryParameter6.Name = "@BaseCurrID";
            queryParameter6.Type = typeof(string);
            queryParameter6.ValueInfo = "VND";
            queryParameter7.Name = "@FromDate";
            queryParameter7.Type = typeof(global::DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("?FromDate", typeof(System.DateTime));
            queryParameter8.Name = "@ToDate";
            queryParameter8.Type = typeof(global::DevExpress.DataAccess.Expression);
            queryParameter8.Value = new DevExpress.DataAccess.Expression("?ToDate", typeof(System.DateTime));
            storedProcQuery1.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter1,
            queryParameter2,
            queryParameter3,
            queryParameter4,
            queryParameter5,
            queryParameter6,
            queryParameter7,
            queryParameter8});
            storedProcQuery1.StoredProcName = "SL_spRptCustomerBalancebyDate";
            this.sqlDataSource.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource.ResultSchemaSerializable = resources.GetString("sqlDataSource.ResultSchemaSerializable");
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new DevExpress.Drawing.DXFont("Arial", 14.25F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.Title.Name = "Title";
            this.Title.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            // 
            // GroupCaption1
            // 
            this.GroupCaption1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(159)))), ((int)(((byte)(228)))));
            this.GroupCaption1.BorderColor = System.Drawing.Color.White;
            this.GroupCaption1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.GroupCaption1.BorderWidth = 2F;
            this.GroupCaption1.Font = new DevExpress.Drawing.DXFont("Arial", 8.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GroupCaption1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.GroupCaption1.Name = "GroupCaption1";
            this.GroupCaption1.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 5, 0, 0, 254F);
            this.GroupCaption1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupData1
            // 
            this.GroupData1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(159)))), ((int)(((byte)(228)))));
            this.GroupData1.BorderColor = System.Drawing.Color.White;
            this.GroupData1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.GroupData1.BorderWidth = 2F;
            this.GroupData1.Font = new DevExpress.Drawing.DXFont("Arial", 8.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GroupData1.ForeColor = System.Drawing.Color.White;
            this.GroupData1.Name = "GroupData1";
            this.GroupData1.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 5, 0, 0, 254F);
            this.GroupData1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailCaption1
            // 
            this.DetailCaption1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(159)))), ((int)(((byte)(228)))));
            this.DetailCaption1.BorderColor = System.Drawing.Color.White;
            this.DetailCaption1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailCaption1.BorderWidth = 2F;
            this.DetailCaption1.Font = new DevExpress.Drawing.DXFont("Arial", 8.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.DetailCaption1.ForeColor = System.Drawing.Color.White;
            this.DetailCaption1.Name = "DetailCaption1";
            this.DetailCaption1.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.DetailCaption1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData1
            // 
            this.DetailData1.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailData1.BorderWidth = 2F;
            this.DetailData1.Font = new DevExpress.Drawing.DXFont("Arial", 8.25F);
            this.DetailData1.ForeColor = System.Drawing.Color.Black;
            this.DetailData1.Name = "DetailData1";
            this.DetailData1.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.DetailData1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupFooterBackground3
            // 
            this.GroupFooterBackground3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(117)))), ((int)(((byte)(129)))));
            this.GroupFooterBackground3.BorderColor = System.Drawing.Color.White;
            this.GroupFooterBackground3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.GroupFooterBackground3.BorderWidth = 2F;
            this.GroupFooterBackground3.Font = new DevExpress.Drawing.DXFont("Arial", 8.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GroupFooterBackground3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.GroupFooterBackground3.Name = "GroupFooterBackground3";
            this.GroupFooterBackground3.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 5, 0, 0, 254F);
            this.GroupFooterBackground3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3_Odd
            // 
            this.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailData3_Odd.BorderWidth = 1F;
            this.DetailData3_Odd.Font = new DevExpress.Drawing.DXFont("Arial", 8.25F);
            this.DetailData3_Odd.ForeColor = System.Drawing.Color.Black;
            this.DetailData3_Odd.Name = "DetailData3_Odd";
            this.DetailData3_Odd.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TotalCaption1
            // 
            this.TotalCaption1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalCaption1.Font = new DevExpress.Drawing.DXFont("Arial", 8.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.TotalCaption1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(186)))), ((int)(((byte)(192)))));
            this.TotalCaption1.Name = "TotalCaption1";
            this.TotalCaption1.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 5, 0, 0, 254F);
            this.TotalCaption1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TotalData1
            // 
            this.TotalData1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalData1.Font = new DevExpress.Drawing.DXFont("Arial", 8.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.TotalData1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.TotalData1.Name = "TotalData1";
            this.TotalData1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 15, 0, 0, 254F);
            this.TotalData1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TotalBackground1
            // 
            this.TotalBackground1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.TotalBackground1.BorderColor = System.Drawing.Color.White;
            this.TotalBackground1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.TotalBackground1.BorderWidth = 2F;
            this.TotalBackground1.Name = "TotalBackground1";
            // 
            // GrandTotalCaption1
            // 
            this.GrandTotalCaption1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GrandTotalCaption1.Font = new DevExpress.Drawing.DXFont("Arial", 8.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GrandTotalCaption1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.GrandTotalCaption1.Name = "GrandTotalCaption1";
            this.GrandTotalCaption1.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 5, 0, 0, 254F);
            this.GrandTotalCaption1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GrandTotalData1
            // 
            this.GrandTotalData1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GrandTotalData1.Font = new DevExpress.Drawing.DXFont("Arial", 8.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GrandTotalData1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.GrandTotalData1.Name = "GrandTotalData1";
            this.GrandTotalData1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 15, 0, 0, 254F);
            this.GrandTotalData1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GrandTotalBackground1
            // 
            this.GrandTotalBackground1.BackColor = System.Drawing.Color.White;
            this.GrandTotalBackground1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.GrandTotalBackground1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.GrandTotalBackground1.BorderWidth = 2F;
            this.GrandTotalBackground1.Name = "GrandTotalBackground1";
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new DevExpress.Drawing.DXFont("Arial", 8.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            // 
            // ARReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1,
            this.GroupHeader2,
            this.Detail,
            this.GroupFooter1,
            this.GroupFooter2,
            this.ReportFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource});
            this.DataMember = "SL_spRptCustomerBalancebyDate";
            this.DataSource = this.sqlDataSource;
            this.Dpi = 254F;
            this.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9F);
            this.Landscape = true;
            this.Margins = new DevExpress.Drawing.DXMargins(254F, 254F, 254F, 254F);
            this.PageHeight = 2970;
            this.PageWidth = 4200;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A3;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.TransactionYear,
            this.TransactionMonth,
            this.FromDate,
            this.ToDate});
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.GroupCaption1,
            this.GroupData1,
            this.DetailCaption1,
            this.DetailData1,
            this.GroupFooterBackground3,
            this.DetailData3_Odd,
            this.TotalCaption1,
            this.TotalData1,
            this.TotalBackground1,
            this.GrandTotalCaption1,
            this.GrandTotalData1,
            this.GrandTotalBackground1,
            this.PageInfo});
            this.Version = "23.2";
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.Parameters.Parameter TransactionYear;
        private DevExpress.XtraReports.Parameters.Parameter TransactionMonth;
        private DevExpress.XtraReports.Parameters.Parameter FromDate;
        private DevExpress.XtraReports.Parameters.Parameter ToDate;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo1;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo2;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel label1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell lblAccountId;
        private DevExpress.XtraReports.UI.XRTableCell GroupAccountId;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.XRTable table2;
        private DevExpress.XtraReports.UI.XRTableRow tableRow2;
        private DevExpress.XtraReports.UI.XRTableCell lblRowNo;
        private DevExpress.XtraReports.UI.XRTableCell lblCustomerId;
        private DevExpress.XtraReports.UI.XRTableCell lblCustomerName;
        private DevExpress.XtraReports.UI.XRTableCell lblBeginDebit;
        private DevExpress.XtraReports.UI.XRTableCell lblBeginCredit;
        private DevExpress.XtraReports.UI.XRTableCell lblDebit;
        private DevExpress.XtraReports.UI.XRTableCell lblCredit;
        private DevExpress.XtraReports.UI.XRTableCell lblEndDebit;
        private DevExpress.XtraReports.UI.XRTableCell lblEndCredit;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable table3;
        private DevExpress.XtraReports.UI.XRTableRow tableRow3;
        private DevExpress.XtraReports.UI.XRTableCell rowRowNo;
        private DevExpress.XtraReports.UI.XRTableCell rowCustomerId;
        private DevExpress.XtraReports.UI.XRTableCell rowCustomerName;
        private DevExpress.XtraReports.UI.XRTableCell rowBeginDebit;
        private DevExpress.XtraReports.UI.XRTableCell rowBeginCredit;
        private DevExpress.XtraReports.UI.XRTableCell rowDebit;
        private DevExpress.XtraReports.UI.XRTableCell rowCredit;
        private DevExpress.XtraReports.UI.XRTableCell rowEndDebit;
        private DevExpress.XtraReports.UI.XRTableCell rowEndCredit;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel label2;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        private DevExpress.XtraReports.UI.XRPanel panel1;
        private DevExpress.XtraReports.UI.XRLabel groupBeginDebit;
        private DevExpress.XtraReports.UI.XRLabel groupBeginCredit;
        private DevExpress.XtraReports.UI.XRLabel groupDebit;
        private DevExpress.XtraReports.UI.XRLabel groupCredit;
        private DevExpress.XtraReports.UI.XRLabel groupEndDebit;
        private DevExpress.XtraReports.UI.XRLabel groupEndCredit;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRPanel panel2;
        private DevExpress.XtraReports.UI.XRLabel totalBeginDebit;
        private DevExpress.XtraReports.UI.XRLabel totalBeginCredit;
        private DevExpress.XtraReports.UI.XRLabel totalDebit;
        private DevExpress.XtraReports.UI.XRLabel totalCredit;
        private DevExpress.XtraReports.UI.XRLabel totalEndDebit;
        private DevExpress.XtraReports.UI.XRLabel totalEndCredit;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle GroupCaption1;
        private DevExpress.XtraReports.UI.XRControlStyle GroupData1;
        private DevExpress.XtraReports.UI.XRControlStyle DetailCaption1;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData1;
        private DevExpress.XtraReports.UI.XRControlStyle GroupFooterBackground3;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData3_Odd;
        private DevExpress.XtraReports.UI.XRControlStyle TotalCaption1;
        private DevExpress.XtraReports.UI.XRControlStyle TotalData1;
        private DevExpress.XtraReports.UI.XRControlStyle TotalBackground1;
        private DevExpress.XtraReports.UI.XRControlStyle GrandTotalCaption1;
        private DevExpress.XtraReports.UI.XRControlStyle GrandTotalData1;
        private DevExpress.XtraReports.UI.XRControlStyle GrandTotalBackground1;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRLabel lblSumGroup;
        private DevExpress.XtraReports.UI.XRLabel lblSumTotal;
    }
}
