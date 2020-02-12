using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp
{
    public class RoundCornerPanel : Panel
    {
        public RoundCornerPanel()
        {
            Font = new System.Drawing.Font("VAGRounded-Light",
            30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath gPath = new GraphicsPath();
            int cornerRadius = 18;

            Color borderColor = Color.Black;
            Pen drawPen = new Pen(borderColor);

            gPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            gPath.AddArc(Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            gPath.AddArc(Width - cornerRadius, Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            gPath.AddArc(0, Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);

            gPath.CloseAllFigures();
            e.Graphics.DrawPath(drawPen, gPath);

            int inside = 1;
            int borderSize = 4;
            Pen drawPenNew = new Pen(borderColor, borderSize);

            GraphicsPath gPathNew = new GraphicsPath();

            gPathNew.AddArc(0 + inside + 1, 0 + inside, cornerRadius, cornerRadius, 180, 90);
            gPathNew.AddArc(Width - cornerRadius - inside - 2,
                0 + inside, cornerRadius, cornerRadius, 270, 90);
            gPathNew.AddArc(Width - cornerRadius - inside - 2,
                Height - cornerRadius - inside - 1, cornerRadius, cornerRadius, 0, 90);
            gPathNew.AddArc(0 + inside + 1,
            Height - cornerRadius - inside, cornerRadius, cornerRadius, 90, 90);

            gPathNew.CloseAllFigures();
            e.Graphics.DrawPath(drawPenNew, gPathNew);

            this.Region = new System.Drawing.Region(gPath);
        }
    }

    public class RoundCornerPanelSmall : Panel
    {
        public RoundCornerPanelSmall()
        {
            Font = new System.Drawing.Font("VAGRounded-Light",
            30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath gPath = new GraphicsPath();
            int cornerRadius = 10;

            Color borderColor = Color.Black;
            Pen drawPen = new Pen(borderColor);

            gPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            gPath.AddArc(Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            gPath.AddArc(Width - cornerRadius, Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            gPath.AddArc(0, Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);

            gPath.CloseAllFigures();
            e.Graphics.DrawPath(drawPen, gPath);

            int inside = 1;
            int borderSize = 4;
            Pen drawPenNew = new Pen(borderColor, borderSize);

            GraphicsPath gPathNew = new GraphicsPath();

            gPathNew.AddArc(0 + inside + 1, 0 + inside, cornerRadius, cornerRadius, 180, 90);
            gPathNew.AddArc(Width - cornerRadius - inside - 2,
                0 + inside, cornerRadius, cornerRadius, 270, 90);
            gPathNew.AddArc(Width - cornerRadius - inside - 2,
                Height - cornerRadius - inside - 1, cornerRadius, cornerRadius, 0, 90);
            gPathNew.AddArc(0 + inside + 1,
            Height - cornerRadius - inside, cornerRadius, cornerRadius, 90, 90);

            gPathNew.CloseAllFigures();
            e.Graphics.DrawPath(drawPenNew, gPathNew);

            this.Region = new System.Drawing.Region(gPath);
        }
    }
}
