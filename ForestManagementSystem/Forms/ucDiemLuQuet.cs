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
    public partial class ucDiemLuQuet : UserControl
    {
        private readonly ForestManagementSystemContext _context;
        private List<DiemLuQuet> _allData;

        public ucDiemLuQuet(ForestManagementSystemContext context)
        {
            InitializeComponent();
            _context = context;
            InitializeDataGridView();
            lbHeader.Text = "Điểm Lũ Quét";
            gListCard.Text = "Danh Sách Điểm Lũ Quét";
            dataGridView1.CellClick += DataGridView1_CellClick;

            // Add search event handlers
            if (tbSearch != null)
            {
                tbSearch.KeyDown += tbSearch_KeyDown;
            }

            if (ptSearch != null)
            {
                ptSearch.Click += (s, e) => FilterData();
            }

            // Load data immediately after initialization
            LoadData();
        }

        private void InitializeDataGridView()
        {
            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add data columns
            dataGridView1.Columns.Add("MaLuQuet", "Mã Lũ Quét");
            dataGridView1.Columns.Add("TenDiem", "Tên Điểm");
            dataGridView1.Columns.Add("ToaDo", "Tọa Độ");
            dataGridView1.Columns.Add("TenXa", "Xã");
            dataGridView1.Columns.Add("NgayXayRa", "Ngày Xảy Ra");
            dataGridView1.Columns.Add("MucDoNghiemTrong", "Mức Độ Nghiêm Trọng");
            dataGridView1.Columns.Add("NguyenNhan", "Nguyên Nhân");
            dataGridView1.Columns.Add("ThietHai", "Thiệt Hại");
            dataGridView1.Columns.Add("TenTrangThai", "Trạng Thái");
            dataGridView1.Columns.Add("TenNguoiCapNhat", "Người Cập Nhật");
            dataGridView1.Columns.Add("NgayCapNhat", "Ngày Cập Nhật");

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
            try
            {
                // Load data with related entities
                _allData = _context.DiemLuQuet
                    .Include(d => d.MaXaNavigation)
                    .Include(d => d.MaTrangThaiNavigation)
                    .Include(d => d.MaNguoiCapNhatNavigation)
                    .ToList();

                DisplayData(_allData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayData(List<DiemLuQuet> data)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (var item in data)
                {
                    dataGridView1.Rows.Add(
                        item.MaLuQuet,
                        item.TenDiem,
                        item.ToaDo,
                        item.MaXaNavigation?.TenXa,
                        item.NgayXayRa,
                        item.MucDoNghiemTrong,
                        item.NguyenNhan,
                        item.ThietHai,
                        item.MaTrangThaiNavigation?.TenTrangThai,
                        item.MaNguoiCapNhatNavigation?.TenNguoiDung,
                        item.NgayCapNhat
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterData()
        {
            if (_allData == null) return;

            string searchText = tbSearch.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadData();
                return;
            }

            var filteredData = _allData.Where(d =>
                d.TenDiem.ToLower().Contains(searchText) ||
                (d.ToaDo != null && d.ToaDo.ToLower().Contains(searchText)) ||
                (d.MaXaNavigation != null && d.MaXaNavigation.TenXa.ToLower().Contains(searchText)) ||
                (d.NgayXayRa.HasValue && d.NgayXayRa.Value.ToString().Contains(searchText)) ||
                (d.MucDoNghiemTrong != null && d.MucDoNghiemTrong.ToLower().Contains(searchText)) ||
                (d.NguyenNhan != null && d.NguyenNhan.ToLower().Contains(searchText)) ||
                (d.ThietHai != null && d.ThietHai.ToLower().Contains(searchText)) ||
                (d.MaTrangThaiNavigation != null && d.MaTrangThaiNavigation.TenTrangThai.ToLower().Contains(searchText)) ||
                (d.MaNguoiCapNhatNavigation != null && d.MaNguoiCapNhatNavigation.TenNguoiDung.ToLower().Contains(searchText))
            ).ToList();

            DisplayData(filteredData);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the clicked column
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var maLuQuet = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaLuQuet"].Value);

            switch (columnName)
            {
                case "Edit":
                    var diemLuQuetToEdit = _context.DiemLuQuet.Find(maLuQuet);
                    if (diemLuQuetToEdit != null)
                    {
                        using (var form = new EditForm(_context))
                        {
                            form.lbHeader.Text = "Sửa Điểm Lũ Quét";
                            InitializeEditFormControls(form, diemLuQuetToEdit);
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                LoadData();
                            }
                        }
                    }
                    break;

                case "Delete":
                    var result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa điểm lũ quét này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var diemLuQuetToDelete = _context.DiemLuQuet.Find(maLuQuet);
                        if (diemLuQuetToDelete != null)
                        {
                            _context.DiemLuQuet.Remove(diemLuQuetToDelete);
                            _context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;
            }
        }

        private async void InitializeEditFormControls(EditForm form, DiemLuQuet diemLuQuet)
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

            // Tên Điểm (TextBox)
            var txtTenDiem = new TextBox();
            if (diemLuQuet != null)
                txtTenDiem.Text = diemLuQuet.TenDiem;
            AddControlRow(txtTenDiem, "Tên Điểm:");

            // Tọa Độ (TextBox)
            var txtToaDo = new TextBox();
            if (diemLuQuet != null)
                txtToaDo.Text = diemLuQuet.ToaDo;
            AddControlRow(txtToaDo, "Tọa Độ:");

            // Xã (ComboBox)
            var cmbXa = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var xaList = _context.DonViHanhChinhXa.ToList();
            cmbXa.DataSource = xaList;
            cmbXa.DisplayMember = "TenXa";
            cmbXa.ValueMember = "MaXa";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (diemLuQuet != null && diemLuQuet.MaXa.HasValue)
                {
                    cmbXa.SelectedValue = diemLuQuet.MaXa.Value;
                    Console.WriteLine($"SelectedValue Xã sau khi set: {cmbXa.SelectedValue}");
                }
                else
                {
                    cmbXa.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbXa, "Xã:");

            // Ngày Xảy Ra (DateTimePicker)
            var dtpNgayXayRa = new DateTimePicker { Format = DateTimePickerFormat.Short };
            if (diemLuQuet != null && diemLuQuet.NgayXayRa.HasValue)
                dtpNgayXayRa.Value = diemLuQuet.NgayXayRa.Value.ToDateTime(TimeOnly.MinValue);
            AddControlRow(dtpNgayXayRa, "Ngày Xảy Ra:");

            // Mức Độ Nghiêm Trọng (TextBox)
            var txtMucDoNghiemTrong = new TextBox();
            if (diemLuQuet != null)
                txtMucDoNghiemTrong.Text = diemLuQuet.MucDoNghiemTrong;
            AddControlRow(txtMucDoNghiemTrong, "Mức Độ Nghiêm Trọng:");

            // Nguyên Nhân (TextBox)
            var txtNguyenNhan = new TextBox { Multiline = true, Height = 80 };
            if (diemLuQuet != null)
                txtNguyenNhan.Text = diemLuQuet.NguyenNhan;
            AddControlRow(txtNguyenNhan, "Nguyên Nhân:", 90);

            // Thiệt Hại (TextBox)
            var txtThietHai = new TextBox { Multiline = true, Height = 80 };
            if (diemLuQuet != null)
                txtThietHai.Text = diemLuQuet.ThietHai;
            AddControlRow(txtThietHai, "Thiệt Hại:", 90);

            // Trạng Thái (ComboBox)
            var cmbTrangThai = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var trangThaiList = _context.TrangThai.ToList();
            cmbTrangThai.DataSource = trangThaiList;
            cmbTrangThai.DisplayMember = "TenTrangThai";
            cmbTrangThai.ValueMember = "MaTrangThai";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (diemLuQuet != null && diemLuQuet.MaTrangThai.HasValue)
                {
                    cmbTrangThai.SelectedValue = diemLuQuet.MaTrangThai.Value;
                    Console.WriteLine($"SelectedValue Trạng Thái sau khi set: {cmbTrangThai.SelectedValue}");
                }
                else
                {
                    cmbTrangThai.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbTrangThai, "Trạng Thái:");

            // Người Cập Nhật (ComboBox)
            var cmbNguoiCapNhat = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var nguoiDungList = _context.NguoiDung.ToList();
            cmbNguoiCapNhat.DataSource = nguoiDungList;
            cmbNguoiCapNhat.DisplayMember = "TenNguoiDung";
            cmbNguoiCapNhat.ValueMember = "MaNguoiDung";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (diemLuQuet != null && diemLuQuet.MaNguoiCapNhat.HasValue)
                {
                    cmbNguoiCapNhat.SelectedValue = diemLuQuet.MaNguoiCapNhat.Value;
                    Console.WriteLine($"SelectedValue Người Cập Nhật sau khi set: {cmbNguoiCapNhat.SelectedValue}");
                }
                else
                {
                    cmbNguoiCapNhat.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbNguoiCapNhat, "Người Cập Nhật:");

            // Add spacing row at the bottom
            form.tbBody.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
            rowIndex++;

            // Handle OK button click
            form.btOk.Click += async (s, args) =>
            {
                try
                {
                    var diemLuQuetEntity = diemLuQuet ?? new DiemLuQuet();
                    diemLuQuetEntity.TenDiem = txtTenDiem.Text;
                    diemLuQuetEntity.ToaDo = txtToaDo.Text;
                    diemLuQuetEntity.MaXa = (int?)cmbXa.SelectedValue;
                    diemLuQuetEntity.NgayXayRa = DateOnly.FromDateTime(dtpNgayXayRa.Value);
                    diemLuQuetEntity.MucDoNghiemTrong = txtMucDoNghiemTrong.Text;
                    diemLuQuetEntity.NguyenNhan = txtNguyenNhan.Text;
                    diemLuQuetEntity.ThietHai = txtThietHai.Text;
                    diemLuQuetEntity.MaTrangThai = (int?)cmbTrangThai.SelectedValue;
                    diemLuQuetEntity.MaNguoiCapNhat = (int?)cmbNguoiCapNhat.SelectedValue;
                    diemLuQuetEntity.NgayCapNhat = DateTime.Now;

                    if (diemLuQuet == null)
                    {
                        _context.DiemLuQuet.Add(diemLuQuetEntity);
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

        private void ucDiemLuQuet_Load(object sender, EventArgs e)
        {
            // Add new row button at the top
            var addButton = new Button
            {
                Text = "Thêm mới",
                Dock = DockStyle.Top,
                Height = 30,
                Margin = new Padding(0, 0, 0, 10)
            };
            addButton.Click += (s, ev) =>
            {
                using (var form = new EditForm(_context))
                {
                    form.lbHeader.Text = "Thêm Điểm Lũ Quét";
                    InitializeEditFormControls(form, null);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            };
            this.Controls.Add(addButton);

            // Load data again when form is loaded
            LoadData();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                FilterData();
            }
        }
    }
}
