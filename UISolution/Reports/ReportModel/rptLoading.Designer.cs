namespace SunSeven.Reports.ReportModel
{
    partial class rptLoading
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup8 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup9 = new Telerik.Reporting.TableGroup();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptLoading));
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector2 = new Telerik.Reporting.Drawing.DescendantSelector();
            this.detailSection1 = new Telerik.Reporting.DetailSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.sqTotal = new Telerik.Reporting.SqlDataSource();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textCompany = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox39 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox43 = new Telerik.Reporting.TextBox();
            this.sqlInvoiceDate = new Telerik.Reporting.SqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detailSection1
            // 
            this.detailSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.4000000953674316D);
            this.detailSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1});
            this.detailSection1.Name = "detailSection1";
            this.detailSection1.PageBreak = Telerik.Reporting.PageBreak.After;
            this.detailSection1.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Cm(0.5D);
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.9166673421859741D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(2.4166669845581055D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.1458321809768677D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.1979160308837891D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.33333340287208557D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.3229166567325592D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.34374979138374329D)));
            this.table1.Body.SetCellContent(2, 0, this.textBox2);
            this.table1.Body.SetCellContent(2, 2, this.textBox4);
            this.table1.Body.SetCellContent(2, 3, this.textBox9);
            this.table1.Body.SetCellContent(0, 0, this.textBox8, 1, 4);
            this.table1.Body.SetCellContent(2, 1, this.textBox5);
            this.table1.Body.SetCellContent(1, 0, this.textBox1);
            this.table1.Body.SetCellContent(1, 1, this.textBox3);
            this.table1.Body.SetCellContent(1, 2, this.textBox6);
            this.table1.Body.SetCellContent(1, 3, this.textBox7);
            tableGroup1.Name = "tableGroup1";
            tableGroup2.Name = "group3";
            tableGroup3.Name = "tableGroup2";
            tableGroup4.Name = "group";
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.ColumnGroups.Add(tableGroup2);
            this.table1.ColumnGroups.Add(tableGroup3);
            this.table1.ColumnGroups.Add(tableGroup4);
            this.table1.DataSource = this.sqTotal;
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox8,
            this.textBox1,
            this.textBox3,
            this.textBox6,
            this.textBox7,
            this.textBox2,
            this.textBox5,
            this.textBox4,
            this.textBox9});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.20310990512371063D));
            this.table1.Name = "table1";
            this.table1.NoDataMessage = "No Invoice found";
            tableGroup6.Name = "group1";
            tableGroup7.Name = "group4";
            tableGroup9.Name = "group2";
            tableGroup8.ChildGroups.Add(tableGroup9);
            tableGroup8.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup8.Name = "detailTableGroup";
            tableGroup5.ChildGroups.Add(tableGroup6);
            tableGroup5.ChildGroups.Add(tableGroup7);
            tableGroup5.ChildGroups.Add(tableGroup8);
            tableGroup5.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.DeliveryPerson"));
            tableGroup5.Name = "rowGroup";
            tableGroup5.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.DeliveryPerson", Telerik.Reporting.SortDirection.Asc));
            this.table1.RowGroups.Add(tableGroup5);
            this.table1.RowHeadersPrintOnEveryPage = true;
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.6770825386047363D), Telerik.Reporting.Drawing.Unit.Inch(0.99999982118606567D));
            this.table1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.table1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.table1.Style.Visible = true;
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9166675806045532D), Telerik.Reporting.Drawing.Unit.Inch(0.34375002980232239D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox2.Style.Font.Name = "Arial Unicode MS";
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.StyleName = "";
            this.textBox2.Value = "= Fields.Product";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1458324193954468D), Telerik.Reporting.Drawing.Unit.Inch(0.34375002980232239D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox4.Style.Font.Name = "Arial Unicode MS";
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.StyleName = "";
            this.textBox4.Value = "= Fields.Unit";
            // 
            // textBox9
            // 
            this.textBox9.Format = "{0:N0}";
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1979156732559204D), Telerik.Reporting.Drawing.Unit.Inch(0.34375D));
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.StyleName = "";
            this.textBox9.Value = "= Fields.totalQuantity";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.6770825386047363D), Telerik.Reporting.Drawing.Unit.Inch(0.33333349227905273D));
            this.textBox8.Style.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.textBox8.Style.Color = System.Drawing.Color.White;
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Name = "Arial Unicode MS";
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.StyleName = "";
            this.textBox8.Value = "= \"Delivery Person : \" + Fields.DeliveryPerson";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4166665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.34375002980232239D));
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox5.Style.Font.Name = "Arial Unicode MS";
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.StyleName = "";
            this.textBox5.Value = "= Fields.Description";
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9166673421859741D), Telerik.Reporting.Drawing.Unit.Inch(0.32291662693023682D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.LightGray;
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox1.Style.Color = System.Drawing.Color.Black;
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.StyleName = "";
            this.textBox1.Value = "Product Name";
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4166669845581055D), Telerik.Reporting.Drawing.Unit.Inch(0.32291662693023682D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.LightGray;
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox3.Style.Color = System.Drawing.Color.Black;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.StyleName = "";
            this.textBox3.Value = "Description";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1458321809768677D), Telerik.Reporting.Drawing.Unit.Inch(0.32291662693023682D));
            this.textBox6.Style.BackgroundColor = System.Drawing.Color.LightGray;
            this.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox6.Style.Color = System.Drawing.Color.Black;
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.StyleName = "";
            this.textBox6.Value = "Unit";
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1979160308837891D), Telerik.Reporting.Drawing.Unit.Inch(0.32291662693023682D));
            this.textBox7.Style.BackgroundColor = System.Drawing.Color.LightGray;
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox7.Style.Color = System.Drawing.Color.Black;
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.StyleName = "";
            this.textBox7.Value = "Total Qty";
            // 
            // sqTotal
            // 
            this.sqTotal.CalculatedFields.AddRange(new Telerik.Reporting.CalculatedField[] {
            new Telerik.Reporting.CalculatedField("DeliveryPerson", typeof(string), "= Fields.LastName + \", \" + Fields.FirstName")});
            this.sqTotal.ConnectionString = "JSConnectionString";
            this.sqTotal.Name = "sqTotal";
            this.sqTotal.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@qST", System.Data.DbType.DateTime, "= Parameters.pST.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@qET", System.Data.DbType.DateTime, "= Parameters.pET.Value")});
            this.sqTotal.SelectCommand = resources.GetString("sqTotal.SelectCommand");
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.800000011920929D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textCompany,
            this.textBox13});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Double;
            // 
            // textCompany
            // 
            this.textCompany.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.5D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textCompany.Name = "textCompany";
            this.textCompany.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.1000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textCompany.Style.Font.Bold = true;
            this.textCompany.Style.Font.Name = "Arial Unicode MS";
            this.textCompany.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.textCompany.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textCompany.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textCompany.Value = "Company Name";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.0999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.4749984741210938D), Telerik.Reporting.Drawing.Unit.Inch(0.29992133378982544D));
            this.textBox13.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Name = "Courier New";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox13.Value = "Daily Packaging List";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox39,
            this.textBox14,
            this.textBox43});
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageFooterSection1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Cm(0D);
            // 
            // textBox39
            // 
            this.textBox39.Format = "{0:dd-MMM-yyyy HH:mm:ss}";
            this.textBox39.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D), Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D));
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105D));
            this.textBox39.Style.Font.Bold = false;
            this.textBox39.Style.Font.Italic = false;
            this.textBox39.Style.Font.Name = "Segoe UI";
            this.textBox39.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox39.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox39.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox39.Value = "= ExecutionTime";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.5D), Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.089583158493042D), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105D));
            this.textBox14.Style.Font.Bold = false;
            this.textBox14.Style.Font.Italic = true;
            this.textBox14.Style.Font.Name = "Segoe UI";
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Value = "= \"Client PC : \" + Parameters.paramClient.Value";
            // 
            // textBox43
            // 
            this.textBox43.Format = "{0}";
            this.textBox43.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0416667461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.09375D));
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
            // sqlInvoiceDate
            // 
            this.sqlInvoiceDate.ConnectionString = "JSConnectionString";
            this.sqlInvoiceDate.Name = "sqlInvoiceDate";
            this.sqlInvoiceDate.SelectCommand = "select cast(max(InvoiceDate) as Date) InvoiceDate from hs.Invoice ";
            // 
            // rptLoading
            // 
            this.DataSource = null;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detailSection1,
            this.pageHeaderSection1,
            this.pageFooterSection1});
            this.Name = "rptLoading";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(1D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "paramClient";
            reportParameter2.Name = "pST";
            reportParameter2.Text = "Invoice Date";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter2.Value = "= Today()";
            reportParameter2.Visible = true;
            reportParameter3.Name = "pET";
            reportParameter3.Text = "End";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter3.Value = "= Today().AddDays(CDbl(1))";
            reportParameter3.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.Table), "Corporate.TableNormal")});
            styleRule2.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Corporate.TableHeader")});
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector1});
            styleRule3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule3.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule3.Style.Color = System.Drawing.Color.White;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            descendantSelector2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Corporate.TableBody")});
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector2});
            styleRule4.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Cm;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.6895833015441895D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detailSection1;
        private Telerik.Reporting.SqlDataSource sqTotal;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textCompany;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox39;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.SqlDataSource sqlInvoiceDate;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox43;

    }
}