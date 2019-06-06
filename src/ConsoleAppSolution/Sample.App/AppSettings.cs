namespace Sample.App
{
    public class AppSettings
    {
        public string Key { get; set; }

        public SubSettings Sub { get; set; }

        public class SubSettings
        {
            public string Key { get; set; }
        }
    }
}
