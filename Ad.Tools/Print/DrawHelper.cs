using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Print
{
    public class DrawHelper
    {
        public DrawHelper(bool isPrint)
        {
            this.isPrint = isPrint; ;
        }

        private bool isPrint = true;

        public SizeF DrawString(Graphics g, Font font, Brush brush, string str, float x, float y)
        {
            if (isPrint)
            {
                g.DrawString(str, font, brush, x, y);
            }
            return g.MeasureString(str, font);
        }


        public SizeF DrawStringSplit(Graphics g, Font font, Brush brush, string str, float maxWidth, float x, float y, float marginRight, float fontHeight)
        {


            var size = g.MeasureString(str, font);
            float useMWidth = maxWidth - x - marginRight;
            if (size.Width <= useMWidth)
            {
                if (isPrint)
                {
                    g.DrawString(str, font, brush, x, y);
                }
                size.Height = fontHeight;
                return size;
            }
            else
            {
                RectangleF rect = new RectangleF(x, y, useMWidth, fontHeight * 1);
                if (isPrint)
                {
                    var format = new StringFormat(StringFormatFlags.LineLimit);
                    format.LineAlignment = StringAlignment.Near;
                    format.Alignment = StringAlignment.Near;
                    g.DrawString(str, font, brush, rect, format);
                }
                return new SizeF(rect.Width, rect.Height);
            }
        }

        public SizeF DrawStringLeft(Graphics g, Font font, Brush brush, string str, float useMWidth, float x, float y, float fontHeight)
        {
            int rows = 1;
            var size = g.MeasureString(str, font);
            if (size.Width > useMWidth)
            {
                rows = (int)Math.Ceiling(size.Width / useMWidth);
            }

            RectangleF rect = new RectangleF(x, y, useMWidth, fontHeight * rows);
            if (isPrint)
            {
                var format = new StringFormat(StringFormatFlags.FitBlackBox);
                format.LineAlignment = StringAlignment.Near;
                format.Alignment = StringAlignment.Near;
                g.DrawString(str, font, brush, rect, format);
            }
            return new SizeF(rect.Width, rect.Height);
        }

        public SizeF DrawStringRight(Graphics g, Font font, Brush brush, string str, float useMWidth, float x, float y, float fontHeight)
        {
            int rows = 1;
            var size = g.MeasureString(str, font);
            if (size.Width > useMWidth)
            {
                rows = (int)Math.Ceiling(size.Width / useMWidth);
            }

            RectangleF rect = new RectangleF(x, y, useMWidth, fontHeight * rows);
            if (isPrint)
            {
                var format = new StringFormat(StringFormatFlags.FitBlackBox);
                format.LineAlignment = StringAlignment.Far;
                format.Alignment = StringAlignment.Far;
                g.DrawString(str, font, brush, rect, format);
            }
            return new SizeF(rect.Width, rect.Height);

        }

        public SizeF DrawStringLineLeft(Graphics g, Font font, Brush brush, string str, float maxWidth, float x, float y, float marginRight, float fontHeight)
        {
            var size = g.MeasureString(str, font);
            float useMWidth = maxWidth - x - marginRight;
            if (size.Width <= useMWidth)
            {
                if (isPrint)
                {
                    g.DrawString(str, font, brush, x, y);
                }
                size.Height = fontHeight;
                return size;
            }
            else
            {
                int rows = (int)Math.Ceiling(size.Width / useMWidth);
                RectangleF rect = new RectangleF(x, y, useMWidth, fontHeight * rows);
                if (isPrint)
                {
                    var format = new StringFormat(StringFormatFlags.FitBlackBox);
                    format.LineAlignment = StringAlignment.Near;
                    format.Alignment = StringAlignment.Near;
                    g.DrawString(str, font, brush, rect, format);
                }
                return new SizeF(rect.Width, rect.Height);
            }
        }

        public SizeF DrawStringLineCenter(Graphics g, Font font, Brush brush, string str, float maxWidth, float y, float marginLeft, float marginRight, float fontHeight)
        {
            var size = g.MeasureString(str, font);
            float x = 0;
            float useMWidth = maxWidth - marginLeft - marginRight;
            if (size.Width <= useMWidth)
            {
                x = (maxWidth - size.Width) / 2;
                if (isPrint)
                {
                    g.DrawString(str, font, brush, x, y);
                }
                size.Height = fontHeight;
                return size;
            }
            else
            {
                int rows = (int)Math.Ceiling(size.Width / useMWidth);
                RectangleF rect = new RectangleF(marginLeft, y, useMWidth - marginRight, fontHeight * rows);
                if (isPrint)
                {
                    var format = new StringFormat(StringFormatFlags.FitBlackBox);
                    format.LineAlignment = StringAlignment.Near;
                    format.Alignment = StringAlignment.Center;
                    g.DrawString(str, font, brush, rect, format);
                }
                return new SizeF(rect.Width, rect.Height);
            }
        }

    }
}
