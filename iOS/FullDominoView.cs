using Foundation;
using System;
using UIKit;
using CoreGraphics;

namespace MexicanTrainScoresheet.iOS
{
    public partial class FullDominoView : UIView
    {
        public CGColor PipColor { get; set; }
		public int PipNumber { get; set; }
        private const int PIP_RADIUS = 10;

        public FullDominoView(IntPtr handle) : base(handle)
		{
		}

        public override void Draw(CGRect rect)
		{
            using (var ctx = UIGraphics.GetCurrentContext())
			{
				ctx.SetFillColor(new CGColor(1, 1, 1));
                ctx.SetStrokeColor(new CGColor(0, 0, 0));
                ctx.SetLineWidth(10);
                ctx.AddRect(new CGRect(0,0,150,300));
                ctx.DrawPath(CGPathDrawingMode.FillStroke);
				DrawPips(ctx);
                ctx.SetStrokeColor(new CGColor(0.4f, 0.4f, 0.4f));
				ctx.SetFillColor(new CGColor(0.4f, 0.4f, 0.4f));
                ctx.SetLineWidth(1);
                ctx.AddRect(new CGRect(15,148,120,4));
                ctx.DrawPath(CGPathDrawingMode.FillStroke);
            }
		}

        private void DrawPips(CGContext ctx)
        {
            switch(PipNumber){
                case 1:
                    DrawCircles(ctx, 75, 75);
                    break;
                case 2:
                    DrawCircles(ctx, 25, 25);
                    DrawCircles(ctx, 125, 125);
                    break;
				case 3:
					DrawCircles(ctx, 75, 75);
					DrawCircles(ctx, 25, 25);
					DrawCircles(ctx, 125, 125);
                    break;
                case 4:
                    DrawCircles(ctx, 25, 25);
                    DrawCircles(ctx, 125,25);
                    DrawCircles(ctx, 25, 125);
                    DrawCircles(ctx, 125, 125);
                    break;
                case 5:
					DrawCircles(ctx, 25, 25);
					DrawCircles(ctx, 125, 25);
					DrawCircles(ctx, 25, 125);
					DrawCircles(ctx, 125, 125);
					DrawCircles(ctx, 75, 75);
                    break;
                case 6:
                    DrawCircles(ctx, 25, 25);
                    DrawCircles(ctx, 125,25);
                    DrawCircles(ctx, 25, 125);
                    DrawCircles(ctx, 125, 125);
                    DrawCircles(ctx, 25, 75);
                    DrawCircles(ctx, 125, 75);
                    break;
                case 7:
					DrawCircles(ctx, 25, 25);
					DrawCircles(ctx, 125, 25);
					DrawCircles(ctx, 25, 125);
					DrawCircles(ctx, 125, 125);
					DrawCircles(ctx, 25, 75);
					DrawCircles(ctx, 125, 75);
					DrawCircles(ctx, 75, 75);
                    break;
				case 8:
					DrawCircles(ctx, 25, 25);
					DrawCircles(ctx, 125, 25);
					DrawCircles(ctx, 25, 125);
					DrawCircles(ctx, 125, 125);
					DrawCircles(ctx, 25, 75);
					DrawCircles(ctx, 125, 75);
                    DrawCircles(ctx, 75, 25);
                    DrawCircles(ctx, 75, 125);
                    break;
                case 9:

					DrawCircles(ctx, 25, 25);
					DrawCircles(ctx, 125, 25);
					DrawCircles(ctx, 25, 125);
					DrawCircles(ctx, 125, 125);
					DrawCircles(ctx, 25, 75);
					DrawCircles(ctx, 125, 75);
					DrawCircles(ctx, 75, 25);
					DrawCircles(ctx, 75, 125);
					DrawCircles(ctx, 75, 75);
                    break;
				case 10:
					DrawCircles(ctx, 25, 25);
					DrawCircles(ctx, 125, 25);
					DrawCircles(ctx, 25, 125);
					DrawCircles(ctx, 125, 125);
                    DrawCircles(ctx, 25, 58);
					DrawCircles(ctx, 25, 92);
					DrawCircles(ctx, 125, 58);
					DrawCircles(ctx, 125, 92);
                    DrawCircles(ctx, 75, 25);
                    DrawCircles(ctx, 75, 125);
                    break;
                case 11:
                    DrawCircles(ctx, 25, 25);
                    DrawCircles(ctx, 125, 25);
                    DrawCircles(ctx, 25, 125);
                    DrawCircles(ctx, 125, 125);
                    DrawCircles(ctx, 25, 58);
                    DrawCircles(ctx, 25, 92);
                    DrawCircles(ctx, 125, 58);
                    DrawCircles(ctx, 125, 92);
                    DrawCircles(ctx, 75, 25);
					DrawCircles(ctx, 75, 125);
					DrawCircles(ctx, 75, 75);
                    break;
                case 12:
					DrawCircles(ctx, 25, 25);
					DrawCircles(ctx, 125, 25);
					DrawCircles(ctx, 25, 125);
					DrawCircles(ctx, 125, 125);
					DrawCircles(ctx, 25, 58);
					DrawCircles(ctx, 25, 92);
					DrawCircles(ctx, 125, 58);
					DrawCircles(ctx, 125, 92);
					DrawCircles(ctx, 75, 25);
					DrawCircles(ctx, 75, 125);
                    DrawCircles(ctx, 75, 58);
                    DrawCircles(ctx, 75, 92);
                    break;
            }
        }

        private void DrawCircles(CGContext ctx, int x, int y){
            ctx.SetFillColor(PipColor);
            ctx.AddArc(x,y,PIP_RADIUS,0,(float)(2*Math.PI),true);
            ctx.DrawPath(CGPathDrawingMode.Fill);
            ctx.AddArc(x, y + 150, PIP_RADIUS, 0, (float)(2 * Math.PI), true);
            ctx.DrawPath(CGPathDrawingMode.Fill);
        }
    }
}