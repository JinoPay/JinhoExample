using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N06_FileStream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = File.ReadAllBytes($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\asd.e3d");

            var size = new byte[4];

            Array.Copy(data, 39, size, 0, 4);

            var sizeint = BitConverter.ToInt32(size);

            var pointx = new byte[4];
            var pointy = new byte[4];
            var pointz = new byte[4];

            var points = new AA[sizeint];

            for (var i = 0; i < sizeint; i++)
            {
                points[i] = new AA();
                Array.Copy(data, 43 + (i * 12), pointx, 0, 4);
                Array.Copy(data, 47 + (i * 12), pointy, 0, 4);
                Array.Copy(data, 51 + (i * 12), pointz, 0, 4);

                var x = BitConverter.ToSingle(pointx);
                var y = BitConverter.ToSingle(pointy);
                var z = BitConverter.ToSingle(pointz);

                if (!Single.IsNaN(x))
                {
                    points[i].x = x;
                    points[i].y = y;
                    points[i].z = z;
                }
            }
        }

        class AA
        {
            public float x;
            public float y;
            public float z;
        }
    }

}
