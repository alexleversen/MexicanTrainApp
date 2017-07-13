using System;
using Foundation;

namespace MexicanTrainScoresheet.iOS
{
    public class ApplicationDefaults
    {
        public static NSString UserListSettingsKey = new NSString("UserListSettingsKey");
        public static NSString ScoreDictionaryKey = new NSString("ScoreDictionaryKey");


		public static NSMutableArray<NSMutableArray<NSNumber>> DefaultPipColors = new NSMutableArray<NSMutableArray<NSNumber>>
		{
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(1.0f),
				NSNumber.FromFloat(0.0f),
				NSNumber.FromFloat(0.0f)
			},
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(0.0f),
				NSNumber.FromFloat(1.0f),
				NSNumber.FromFloat(0.0f)
			},
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(1.0f),
				NSNumber.FromFloat(1.0f),
				NSNumber.FromFloat(0.0f)
			},
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(0.0f),
				NSNumber.FromFloat(0.0f),
				NSNumber.FromFloat(1.0f)
			},
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(1.0f),
				NSNumber.FromFloat(0.0f),
				NSNumber.FromFloat(1.0f)
			},
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(0.0f),
				NSNumber.FromFloat(1.0f),
				NSNumber.FromFloat(1.0f)
			},
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(0.5f),
				NSNumber.FromFloat(1.0f),
				NSNumber.FromFloat(0.5f)
			},
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(1.0f),
				NSNumber.FromFloat(0.5f),
				NSNumber.FromFloat(1.0f)
			},
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(0.5f),
				NSNumber.FromFloat(0.5f),
				NSNumber.FromFloat(1.0f)
			},
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(1.0f),
				NSNumber.FromFloat(0.5f),
				NSNumber.FromFloat(0.5f)
			},
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(1.0f),
				NSNumber.FromFloat(1.0f),
				NSNumber.FromFloat(0.5f)
			},
			new NSMutableArray<NSNumber>{
				NSNumber.FromFloat(0.5f),
				NSNumber.FromFloat(0.5f),
				NSNumber.FromFloat(0.5f)
			},
		};
    }
}
