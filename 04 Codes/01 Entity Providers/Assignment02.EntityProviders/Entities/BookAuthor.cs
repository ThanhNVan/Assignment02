﻿using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Assignment02.EntityProviders;

[Table(nameof(BookAuthor))]
[Index(nameof(BookId), nameof(AuthorId), IsUnique = true)]
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
    public string? AuthorOrder { get; set; }

    [DataType(DataType.Text)]
    public string? RoyalityPercentage { get; set; }
    #endregion

    #region [ Virtual FK Properties ]
    [JsonIgnore]
    [NotMapped]
    [ForeignKey("AuthorId")]
    [InverseProperty("BookAuthor")]
    public Author? Author { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    [ForeignKey("BookId")]
    [InverseProperty("BookAuthor")]
    public Book? Book { get; set; }
    #endregion

    #region [ CTor ]
    public BookAuthor() {

    }
    #endregion
}
