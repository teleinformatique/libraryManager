namespace LibraryManagement.Data.Model
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }

        public virtual Author Author { get; set; }
        public int AuthorID { get; set; }

        public virtual Customer Borrower { get; set; }
        public int CustomerID { get; set; }

    }
}