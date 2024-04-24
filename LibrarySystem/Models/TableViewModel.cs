namespace LibrarySystem.Models
{
    public class TableViewModel
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string borrower { get; set; }
        public string city { get; set; }
        public string genre { get; set; }
        public DateOnly dateofissue { get; set; }
    }
}
