using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Playground.RxUI
{
    public class ProjectViewModel : ReactiveObject
    {
        public ProjectViewModel()
        {
            Tasks = new ReactiveList<TaskViewModel>();

            Tasks.Add(new TaskViewModel{Title = "Add new tasks command"});
            Tasks.Add(new TaskViewModel{Title = "Add delete task command"});
            Tasks.Add(new TaskViewModel{Title = "Allow reorder of tasks"});

            AddTask = this.WhenAny(x => x.NewTaskTitle, x => !String.IsNullOrWhiteSpace(x.Value)).ToCommand();
            AddTask
                .Select(_ => new TaskViewModel {Title = NewTaskTitle})
                .Subscribe(x =>
                {
                    Tasks.Add(x);
                    NewTaskTitle = String.Empty;
                });
        }

        public ReactiveList<TaskViewModel> Tasks { get; private set; }

        public ReactiveCommand<object> AddTask { get; private set; }
        
        string _newTaskTitle;
        public string NewTaskTitle
        {
            get { return _newTaskTitle; }
            set { this.RaiseAndSetIfChanged(ref _newTaskTitle, value); }
        }
    }
}
