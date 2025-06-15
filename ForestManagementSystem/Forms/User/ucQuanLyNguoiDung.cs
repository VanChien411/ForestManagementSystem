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

namespace ForestManagementSystem.Forms.User
{
    public partial class ucQuanLyNguoiDung : UserControl
    {
        private readonly ForestManagementSystemContext _context;
        private List<NguoiDung> _allData;

        public ucQuanLyNguoiDung(ForestManagementSystemContext context)
        {
            InitializeComponent();
            _context = context;
            InitializeDataGridView();
            lbHeader.Text = "Quản Lý Người Dùng";
            gListCard.Text = "Danh Sách Người Dùng";
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

            // Add Load event handler
            this.Load += ucQuanLyNguoiDung_Load;

            // Load data immediately after initialization
            LoadData();
        }

        private void InitializeDataGridView()
        {
            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add data columns
            dataGridView1.Columns.Add("MaNguoiDung", "Mã Người Dùng");
            dataGridView1.Columns.Add("TenNguoiDung", "Tên Người Dùng");
            dataGridView1.Columns.Add("TaiKhoan", "Tài Khoản");
            dataGridView1.Columns.Add("MatKhau", "Mật Khẩu");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("TenXa", "Xã");
            dataGridView1.Columns.Add("TenTrangThai", "Trạng Thái");
            dataGridView1.Columns.Add("NgayTao", "Ngày Tạo");

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
                _allData = _context.NguoiDung
                    .Include(n => n.MaTrangThaiNavigation)
                    .Include(n => n.MaXaNavigation)
                    .ToList();

                DisplayData(_allData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayData(List<NguoiDung> data)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (var item in data)
                {
                    dataGridView1.Rows.Add(
                        item.MaNguoiDung,
                        item.TenNguoiDung,
                        item.TaiKhoan,
                        item.MatKhau,
                        item.Email,
                        item.MaXaNavigation?.TenXa,
                        item.MaTrangThaiNavigation?.TenTrangThai,
                        item.NgayTao
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

            var filteredData = _allData.Where(n =>
                n.TenNguoiDung.ToLower().Contains(searchText) ||
                n.TaiKhoan.ToLower().Contains(searchText) ||
                (n.Email != null && n.Email.ToLower().Contains(searchText)) ||
                (n.MaXaNavigation != null && n.MaXaNavigation.TenXa.ToLower().Contains(searchText)) ||
                (n.MaTrangThaiNavigation != null && n.MaTrangThaiNavigation.TenTrangThai.ToLower().Contains(searchText))
            ).ToList();

            DisplayData(filteredData);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the clicked column
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var maNguoiDung = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaNguoiDung"].Value);

            switch (columnName)
            {
                case "Edit":
                    var nguoiDungToEdit = _context.NguoiDung
                        .Include(n => n.MaXaNavigation)
                        .Include(n => n.MaTrangThaiNavigation)
                        .FirstOrDefault(n => n.MaNguoiDung == maNguoiDung);
                    if (nguoiDungToEdit != null)
                    {
                        using (var form = new EditForm(_context))
                        {
                            form.lbHeader.Text = "Sửa Người Dùng";
                            InitializeEditFormControls(form, nguoiDungToEdit);
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                LoadData();
                            }
                        }
                    }
                    break;

                case "Delete":
                    var result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa người dùng này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var nguoiDungToDelete = _context.NguoiDung.Find(maNguoiDung);
                        if (nguoiDungToDelete != null)
                        {
                            _context.NguoiDung.Remove(nguoiDungToDelete);
                            _context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;
            }
        }

        private async void InitializeEditFormControls(EditForm form, NguoiDung nguoiDung)
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

            // Tên Người Dùng (TextBox)
            var txtTenNguoiDung = new TextBox();
            if (nguoiDung != null)
                txtTenNguoiDung.Text = nguoiDung.TenNguoiDung;
            AddControlRow(txtTenNguoiDung, "Tên Người Dùng:");

            // Tài Khoản (TextBox)
            var txtTaiKhoan = new TextBox();
            if (nguoiDung != null)
                txtTaiKhoan.Text = nguoiDung.TaiKhoan;
            AddControlRow(txtTaiKhoan, "Tài Khoản:");

            // Mật Khẩu (TextBox)
            var txtMatKhau = new TextBox();
            if (nguoiDung != null)
                txtMatKhau.Text = nguoiDung.MatKhau;
            AddControlRow(txtMatKhau, "Mật Khẩu:");

            // Email (TextBox)
            var txtEmail = new TextBox();
            if (nguoiDung != null)
                txtEmail.Text = nguoiDung.Email;
            AddControlRow(txtEmail, "Email:");

            // Load all data first
            var xaList = _context.DonViHanhChinhXa.ToList();
            var trangThaiList = _context.TrangThai.ToList();

            // Xã (ComboBox)
            var cmbXa = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cmbXa.DataSource = xaList;      // Set DataSource TRƯỚC
            cmbXa.DisplayMember = "TenXa";  // Set DisplayMember SAU
            cmbXa.ValueMember = "MaXa";     // Set ValueMember SAU

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (nguoiDung != null && nguoiDung.MaXa.HasValue)
                {
                    cmbXa.SelectedValue = nguoiDung.MaXa.Value;
                    Console.WriteLine($"SelectedValue Xã sau khi set: {cmbXa.SelectedValue}");
                }
                else
                {
                    cmbXa.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbXa, "Xã:");

            // Trạng Thái (ComboBox)
            var cmbTrangThai = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cmbTrangThai.DataSource = trangThaiList;      // Set DataSource TRƯỚC
            cmbTrangThai.DisplayMember = "TenTrangThai";  // Set DisplayMember SAU
            cmbTrangThai.ValueMember = "MaTrangThai";     // Set ValueMember SAU

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (nguoiDung != null && nguoiDung.MaTrangThai.HasValue)
                {
                    cmbTrangThai.SelectedValue = nguoiDung.MaTrangThai.Value;
                    Console.WriteLine($"SelectedValue Trạng Thái sau khi set: {cmbTrangThai.SelectedValue}");
                }
                else
                {
                    cmbTrangThai.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbTrangThai, "Trạng Thái:");

            // Add spacing row at the bottom
            form.tbBody.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
            rowIndex++;

            // Handle OK button click
            form.btOk.Click += async (s, args) =>
            {
                try
                {
                    var nguoiDungEntity = nguoiDung ?? new NguoiDung();
                    nguoiDungEntity.TenNguoiDung = txtTenNguoiDung.Text;
                    nguoiDungEntity.TaiKhoan = txtTaiKhoan.Text;
                    nguoiDungEntity.MatKhau = txtMatKhau.Text;
                    nguoiDungEntity.Email = txtEmail.Text;

                    // Handle foreign key fields
                    if (cmbXa.SelectedValue != null)
                    {
                        nguoiDungEntity.MaXa = (int)cmbXa.SelectedValue;
                    }
                    else
                    {
                        nguoiDungEntity.MaXa = null;
                    }

                    if (cmbTrangThai.SelectedValue != null)
                    {
                        nguoiDungEntity.MaTrangThai = (int)cmbTrangThai.SelectedValue;
                    }
                    else
                    {
                        nguoiDungEntity.MaTrangThai = null;
                    }

                    if (nguoiDung == null)
                    {
                        nguoiDungEntity.NgayTao = DateTime.Now;
                        _context.NguoiDung.Add(nguoiDungEntity);
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

        private void ucQuanLyNguoiDung_Load(object sender, EventArgs e)
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
                    form.lbHeader.Text = "Thêm Người Dùng";
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
