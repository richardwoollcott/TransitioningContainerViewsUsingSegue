using Foundation;
using System;
using UIKit;

namespace ContainerViews
{
    public partial class FirstViewController : UIViewController
    {
        public FirstViewController(IntPtr handle) : base(handle)
        {
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
        }
    }
}