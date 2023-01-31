namespace ASYNCAPPLICATION
{
    public class GenericTaskEventHandler<T> where T : class
    {
        public event EventHandler<GenericTaskEventArgs<T>>? GenericTaskEvent;
        
        public async Task TriggerGenericTaskEvent()
        {

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
