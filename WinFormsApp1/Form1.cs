using Microsoft.Win32;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            main_();
            Size = new Size(320, 250);
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            label1.Font = new Font("dotum", 14);
            label2.Font = new Font("dotum", 14);
            label3.Font = new Font("dotum", 14);
            label4.Font = new Font("dotum", 14);
            label5.Font = new Font("dotum", 14);
            label1.Location = new Point(20, 20);
            label2.Location = new Point(20, 50);
            label3.Location = new Point(20, 80);
            label4.Location = new Point(20, 110);
            label5.Location = new Point(20, 140);
            button1.Location = new Point(200, 20);
            button2.Location = new Point(200, 50);
            button3.Location = new Point(200, 80);
            button4.Location = new Point(200, 110);
            button5.Location = new Point(200, 140);
            button6.Location = new Point(50, 170);
            button1.Text = "재입력시간";
            button2.Text = "고정키";
            button3.Text = "필터키";
            button4.Text = "키 시퀀스";
            button5.Text = "사용자계정";
            button6.Text = "전원옵션";
            /*
            net8 / visual studio 2022 ver 17.8
            2023. 11.
            */
        }

        void main_()
        {
            RegistryKey localmachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var opensubkey = localmachine.OpenSubKey("software\\microsoft\\windows nt\\currentversion");
            int currentbuild = Convert.ToInt32(opensubkey.GetValue("currentbuild"));
            if (currentbuild < 19045)
            {
                MessageBox.Show("windows update 22H2" + Environment.NewLine + "윈도우 업데이트 필요");
            }
            if (currentbuild == 22000)
            {
                MessageBox.Show("windows update 23H2" + Environment.NewLine + "윈도우 업데이트 필요");
            }
            if (currentbuild == 22621)
            {
                MessageBox.Show("windows update 23H2" + Environment.NewLine + "윈도우 업데이트 필요");
            }
            RegistryKey currentuser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            var keyboard = currentuser.OpenSubKey("control panel\\keyboard");
            int keyboarddelay = Convert.ToInt32(keyboard.GetValue("keyboarddelay"));
            if (keyboarddelay == 1)
            {
                label1.Text = "KeyboardDelay" + string.Empty.PadLeft(1) + keyboard.GetValue("keyboarddelay");
            }
            else
            {
                label1.Text = "재입력 시간 짧게";
            }
            RegistryKey currentuser2 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            var stickykeys = currentuser2.OpenSubKey("control panel\\accessibility\\stickykeys");
            int stickykeys_ = Convert.ToInt32(stickykeys.GetValue("flags"));
            if (stickykeys_ == 510)
            {
                label2.Text = "Flags" + string.Empty.PadLeft(1) + stickykeys.GetValue("flags");
            }
            else
            {
                label2.Text = "고정키 안함";
            }
            RegistryKey currentuser3 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            var keyboard_response = currentuser3.OpenSubKey("control panel\\accessibility\\keyboard response");
            int keyboard_response_ = Convert.ToInt32(keyboard_response.GetValue("flags"));
            if (keyboard_response_ == 126)
            {
                label3.Text = "Flags" + string.Empty.PadLeft(1) + keyboard_response.GetValue("flags");
            }
            else
            {
                label3.Text = "필터키 안함";
            }
            RegistryKey currentuser4 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            var toggle = currentuser4.OpenSubKey("keyboard layout\\toggle");
            var hotkey_check = toggle.GetValue("hotkey");
            int hotkey = Convert.ToInt32(toggle.GetValue("hotkey"));
            if (hotkey_check == null)
            {
                label4.Text = "HotKey 1";
            }
            else if (hotkey == 1)
            {
                label4.Text = "HotKey" + string.Empty.PadLeft(1) + toggle.GetValue("hotkey");
            }
            else
            {
                label4.Text = "키 시퀀스 안함";
            }
            RegistryKey localmachine2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            var system = localmachine2.OpenSubKey("software\\microsoft\\windows\\currentversion\\policies\\system");
            int enablelua = Convert.ToInt32(system.GetValue("enablelua"));
            if (enablelua == 1)
            {
                label5.Text = "EnableLUA" + string.Empty.PadLeft(1) + system.GetValue("enablelua");
            }
            else if (enablelua == 0)
            {
                label5.Text = "사용자계정 안함";
            }
            localmachine.Dispose();
            currentuser.Dispose();
            currentuser2.Dispose();
            currentuser3.Dispose();
            currentuser4.Dispose();
            localmachine2.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = "/c" + string.Empty.PadLeft(1) + "control keyboard";
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.Close();
            process.Dispose();
            main_();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey currentuser2 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            var stickykeys = currentuser2.CreateSubKey("control panel\\accessibility\\stickykeys");
            int stickykeys_ = Convert.ToInt32(stickykeys.GetValue("flags"));
            if (stickykeys_ == 510)
            {
                stickykeys.SetValue("flags", 506, RegistryValueKind.String);
                label2.Text = "고정키 안함";
                stickykeys.Close();
                stickykeys.Dispose();
            }
            else if (stickykeys_ == 506)
            {
                stickykeys.SetValue("flags", 510, RegistryValueKind.String);
                label2.Text = "Flags" + string.Empty.PadLeft(1) + stickykeys.GetValue("flags");
                stickykeys.Close();
                stickykeys.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistryKey currentuser3 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            var keyboard_response = currentuser3.CreateSubKey("control panel\\accessibility\\keyboard response");
            int keyboard_response_ = Convert.ToInt32(keyboard_response.GetValue("flags"));
            if (keyboard_response_ == 126)
            {
                keyboard_response.SetValue("flags", 122, RegistryValueKind.String);
                label3.Text = "필터키 안함";
                keyboard_response.Close();
                keyboard_response.Dispose();
            }
            else if (keyboard_response_ == 122)
            {
                keyboard_response.SetValue("flags", 126, RegistryValueKind.String);
                keyboard_response.SetValue("autorepeatdelay", 1000, RegistryValueKind.String);
                keyboard_response.SetValue("autorepeatrate", 500, RegistryValueKind.String);
                label3.Text = "Flags" + string.Empty.PadLeft(1) + keyboard_response.GetValue("flags");
                keyboard_response.Close();
                keyboard_response.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistryKey currentuser4 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            var toggle = currentuser4.CreateSubKey("keyboard layout\\toggle");
            var hotkey_check = toggle.GetValue("hotkey");
            int hotkey = Convert.ToInt32(toggle.GetValue("hotkey"));
            if (hotkey_check == null)
            {
                toggle.SetValue("hotkey", 1, RegistryValueKind.String);
                label4.Text = "HotKey" + string.Empty.PadLeft(1) + toggle.GetValue("hotkey");
                toggle.Close();
                toggle.Dispose();
            }
            else if (hotkey == 1)
            {
                toggle.SetValue("hotkey", 3, RegistryValueKind.String);
                label4.Text = "키 시퀀스 안함";
                toggle.Close();
                toggle.Dispose();
            }
            else if (hotkey == 3)
            {
                toggle.SetValue("hotkey", 1, RegistryValueKind.String);
                label4.Text = "HotKey" + string.Empty.PadLeft(1) + toggle.GetValue("hotkey");
                toggle.Close();
                toggle.Dispose();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey localmachine2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
                var system = localmachine2.CreateSubKey("software\\microsoft\\windows\\currentversion\\policies\\system");
                int enablelua = Convert.ToInt32(system.GetValue("enablelua"));
                if (enablelua == 1)
                {
                    system.SetValue("enablelua", 0, RegistryValueKind.DWord);
                    label5.Text = "사용자계정 안함";
                    system.Close();
                    system.Dispose();
                }
                else if (enablelua == 0)
                {
                    system.SetValue("enablelua", 1, RegistryValueKind.DWord);
                    label5.Text = "EnableLUA" + string.Empty.PadLeft(1) + system.GetValue("enablelua");
                    system.Close();
                    system.Dispose();
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("administrator run" + Environment.NewLine + "관리자 권한으로 실행 필요");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = "/c" + string.Empty.PadLeft(1) + "powercfg.cpl";
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.Close();
            process.Dispose();
        }
    }
}
