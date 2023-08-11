using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02.EntityProviders;

public class UpdateBookAndAuthorModel
{
	#region [ Properties ]
	public Book Book { get; set; }
	public IEnumerable<Author> Authors { get; set; }
	#endregion
}
