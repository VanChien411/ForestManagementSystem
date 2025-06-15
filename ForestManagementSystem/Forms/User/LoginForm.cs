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
    public partial class LoginForm : Form
    {
        private readonly ForestManagementSystemContext _context;

        public LoginForm(ForestManagementSystemContext context)
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }


        private void lbRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(_context);
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void customButton1_Click_1(object sender, EventArgs e)
        {
            string username = tbUserName.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lbError.Text = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!";
                return;
            }

            try
            {
                var user = _context.NguoiDung
                    .FirstOrDefault(u => u.TaiKhoan == username && u.MatKhau == password);

                if (user != null)
                {
                    // Ghi lịch sử truy cập
                    var lichSuTruyCap = new LichSuTruyCap
                    {
                        MaNguoiDung = user.MaNguoiDung,
                        ThoiGianTruyCap = DateTime.Now,
                        IPAddress = GetLocalIPAddress(),
                        HanhDong = "DangNhap"
                    };
                    _context.LichSuTruyCap.Add(lichSuTruyCap);
                    _context.SaveChanges();

                    // Đăng nhập thành công
                    lbError.Text = "";
                    MainForm mainForm = new MainForm(_context);
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    lbError.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
                }
            }
            catch (Exception ex)
            {
                lbError.Text = "Có lỗi xảy ra: " + ex.Message;
            }
        }
    }
}
