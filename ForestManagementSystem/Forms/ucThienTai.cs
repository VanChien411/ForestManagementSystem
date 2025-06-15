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
    public partial class ucThienTai : UserControl
    {
        private readonly ForestManagementSystemContext _context;
        private List<BaoCaoThienTai> _allData;

        public ucThienTai(ForestManagementSystemContext context)
        {
            InitializeComponent();
            _context = context;
            InitializeDataGridView();
            lbHeader.Text = "Báo Cáo Thiên Tai";
            gListCard.Text = "Danh Sách Báo Cáo Thiên Tai";
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
            dataGridView1.Columns.Add("MaBaoCaoThienTai", "Mã Báo Cáo");
            dataGridView1.Columns.Add("TieuDe", "Tiêu Đề");
            dataGridView1.Columns.Add("LoaiThienTai", "Loại Thiên Tai");
            dataGridView1.Columns.Add("TenDiemTruotLo", "Điểm Trượt Lở");
            dataGridView1.Columns.Add("TenDiemLuQuet", "Điểm Lũ Quét");
            dataGridView1.Columns.Add("TenXa", "Xã");
            dataGridView1.Columns.Add("NgayBaoCao", "Ngày Báo Cáo");
            dataGridView1.Columns.Add("NoiDung", "Nội Dung");
            dataGridView1.Columns.Add("TenNguoiTao", "Người Tạo");
            dataGridView1.Columns.Add("TenTrangThai", "Trạng Thái");
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
                _allData = _context.BaoCaoThienTai
                    .Include(b => b.MaTruotLoNavigation)
                    .Include(b => b.MaLuQuetNavigation)
                    .Include(b => b.MaXaNavigation)
                    .Include(b => b.MaNguoiTaoNavigation)
                    .Include(b => b.MaTrangThaiNavigation)
                    .ToList();

                DisplayData(_allData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayData(List<BaoCaoThienTai> data)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (var item in data)
                {
                    dataGridView1.Rows.Add(
                        item.MaBaoCaoThienTai,
                        item.TieuDe,
                        item.LoaiThienTai,
                        item.MaTruotLoNavigation?.TenDiem,
                        item.MaLuQuetNavigation?.TenDiem,
                        item.MaXaNavigation?.TenXa,
                        item.NgayBaoCao,
                        item.NoiDung,
                        item.MaNguoiTaoNavigation?.TenNguoiDung,
                        item.MaTrangThaiNavigation?.TenTrangThai,
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

            var filteredData = _allData.Where(b =>
                b.TieuDe.ToLower().Contains(searchText) ||
                b.LoaiThienTai.ToLower().Contains(searchText) ||
                (b.MaTruotLoNavigation != null && b.MaTruotLoNavigation.TenDiem.ToLower().Contains(searchText)) ||
                (b.MaLuQuetNavigation != null && b.MaLuQuetNavigation.TenDiem.ToLower().Contains(searchText)) ||
                (b.MaXaNavigation != null && b.MaXaNavigation.TenXa.ToLower().Contains(searchText)) ||
                b.NgayBaoCao.ToString().Contains(searchText) ||
                (b.NoiDung != null && b.NoiDung.ToLower().Contains(searchText)) ||
                (b.MaNguoiTaoNavigation != null && b.MaNguoiTaoNavigation.TenNguoiDung.ToLower().Contains(searchText)) ||
                (b.MaTrangThaiNavigation != null && b.MaTrangThaiNavigation.TenTrangThai.ToLower().Contains(searchText))
            ).ToList();

            DisplayData(filteredData);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the clicked column
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var maBaoCao = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaBaoCaoThienTai"].Value);

            switch (columnName)
            {
                case "Edit":
                    var baoCaoToEdit = _context.BaoCaoThienTai.Find(maBaoCao);
                    if (baoCaoToEdit != null)
                    {
                        using (var form = new EditForm(_context))
                        {
                            form.lbHeader.Text = "Sửa Báo Cáo Thiên Tai";
                            InitializeEditFormControls(form, baoCaoToEdit);
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                LoadData();
                            }
                        }
                    }
                    break;

                case "Delete":
                    var result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa báo cáo thiên tai này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var baoCaoToDelete = _context.BaoCaoThienTai.Find(maBaoCao);
                        if (baoCaoToDelete != null)
                        {
                            _context.BaoCaoThienTai.Remove(baoCaoToDelete);
                            _context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;
            }
        }

        private async void InitializeEditFormControls(EditForm form, BaoCaoThienTai baoCao)
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

            // Tiêu Đề (TextBox)
            var txtTieuDe = new TextBox();
            if (baoCao != null)
                txtTieuDe.Text = baoCao.TieuDe;
            AddControlRow(txtTieuDe, "Tiêu Đề:");

            // Loại Thiên Tai (TextBox)
            var txtLoaiThienTai = new TextBox();
            if (baoCao != null)
                txtLoaiThienTai.Text = baoCao.LoaiThienTai;
            AddControlRow(txtLoaiThienTai, "Loại Thiên Tai:");

            // Điểm Trượt Lở (ComboBox)
            var cmbTruotLo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var truotLoList = _context.DiemTruotLo.ToList();
            cmbTruotLo.DataSource = truotLoList;
            cmbTruotLo.DisplayMember = "TenDiem";
            cmbTruotLo.ValueMember = "MaTruotLo";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (baoCao != null && baoCao.MaTruotLo.HasValue)
                {
                    cmbTruotLo.SelectedValue = baoCao.MaTruotLo.Value;
                    Console.WriteLine($"SelectedValue Điểm Trượt Lở sau khi set: {cmbTruotLo.SelectedValue}");
                }
                else
                {
                    cmbTruotLo.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbTruotLo, "Điểm Trượt Lở:");

            // Điểm Lũ Quét (ComboBox)
            var cmbLuQuet = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var luQuetList = _context.DiemLuQuet.ToList();
            cmbLuQuet.DataSource = luQuetList;
            cmbLuQuet.DisplayMember = "TenDiem";
            cmbLuQuet.ValueMember = "MaLuQuet";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (baoCao != null && baoCao.MaLuQuet.HasValue)
                {
                    cmbLuQuet.SelectedValue = baoCao.MaLuQuet.Value;
                    Console.WriteLine($"SelectedValue Điểm Lũ Quét sau khi set: {cmbLuQuet.SelectedValue}");
                }
                else
                {
                    cmbLuQuet.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbLuQuet, "Điểm Lũ Quét:");

            // Xã (ComboBox)
            var cmbXa = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var xaList = _context.DonViHanhChinhXa.ToList();
            cmbXa.DataSource = xaList;
            cmbXa.DisplayMember = "TenXa";
            cmbXa.ValueMember = "MaXa";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (baoCao != null && baoCao.MaXa.HasValue)
                {
                    cmbXa.SelectedValue = baoCao.MaXa.Value;
                    Console.WriteLine($"SelectedValue Xã sau khi set: {cmbXa.SelectedValue}");
                }
                else
                {
                    cmbXa.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbXa, "Xã:");

            // Ngày Báo Cáo (DateTimePicker)
            var dtpNgayBaoCao = new DateTimePicker { Format = DateTimePickerFormat.Short };
            if (baoCao != null)
                dtpNgayBaoCao.Value = baoCao.NgayBaoCao.ToDateTime(TimeOnly.MinValue);
            AddControlRow(dtpNgayBaoCao, "Ngày Báo Cáo:");

            // Nội Dung (TextBox)
            var txtNoiDung = new TextBox { Multiline = true, Height = 80 };
            if (baoCao != null)
                txtNoiDung.Text = baoCao.NoiDung;
            AddControlRow(txtNoiDung, "Nội Dung:", 90);

            // Người Tạo (ComboBox)
            var cmbNguoiTao = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var nguoiDungList = _context.NguoiDung.ToList();
            cmbNguoiTao.DataSource = nguoiDungList;
            cmbNguoiTao.DisplayMember = "TenNguoiDung";
            cmbNguoiTao.ValueMember = "MaNguoiDung";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (baoCao != null && baoCao.MaNguoiTao.HasValue)
                {
                    cmbNguoiTao.SelectedValue = baoCao.MaNguoiTao.Value;
                    Console.WriteLine($"SelectedValue Người Tạo sau khi set: {cmbNguoiTao.SelectedValue}");
                }
                else
                {
                    cmbNguoiTao.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbNguoiTao, "Người Tạo:");

            // Trạng Thái (ComboBox)
            var cmbTrangThai = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var trangThaiList = _context.TrangThai.ToList();
            cmbTrangThai.DataSource = trangThaiList;
            cmbTrangThai.DisplayMember = "TenTrangThai";
            cmbTrangThai.ValueMember = "MaTrangThai";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (baoCao != null && baoCao.MaTrangThai.HasValue)
                {
                    cmbTrangThai.SelectedValue = baoCao.MaTrangThai.Value;
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
                    var baoCaoEntity = baoCao ?? new BaoCaoThienTai();
                    baoCaoEntity.TieuDe = txtTieuDe.Text;
                    baoCaoEntity.LoaiThienTai = txtLoaiThienTai.Text;
                    baoCaoEntity.MaTruotLo = (int?)cmbTruotLo.SelectedValue;
                    baoCaoEntity.MaLuQuet = (int?)cmbLuQuet.SelectedValue;
                    baoCaoEntity.MaXa = (int?)cmbXa.SelectedValue;
                    baoCaoEntity.NgayBaoCao = DateOnly.FromDateTime(dtpNgayBaoCao.Value);
                    baoCaoEntity.NoiDung = txtNoiDung.Text;
                    baoCaoEntity.MaNguoiTao = (int?)cmbNguoiTao.SelectedValue;
                    baoCaoEntity.MaTrangThai = (int?)cmbTrangThai.SelectedValue;
                    baoCaoEntity.NgayCapNhat = DateTime.Now;

                    if (baoCao == null)
                    {
                        _context.BaoCaoThienTai.Add(baoCaoEntity);
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

        private void ucThienTai_Load(object sender, EventArgs e)
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
                    form.lbHeader.Text = "Thêm Báo Cáo Thiên Tai";
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
