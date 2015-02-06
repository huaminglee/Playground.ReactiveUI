using System.Windows;
using ReactiveUI;

namespace Playground.RxUI
{
    public partial class TaskView : IViewFor<TaskViewModel>
    {
        public TaskView()
        {
            InitializeComponent();

            this.Bind(ViewModel, vm => vm.IsComplete, v => v.IsComplete.IsChecked);
            this.Bind(ViewModel, vm => vm.Title, v => v.Title.Text);
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (TaskViewModel) value; }
        }

        public TaskViewModel ViewModel
        {
            get { return (TaskViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof (TaskViewModel), typeof (TaskView));

    }
}
