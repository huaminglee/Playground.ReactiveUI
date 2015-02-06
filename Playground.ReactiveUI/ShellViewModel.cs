using ReactiveUI;

namespace Playground.RxUI
{
    public class ShellViewModel : ReactiveObject
    {
        public ShellViewModel()
        {
            Project = new ProjectViewModel();
        }

        public ProjectViewModel Project { get; private set; }
    }
}
