using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;

namespace MexicanTrainScoresheet.iOS
{
	public partial class ViewController : UIViewController
	{
        private UIImageView[] _trains;
        private bool[] _trainValues;
        private string[] _users;
        public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad(); 
            _trains = new[]{
				trainTopLeft,    trainTop,    trainTopRight,
				trainLeft,                    trainRight,
				trainBottomLeft, trainBottom, trainBottomRight
			};
			_trainValues = new bool[]{
				false, false, false, false, false, false, false, false
			};
            var tempArray = NSUserDefaults.StandardUserDefaults.ArrayForKey(ApplicationDefaults.UserListSettingsKey);
            _users = new string[tempArray?.Length ?? 0];
            tempArray?.CopyTo(_users,0);
            for (int i = 0; i < _trains.Length; i++)
            {
                var x = i;
                _trains[i].UserInteractionEnabled = true;
                _trains[i].AddGestureRecognizer(new UITapGestureRecognizer(() => HandleTap(x)));
            }
            var settingsButton = new UIBarButtonItem("Settings", UIBarButtonItemStyle.Plain, ScoreButton_Clicked);
            var addButton = new UIBarButtonItem("+", UIBarButtonItemStyle.Plain, AddButton_Clicked);
            addButton.Clicked += AddButton_Clicked;
            settingsButton.Clicked += SettingsButton_Clicked;
            scoreButton.TouchUpInside += ScoreButton_Clicked;
            NavigationItem.LeftBarButtonItem = settingsButton;
            NavigationItem.RightBarButtonItem = addButton;
            dominoView.PipColor = new CGColor(0.5f, 0.5f, 0.5f);
            dominoView.PipNumber = 12;
		}

        void HandleTap(int index){
            var train = _trains[index];
            train.Image = _trainValues[index] ? UIImage.FromBundle("train.gif") : UIImage.FromBundle("train_selected.gif");
            _trainValues[index] = !_trainValues[index];
        }

        void AddButton_Clicked(object sender, EventArgs e)
        {
            var alert = UIAlertController.Create("Create new player?", "Enter the new player's name", UIAlertControllerStyle.Alert);
            alert.AddTextField(_ => { });
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (action) =>
            {
                AddUser(alert.TextFields[0].Text);
            }));
            PresentViewController(alert, true, () => { });
        }

        void AddUser(string user){
            NSUserDefaults.StandardUserDefaults.ArrayForKey(ApplicationDefaults.UserListSettingsKey)?.CopyTo(_users,0);
            var newUsers = new string[_users.Length + 1];
            for (int i = 0; i < _users.Length; i++){
                newUsers[i] = _users[i];
            }
            newUsers[_users.Length] = new NSString(user);
            NSUserDefaults.StandardUserDefaults.SetValueForKey(NSArray.FromStrings(_users), new NSString(ApplicationDefaults.UserListSettingsKey));
        }

        void ScoreButton_Clicked(object sender, EventArgs e)
        {
            //TODO: Implement
            Console.WriteLine("Score Button Clicked");
            dominoView.PipNumber = dominoView.PipNumber - 1;
            dominoView.SetNeedsDisplay();
        }

        void SettingsButton_Clicked(object sender, EventArgs e)
		{
			//TODO: Implement
			Console.WriteLine("Settings Button Clicked");
        }
    }
}
