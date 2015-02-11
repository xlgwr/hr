using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;
using System.Data.SqlClient;

using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;


using HR.Zip.API;
using HR.Zip.EF;

namespace HR.Zip
{
    public partial class SendEmailByXls : Form
    {
        apioutlook apiol;
        apiZip apizip;
        List<user_mstrViewXls> _guserMstrList;
        List<savezipfile> _gzipfilepath;
        //attr for excel 
        public NPOI.HSSF.UserModel.HSSFWorkbook _hssfworkbook { get; set; }//xls
        public NPOI.XSSF.UserModel.XSSFWorkbook _xssfworkbook { get; set; }//xlsx
        //attribute
        public DateTime oldtime { get; set; }
        public string _strext { get; set; }
        public int _tidLength { get; set; }
        //for excel
        public ISheet sheet { get; set; }
        public IRow row { get; set; }
        //
        public bool _cellNullFlag { get; set; }

        public SendEmailByXls()
        {
            InitializeComponent();
            //
            init();
            //
            apiol = new apioutlook();
            apizip = new apiZip();

            _guserMstrList = new List<user_mstrViewXls>();
            _gzipfilepath = new List<savezipfile>();
        }
        void init()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            btnSelectfileUploadExcel.Focus();
            this.AcceptButton = btnSelectfileUploadExcel;
            //initwith
            initwith();
            //meth
            this.Resize += SendEmailByXls_Resize;
            //set vaule
            _tidLength = 7;
        }

        void SendEmailByXls_Resize(object sender, EventArgs e)
        {
            initwith();
            //throw new NotImplementedException();
        }
        void initwith()
        {
            groupBox3detUploadExcel.Width = this.Width - 30;
            groupBox3detUploadExcel.Height = this.Height - groupBox3detUploadExcel.Top - 39;
        }
        void initdgv(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void SendEmailByXls_Load(object sender, EventArgs e)
        {

        }
        private void btnSelectfileUploadExcel_Click(object sender, EventArgs e)
        {
            txt0ExcelFileUploadExcel.Text = "";
            btnSelectfileUploadExcel.Enabled = false;
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txt0ExcelFileUploadExcel.Text = ofd.FileName;
                    btn3QuickUploadExcel.Enabled = true;
                    btn0SetZip.Focus();
                    this.AcceptButton = btn3QuickUploadExcel;
                }
                else
                {
                    this.AcceptButton = btnSelectfileUploadExcel;

                }
                btnSelectfileUploadExcel.Enabled = true;
            }
            catch (Exception ex)
            {
                btnSelectfileUploadExcel.Enabled = true;
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btn2TempleFileUploadExcel_Click(object sender, EventArgs e)
        {
            string pathname = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"attach\template.xlsx";
            apisharp.OpenFolderAndSelectFile(pathname);
        }

        private void btn0SetZip_Click(object sender, EventArgs e)
        {
            txt1ZipPath.Text = apiol.getfilepath();
            this.AcceptButton = btn3QuickUploadExcel;
        }

        void btnEnable(bool enable, bool visual)
        {
            if (enable)
            {
                apisharp.setControlText<SendEmailByXls>(this, txt0ExcelFileUploadExcel, "", enable, true);
                apisharp.setControlText<SendEmailByXls>(this, txt1ZipPath, "", enable, true);
            }
            apisharp.setControlText<SendEmailByXls>(this, btnSelectfileUploadExcel, enable, visual);
            apisharp.setControlText<SendEmailByXls>(this, btn0SetZip, enable, visual);
            apisharp.setControlText<SendEmailByXls>(this, btn3QuickUploadExcel, enable, visual);
            apisharp.setControlText<SendEmailByXls>(this, btn2GoUploadToERP, enable, visual);

        }
        private void btn3QuickUploadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                apisharp.setControlText<SendEmailByXls>(this, lbl1UploadExcelThreadMsg, "Notiec: Load Excel File ......", true, true);
                if (txt0ExcelFileUploadExcel.Text.Trim() == "")
                {
                    apisharp.setControlText<SendEmailByXls>(this, lbl1UploadExcelThreadMsg, "Error,Please Select a Excel file.！", true, true);
                    btnSelectfileUploadExcel.Focus();
                }
                else if (txt1ZipPath.Text.Trim() == "")
                {
                    apisharp.setControlText<SendEmailByXls>(this, lbl1UploadExcelThreadMsg, "Error,Please Set a Path (Excel file) to Zip！", true, true);
                    btn0SetZip.Focus();

                }
                else
                {
                    btnEnable(false, true);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Init0ializeWorkbook), txt0ExcelFileUploadExcel.Text);
                }
                btn2GoUploadToERP.Focus();
                this.AcceptButton = btn2GoUploadToERP;
            }
            catch (Exception ex)
            {
                btnEnable(true, true);
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #region init excel for xls xlsx

        void Init0ializeWorkbook(object path)
        {
            try
            {
                //read xls
                using (FileStream file = new FileStream((string)path, FileMode.Open, FileAccess.Read))
                {
                    if (Path.GetExtension((string)path).ToLower().Equals(".xls"))
                    {
                        _strext = ".xls";
                        _hssfworkbook = new HSSFWorkbook(file);
                        sheet = _hssfworkbook.GetSheetAt(0);
                    }
                    else if (Path.GetExtension((string)path).ToLower().Equals(".xlsx"))
                    {
                        _strext = ".xlsx";
                        _xssfworkbook = new XSSFWorkbook(file);
                        sheet = _xssfworkbook.GetSheetAt(0);
                    }
                    else
                    {
                        btnEnable(true, true);
                        var tmpmsg = "Error0: this file is not the xls or xlsx file.0";
                        apisharp.setControlText<SendEmailByXls>(this, lbl1UploadExcelThreadMsg, tmpmsg, true, true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                btnEnable(true, true);
                apisharp.setControlText<SendEmailByXls>(this, lbl1UploadExcelThreadMsg, ex.Message, true, true);
                return;

            }

            var strmsg = Convert0ToDataTable();


            apisharp.setControlText<SendEmailByXls>(this, lbl1UploadExcelThreadMsg, strmsg, true, true);

            btnEnable(true, true);
        }

        string Convert0ToDataTable()
        {
            //initvalue
            _guserMstrList.Clear();
            this.Invoke(new Action(delegate
            {
                data1GV1ePackingDet1UploadExcel.DataSource = null;
            }));

            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();


            int rows_success_count = 0;
            int rows_errs_count = 0;
            int rows_current = 0;
            int rows_countsum = sheet.LastRowNum;

            string strerrnullrows = "At ";


            while (rows.MoveNext())
            {
                if (rows_success_count == 0)
                {
                    //command.UpdateCommand = cmdb.GetUpdateCommand();
                    rows_success_count = 1;
                    continue;
                }
                //
                rows_current++;

                if (_strext.Equals(".xls"))
                {
                    row = (HSSFRow)rows.Current;
                }
                else if (_strext.Equals(".xlsx"))
                {
                    row = (XSSFRow)rows.Current;
                }
                else
                {
                    return "Error1: this file is not the xls or xlsx file .";
                }
                ///////////
                var tmp_user_mstr_model = new user_mstrViewXls();

                tmp_user_mstr_model.Tid = rows_success_count;

                var tmpmsg = "Excel File has Total: " + rows_countsum + " rows,Load Current Rows at:" + rows_current;
                apisharp.setControlText<SendEmailByXls>(this, lbl1UploadExcelThreadMsg, tmpmsg, true, true);

                #region inittmp
                tmp_user_mstr_model.userID = addCelltoData(row, 0, _tidLength) == null ? "" : addCelltoData(row, 0, _tidLength).ToString();
                tmp_user_mstr_model.name = addCelltoData(row, 1, 0) == null ? "" : addCelltoData(row, 1, 0).ToString();
                tmp_user_mstr_model.email = addCelltoData(row, 2, 0) == null ? "" : addCelltoData(row, 2, 0).ToString();
                tmp_user_mstr_model.password = addCelltoData(row, 3, 0) == null ? "" : addCelltoData(row, 3, 0).ToString();
                tmp_user_mstr_model.cc_super = addCelltoData(row, 4, 0) == null ? "" : addCelltoData(row, 4, 0).ToString();
                tmp_user_mstr_model.cc_hr = addCelltoData(row, 5, 0) == null ? "" : addCelltoData(row, 5, 0).ToString();

                if (_cellNullFlag)
                {
                    _cellNullFlag = false;
                    rows_errs_count++;
                    strerrnullrows += rows_current - 1 + ",";
                    continue;

                }
                #endregion

                rows_success_count++;

                _guserMstrList.Add(tmp_user_mstr_model);
            }
            if (_guserMstrList.Count > 0)
            {
                apisharp.setControlText<SendEmailByXls>(this, lbl1UploadExcelThreadMsg, "Start: Load Data to DataGridView.", true, true);
                this.Invoke(new Action(delegate
                {
                    data1GV1ePackingDet1UploadExcel.DataSource = _guserMstrList;
                    initdgv(data1GV1ePackingDet1UploadExcel);
                    data1GV1ePackingDet1UploadExcel.Refresh();


                }));
            }
            return "Notice: Total: " + rows_countsum + " ,Update " + (rows_success_count - 1) + " Rows Success, Error:" + rows_errs_count + " Rows has null cell(" + strerrnullrows + ").";

        }
        public object addCelltoData(IRow row, int i, int lenTid)
        {
            if (_cellNullFlag)
            {
                return null;
            }
            ICell cell = row.GetCell(i);
            if (cell == null || string.IsNullOrEmpty(cell.ToString()))
            {
                _cellNullFlag = true;
                return null;
            }
            else
            {
                var tmpValue = new object();

                if (cell.CellType == CellType.Numeric)
                {
                    if (lenTid > 0)
                    {
                        var tmp0 = "";
                        for (int z = 0; z < lenTid; z++)
                        {
                            tmp0 += "0";
                        }
                        var tmpnum = cell.NumericCellValue;
                        tmpValue = tmpnum.ToString(tmp0);
                    }
                    else
                    {

                        tmpValue = cell.NumericCellValue.ToString();
                    }
                }
                else if (cell.CellType == CellType.String)
                {

                    tmpValue = cell.ToString().Trim();
                }
                else
                {
                    tmpValue = cell.ToString();
                }
                return tmpValue;
            }
        }

        #endregion


        private void txt0TidLength_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt0TidLength.Text))
            {
                _tidLength = Convert.ToInt16(txt0TidLength.Text);
            }
        }

        private void btn2GoUploadToERP_Click(object sender, EventArgs e)
        {
            if (_guserMstrList.Count < 0)
            {
                return;
            }
        }

    }
}
