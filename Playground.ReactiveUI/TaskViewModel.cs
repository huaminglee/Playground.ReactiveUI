using ReactiveUI;

namespace Playground.RxUI
{
    public class TaskViewModel : ReactiveObject
    {
        string _title;
        public string Title
        {
            get { return _title; }
            set { this.RaiseAndSetIfChanged(ref _title, value); }
        }

        bool _isComplete;
        public bool IsComplete
        {
            get { return _isComplete; }
            set { this.RaiseAndSetIfChanged(ref _isComplete, value); }
        }
    }
}