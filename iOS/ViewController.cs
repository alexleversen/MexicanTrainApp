using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;

namespace MexicanTrainScoresheet.iOS
{
	public partial class ViewController : UIViewController
	{
        UIImageView[] _trains;
        bool[] _trainValues;
        NSMutableArray<NSString> _users;
        UILabel[] _names;
        int[] _nameMap;
        enum TrainTapMode
        {
            Normal,
            UserSelect,
            Scoring
        }
        TrainTapMode _trainTapMode = TrainTapMode.Normal;
        bool _scoring;
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
            _names = new[]{
                labelTopLeft,   labelTop,   labelTopRight,
                labelLeft,                  labelRight,
                labelBottomLeft,labelBottom,labelBottomRight
            };
            foreach (var label in _names)
            {
                label.Text = "";
            }
            _nameMap = new []{-1,-1,-1,-1,-1,-1,-1,-1};
            _users = GetUsersFromSettingsStore();
            for (int i = 0; i < _trains.Length; i++)
            {
                var x = i;
                _trains[i].UserInteractionEnabled = true;
                _trains[i].AddGestureRecognizer(new UITapGestureRecognizer(() => HandleTap(x)));
                _trains[i].AddGestureRecognizer(new UILongPressGestureRecognizer(() => HandleLongPress(x)));
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
            var downSwipe = new UISwipeGestureRecognizer(DecrementPips)
            {
                Direction = UISwipeGestureRecognizerDirection.Down
            };
            dominoView.AddGestureRecognizer(downSwipe);
            var upSwipe = new UISwipeGestureRecognizer(IncrementPips)
            {
                Direction = UISwipeGestureRecognizerDirection.Up
            };
            dominoView.AddGestureRecognizer(upSwipe);
        }

        object HandleLongPress(int x)
        {
            throw new NotImplementedException();
        }

        void HandleTap(int index)
        {
            switch (_trainTapMode)
            {
                case TrainTapMode.Normal:
		            var train = _trains[index];
		            train.Image = _trainValues[index] ? UIImage.FromBundle("train.gif") : UIImage.FromBundle("train_selected.gif");
		            _trainValues[index] = !_trainValues[index];
                    break;
                case TrainTapMode.UserSelect:
                    var label = _names[index];
                    if(_nameMap[index] == -1){
                        _nameMap[index] = (int)(_users.Count) - 1;
                        label.Text = _users[_users.Count - 1].ToString();
                        _trainTapMode = TrainTapMode.Normal;
                    }else{
                        ShowTrainTakenAlert(_users.GetItem<NSString>((System.nuint)_nameMap[index]).ToString());
                    }
                    break;
                case TrainTapMode.Scoring:

                    break;
            }
        }

        void ShowTrainTakenAlert(string user)
        {
            var alert = UIAlertController.Create("Train Already Taken!", $"This train has already been taken by {user}. Please pick a different one.", UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, _ => { }));
            PresentViewController(alert, true, () => { });
        }

        void AddButton_Clicked(object sender, EventArgs e)
        {
            if (_users.Count <= 7)
            {
                var alert = UIAlertController.Create("Create new player?", "Enter the new player's name", UIAlertControllerStyle.Alert);
                alert.AddTextField(_ => { });
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (action) =>
                {
                    AddUser(alert.TextFields[0].Text);
                }));
                PresentViewController(alert, true, () => { });
            }else{
                var alert = UIAlertController.Create("Error", "Max number of players reached", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel,_=>{}));
                PresentViewController(alert, true, () => { });
            }
        }

        NSMutableArray<NSString> GetUsersFromSettingsStore(){
            var temp = NSUserDefaults.StandardUserDefaults.ValueForKey(new NSString(ApplicationDefaults.UserListSettingsKey));
            if (temp != null)
            {
                var temp2 = (NSArray)(temp);
                var retval = new NSMutableArray<NSString>();
                for (nuint i = 0; i < temp2.Count; i++){
                    retval.Add(temp2.GetItem<NSString>(i));
                }
                return retval;
            }
            return new NSMutableArray<NSString>();
        }

        void PutUsersToSettingsStore(NSMutableArray<NSString> users = null){
            NSUserDefaults.StandardUserDefaults.SetValueForKey(users ?? _users, ApplicationDefaults.UserListSettingsKey);
        }

        void AddUser(string user){
            _users.AddObjects(new NSString(user));
            PutUsersToSettingsStore();
            _trainTapMode = TrainTapMode.UserSelect;
            ShowChooseTrainAlert(user);
        }

        void ShowChooseTrainAlert(string user){
            var alert = UIAlertController.Create($"Welcome, {user}!", "Hit 'OK' and tap an empty train you would like to use.", UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default,_=>{}));
            PresentViewController(alert, true, ()=>{});
        }

        UILabel GetLabelForUser(nuint index){
            return _names[_nameMap[index]];
        }

        void ScoreButton_Clicked(object sender, EventArgs e)
        {
            //TODO: Implement
            if (!_scoring)
            {
                _trainTapMode = TrainTapMode.Scoring;
                var alert = UIAlertController.Create("Choose a player to score", "Tap the train of the player you want to score", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, _ => { }));
                PresentViewController(alert, true, () => { });
                _scoring = true;
                scoreButton.SetTitle("Cancel Scoring", UIControlState.Normal);
            }else{
                CancelScoring();
                _scoring = false;
                scoreButton.SetTitle("Score Round", UIControlState.Normal);
            }
        }

        void CancelScoring(){
            //TODO: Implement
        }

        void SettingsButton_Clicked(object sender, EventArgs e)
		{
			//TODO: Implement
			Console.WriteLine("Settings Button Clicked");
        }

        void DecrementPips(){
			dominoView.PipNumber = dominoView.PipNumber - 1;
			var rand = new Random();
			dominoView.PipColor = new CGColor(((float)rand.Next(0, 100)) / 100, ((float)rand.Next(0, 100)) / 100, ((float)rand.Next(0, 100)) / 100);
			dominoView.SetNeedsDisplay();
        }

        void IncrementPips(){
            dominoView.PipNumber = dominoView.PipNumber + 1;
            var rand = new Random();
            dominoView.PipColor = new CGColor(((float)rand.Next(0, 100)) / 100, ((float)rand.Next(0, 100)) / 100, ((float)rand.Next(0, 100)) / 100);
            dominoView.SetNeedsDisplay();
        }
    }
}
