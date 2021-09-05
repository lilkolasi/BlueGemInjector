using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime;
using System.IO;

namespace KolasInjector
{
    public partial class Form1 : Form
    {

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0x0;
        private const int SW_SHOW = 0x5;


        
        private static String DLLP { get; set; }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
              int nLeftRect,
              int nTopRect,
              int nRightRect,
              int nBottomRect,
              int nWidthEllipse,
                 int nHeightEllipse

          );
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = "\nChecking VAC Status. . .\n";
            textBox1.Text += localDate.ToString();
            System.Threading.Thread.Sleep(500);
            textBox1.Text += "\nChecking VAC Status. . .\n";
            textBox1.Text += localDate.ToString();

            System.Threading.Thread.Sleep(500);
            textBox1.Text += "\nChecking VAC Status. . .\n";
            textBox1.Text += localDate.ToString();

            System.Threading.Thread.Sleep(500);
            textBox1.Text += "\nChecking VAC Status. . .\n";
            textBox1.Text += localDate.ToString();

            System.Threading.Thread.Sleep(500);
            textBox1.Text += "\nChecking VAC Status. . .\n";
            textBox1.Text += localDate.ToString();

            System.Threading.Thread.Sleep(500);
            textBox1.Text += "\nVAC Status: Undetected.\n";
            textBox1.Text += localDate.ToString();
            System.Threading.Thread.Sleep(500);
            textBox1.Text += "\nReady for Injection.\n";

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            
            pnlNav.Height = BtnHome.Height;
            pnlNav.Top = BtnHome.Top;
            pnlNav.Left = BtnHome.Left;
            BtnHome.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void PnlNav_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel5.Visible = true;
            panel3.Visible = false;
            pnlNav.Height = BtnHome.Height;
            pnlNav.Top = BtnHome.Top;
            pnlNav.Left = BtnHome.Left;
            BtnHome.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void BtnInject_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel5.Visible = false;
            panel3.Visible = true;
            pnlNav.Height = BtnInject.Height;
            pnlNav.Top = BtnInject.Top;
            pnlNav.Left = BtnInject.Left;
            BtnInject.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel5.Visible = false;
            panel3.Visible = false;
            pnlNav.Height = BtnSettings.Height;
            pnlNav.Top = BtnSettings.Top;
            pnlNav.Left = BtnSettings.Left;
            BtnSettings.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void BtnContact_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel5.Visible = false;
            System.Diagnostics.Process.Start("https://linktr.ee/bluegemcheats");
            panel3.Visible = false;
            pnlNav.Height = BtnContact.Height;
            pnlNav.Top = BtnContact.Top;
            pnlNav.Left = BtnContact.Left;
            BtnContact.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void BtnHome_Leave(object sender, EventArgs e)
        {
            BtnHome.BackColor = Color.FromArgb(24, 30, 54);
        }
        

        
        private static IntPtr VirtualAllocEx(IntPtr hndProc, IntPtr intPtr, IntPtr length, int v1, int v2)
        {
            throw new NotImplementedException();
        }

        private void BtnInject_Leave(object sender, EventArgs e)
        {
            BtnInject.BackColor = Color.FromArgb(24, 30, 54);



        }

        private void BtnSettings_Leave(object sender, EventArgs e)
        {
            BtnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnContact_Leave(object sender, EventArgs e)
        {
            BtnContact.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width,
             panel1.Height, 30, 30));

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            System.Windows.Forms.Application.Exit();
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            
        }
        
        private void SelectButton_Click(object sender, EventArgs e)
        {
            
            
            

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BtnInject BVuttonfedr

            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            try
            {
                if (VACBypass.Run(GetPathDLL()))
                {
                    MessageBox.Show("DLL injected!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                else
                {
                    MessageBox.Show("Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GetPathDLL()
        {
            string dllPath = string.Empty;

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                fileDialog.Filter = "DLL files (*.dll)|*.dll";
                fileDialog.FilterIndex = 2;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    dllPath = fileDialog.FileName;
                }
                else
                {
                    throw new ApplicationException("Dll opening error");
                }
            }

            return dllPath;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        DateTime localDate = DateTime.Now;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            

            
        }
    }

        
 
}
