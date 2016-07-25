using System;

using UIKit;

namespace ContainerViews
{
    public partial class ViewController : UIViewController
    {
        private ContainerViewController containerViewController;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            if (segue.Identifier == "embedContainer")
            {
                containerViewController = segue.DestinationViewController as ContainerViewController;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SwapViewsButton.TouchUpInside += (object sender, EventArgs e) => 
            {
                containerViewController.SwapViewControllers();
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

