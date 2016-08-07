using System.Threading.Tasks;

namespace ContainerViews
{
    public interface ITransitioningViewController
    {
        TaskCompletionSource<bool> ViewChanging { get; set;}
    }
}

