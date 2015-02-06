using System.Windows;
using ReactiveUI;
using Splat;

namespace Playground.RxUI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Locator.CurrentMutable.Register(() => new ShellView(), typeof(IViewFor<ShellViewModel>));
            Locator.CurrentMutable.Register(() => new ProjectView(), typeof(IViewFor<ProjectViewModel>));
            Locator.CurrentMutable.Register(() => new TaskView(), typeof(IViewFor<TaskViewModel>));
        }
    }
}
