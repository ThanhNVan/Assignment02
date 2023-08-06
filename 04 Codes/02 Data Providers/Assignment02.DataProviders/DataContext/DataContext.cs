namespace Assignment02.DataProviders;

public class DataContext
{
	#region [ CTor ]
	public DataContext(IAuthorDataProvider author) {
		this.Author = author;
	}
	#endregion
	#region [ Properties ]
	public IAuthorDataProvider Author { get; set; }	
	#endregion
}
