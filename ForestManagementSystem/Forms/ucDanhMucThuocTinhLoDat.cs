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
    public partial class ucDanhMucThuocTinhLoDat : UserControl
    {
        private readonly ForestManagementSystemContext _context;

        public ucDanhMucThuocTinhLoDat(ForestManagementSystemContext context)
        {
            InitializeComponent();
            _context = context;
            InitializeDataGridView();
            lbHeader.Text = "Danh Mục Thuộc Tính Loại Đất";
            gListCard.Text = "Danh Sách Thuộc Tính Loại Đất";
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void InitializeDataGridView()
        {
            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add data columns
            dataGridView1.Columns.Add("MaLoDat", "Mã Loại Đất");
            dataGridView1.Columns.Add("TenLoDat", "Tên Loại Đất");
            dataGridView1.Columns.Add("DienTich", "Diện Tích");
            dataGridView1.Columns.Add("ToaDo", "Tọa Độ");
            dataGridView1.Columns.Add("MaLoaiRung", "Mã Loại Rừng");
            dataGridView1.Columns.Add("MaNguonGoc", "Mã Nguồn Gốc");
            dataGridView1.Columns.Add("MaLapDia", "Mã Lập Địa");
            dataGridView1.Columns.Add("ChuSoHuu", "Chủ Sở Hữu");
            dataGridView1.Columns.Add("TrangThai", "Trạng Thái");

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
                var loDatList = _context.LoDatRung
                    .Include(l => l.MaLoaiRungNavigation)
                    .Include(l => l.MaNguonGocNavigation)
                    .Include(l => l.MaLapDiaNavigation)
                    .ToList();
                dataGridView1.Rows.Clear();

                foreach (var loDat in loDatList)
                {
                    dataGridView1.Rows.Add(
                        loDat.MaLoDat,
                        loDat.TenLoDat,
                        loDat.DienTich,
                        loDat.ToaDo,
                        loDat.MaLoaiRungNavigation?.TenLoaiRung,
                        loDat.MaNguonGocNavigation?.TenNguonGoc,
                        loDat.MaLapDia,
                        loDat.ChuSoHuu,
                        loDat.TrangThai
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the clicked column
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var maLoDat = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaLoDat"].Value);

            switch (columnName)
            {
                case "Edit":
                    var loDatToEdit = _context.LoDatRung
                        .Include(l => l.MaLoaiRungNavigation)
                        .Include(l => l.MaNguonGocNavigation)
                        .Include(l => l.MaLapDiaNavigation)
                        .FirstOrDefault(l => l.MaLoDat == maLoDat);
                    if (loDatToEdit != null)
                    {
                        using (var form = new EditForm(_context))
                        {
                            form.lbHeader.Text = "Sửa Thuộc Tính Loại Đất";
                            InitializeEditFormControls(form, loDatToEdit);
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                LoadData();
                            }
                        }
                    }
                    break;

                case "Delete":
                    var result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa thuộc tính loại đất này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var loDatToDelete = _context.LoDatRung.Find(maLoDat);
                        if (loDatToDelete != null)
                        {
                            _context.LoDatRung.Remove(loDatToDelete);
                            _context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;
            }
        }

        private async void InitializeEditFormControls(EditForm form, LoDatRung loDat)
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

            // Tên Loại Đất (TextBox)
            var txtTenLoDat = new TextBox();
            if (loDat != null)
                txtTenLoDat.Text = loDat.TenLoDat;
            AddControlRow(txtTenLoDat, "Tên Loại Đất:");

            // Diện Tích (NumericUpDown)
            var numDienTich = new NumericUpDown
            {
                DecimalPlaces = 2,
                Maximum = 999999999,
                Minimum = 0
            };
            if (loDat != null)
                numDienTich.Value = (decimal)loDat.DienTich;
            AddControlRow(numDienTich, "Diện Tích:");

            // Tọa Độ (TextBox)
            var txtToaDo = new TextBox();
            if (loDat != null)
                txtToaDo.Text = loDat.ToaDo;
            AddControlRow(txtToaDo, "Tọa Độ:");

            // Loại Rừng (ComboBox)
            var cmbLoaiRung = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var loaiRungList = _context.LoaiRung.ToList();
            cmbLoaiRung.DataSource = loaiRungList;
            cmbLoaiRung.DisplayMember = "TenLoaiRung";
            cmbLoaiRung.ValueMember = "MaLoaiRung";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (loDat != null && loDat.MaLoaiRung.HasValue)
                {
                    cmbLoaiRung.SelectedValue = loDat.MaLoaiRung.Value;
                    Console.WriteLine($"SelectedValue Loại Rừng sau khi set: {cmbLoaiRung.SelectedValue}");
                }
                else
                {
                    cmbLoaiRung.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbLoaiRung, "Loại Rừng:");

            // Nguồn Gốc (ComboBox)
            var cmbNguonGoc = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var nguonGocList = _context.NguonGocRung.ToList();
            cmbNguonGoc.DataSource = nguonGocList;
            cmbNguonGoc.DisplayMember = "TenNguonGoc";
            cmbNguonGoc.ValueMember = "MaNguonGoc";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (loDat != null && loDat.MaNguonGoc.HasValue)
                {
                    cmbNguonGoc.SelectedValue = loDat.MaNguonGoc.Value;
                    Console.WriteLine($"SelectedValue Nguồn Gốc sau khi set: {cmbNguonGoc.SelectedValue}");
                }
                else
                {
                    cmbNguonGoc.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbNguonGoc, "Nguồn Gốc:");

            // Lập Địa (ComboBox)
            var cmbLapDia = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var lapDiaList = _context.DieuKienLapDia.ToList();
            cmbLapDia.DataSource = lapDiaList;
            cmbLapDia.DisplayMember = "TenLapDia";
            cmbLapDia.ValueMember = "MaLapDia";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (loDat != null && loDat.MaLapDia.HasValue)
                {
                    cmbLapDia.SelectedValue = loDat.MaLapDia.Value;
                    Console.WriteLine($"SelectedValue Lập Địa sau khi set: {cmbLapDia.SelectedValue}");
                }
                else
                {
                    cmbLapDia.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbLapDia, "Lập Địa:");

            // Chủ Sở Hữu (TextBox)
            var txtChuSoHuu = new TextBox();
            if (loDat != null)
                txtChuSoHuu.Text = loDat.ChuSoHuu;
            AddControlRow(txtChuSoHuu, "Chủ Sở Hữu:");

            // Trạng Thái (TextBox)
            var txtTrangThai = new TextBox();
            if (loDat != null)
                txtTrangThai.Text = loDat.TrangThai;
            AddControlRow(txtTrangThai, "Trạng Thái:");

            // Add spacing row at the bottom
            form.tbBody.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
            rowIndex++;

            // Handle OK button click
            form.btOk.Click += async (s, args) =>
            {
                try
                {
                    var loDatToSave = loDat ?? new LoDatRung();
                    loDatToSave.TenLoDat = txtTenLoDat.Text;
                    loDatToSave.DienTich = numDienTich.Value;
                    loDatToSave.ToaDo = txtToaDo.Text;
                    loDatToSave.MaLoaiRung = cmbLoaiRung.SelectedValue != null ? (int)cmbLoaiRung.SelectedValue : null;
                    loDatToSave.MaNguonGoc = cmbNguonGoc.SelectedValue != null ? (int)cmbNguonGoc.SelectedValue : null;
                    loDatToSave.MaLapDia = cmbLapDia.SelectedValue != null ? (int)cmbLapDia.SelectedValue : null;
                    loDatToSave.ChuSoHuu = txtChuSoHuu.Text;
                    loDatToSave.TrangThai = txtTrangThai.Text;

                    if (loDat == null)
                    {
                        _context.LoDatRung.Add(loDatToSave);
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

        private void ucDanhMucThuocTinhLoDat_Load(object sender, EventArgs e)
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
                    form.lbHeader.Text = "Thêm Thuộc Tính Loại Đất";
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
