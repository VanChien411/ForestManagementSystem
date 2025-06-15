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
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ForestManagementSystem.Forms.User
{
    public partial class RegisterForm : Form
    {
        private readonly ForestManagementSystemContext _context;

        public RegisterForm(ForestManagementSystemContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        private bool ValidateInput(string username, string password, string rePassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(rePassword))
            {
                lbError.Text = "Vui lòng nhập đầy đủ thông tin!";
                return false;
            }

            if (password != rePassword)
            {
                lbError.Text = "Mật khẩu nhập lại không khớp!";
                return false;
            }

            if (username.Length < 3)
            {
                lbError.Text = "Tên đăng nhập phải có ít nhất 3 ký tự!";
                return false;
            }

            if (password.Length < 6)
            {
                lbError.Text = "Mật khẩu phải có ít nhất 6 ký tự!";
                return false;
            }

            return true;
        }

        private void btRegister_Click(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            lbError.Text = "";
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            lbError.Text = "";
        }

        private void tbRePassword_TextChanged(object sender, EventArgs e)
        {
            lbError.Text = "";
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            string username = tbUserName.Text.Trim();
            string password = tbPassword.Text.Trim();
            string rePassword = tbRePassword.Text.Trim();

            if (!ValidateInput(username, password, rePassword))
            {
                return;
            }

            try
            {
                // Kiểm tra tài khoản đã tồn tại chưa
                var existingUser = _context.NguoiDung
                    .FirstOrDefault(u => u.TaiKhoan == username);

                if (existingUser != null)
                {
                    lbError.Text = "Tên đăng nhập đã tồn tại!";
                    return;
                }

                // Tạo người dùng mới
                var newUser = new NguoiDung
                {
                    TaiKhoan = username,
                    MatKhau = password,
                    TenNguoiDung = username, // Sử dụng username làm tên người dùng
                    NgayTao = DateTime.Now,
                    MaTrangThai = 1 // Trạng thái hoạt động
                };

                _context.NguoiDung.Add(newUser);
                _context.SaveChanges();

                // Ghi lịch sử truy cập
                var lichSuTruyCap = new LichSuTruyCap
                {
                    MaNguoiDung = newUser.MaNguoiDung,
                    ThoiGianTruyCap = DateTime.Now,
                    IPAddress = GetLocalIPAddress(),
                    HanhDong = "DangKy"
                };
                _context.LichSuTruyCap.Add(lichSuTruyCap);
                _context.SaveChanges();

                MessageBox.Show("Đăng ký thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Chuyển đến MainForm
                MainForm mainForm = new MainForm(_context);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                lbError.Text = "Có lỗi xảy ra: " + ex.Message;
            }
        }

        private void lbRegister_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm(_context);
            this.Hide();
            login.ShowDialog();
            this.Show();
        }
    }
}
