using Foundation;
using System;
using UIKit;
using CoreGraphics;

namespace MexicanTrainScoresheet.iOS
{
    public partial class FullDominoView : UIView
    {
		public UIColor PipColor { get; set; }
		public int PipNumber { get; set; }

        public FullDominoView(IntPtr handle) : base(handle)
		{
		}

        public override void Draw(CGRect rect)
		{
            using (var ctx = UIGraphics.GetCurrentContext())
            {
                ctx.AddRect(new CGRect(0, 0, 50, 50));
                ctx.SetFillColor(new CGColor(0.5f, 0.5f, 0.5f, 0.5f));
                ctx.DrawPath(CGPathDrawingMode.FillStroke);
            }
		}
    }
}