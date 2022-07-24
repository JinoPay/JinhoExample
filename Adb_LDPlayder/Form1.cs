using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adb_LDPlayder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(getDeviceInfo("a"));
        }
        private static string getDeviceInfo(string command)
        {

            ProcessStartInfo psInfo = new ProcessStartInfo();

            psInfo.FileName = @"adb.exe";                       //실행파일
            psInfo.Arguments = command;
            psInfo.UseShellExecute = false;                      //쉘 기능을 사용 하지 않는다.
            psInfo.CreateNoWindow = true;
            psInfo.RedirectStandardOutput = true;               //표준 출력을 리다이렉트

            Process p = Process.Start(psInfo);                  //어플리케이션 실행
            p.WaitForExit();

            string output = p.StandardOutput.ReadToEnd();       //표준 출력 읽어 잡기

            output = output.Replace("\r\r\n", "\n");            //줄바꿈 코드의 수정
            //txt_Output.Text = output;

            string szTemp = output;

            szTemp = szTemp.Replace("\r\r\n", "\n");            //줄바꿈 코드의 수정

            return szTemp;

        }
    }
}
