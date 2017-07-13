using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace MexicanTrainScoresheet.iOS
{
    public class HalfDominoView : UIView
    {
        private int _pipCount;
		UILabel testlabel;
		const int PIP_RADIUS = 10;

        public HalfDominoView(int pipCount)
        {
            _pipCount = pipCount;
            testlabel = new UILabel(Frame)
            {
                Text = pipCount.ToString()
            };
            AddSubview(testlabel);
            BackgroundColor = new UIColor(1.0f, 1.0f, 1.0f, 1.0f);
        }

        public override void Draw(CGRect rect)
        {
            using (var ctx = UIGraphics.GetCurrentContext()){
                DrawPips(ctx);
            }
        }

		private void DrawPips(CGContext ctx)
		{
            switch (_pipCount)
			{
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
					DrawCircles(ctx, 125, 25);
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
					DrawCircles(ctx, 125, 25);
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

		private void DrawCircles(CGContext ctx, int x, int y)
		{
            ctx.SetFillColor(new CGColor(ApplicationDefaults.DefaultPipColors
                                         .GetItem<NSArray<NSNumber>>((System.nuint)_pipCount - 1)
                                         .GetItem<NSNumber>(0).FloatValue,
                            ApplicationDefaults.DefaultPipColors
                                         .GetItem<NSArray<NSNumber>>((System.nuint)_pipCount - 1)
                                         .GetItem<NSNumber>(1).FloatValue,
                            ApplicationDefaults.DefaultPipColors
                                         .GetItem<NSArray<NSNumber>>((System.nuint)_pipCount - 1)
                                         .GetItem<NSNumber>(2).FloatValue));
			ctx.AddArc(x+50, y+38, PIP_RADIUS, 0, (float)(2 * Math.PI), true);
			ctx.DrawPath(CGPathDrawingMode.Fill);
		}
    }
}