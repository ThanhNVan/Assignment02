using Assignment02.SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment02.EntityProviders;

public class BookAuthor : BaseEntity
{
	#region [ Properties ]
	[Required]
    [DataType(DataType.Text)]
    public string AuthorId { get; set; }

	[Required]
    [DataType(DataType.Text)]
    public string BookId { get; set; }

    [DataType(DataType.Text)]
    public string AuthorOrder { get; set; }

    [DataType(DataType.Text)]
    public string RoyalityPercentage { get; set; }
    #endregion

    #region [ Virtual FK Properties ]
    [JsonIgnore]
    [ForeignKey("BookAuthor_Author")]
    public Author? Author { get; set; }
    
    [JsonIgnore]
    [ForeignKey("BookAuthor_Book")]
    public Book? Book { get; set; }
    #endregion
}
