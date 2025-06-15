using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForestManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ForestManagementSystem.Forms
{
    public partial class ucQuyHoachRung : UserControl
    {
        private readonly ForestManagementSystemContext _context;

        public ucQuyHoachRung(ForestManagementSystemContext context)
        {
            InitializeComponent();
            _context = context;
            InitializeDataGridView();
            lbHeader.Text = "Quy Hoạch Rừng";
            gListCard.Text = "Danh Sách Quy Hoạch Rừng";
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void InitializeDataGridView()
        {
            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add data columns
            dataGridView1.Columns.Add("MaQuyHoach", "Mã Quy Hoạch");
            dataGridView1.Columns.Add("MaKhuRung", "Mã Khu Rừng");
            dataGridView1.Columns.Add("KyQuyHoach", "Kỳ Quy Hoạch");
            dataGridView1.Columns.Add("NgayBatDau", "Ngày Bắt Đầu");
            dataGridView1.Columns.Add("NgayKetThuc", "Ngày Kết Thúc");
            dataGridView1.Columns.Add("NoiDungBaoCao", "Nội Dung Báo Cáo");
            dataGridView1.Columns.Add("DuongDanBanDo", "Đường Dẫn Bản Đồ");
            dataGridView1.Columns.Add("MaNguoiDung", "Mã Người Dùng");
            dataGridView1.Columns.Add("MaTrangThai", "Mã Trạng Thái");

            // Add action button columns
            var editColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Sửa",
                Text = "Sửa",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            dataGridView1.Columns.Add(editColumn);

            var deleteColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Xóa",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            dataGridView1.Columns.Add(deleteColumn);

            // Set column properties
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void LoadData()
        {
            // Load data
            var quyHoachList = _context.QuyHoachRung.ToList();
            dataGridView1.Rows.Clear();

            foreach (var quyHoach in quyHoachList)
            {
                dataGridView1.Rows.Add(
                    quyHoach.MaQuyHoach,
                    quyHoach.MaKhuRung,
                    quyHoach.KyQuyHoach,
                    quyHoach.NgayBatDau,
                    quyHoach.NgayKetThuc,
                    quyHoach.NoiDungBaoCao,
                    quyHoach.DuongDanBanDo,
                    quyHoach.MaNguoiDung,
                    quyHoach.MaTrangThai
                );
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the clicked column
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var maQuyHoach = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaQuyHoach"].Value);

            switch (columnName)
            {
                case "Edit":
                    var quyHoachToEdit = _context.QuyHoachRung.Find(maQuyHoach);
                    if (quyHoachToEdit != null)
                    {
                        using (var form = new EditForm(_context))
                        {
                            form.lbHeader.Text = "Sửa Quy Hoạch Rừng";
                            InitializeEditFormControls(form, quyHoachToEdit);
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                LoadData();
                            }
                        }
                    }
                    break;

                case "Delete":
                    var result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa quy hoạch rừng này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var quyHoachToDelete = _context.QuyHoachRung.Find(maQuyHoach);
                        if (quyHoachToDelete != null)
                        {
                            _context.QuyHoachRung.Remove(quyHoachToDelete);
                            _context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;
            }
        }

        private async void InitializeEditFormControls(EditForm form, QuyHoachRung quyHoachRung)
        {
            // Clear existing controls
            form.tbBody.Controls.Clear();
            form.tbBody.RowStyles.Clear();
            form.tbBody.RowCount = 0;
            form.tbBody.Padding = new Padding(10);
            form.tbBody.ColumnStyles.Clear();
            form.tbBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            form.tbBody.AutoScroll = true;

            // Add controls for each field
            int rowIndex = 0;

            // Add spacing row
            form.tbBody.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
            rowIndex++;

            // Helper function to create a row with label and control
            void AddControlRow(Control control, string labelText, int height = 40)
            {
                var rowPanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 1,
                    Height = height,
                    Margin = new Padding(0, 5, 0, 5)
                };
                rowPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                rowPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

                var label = new Label
                {
                    Text = labelText,
                    Dock = DockStyle.Fill,
                    Font = new Font(form.Font, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true
                };

                control.Dock = DockStyle.Fill;
                rowPanel.Controls.Add(label, 0, 0);
                rowPanel.Controls.Add(control, 1, 0);

                form.tbBody.Controls.Add(rowPanel, 0, rowIndex);
                form.tbBody.RowStyles.Add(new RowStyle(SizeType.Absolute, height + 10));
                rowIndex++;
            }

            // Khu Rừng (ComboBox)
            var cmbKhuRung = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var khuRungList = await _context.KhuRung.ToListAsync();
            cmbKhuRung.DataSource = khuRungList;
            cmbKhuRung.DisplayMember = "TenKhuRung";
            cmbKhuRung.ValueMember = "MaKhuRung";
            if (quyHoachRung != null)
                cmbKhuRung.SelectedValue = quyHoachRung.MaKhuRung;
            AddControlRow(cmbKhuRung, "Khu Rừng:");

            // Kỳ Quy Hoạch (TextBox)
            var txtKyQuyHoach = new TextBox();
            if (quyHoachRung != null)
                txtKyQuyHoach.Text = quyHoachRung.KyQuyHoach;
            AddControlRow(txtKyQuyHoach, "Kỳ Quy Hoạch:");

            // Ngày Bắt Đầu (DateTimePicker)
            var dtpNgayBatDau = new DateTimePicker { Format = DateTimePickerFormat.Short };
            if (quyHoachRung != null && quyHoachRung.NgayBatDau.HasValue)
                dtpNgayBatDau.Value = quyHoachRung.NgayBatDau.Value;
            AddControlRow(dtpNgayBatDau, "Ngày Bắt Đầu:");

            // Ngày Kết Thúc (DateTimePicker)
            var dtpNgayKetThuc = new DateTimePicker { Format = DateTimePickerFormat.Short };
            if (quyHoachRung != null && quyHoachRung.NgayKetThuc.HasValue)
                dtpNgayKetThuc.Value = quyHoachRung.NgayKetThuc.Value;
            AddControlRow(dtpNgayKetThuc, "Ngày Kết Thúc:");

            // Nội Dung Báo Cáo (TextBox)
            var txtNoiDungBaoCao = new TextBox { Multiline = true, Height = 80 };
            if (quyHoachRung != null)
                txtNoiDungBaoCao.Text = quyHoachRung.NoiDungBaoCao;
            AddControlRow(txtNoiDungBaoCao, "Nội Dung Báo Cáo:", 90);

            // Đường Dẫn Bản Đồ (TextBox)
            var txtDuongDanBanDo = new TextBox();
            if (quyHoachRung != null)
                txtDuongDanBanDo.Text = quyHoachRung.DuongDanBanDo;
            AddControlRow(txtDuongDanBanDo, "Đường Dẫn Bản Đồ:");

            // Người Dùng (ComboBox)
            var cmbNguoiDung = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var nguoiDungList = await _context.NguoiDung.ToListAsync();
            cmbNguoiDung.DataSource = nguoiDungList;
            cmbNguoiDung.DisplayMember = "TenNguoiDung";
            cmbNguoiDung.ValueMember = "MaNguoiDung";
            if (quyHoachRung != null)
                cmbNguoiDung.SelectedValue = quyHoachRung.MaNguoiDung;
            AddControlRow(cmbNguoiDung, "Người Dùng:");

            // Trạng Thái (ComboBox)
            var cmbTrangThai = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var trangThaiList = await _context.TrangThai.ToListAsync();
            cmbTrangThai.DataSource = trangThaiList;
            cmbTrangThai.DisplayMember = "TenTrangThai";
            cmbTrangThai.ValueMember = "MaTrangThai";
            if (quyHoachRung != null)
                cmbTrangThai.SelectedValue = quyHoachRung.MaTrangThai;
            AddControlRow(cmbTrangThai, "Trạng Thái:");

            // Add spacing row at the bottom
            form.tbBody.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
            rowIndex++;

            // Handle OK button click
            form.btOk.Click += async (s, args) =>
            {
                try
                {
                    var quyHoach = quyHoachRung ?? new QuyHoachRung();
                    quyHoach.MaKhuRung = (int)cmbKhuRung.SelectedValue;
                    quyHoach.KyQuyHoach = txtKyQuyHoach.Text;
                    quyHoach.NgayBatDau = dtpNgayBatDau.Value;
                    quyHoach.NgayKetThuc = dtpNgayKetThuc.Value;
                    quyHoach.NoiDungBaoCao = txtNoiDungBaoCao.Text;
                    quyHoach.DuongDanBanDo = txtDuongDanBanDo.Text;
                    quyHoach.MaNguoiDung = (int)cmbNguoiDung.SelectedValue;
                    quyHoach.MaTrangThai = (int)cmbTrangThai.SelectedValue;

                    if (quyHoachRung == null)
                    {
                        _context.QuyHoachRung.Add(quyHoach);
                    }

                    await _context.SaveChangesAsync();
                    form.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            form.btCancel.Click += (s, args) =>
            {
                form.DialogResult = DialogResult.Cancel;
            };
        }

        private void ucQuyHoachRung_Load_1(object sender, EventArgs e)
        {
            // Add new row button at the top
            var addButton = new Button
            {
                Text = "Thêm mới",
                Dock = DockStyle.Top,
                Height = 30,
                Margin = new Padding(0, 0, 0, 10)
            };
            addButton.Click += (s, e) =>
            {
                using (var form = new EditForm(_context))
                {
                    form.lbHeader.Text = "Thêm Quy Hoạch Rừng";
                    InitializeEditFormControls(form, null);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            };
            this.Controls.Add(addButton);

            LoadData();
        }
    }
}
