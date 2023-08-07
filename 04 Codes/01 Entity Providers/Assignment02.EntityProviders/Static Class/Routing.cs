namespace Assignment02.EntityProviders;

public static class RoutingUrl
{
	#region [ Properties ]
	public static string BaseUrl = "https://localhost:7070";
	//";http://localhost:5059",

	public static string BaseClientName = "BaseClientName";
    #endregion
}

public static class EntityUrl {
    #region [ Properties ]
    public static string Author = "Api/V1/Author";

    public static string Book = "Api/V1/Book";

    public static string BookAuthor = "Api/V1/BookAuthor";

    public static string Publisher = "Api/V1/Publisher";

    public static string Role = "Api/V1/Role";

    public static string User = "Api/V1/User";
    #endregion
}
