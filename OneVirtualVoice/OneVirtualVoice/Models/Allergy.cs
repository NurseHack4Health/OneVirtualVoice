namespace OneVirtualVoice.Models
{
    public class Allergy
    {
        public Entry[] Entry { get; set; }
    }

    public class Entry
    {
        public Resource Resource { get; set; }
    }

    public class Resource
    {
        public string Criticality { get; set; }
        public Substance Substance { get; set; }
        public Note Note { get; set; }
    }

    public class Note
    {
        public string Text { get; set; }
    }

    public class Substance
    {
        public string Text { get; set; }
    }
}