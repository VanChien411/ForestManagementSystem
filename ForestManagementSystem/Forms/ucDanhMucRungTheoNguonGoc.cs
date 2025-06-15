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
    public partial class ucDanhMucRungTheoNguonGoc : UserControl
    {
        private readonly ForestManagementSystemContext _context;

        public ucDanhMucRungTheoNguonGoc(ForestManagementSystemContext context)
        {
            InitializeComponent();
            _context = context;
            InitializeDataGridView();
            lbHeader.Text = "Danh Mục Rừng Theo Nguồn Gốc";
            gListCard.Text = "Danh Sách Khu Rừng";
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void InitializeDataGridView()
        {
            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add data columns
            dataGridView1.Columns.Add("MaKhuRung", "Mã Khu Rừng");
            dataGridView1.Columns.Add("TenKhuRung", "Tên Khu Rừng");
            dataGridView1.Columns.Add("MoTa", "Mô Tả");
            dataGridView1.Columns.Add("MaLoaiRung", "Mã Loại Rừng");
            dataGridView1.Columns.Add("MaNguonGoc", "Mã Nguồn Gốc");
            dataGridView1.Columns.Add("MaLapDia", "Mã Lập Địa");
            dataGridView1.Columns.Add("MaLoDat", "Mã Loại Đất");
            dataGridView1.Columns.Add("MaNguoiSoHuu", "Mã Người Sở Hữu");

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

        private async Task LoadNguonGocComboBox()
        {
            try
            {
                var nguonGocList = await _context.NguonGocRung.ToListAsync();
                cbNguonGoc.DataSource = null;
                cbNguonGoc.Items.Clear();
                cbNguonGoc.Items.Add(new { MaNguonGoc = (int?)null, TenNguonGoc = "Tất cả" });
                cbNguonGoc.Items.AddRange(nguonGocList.ToArray());
                cbNguonGoc.DisplayMember = "TenNguonGoc";
                cbNguonGoc.ValueMember = "MaNguonGoc";
                cbNguonGoc.SelectedIndex = 0;

                // Đăng ký sự kiện SelectedIndexChanged
                cbNguonGoc.SelectedIndexChanged -= cbNguonGoc_SelectedIndexChanged;
                cbNguonGoc.SelectedIndexChanged += cbNguonGoc_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nguồn gốc rừng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadLapDiaComboBox()
        {
            try
            {
                var lapDiaList = await _context.DieuKienLapDia.ToListAsync();
                cbLapDia.DataSource = null;
                cbLapDia.Items.Clear();
                cbLapDia.Items.Add(new { MaLapDia = (int?)null, TenLapDia = "Tất cả" });
                cbLapDia.Items.AddRange(lapDiaList.ToArray());
                cbLapDia.DisplayMember = "TenLapDia";
                cbLapDia.ValueMember = "MaLapDia";
                cbLapDia.SelectedIndex = 0;

                // Đăng ký sự kiện SelectedIndexChanged
                cbLapDia.SelectedIndexChanged -= cbLapDia_SelectedIndexChanged;
                cbLapDia.SelectedIndexChanged += cbLapDia_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách điều kiện lập địa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadData()
        {
            try
            {
                // Get selected NguonGoc
                var selectedNguonGoc = cbNguonGoc.SelectedItem;
                int? maNguonGoc = null;

                if (selectedNguonGoc != null)
                {
                    var property = selectedNguonGoc.GetType().GetProperty("MaNguonGoc");
                    if (property != null)
                    {
                        maNguonGoc = (int?)property.GetValue(selectedNguonGoc);
                    }
                }

                // Get selected LapDia
                var selectedLapDia = cbLapDia.SelectedItem;
                int? maLapDia = null;

                if (selectedLapDia != null)
                {
                    var property = selectedLapDia.GetType().GetProperty("MaLapDia");
                    if (property != null)
                    {
                        maLapDia = (int?)property.GetValue(selectedLapDia);
                    }
                }

                // Load data with filters
                var query = _context.KhuRung.AsQueryable();
                if (maNguonGoc.HasValue)
                {
                    query = query.Where(k => k.MaNguonGoc == maNguonGoc);
                }
                if (maLapDia.HasValue)
                {
                    query = query.Where(k => k.MaLapDia == maLapDia);
                }
                var khuRungList = await query.ToListAsync();

                dataGridView1.Rows.Clear();
                foreach (var khuRung in khuRungList)
                {
                    dataGridView1.Rows.Add(
                        khuRung.MaKhuRung,
                        khuRung.TenKhuRung,
                        khuRung.MoTa,
                        khuRung.MaLoaiRung,
                        khuRung.MaNguonGoc,
                        khuRung.MaLapDia,
                        khuRung.MaLoDat,
                        khuRung.MaNguoiSoHuu
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cbNguonGoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cbLapDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the clicked column
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var maKhuRung = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaKhuRung"].Value);

            switch (columnName)
            {
                case "Edit":
                    var khuRungToEdit = _context.KhuRung.Find(maKhuRung);
                    if (khuRungToEdit != null)
                    {
                        using (var form = new EditForm(_context))
                        {
                            form.lbHeader.Text = "Sửa Khu Rừng";
                            InitializeEditFormControls(form, khuRungToEdit);
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                LoadData();
                            }
                        }
                    }
                    break;

                case "Delete":
                    var result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa khu rừng này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var khuRungToDelete = _context.KhuRung.Find(maKhuRung);
                        if (khuRungToDelete != null)
                        {
                            _context.KhuRung.Remove(khuRungToDelete);
                            _context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;
            }
        }

        private async void InitializeEditFormControls(EditForm form, KhuRung khuRung)
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

            // Tên Khu Rừng (TextBox)
            var txtTenKhuRung = new TextBox();
            if (khuRung != null)
                txtTenKhuRung.Text = khuRung.TenKhuRung;
            AddControlRow(txtTenKhuRung, "Tên Khu Rừng:");

            // Mô Tả (TextBox)
            var txtMoTa = new TextBox { Multiline = true, Height = 80 };
            if (khuRung != null)
                txtMoTa.Text = khuRung.MoTa;
            AddControlRow(txtMoTa, "Mô Tả:", 90);

            // Nguồn Gốc (ComboBox)
            var cmbNguonGoc = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var nguonGocList = _context.NguonGocRung.ToList();
            cmbNguonGoc.DataSource = nguonGocList;
            cmbNguonGoc.DisplayMember = "TenNguonGoc";
            cmbNguonGoc.ValueMember = "MaNguonGoc";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (khuRung != null && khuRung.MaNguonGoc.HasValue)
                {
                    cmbNguonGoc.SelectedValue = khuRung.MaNguonGoc.Value;
                    Console.WriteLine($"SelectedValue Nguồn Gốc sau khi set: {cmbNguonGoc.SelectedValue}");
                }
                else
                {
                    cmbNguonGoc.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbNguonGoc, "Nguồn Gốc:");

            // Loại Rừng (ComboBox)
            var cmbLoaiRung = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var loaiRungList = _context.LoaiRung.ToList();
            cmbLoaiRung.DataSource = loaiRungList;
            cmbLoaiRung.DisplayMember = "TenLoaiRung";
            cmbLoaiRung.ValueMember = "MaLoaiRung";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (khuRung != null && khuRung.MaLoaiRung.HasValue)
                {
                    cmbLoaiRung.SelectedValue = khuRung.MaLoaiRung.Value;
                    Console.WriteLine($"SelectedValue Loại Rừng sau khi set: {cmbLoaiRung.SelectedValue}");
                }
                else
                {
                    cmbLoaiRung.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbLoaiRung, "Loại Rừng:");

            // Điều Kiện Lập Địa (ComboBox)
            var cmbLapDia = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var lapDiaList = await _context.DieuKienLapDia.ToListAsync();
            cmbLapDia.DataSource = lapDiaList;
            cmbLapDia.DisplayMember = "TenLapDia";
            cmbLapDia.ValueMember = "MaLapDia";
            if (khuRung != null)
                cmbLapDia.SelectedValue = khuRung.MaLapDia;
            AddControlRow(cmbLapDia, "Điều Kiện Lập Địa:");

            // Loại Đất (ComboBox)
            var cmbLoDat = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var loDatList = await _context.LoDatRung.ToListAsync();
            cmbLoDat.DataSource = loDatList;
            cmbLoDat.DisplayMember = "TenLoDat";
            cmbLoDat.ValueMember = "MaLoDat";
            if (khuRung != null)
                cmbLoDat.SelectedValue = khuRung.MaLoDat;
            AddControlRow(cmbLoDat, "Loại Đất:");

            // Người Sở Hữu (ComboBox)
            var cmbNguoiSoHuu = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var nguoiSoHuuList = await _context.NguoiDung.ToListAsync();
            cmbNguoiSoHuu.DataSource = nguoiSoHuuList;
            cmbNguoiSoHuu.DisplayMember = "TenNguoiDung";
            cmbNguoiSoHuu.ValueMember = "MaNguoiDung";
            if (khuRung != null)
                cmbNguoiSoHuu.SelectedValue = khuRung.MaNguoiSoHuu;
            AddControlRow(cmbNguoiSoHuu, "Người Sở Hữu:");

            // Add spacing row at the bottom
            form.tbBody.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
            rowIndex++;

            // Handle OK button click
            form.btOk.Click += async (s, args) =>
            {
                try
                {
                    var khuRungToSave = khuRung ?? new KhuRung();
                    khuRungToSave.TenKhuRung = txtTenKhuRung.Text;
                    khuRungToSave.MoTa = txtMoTa.Text;
                    khuRungToSave.MaLoaiRung = (int?)cmbLoaiRung.SelectedValue;
                    khuRungToSave.MaNguonGoc = (int?)cmbNguonGoc.SelectedValue;
                    khuRungToSave.MaLapDia = (int?)cmbLapDia.SelectedValue;
                    khuRungToSave.MaLoDat = (int?)cmbLoDat.SelectedValue;
                    khuRungToSave.MaNguoiSoHuu = (int?)cmbNguoiSoHuu.SelectedValue;

                    if (khuRung == null)
                    {
                        _context.KhuRung.Add(khuRungToSave);
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

        private async void ucDanhMucRungTheoNguonGoc_Load(object sender, EventArgs e)
        {
            // Add new row button at the top
            var addButton = new Button
            {
                Text = "Thêm mới",
                Dock = DockStyle.Top,
                Height = 30,
                Margin = new Padding(0, 0, 0, 10)
            };
            addButton.Click += async (s, ev) =>
            {
                using (var form = new EditForm(_context))
                {
                    form.lbHeader.Text = "Thêm Khu Rừng";
                    InitializeEditFormControls(form, null);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await LoadData();
                    }
                }
            };
            this.Controls.Add(addButton);

            // Load initial data
            await LoadNguonGocComboBox();
            await LoadLapDiaComboBox();
            await LoadData();
        }
    }
}
