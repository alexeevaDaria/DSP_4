using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DSP_4
{
    public partial class MainForm : Form
    {
        Chart[] targetCharts;
        Bitmap originImage;
        ConvolutionFilterBase filterBase;

        public MainForm()
        {
            InitializeComponent();

            targetCharts = new Chart[3];
            targetCharts[0] = chart1;
            targetCharts[1] = chart2;
            targetCharts[2] = chart3;

            groupBox1.Enabled = true;
            groupBox2.Enabled = false;

            Calculate(1,NoisySignal.FilteringType.Parabolic);
        }

        private void ClearCharts()
        {
            for(int i = 0; i <= 2; i++)
            {
                foreach(var j in targetCharts[i].Series)
                {
                    j.Points.Clear();
                }
            }
        }

        private void Calculate(int freq, NoisySignal.FilteringType ft)
        {
            NoisySignal hs = new NoisySignal(10, freq, 0, 512);
            double[] fs=null;
            switch (ft)
            {
                case NoisySignal.FilteringType.Parabolic:
                    fs = hs.ps;
                    break;
                case NoisySignal.FilteringType.Median:
                    fs = hs.ms;
                    break;
                case NoisySignal.FilteringType.Sliding:
                    fs = hs.ss;
                    break;
                default:
                    break;
            }

            ClearCharts();

            for (int i = 0; i <= 359; i++)
            {
                targetCharts[0].Series[0].Points.AddXY(2 * Math.PI * i / 360, hs.signVal[i]);
                targetCharts[0].Series[1].Points.AddXY(2 * Math.PI * i / 360, fs[i]);
            }

            hs.Operate(ft);

            for (int i = 0; i <= 49; i++)
            {
                targetCharts[1].Series[0].Points.AddXY(i, hs.phaseSp[i]);
                targetCharts[1].Series[1].Points.AddXY(i, hs.psp[i]);
                targetCharts[2].Series[0].Points.AddXY(i, hs.amplSp[i]);
                targetCharts[2].Series[1].Points.AddXY(i, hs.asp[i]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Calculate(1, NoisySignal.FilteringType.Parabolic);
                    break;
                case 1:
                    Calculate(1, NoisySignal.FilteringType.Sliding);
                    break;
                case 2:
                    Calculate(1, NoisySignal.FilteringType.Median);
                    break;
                default: return;
            }
        }

        private void Transform()
        {
            Bitmap finalImage = ImageTransformation.ConvolutionFilter(originImage, filterBase);
            pictureBox2.Image = finalImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Выберите изображение";
            fileDialog.Filter = "Image File (*png; *jpg; *bmp;) | *png; *jpg; *bmp;";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                originImage = new Bitmap(fileDialog.FileName);
                pictureBox1.Image = originImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                comboBox2.SelectedIndex = 0;
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3 && pictureBox1.Image != null)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
            else if (tabControl1.SelectedIndex == 3 && pictureBox1.Image == null)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    filterBase = new SimpleBlurFilter();
                    break;
                case 1:
                    filterBase = new Emboss45DegreeFilter();
                    break;
                case 2:
                    filterBase = new SimpleSharpenFilter();
                    break;
                case 3:
                    filterBase = new EdgeDetectionTopLeftBottomRightFilter();
                    break;
                case 4:
                    filterBase = new SimpleEdgeDetectionFilter();
                    break;
                case 5:
                    filterBase = new SharpenFilter();
                    break;
                case 6:
                    filterBase = new SoftenFilter();
                    break;
                default: return;
            }
            Transform();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
