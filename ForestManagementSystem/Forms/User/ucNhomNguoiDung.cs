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
    public partial class ucNhomNguoiDung : UserControl
    {
        private readonly ForestManagementSystemContext _context;
        private List<NhomNguoiDung> _allData;

        public ucNhomNguoiDung(ForestManagementSystemContext context)
        {
            InitializeComponent();
            _context = context;
            InitializeDataGridView();
            lbHeader.Text = "Quản Lý Nhóm Người Dùng";
            gListCard.Text = "Danh Sách Nhóm Người Dùng";
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
            this.Load += ucNhomNguoiDung_Load;

            // Load data immediately after initialization
            LoadData();
        }

        private void InitializeDataGridView()
        {
            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add data columns
            dataGridView1.Columns.Add("MaNhom", "Mã Nhóm");
            dataGridView1.Columns.Add("TenNhom", "Tên Nhóm");
            dataGridView1.Columns.Add("MoTa", "Mô Tả");
            dataGridView1.Columns.Add("TrangThai", "Trạng Thái");
            dataGridView1.Columns.Add("SoNguoiDung", "Số Người Dùng");

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
                _allData = _context.NhomNguoiDung
                    .Include(n => n.MaTrangThaiNavigation)
                    .Include(n => n.NguoiDung_Nhom)
                    .ToList();

                DisplayData(_allData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayData(List<NhomNguoiDung> data)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (var item in data)
                {
                    dataGridView1.Rows.Add(
                        item.MaNhom,
                        item.TenNhom,
                        item.MoTa,
                        item.MaTrangThaiNavigation?.TenTrangThai,
                        item.NguoiDung_Nhom.Count
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
                n.TenNhom.ToLower().Contains(searchText) ||
                (n.MoTa != null && n.MoTa.ToLower().Contains(searchText)) ||
                (n.MaTrangThaiNavigation != null && n.MaTrangThaiNavigation.TenTrangThai.ToLower().Contains(searchText))
            ).ToList();

            DisplayData(filteredData);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the clicked column
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var maNhom = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaNhom"].Value);

            switch (columnName)
            {
                case "Edit":
                    var nhomToEdit = _context.NhomNguoiDung
                        .Include(n => n.MaTrangThaiNavigation)
                        .FirstOrDefault(n => n.MaNhom == maNhom);
                    if (nhomToEdit != null)
                    {
                        using (var form = new EditForm(_context))
                        {
                            form.lbHeader.Text = "Sửa Nhóm Người Dùng";
                            InitializeEditFormControls(form, nhomToEdit);
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                LoadData();
                            }
                        }
                    }
                    break;

                case "Delete":
                    var result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa nhóm người dùng này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var nhomToDelete = _context.NhomNguoiDung.Find(maNhom);
                        if (nhomToDelete != null)
                        {
                            _context.NhomNguoiDung.Remove(nhomToDelete);
                            _context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;
            }
        }

        private void InitializeEditFormControls(EditForm form, NhomNguoiDung nhom)
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

            // Tên Nhóm (TextBox)
            var txtTenNhom = new TextBox();
            if (nhom != null)
                txtTenNhom.Text = nhom.TenNhom;
            AddControlRow(txtTenNhom, "Tên Nhóm:");

            // Mô Tả (TextBox)
            var txtMoTa = new TextBox { Multiline = true, Height = 80 };
            if (nhom != null)
                txtMoTa.Text = nhom.MoTa;
            AddControlRow(txtMoTa, "Mô Tả:", 90);

            // Trạng Thái (ComboBox)
            var cmbTrangThai = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var trangThaiList = _context.TrangThai.ToList();
            cmbTrangThai.DataSource = trangThaiList;
            cmbTrangThai.DisplayMember = "TenTrangThai";
            cmbTrangThai.ValueMember = "MaTrangThai";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (nhom != null && nhom.MaTrangThai.HasValue)
                {
                    cmbTrangThai.SelectedValue = nhom.MaTrangThai.Value;
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
                    var nhomToSave = nhom ?? new NhomNguoiDung();
                    nhomToSave.TenNhom = txtTenNhom.Text;
                    nhomToSave.MoTa = txtMoTa.Text;
                    nhomToSave.MaTrangThai = (int?)cmbTrangThai.SelectedValue;

                    if (nhom == null)
                    {
                        _context.NhomNguoiDung.Add(nhomToSave);
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

        private void ucNhomNguoiDung_Load(object sender, EventArgs e)
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
                    form.lbHeader.Text = "Thêm Nhóm Người Dùng";
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
