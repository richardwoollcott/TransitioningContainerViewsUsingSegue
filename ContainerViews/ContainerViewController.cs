using Foundation;
using System;
using UIKit;

namespace ContainerViews
{
    public partial class ContainerViewController : UIViewController
    {
        private NSString SegueIdentifierFirst = (Foundation.NSString)"embedFirst";
        private NSString SegueIdentifierSecond = (Foundation.NSString)"embedSecond";

        private NSString currentSegueIdentifier;

        public ContainerViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            currentSegueIdentifier = SegueIdentifierFirst;

            PerformSegue(currentSegueIdentifier, this);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == SegueIdentifierFirst)
            {
                if (this.ChildViewControllers.Length > 0)
                {
                    swapFromViewController(this.ChildViewControllers[0], segue.DestinationViewController);
                }
                else
                {
                    //on first run no transition animation
                    AddChildViewController(segue.DestinationViewController);

                    segue.DestinationViewController.View.Frame = new CoreGraphics.CGRect(0, 0, this.View.Frame.Size.Width, this.View.Frame.Size.Height);
                    Add(segue.DestinationViewController.View);

                    segue.DestinationViewController.DidMoveToParentViewController(this);
                }
            }
            else if (segue.Identifier == SegueIdentifierSecond)
            {
                swapFromViewController(this.ChildViewControllers[0], segue.DestinationViewController);
            }
        }

        private void swapFromViewController(UIViewController fromViewController, UIViewController toViewController)
        {
            toViewController.View.Frame = new CoreGraphics.CGRect(0, 0, this.View.Frame.Size.Width, this.View.Frame.Size.Height);

            toViewController.WillMoveToParentViewController(this);

            AddChildViewController(toViewController);

            Transition(fromViewController, toViewController, 1.0, UIViewAnimationOptions.TransitionCrossDissolve, () => { }, (bool finished) => 
            { 
                fromViewController.RemoveFromParentViewController();
                toViewController.DidMoveToParentViewController(this);
            });
        }
    
        public void SwapViewControllers()
        {
            currentSegueIdentifier = currentSegueIdentifier == SegueIdentifierFirst ? SegueIdentifierSecond : SegueIdentifierFirst;

            PerformSegue(currentSegueIdentifier, null);
        }
    }
}