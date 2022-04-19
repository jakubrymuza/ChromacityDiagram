using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace GK_proj3
{
    public partial class Form1 : Form
    {
        private CIEXYZ[] _WavelengthsXYZ;
        private ChromacityDiagram _ChromacityDiagram;
        private ChromacityCurve _ChromacityCurve;

        public Form1()
        {
            InitializeComponent();

            _WavelengthsXYZ = new CIEXYZ[ChromacityDiagram.VisibleMax + 1];
            LoadWavelengthsXYZ();

            _ChromacityCurve = new ChromacityCurve(SpectrumPictureBox.Width, SpectrumPictureBox.Height, _WavelengthsXYZ);
            _ChromacityDiagram = new ChromacityDiagram(DiagramPictureBox.Width, DiagramPictureBox.Height, _WavelengthsXYZ);
        }

        private void SpectrumPictureBox_Paint(object sender, PaintEventArgs e)
        {
            _ChromacityCurve.Draw(e.Graphics);

            _ChromacityDiagram.ChosenPoint = _ChromacityCurve.GetChosenPoint();
            DiagramPictureBox.Invalidate();
        }
        
        private void DiagramPictureBox_Paint(object sender, PaintEventArgs e)
        {
            _ChromacityDiagram.Draw(e.Graphics);               
        }

        private void PointsCountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _ChromacityCurve.PointsCount = (int)PointsCountNumericUpDown.Value;
            SpectrumPictureBox.Invalidate();
        }

        private void BackgroundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _ChromacityDiagram.DrawBackground = BackgroundCheckBox.Checked;
            DiagramPictureBox.Invalidate();
        }

        private void LoadWavelengthsXYZ()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB"); // needed to recognise '.' chracter as decimal separator

            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\Data\wavelengths.txt");
            foreach (var line in lines)
            {
                string[] subs = line.Split(' ', '\t');

                int WL = int.Parse(subs[0]);
                double X = double.Parse(subs[1]);
                double Y = double.Parse(subs[2]);
                double Z = double.Parse(subs[3]);

                _WavelengthsXYZ[WL] = new CIEXYZ(X, Y, Z);
            }
        }

        private void sRGBRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _ChromacityDiagram.sRGB = sRGBRadioButton.Checked;
            _ChromacityCurve.sRGB = sRGBRadioButton.Checked;
            SpectrumPictureBox.Invalidate();
        }
    }
}
