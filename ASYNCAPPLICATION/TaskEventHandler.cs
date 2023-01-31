namespace ASYNCAPPLICATION
{
    public class TaskEventHandler
    {
        public event EventHandler<TaskEventArgs>? TaskEvent;

        public async Task TriggerTaskEvent(List<Task<object>> listOfTask)
        {
            int taskIndex = 0;
            do
            {
                taskIndex = Task.WaitAny(listOfTask.ToArray());
                OnTaskCompletedEvent(new TaskEventArgs { TaskEventResult = await listOfTask[taskIndex] });
                listOfTask.RemoveAt(taskIndex);
            }
            while (!listOfTask.All(x => x.IsCompletedSuccessfully));
        }

        protected virtual void OnTaskCompletedEvent(TaskEventArgs e)
        {
            if (TaskEvent != null)
                TaskEvent?.Invoke(this, e);
        }
    }

    public sealed class TaskEventArgs : EventArgs
    {
        public object? TaskEventResult { get; set; }
    }
}
