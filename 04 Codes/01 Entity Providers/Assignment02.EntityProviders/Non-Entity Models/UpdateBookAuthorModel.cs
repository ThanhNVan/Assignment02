using System.Collections.Generic;

namespace Assignment02.EntityProviders;

public class UpdateBookAuthorModel
{
	#region [ Properties ]
	public string BookId { get; set; }
	public IEnumerable<string> AuthorIds { get; set; }
	#endregion
}
