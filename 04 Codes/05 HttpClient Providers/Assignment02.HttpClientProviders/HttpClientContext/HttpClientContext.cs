namespace Assignment02.HttpClientProviders;

public  class HttpClientContext
{
    #region [ CTor ]
    public HttpClientContext(IAuthorHttpClientProvider author) {
        Author = author;
    }

    #endregion

    #region [ Properties ]
    public IAuthorHttpClientProvider Author { get; }
    #endregion
}
