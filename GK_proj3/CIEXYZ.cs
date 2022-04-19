using System.Drawing;
using System;

namespace GK_proj3
{
    public class CIEXYZ
    {
        public double X;
        public double Y;
        public double Z;

        public CIEXYZ(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public (double, double, double) Getxyz()
        {
            double sum = X + Y + Z;

            if (sum == 0)
                return (0, 0, 0);

            return (X / sum, Y / sum, Z / sum);
        }

        private static double[,] _sRGBConversionMatrix = new double[3, 3]{
        { 3.2410, -1.5374, -0.4986},
        { -0.9692,  1.8760,  0.0416},
        { 0.0556, -0.2040,  1.0570} };
        private static double[,] _WideGamutConversionMatrix = new double[3, 3]{
        { 1.4628067, -0.1840623, -0.2743606 },
        { -0.5217933,  1.4472381,  0.0677227},
        { 0.0349342, -0.0968930,  1.2884099} };

        public Color GetRGBColor(bool sRGB)
        {
            var matrix = sRGB? _sRGBConversionMatrix : _WideGamutConversionMatrix;
            (double r, double g, double b) = Utils.MultiplyMatrixVector3x3(matrix, X, Y, Z);

            r = Math.Max(r, 0);
            g = Math.Max(g, 0);
            b = Math.Max(b, 0);

            r = GammaCorrection(r);
            g = GammaCorrection(g);
            b = GammaCorrection(b);

            return Color.FromArgb(ScaleRGB(r), ScaleRGB(g), ScaleRGB(b));
        }

        private const double GammaInv = 1 / 2.2;

        public double GammaCorrection(double x) => Math.Pow(x, GammaInv);

        public int ScaleRGB(double x) => Math.Min((int)(255 * x),255);
    }
}
