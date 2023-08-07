namespace Assignment02.HttpClientProviders;

public  class HttpClientContext
{
    #region [ CTor ]
    public HttpClientContext(IAuthorHttpClientProvider author,
                                IBookAuthorHttpClientProvider bookAuthor,
                                IBookHttpClientProvider book,
                                IPublisherHttpClientProvider publisher,
                                IRoleHttpClientProvider role,
                                IUserHttpClientProvider user) {
        Author = author;
        BookAuthor = bookAuthor;
        Book = book;
        Publisher = publisher;
        Role = role;
        User = user;
    }

    #endregion

    #region [ Properties ]
    public IAuthorHttpClientProvider Author { get; }
    public IBookAuthorHttpClientProvider BookAuthor { get; }
    public IBookHttpClientProvider Book { get; }
    public IPublisherHttpClientProvider Publisher { get; }
    public IRoleHttpClientProvider Role { get; }
    public IUserHttpClientProvider User { get; }
    #endregion
}
