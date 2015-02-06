using System;
using System.Windows;
using ReactiveUI;

namespace Playground.RxUI
{
    public partial class ProjectView : IViewFor<ProjectViewModel>
    {
        public ProjectView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.Tasks, v => v.Tasks.ItemsSource);
            this.Bind(ViewModel, vm => vm.NewTaskTitle, v => v.NewTaskTitle.Text);
            this.BindCommand(ViewModel, vm => vm.AddTask, v => v.AddTask);

            this.WhenAnyObservable(x => x.ViewModel.AddTask)
                .Subscribe(_ => NewTaskTitle.Focus());
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ProjectViewModel) value; }
        }

        public ProjectViewModel ViewModel
        {
            get { return (ProjectViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof (ProjectViewModel), typeof (ProjectView));

    }
}
