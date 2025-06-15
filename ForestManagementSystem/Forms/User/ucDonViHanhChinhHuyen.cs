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
    public partial class ucDonViHanhChinhHuyen : UserControl
    {
        private readonly ForestManagementSystemContext _context;
        private List<DonViHanhChinhHuyen> _allData;

        public ucDonViHanhChinhHuyen(ForestManagementSystemContext context)
        {
            InitializeComponent();
            _context = context;
            InitializeDataGridView();
            lbHeader.Text = "Đơn Vị Hành Chính Huyện";
            gListCard.Text = "Danh Sách Đơn Vị Hành Chính Huyện";
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
            this.Load += ucDonViHanhChinhHuyen_Load;

            // Load data immediately after initialization
            LoadData();
        }

        private void InitializeDataGridView()
        {
            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add data columns
            dataGridView1.Columns.Add("MaHuyen", "Mã Huyện");
            dataGridView1.Columns.Add("TenHuyen", "Tên Huyện");
            dataGridView1.Columns.Add("MaTinh", "Mã Tỉnh");

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
                _allData = _context.DonViHanhChinhHuyen
                    .Include(h => h.MaTinhNavigation)
                    .ToList();

                DisplayData(_allData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayData(List<DonViHanhChinhHuyen> data)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (var item in data)
                {
                    dataGridView1.Rows.Add(
                        item.MaHuyen,
                        item.TenHuyen,
                        item.MaTinh
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

            var filteredData = _allData.Where(h =>
                h.TenHuyen.ToLower().Contains(searchText) ||
                h.MaHuyen.ToString().Contains(searchText) ||
                h.MaTinh.ToString().Contains(searchText)
            ).ToList();

            DisplayData(filteredData);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the clicked column
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var maHuyen = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaHuyen"].Value);

            switch (columnName)
            {
                case "Edit":
                    var huyenToEdit = _context.DonViHanhChinhHuyen.Find(maHuyen);
                    if (huyenToEdit != null)
                    {
                        using (var form = new EditForm(_context))
                        {
                            form.lbHeader.Text = "Sửa Đơn Vị Hành Chính Huyện";
                            InitializeEditFormControls(form, huyenToEdit);
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                LoadData();
                            }
                        }
                    }
                    break;

                case "Delete":
                    var result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa đơn vị hành chính huyện này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var huyenToDelete = _context.DonViHanhChinhHuyen.Find(maHuyen);
                        if (huyenToDelete != null)
                        {
                            _context.DonViHanhChinhHuyen.Remove(huyenToDelete);
                            _context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;
            }
        }

        private async void InitializeEditFormControls(EditForm form, DonViHanhChinhHuyen huyen)
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

            // Tên Huyện (TextBox)
            var txtTenHuyen = new TextBox();
            if (huyen != null)
                txtTenHuyen.Text = huyen.TenHuyen;
            AddControlRow(txtTenHuyen, "Tên Huyện:");

            // Mã Tỉnh (ComboBox)
            var cmbTinh = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            var tinhList = _context.DonViHanhChinhTinh.ToList();
            cmbTinh.DataSource = tinhList;
            cmbTinh.DisplayMember = "TenTinh";
            cmbTinh.ValueMember = "MaTinh";

            // Đợi ComboBox render xong rồi mới set SelectedValue
            this.BeginInvoke(new Action(() => {
                if (huyen != null)
                {
                    cmbTinh.SelectedValue = huyen.MaTinh;
                    Console.WriteLine($"SelectedValue Tỉnh sau khi set: {cmbTinh.SelectedValue}");
                }
                else
                {
                    cmbTinh.SelectedIndex = -1;
                }
            }));

            AddControlRow(cmbTinh, "Tỉnh:");

            // Add spacing row at the bottom
            form.tbBody.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
            rowIndex++;

            // Handle OK button click
            form.btOk.Click += async (s, args) =>
            {
                try
                {
                    var huyenEntity = huyen ?? new DonViHanhChinhHuyen();
                    huyenEntity.TenHuyen = txtTenHuyen.Text;
                    huyenEntity.MaTinh = (int)cmbTinh.SelectedValue;

                    if (huyen == null)
                    {
                        _context.DonViHanhChinhHuyen.Add(huyenEntity);
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

        private void ucDonViHanhChinhHuyen_Load(object sender, EventArgs e)
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
                    form.lbHeader.Text = "Thêm Đơn Vị Hành Chính Huyện";
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
