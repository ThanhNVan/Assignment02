using Assignment02.SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Assignment02.EntityProviders;

[Table(nameof(Book))]
public class Book : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string Title { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    public string Type { get; set; }
    
    [Required]
    public decimal Price { get; set; }

    [DataType(DataType.Text)]
    public string Advance { get; set; }

    [DataType(DataType.Text)]
    public string Royalty { get; set; }

    public decimal Sales { get; set; }

    [DataType(DataType.Text)]
    public string Note { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime PublishedDate { get; set; }
    #endregion

    #region [ FK Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string PublisherId { get; set; }
    #endregion

    #region [ Virtual FK Properties ]
    [JsonIgnore]
    [ForeignKey("Book_Publisher")]
    //[InverseProperty("Books")]
    public virtual Publisher? Publisher { get; set; } 
    
    [JsonIgnore]
    //[InverseProperty("Books")]
    public virtual ICollection<BookAuthor>? BookAuthor { get; set; }
    #endregion

    #region [ CTor ]
    public Book() {

    }
    #endregion
}
