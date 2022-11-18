namespace dotnet_signalr_charts.Services
{
    public class Buffer<T> : Queue<T>
    {
        public int? MaxCapacity { get; set; }
        public Buffer(int capacity) { MaxCapacity = capacity; }
        public int TotalItemsAddedCount { get; private set; }

        public void Add(T item) {
            if (Count == (MaxCapacity ?? -1))
            {
                Dequeue();
            }

            Enqueue(item);
            TotalItemsAddedCount++;
        } 
    }
}
