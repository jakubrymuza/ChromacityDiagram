using System;
using System.Drawing;
using System.Windows.Forms;


namespace GK_proj3
{
    public partial class Form1 : Form
    {
        private void SpectrumPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            CheckDragHitboxes(e.Location);
        }

        private void CheckDragHitboxes(Point p)
        {
            bool selected = _ChromacityCurve.CheckHitboxes(p);

            if (selected)
            {
                EnableDragging();
            }
        }

        private void EnableDragging()
        {
            SpectrumPictureBox.MouseMove += new MouseEventHandler(SpectrumPictureBox_MouseMove);
            SpectrumPictureBox.MouseUp += new MouseEventHandler(SpectrumPictureBox_MouseUp);
        }

        private void DisableDragging()
        {
            SpectrumPictureBox.MouseMove -= SpectrumPictureBox_MouseMove;
            SpectrumPictureBox.MouseUp -= SpectrumPictureBox_MouseUp;
        }

        private void SpectrumPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _ChromacityCurve.ChangePosition(e.Location);
            SpectrumPictureBox.Invalidate();
        }

        private void SpectrumPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            DisableDragging();
        }

    }
}
