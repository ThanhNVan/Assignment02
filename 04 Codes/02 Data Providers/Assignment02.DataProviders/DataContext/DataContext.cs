namespace Assignment02.DataProviders;

public class DataContext
{
	#region [ CTor ]
	public DataContext(IAuthorDataProvider author,
						IBookDataProvider book,
						IBookAuthorDataProvider bookAuthor,
						IPublisherDataProvider publisher,
						IRoleDataProvider role,
                        IUserDataProvider user) {
		this.Author = author;
        this.Book = book;
        this.BookAuthor = bookAuthor;
        this.Publisher = publisher;
        this.Role = role;
        this.User = user;
    }
	#endregion
	#region [ Properties ]
	public IAuthorDataProvider Author { get; set; }
    public IBookDataProvider Book { get; }
    public IBookAuthorDataProvider BookAuthor { get; }
    public IPublisherDataProvider Publisher { get; }
    public IRoleDataProvider Role { get; }
    public IUserDataProvider User { get; }
    #endregion
}
