using Foundation;
using System;
using UIKit;
using System.Threading.Tasks;

namespace ContainerViews
{
    public partial class ContainerViewController : UIViewController
    {
        private NSString SegueIdentifierFirst = (NSString)"embedFirst";
        private NSString SegueIdentifierSecond = (NSString)"embedSecond";

        private TaskCompletionSource<bool> viewChangingTcs;

        public ContainerViewController(IntPtr handle) : base(handle)
        {
        }

        public TaskCompletionSource<bool> ViewChangingTcs
        {
            get { return viewChangingTcs; }

            set { viewChangingTcs = value; }
        }

        public Task<bool> PresentFirstViewAsync()
        {
            viewChangingTcs = new TaskCompletionSource<bool>();

            PerformSegue(SegueIdentifierFirst, this);

            return viewChangingTcs.Task;
        }

        public Task<bool> PresentSecondViewAsync()
        {
            viewChangingTcs = new TaskCompletionSource<bool>();

            PerformSegue(SegueIdentifierSecond, this);

            return viewChangingTcs.Task;
        }

    }
}