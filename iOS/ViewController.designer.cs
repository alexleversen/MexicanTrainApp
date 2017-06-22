// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MexicanTrainScoresheet.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MexicanTrainScoresheet.iOS.FullDominoView dominoView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton scoreButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView trainBottom { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView trainBottomLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView trainBottomRight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView trainLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView trainRight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView trainTop { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView trainTopLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView trainTopRight { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (dominoView != null) {
                dominoView.Dispose ();
                dominoView = null;
            }

            if (scoreButton != null) {
                scoreButton.Dispose ();
                scoreButton = null;
            }

            if (trainBottom != null) {
                trainBottom.Dispose ();
                trainBottom = null;
            }

            if (trainBottomLeft != null) {
                trainBottomLeft.Dispose ();
                trainBottomLeft = null;
            }

            if (trainBottomRight != null) {
                trainBottomRight.Dispose ();
                trainBottomRight = null;
            }

            if (trainLeft != null) {
                trainLeft.Dispose ();
                trainLeft = null;
            }

            if (trainRight != null) {
                trainRight.Dispose ();
                trainRight = null;
            }

            if (trainTop != null) {
                trainTop.Dispose ();
                trainTop = null;
            }

            if (trainTopLeft != null) {
                trainTopLeft.Dispose ();
                trainTopLeft = null;
            }

            if (trainTopRight != null) {
                trainTopRight.Dispose ();
                trainTopRight = null;
            }
        }
    }
}