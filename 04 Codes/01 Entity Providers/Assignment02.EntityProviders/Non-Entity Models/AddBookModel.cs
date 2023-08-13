using System.Collections.Generic;

namespace Assignment02.EntityProviders;

public class AddBookModel
{
	#region [ Properties ]
	public Book Book { get; set; }
	public List<string> AuthorIds { get; set; }
	#endregion
}
