using System;
using Foundation;
using UIKit;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;

namespace MexicanTrainScoresheet.iOS
{
    public partial class ScoringViewController : UIViewController
    {
        NSString _userName;
        HalfDominoView[] _pipViews;
        int _score;

        public ScoringViewController(NSString userName) : base("ScoringViewController", null)
        {
            _score = 0;
            _userName = userName;
            _pipViews = new HalfDominoView[12];
            for (var i = 0; i < 12; i++){
                _pipViews[i] = new HalfDominoView(i + 1);
                var x = i;
                _pipViews[i].AddGestureRecognizer(new UITapGestureRecognizer(_ => HalfDominoTapped(x + 1)));
            }
        }

        private void HalfDominoTapped(int i)
		{
			_score += i;
            scoreLabel.Text = $"Score: {_score}";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			View.AddSubviews(_pipViews);
			View.AddSubview(scoreLabel);
            NavigationItem.Title = _userName;
            scoreLabel.Text = $"Score: {_score}";
            ConstrainViews();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        void ConstrainViews(){
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(
                _pipViews[0].WithSameLeft(View),
                _pipViews[0].WithSameTop(View).Plus(150),
                _pipViews[1].ToRightOf(_pipViews[0]),
                _pipViews[1].WithSameTop(_pipViews[0]),
                _pipViews[1].WithSameWidth(_pipViews[0]),
                _pipViews[1].WithSameHeight(_pipViews[0]),
                _pipViews[2].WithSameRight(View),
                _pipViews[2].WithSameTop(_pipViews[1]),
                _pipViews[2].ToRightOf(_pipViews[1]),
                _pipViews[2].WithSameWidth(_pipViews[1]),
				_pipViews[2].WithSameHeight(_pipViews[1]),
				_pipViews[3].WithSameLeft(View),
                _pipViews[3].Below(_pipViews[0]),
				_pipViews[3].WithSameHeight(_pipViews[2]),
				_pipViews[4].ToRightOf(_pipViews[3]),
				_pipViews[4].WithSameTop(_pipViews[3]),
				_pipViews[4].WithSameWidth(_pipViews[3]),
				_pipViews[4].WithSameHeight(_pipViews[3]),
				_pipViews[5].WithSameRight(View),
				_pipViews[5].WithSameTop(_pipViews[4]),
				_pipViews[5].ToRightOf(_pipViews[4]),
				_pipViews[5].WithSameWidth(_pipViews[4]),
				_pipViews[5].WithSameHeight(_pipViews[4]),
				_pipViews[6].WithSameLeft(View),
				_pipViews[6].Below(_pipViews[3]),
				_pipViews[6].WithSameHeight(_pipViews[5]),
				_pipViews[7].ToRightOf(_pipViews[6]),
				_pipViews[7].WithSameTop(_pipViews[6]),
				_pipViews[7].WithSameWidth(_pipViews[6]),
				_pipViews[7].WithSameHeight(_pipViews[6]),
				_pipViews[8].WithSameRight(View),
				_pipViews[8].WithSameTop(_pipViews[7]),
				_pipViews[8].ToRightOf(_pipViews[7]),
				_pipViews[8].WithSameWidth(_pipViews[7]),
				_pipViews[8].WithSameHeight(_pipViews[7]),
				_pipViews[9].WithSameLeft(View),
				_pipViews[9].Below(_pipViews[6]),
				_pipViews[9].WithSameHeight(_pipViews[8]),
				_pipViews[10].ToRightOf(_pipViews[9]),
				_pipViews[10].WithSameTop(_pipViews[9]),
				_pipViews[10].WithSameWidth(_pipViews[9]),
				_pipViews[10].WithSameHeight(_pipViews[9]),
				_pipViews[11].WithSameRight(View),
				_pipViews[11].WithSameTop(_pipViews[10]),
				_pipViews[11].ToRightOf(_pipViews[10]),
				_pipViews[11].WithSameWidth(_pipViews[10]),
				_pipViews[11].WithSameHeight(_pipViews[10]),
                _pipViews[11].WithSameBottom(View),
                scoreLabel.WithSameTop(View).Plus(100),
                scoreLabel.WithSameLeft(View)
            );
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

