namespace ASYNCAPPLICATION
{
    public class GenericTaskEventHandler<T> where T : class
    {
        public event EventHandler<GenericTaskEventArgs<T>>? GenericTaskEvent;

        public async Task TriggerGenericTaskEvent(List<Task<T>> listOfTask)
        {
            int taskIndex = 0;
            do
            {
                taskIndex = Task.WaitAny(listOfTask.ToArray());
                OnGenericTaskEventHandler(new GenericTaskEventArgs<T> { TaskEventResult = await listOfTask[taskIndex] });
                listOfTask.RemoveAt(taskIndex);
            } while (!listOfTask.All(x => x.IsCompletedSuccessfully));
        }

        protected virtual void OnGenericTaskEventHandler(GenericTaskEventArgs<T> e)
        {
            if (GenericTaskEvent != null)
                GenericTaskEvent.Invoke(this, e);
        }
    }

    public sealed class GenericTaskEventArgs<T> : EventArgs where T : class
    {
        public GenericTaskEventArgs()
        {
            TaskEventResult = Activator.CreateInstance<T>();
        }

        public T TaskEventResult { get; set; }
    }
}
