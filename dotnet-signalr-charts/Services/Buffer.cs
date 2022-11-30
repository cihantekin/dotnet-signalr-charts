using System.Drawing;

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

    public record Point(string Label, int Value);
    public record Stack(string Label, List<TeamSupporters> TeamSupporters);
    public class TeamSupporters
    {
        public string TeamName { get; set; }
        public int Count { get; set; }
        public string Color { get; set; }
    }
}
