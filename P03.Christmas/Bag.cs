namespace Christmas
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private ICollection<Present> presentList;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.presentList = new List<Present>();
        }
        public string Color { get; private set; }
        public int Capacity { get; private set; }

        public int Count
        {
            get => this.presentList.Count;
        }
        public void Add(Present present)
        {
            if (this.Capacity > 0)
            {
                this.presentList.Add(present);
                this.Capacity--;
            }
        }
        public bool Remove(string name)
        {
            Present selected = this.presentList.FirstOrDefault(x => x.Name == name);
            return this.presentList.Remove(selected);
        }

        public Present GetHeaviestPresent()
        {
           return this.presentList.OrderByDescending(x => x.Weight).FirstOrDefault();

        }

        public Present GetPresent(string name)
        {
            return this.presentList.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var item in presentList)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
