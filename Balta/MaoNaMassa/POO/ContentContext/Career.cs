namespace POO.ContentContext
{
    public class Career : Content
    {
        public Career(string title, string url) : base(title, url)
        {
            Items = new List<CareerItem>();
        }

        public int TotalCourses => Items.Count; // expression body

        public IList<CareerItem> Items { get; set; }
    }
}