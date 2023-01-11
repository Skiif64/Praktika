using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_14Fractals
{
    public class Program
    {
        static void Main(string[] args)
        {
            var generator = new FractalGenerator();
            var fractalBitmap = generator.Generate(1024, 2);
            fractalBitmap.Save("fractal.bmp");
        }
    }

    public class FractalGenerator
    {
        private const int IMAGE_SIZE = 4096;
        private Bitmap _bitmap = new Bitmap(IMAGE_SIZE, IMAGE_SIZE);

        public Bitmap Generate(int size, int depth)
        {
            Generate(IMAGE_SIZE / 2, IMAGE_SIZE / 2, size, depth);
            return _bitmap;
        }
        private void Generate(int x, int y, int radius, int depth)
        {            
            using (var graphics = Graphics.FromImage(_bitmap))
            {
                using (var pen = new Pen(Color.Red, 5))
                {
                    graphics.DrawEllipse(pen, x - radius / 2, y - radius / 2, radius, radius);
                }
            }
            if (radius == 0)
                return;
            if (depth != 0)
            {
                var nextOffset = (int)Math.Round(Math.PI * radius / 6);
                Generate(x + nextOffset, y, radius / 2, depth - 1);
                Generate(x, y + nextOffset, radius / 2, depth - 1);
                Generate(x - nextOffset, y, radius / 2, depth - 1);
                Generate(x, y - nextOffset, radius / 2, depth - 1);
            }

        }
    }
}
