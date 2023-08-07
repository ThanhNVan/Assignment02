namespace Assignment02.LogicProviders;

public class LogicContext
{
    #region [ CTor ]
    public LogicContext(IAuthorLogicProvider author,
                        IBookLogicProvider book,
                        IBookAuthorLogicProvider bookAuthor,
                        IPublisherLogicProvider publisher,
                        IRoleLogicProvider role,
                        IUserLogicProvider user) {
        Author = author;
        Book = book;
        BookAuthor = bookAuthor;
        Publisher = publisher;
        Role = role;
        User = user;
    }

    #endregion

    #region [ Properties ]
    public IAuthorLogicProvider Author { get; }
    public IBookLogicProvider Book { get; }
    public IBookAuthorLogicProvider BookAuthor { get; }
    public IPublisherLogicProvider Publisher { get; }
    public IRoleLogicProvider Role { get; }
    public IUserLogicProvider User { get; }

    #endregion
}
