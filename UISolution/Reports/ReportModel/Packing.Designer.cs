namespace SunSeven.Reports.ReportModel
{
    partial class Packing
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Packing));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group3 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.groupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.totalTypeGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.totalTypeGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.productCaptionTextBox = new Telerik.Reporting.TextBox();
            this.descriptionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.unitCaptionTextBox = new Telerik.Reporting.TextBox();
            this.totalQuantityCaptionTextBox = new Telerik.Reporting.TextBox();
            this.sqlDSDelivery = new Telerik.Reporting.SqlDataSource();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textCompany = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox39 = new Telerik.Reporting.TextBox();
            this.textBox43 = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.productDataTextBox = new Telerik.Reporting.TextBox();
            this.descriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.unitDataTextBox = new Telerik.Reporting.TextBox();
            this.totalQuantityDataTextBox = new Telerik.Reporting.TextBox();
            this.sqlDSPacking = new Telerik.Reporting.SqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // groupFooterSection
            // 
            this.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D);
            this.groupFooterSection.KeepTogether = true;
            this.groupFooterSection.Name = "groupFooterSection";
            this.groupFooterSection.PageBreak = Telerik.Reporting.PageBreak.None;
            this.groupFooterSection.PrintAtBottom = false;
            this.groupFooterSection.PrintOnEveryPage = false;
            this.groupFooterSection.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0D);
            this.groupFooterSection.Style.Visible = true;
            // 
            // groupHeaderSection
            // 
            this.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D);
            this.groupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3});
            this.groupHeaderSection.KeepTogether = true;
            this.groupHeaderSection.Name = "groupHeaderSection";
            this.groupHeaderSection.PageBreak = Telerik.Reporting.PageBreak.Before;
            this.groupHeaderSection.PrintOnEveryPage = true;
            this.groupHeaderSection.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.groupHeaderSection.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.groupHeaderSection.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Inch(0D);
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.KeepTogether = false;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.7125587463378906D), Telerik.Reporting.Drawing.Unit.Inch(0.29999995231628418D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox3.Style.Color = System.Drawing.Color.Black;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Name = "Arial Unicode MS";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox3.StyleName = "Data";
            this.textBox3.Value = "= \"Delivery Person : \" + Fields.DeliveryPerson";
            // 
            // totalTypeGroupFooterSection
            // 
            this.totalTypeGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003953576087952D);
            this.totalTypeGroupFooterSection.KeepTogether = true;
            this.totalTypeGroupFooterSection.Name = "totalTypeGroupFooterSection";
            this.totalTypeGroupFooterSection.Style.Visible = false;
            // 
            // totalTypeGroupHeaderSection
            // 
            this.totalTypeGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.30000010132789612D);
            this.totalTypeGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2});
            this.totalTypeGroupHeaderSection.KeepTogether = true;
            this.totalTypeGroupHeaderSection.Name = "totalTypeGroupHeaderSection";
            this.totalTypeGroupHeaderSection.PageBreak = Telerik.Reporting.PageBreak.None;
            this.totalTypeGroupHeaderSection.PrintOnEveryPage = true;
            this.totalTypeGroupHeaderSection.Style.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.totalTypeGroupHeaderSection.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0D);
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D), Telerik.Reporting.Drawing.Unit.Inch(1.5894572413799324E-07D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.9166669845581055D), Telerik.Reporting.Drawing.Unit.Inch(0.27916660904884338D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "= IIF(Fields.TotalType = 0, \"Non Single Items\", \"Single Items\")";
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.17916679382324219D);
            this.labelsGroupFooterSection.KeepTogether = true;
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.PageBreak = Telerik.Reporting.PageBreak.None;
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.32083332538604736D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productCaptionTextBox,
            this.descriptionCaptionTextBox,
            this.unitCaptionTextBox,
            this.totalQuantityCaptionTextBox});
            this.labelsGroupHeaderSection.KeepTogether = true;
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // productCaptionTextBox
            // 
            this.productCaptionTextBox.CanGrow = true;
            this.productCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.productCaptionTextBox.Name = "productCaptionTextBox";
            this.productCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.2999210357666016D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.productCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.productCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.productCaptionTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.productCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.productCaptionTextBox.Style.Font.Bold = true;
            this.productCaptionTextBox.Style.Font.Name = "Arial Unicode MS";
            this.productCaptionTextBox.StyleName = "Caption";
            this.productCaptionTextBox.Value = "Product";
            // 
            // descriptionCaptionTextBox
            // 
            this.descriptionCaptionTextBox.CanGrow = true;
            this.descriptionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.5D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.descriptionCaptionTextBox.Name = "descriptionCaptionTextBox";
            this.descriptionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0999212265014648D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.descriptionCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.descriptionCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.descriptionCaptionTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.descriptionCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.descriptionCaptionTextBox.Style.Font.Bold = true;
            this.descriptionCaptionTextBox.Style.Font.Name = "Arial Unicode MS";
            this.descriptionCaptionTextBox.StyleName = "Caption";
            this.descriptionCaptionTextBox.Value = "Description";
            // 
            // unitCaptionTextBox
            // 
            this.unitCaptionTextBox.CanGrow = true;
            this.unitCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.unitCaptionTextBox.Name = "unitCaptionTextBox";
            this.unitCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992078542709351D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.unitCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.unitCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.unitCaptionTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.unitCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.unitCaptionTextBox.Style.Font.Bold = true;
            this.unitCaptionTextBox.Style.Font.Name = "Arial Unicode MS";
            this.unitCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.unitCaptionTextBox.StyleName = "Caption";
            this.unitCaptionTextBox.Value = "Unit";
            // 
            // totalQuantityCaptionTextBox
            // 
            this.totalQuantityCaptionTextBox.CanGrow = true;
            this.totalQuantityCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.totalQuantityCaptionTextBox.Name = "totalQuantityCaptionTextBox";
            this.totalQuantityCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.98749983310699463D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.totalQuantityCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.totalQuantityCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.totalQuantityCaptionTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.totalQuantityCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.totalQuantityCaptionTextBox.Style.Font.Bold = true;
            this.totalQuantityCaptionTextBox.Style.Font.Name = "Arial Unicode MS";
            this.totalQuantityCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.totalQuantityCaptionTextBox.StyleName = "Caption";
            this.totalQuantityCaptionTextBox.Value = "Quantity";
            // 
            // sqlDSDelivery
            // 
            this.sqlDSDelivery.ConnectionString = "SunSeven.Properties.Settings.JSConnectionString";
            this.sqlDSDelivery.Name = "sqlDSDelivery";
            this.sqlDSDelivery.SelectCommand = "select -1 Id,\'All\'  Person\r\nunion all\r\nSELECT        Id, Person\r\nFROM            " +
    "HS.vEmpDept\r\nWHERE        (Department = \'Delivery\') ";
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox13,
            this.textCompany,
            this.textBox1});
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageHeader.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0D);
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.1000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.4749984741210938D), Telerik.Reporting.Drawing.Unit.Inch(0.29992133378982544D));
            this.textBox13.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Name = "Courier New";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox13.Value = "Packing List";
            // 
            // textCompany
            // 
            this.textCompany.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.4874989986419678D), Telerik.Reporting.Drawing.Unit.Inch(0.37920603156089783D));
            this.textCompany.Name = "textCompany";
            this.textCompany.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.1000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textCompany.Style.Font.Bold = true;
            this.textCompany.Style.Font.Name = "Arial Unicode MS";
            this.textCompany.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.textCompany.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textCompany.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textCompany.Value = "Company Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.3999989032745361D), Telerik.Reporting.Drawing.Unit.Inch(0.67920607328414917D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1875D), Telerik.Reporting.Drawing.Unit.Inch(0.29996058344841003D));
            this.textBox1.Style.Font.Bold = false;
            this.textBox1.Style.Font.Italic = true;
            this.textBox1.Style.Font.Name = "Arial";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = resources.GetString("textBox1.Value");
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.44166669249534607D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox14,
            this.textBox39,
            this.textBox43});
            this.pageFooter.Name = "pageFooter";
            this.pageFooter.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.5D), Telerik.Reporting.Drawing.Unit.Inch(0.12291685491800308D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105D));
            this.textBox14.Style.Font.Bold = false;
            this.textBox14.Style.Font.Italic = true;
            this.textBox14.Style.Font.Name = "Segoe UI";
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Value = "= \"Client PC : \" + Parameters.paramClient.Value";
            // 
            // textBox39
            // 
            this.textBox39.Format = "{0:dd-MMM-yyyy HH:mm:ss}";
            this.textBox39.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D), Telerik.Reporting.Drawing.Unit.Inch(0.12291685491800308D));
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105D));
            this.textBox39.Style.Font.Bold = false;
            this.textBox39.Style.Font.Italic = false;
            this.textBox39.Style.Font.Name = "Segoe UI";
            this.textBox39.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox39.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox39.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox39.Value = "=Format(\"{0:dd-MMM-yy HH:mm}\", ExecutionTime) + \" (\" + ExecutionTime.ToString(\"dd" +
    "d\") + \") \"";
            // 
            // textBox43
            // 
            this.textBox43.Format = "{0}";
            this.textBox43.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0520832538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.1145833358168602D));
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105D));
            this.textBox43.Style.Font.Bold = false;
            this.textBox43.Style.Font.Italic = false;
            this.textBox43.Style.Font.Name = "Segoe UI";
            this.textBox43.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox43.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox43.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox43.Value = "= CStr(PageNumber) + \" of \" + CStr(PageCount)";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.reportFooter.KeepTogether = false;
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Cm(0.5D);
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.76200002431869507D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.productDataTextBox,
            this.descriptionDataTextBox,
            this.unitDataTextBox,
            this.totalQuantityDataTextBox});
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            // 
            // productDataTextBox
            // 
            this.productDataTextBox.CanGrow = true;
            this.productDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.productDataTextBox.Name = "productDataTextBox";
            this.productDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.2999212741851807D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.productDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.productDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.productDataTextBox.Style.Font.Name = "Arial Unicode MS";
            this.productDataTextBox.StyleName = "Data";
            this.productDataTextBox.Value = "= Fields.Product";
            // 
            // descriptionDataTextBox
            // 
            this.descriptionDataTextBox.CanGrow = true;
            this.descriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.5D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.descriptionDataTextBox.Name = "descriptionDataTextBox";
            this.descriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0999212265014648D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.descriptionDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.descriptionDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.descriptionDataTextBox.Style.Font.Name = "Arial Unicode MS";
            this.descriptionDataTextBox.StyleName = "Data";
            this.descriptionDataTextBox.Value = "= Fields.Description";
            // 
            // unitDataTextBox
            // 
            this.unitDataTextBox.CanGrow = true;
            this.unitDataTextBox.Format = "{0}";
            this.unitDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.unitDataTextBox.Name = "unitDataTextBox";
            this.unitDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992114305496216D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.unitDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.unitDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.unitDataTextBox.Style.Font.Name = "Arial Unicode MS";
            this.unitDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.unitDataTextBox.StyleName = "Data";
            this.unitDataTextBox.Value = "= Fields.Unit";
            // 
            // totalQuantityDataTextBox
            // 
            this.totalQuantityDataTextBox.CanGrow = true;
            this.totalQuantityDataTextBox.Format = "{0:0.0}";
            this.totalQuantityDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.totalQuantityDataTextBox.Name = "totalQuantityDataTextBox";
            this.totalQuantityDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.9874998927116394D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.totalQuantityDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.totalQuantityDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.totalQuantityDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.totalQuantityDataTextBox.StyleName = "Data";
            this.totalQuantityDataTextBox.Value = "= Fields.totalQuantity";
            // 
            // sqlDSPacking
            // 
            this.sqlDSPacking.ConnectionString = "SunSeven.Properties.Settings.JSConnectionString";
            this.sqlDSPacking.Name = "sqlDSPacking";
            this.sqlDSPacking.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@pST", System.Data.DbType.DateTime, "= Parameters.pST.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@pET", System.Data.DbType.DateTime, "= Parameters.pET.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@pDeliveryId", System.Data.DbType.DateTime, "= Parameters.pDelivery.Value")});
            this.sqlDSPacking.SelectCommand = "HS.Packing";
            this.sqlDSPacking.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // Packing
            // 
            this.DataSource = this.sqlDSPacking;
            group1.GroupFooter = this.groupFooterSection;
            group1.GroupHeader = this.groupHeaderSection;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.DeliveryPerson"));
            group1.Name = "groupDelivery";
            group1.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.DeliveryPerson", Telerik.Reporting.SortDirection.Asc));
            group2.GroupFooter = this.totalTypeGroupFooterSection;
            group2.GroupHeader = this.totalTypeGroupHeaderSection;
            group2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.TotalType"));
            group2.Name = "totalTypeGroup";
            group2.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.TotalType", Telerik.Reporting.SortDirection.Asc));
            group3.GroupFooter = this.labelsGroupFooterSection;
            group3.GroupHeader = this.labelsGroupHeaderSection;
            group3.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2,
            group3});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection,
            this.groupFooterSection,
            this.totalTypeGroupHeaderSection,
            this.totalTypeGroupFooterSection,
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportFooter,
            this.detail});
            this.Name = "Packaging";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "paramClient";
            reportParameter2.Name = "pST";
            reportParameter2.Text = "Delivery Start Date";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter2.Value = "=Today()";
            reportParameter2.Visible = true;
            reportParameter3.Name = "pET";
            reportParameter3.Text = "End Date";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter3.Value = "=Today().AddDays(CDbl(1))";
            reportParameter3.Visible = true;
            reportParameter4.AllowBlank = false;
            reportParameter4.AvailableValues.DataSource = this.sqlDSDelivery;
            reportParameter4.AvailableValues.DisplayMember = "= Fields.Person";
            reportParameter4.AvailableValues.ValueMember = "= Fields.Id";
            reportParameter4.Name = "pDelivery";
            reportParameter4.Text = "Delivery Perrson";
            reportParameter4.Value = "0";
            reportParameter4.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.Product", Telerik.Reporting.SortDirection.Asc));
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule3.Style.Color = System.Drawing.Color.White;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule4.Style.Color = System.Drawing.Color.Black;
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule5.Style.Color = System.Drawing.Color.Black;
            styleRule5.Style.Font.Name = "Tahoma";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Cm;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.7125978469848633D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.GroupHeaderSection totalTypeGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.GroupFooterSection totalTypeGroupFooterSection;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox productDataTextBox;
        private Telerik.Reporting.TextBox descriptionDataTextBox;
        private Telerik.Reporting.TextBox unitDataTextBox;
        private Telerik.Reporting.TextBox totalQuantityDataTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.TextBox totalQuantityCaptionTextBox;
        private Telerik.Reporting.TextBox unitCaptionTextBox;
        private Telerik.Reporting.TextBox descriptionCaptionTextBox;
        private Telerik.Reporting.TextBox productCaptionTextBox;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.GroupFooterSection groupFooterSection;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textCompany;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox39;
        private Telerik.Reporting.SqlDataSource sqlDSDelivery;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.SqlDataSource sqlDSPacking;
        private Telerik.Reporting.TextBox textBox43;

    }
}