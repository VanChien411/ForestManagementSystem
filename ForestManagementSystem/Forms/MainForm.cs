using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForestManagementSystem.Models;
using ForestManagementSystem.Models.Repositories;
using ForestManagementSystem.Forms.User;

namespace ForestManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        private readonly ForestManagementSystemContext _context;

        public MainForm(ForestManagementSystemContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void customButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Quản lý loại rừng",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucLoaiRung = new ucLoaiRung(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucLoaiRung);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form LoaiRung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton6_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Quản lý quy hoạch rừng",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucQuyHoachRung = new ucQuyHoachRung(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucQuyHoachRung);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form QuyHoachRung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Danh Mục Rừng",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucDanhMucRung = new ucDanhMucRung(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucDanhMucRung);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form DanhMucRung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton3_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Quản lý nguồn gốc rừng",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucNguonGocRung = new ucNguonGocRung(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucNguonGocRung);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form NguonGocRung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton4_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Danh Mục Rừng Theo Nguồn Gốc",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucDanhMucRungTheoNguonGoc = new ucDanhMucRungTheoNguonGoc(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucDanhMucRungTheoNguonGoc);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form DanhMucRungTheoNguonGoc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton5_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Danh Mục Thuộc Tính Loại Đất",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucDanhMucThuocTinhLoDat = new ucDanhMucThuocTinhLoDat(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucDanhMucThuocTinhLoDat);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form DanhMucThuocTinhLoDat: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton7_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Quản lý điểm trượt lở",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucDiemTruotLo = new ucDiemTruotLo(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucDiemTruotLo);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form DiemTruotLo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton8_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Quản lý điểm lũ quét",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucDiemLuQuet = new ucDiemLuQuet(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucDiemLuQuet);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form DiemLuQuet: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton9_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Quản lý báo cáo thiên tai",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucThienTai = new ucThienTai(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucThienTai);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form ThienTai: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton10_Click_1(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Quản lý đơn vị hành chính huyện",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucDonViHanhChinhHuyen = new ucDonViHanhChinhHuyen(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucDonViHanhChinhHuyen);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form DonViHanhChinhHuyen: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton11_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Quản lý đơn vị hành chính xã",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucDonViHanChinhXa = new ucDonViHanChinhXa(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucDonViHanChinhXa);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form DonViHanhChinhXa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton12_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Quản lý người dùng",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucQuanLyNguoiDung = new ucQuanLyNguoiDung(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucQuanLyNguoiDung);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form QuanLyNguoiDung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customButton13_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Form
                {
                    Text = "Quản lý nhóm người dùng",
                    WindowState = FormWindowState.Maximized,
                    StartPosition = FormStartPosition.CenterScreen
                };

                var ucNhomNguoiDung = new ucNhomNguoiDung(_context)
                {
                    Dock = DockStyle.Fill
                };
                form.Controls.Add(ucNhomNguoiDung);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo form NhomNguoiDung: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
