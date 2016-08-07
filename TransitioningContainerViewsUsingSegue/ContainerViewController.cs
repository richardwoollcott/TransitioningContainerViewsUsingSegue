using Foundation;
using System;
using UIKit;
using System.Threading.Tasks;

namespace ContainerViews
{
    public partial class ContainerViewController : UIViewController, ITransitioningViewController
    {
        private NSString SegueIdentifierFirst = (NSString)"embedFirst";
        private NSString SegueIdentifierSecond = (NSString)"embedSecond";

        private TaskCompletionSource<bool> viewChanging;

        public ContainerViewController(IntPtr handle) : base(handle)
        {
        }

        public TaskCompletionSource<bool> ViewChanging
        {
            get { return viewChanging; }

            set { viewChanging = value; }
        }

        public Task<bool> PresentFirstViewAsync()
        {
            ViewChanging = new TaskCompletionSource<bool>();

            PerformSegue(SegueIdentifierFirst, this);

            return viewChanging.Task;
        }

        public Task<bool> PresentSecondViewAsync()
        {
            ViewChanging = new TaskCompletionSource<bool>();

            PerformSegue(SegueIdentifierSecond, this);

            return viewChanging.Task;
        }
    }
}