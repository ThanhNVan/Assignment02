using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Assignment02.EntityProviders;

[Table(nameof(Author))]
[Index(nameof(Email), IsUnique = true)]
public class Author : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string FirstName { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }


    [DataType(DataType.Text)]
    public string? Address { get; set; }


    [DataType(DataType.Text)]
    public string? City { get; set; }


    [DataType(DataType.Text)]
    public string? State { get; set; }


    [DataType(DataType.PostalCode)]
    public string? Zip { get; set; }
    #endregion

    #region [ Virtual Entity FK Properties ]
    [JsonIgnore]
    [InverseProperty("Author")]
    public virtual ICollection<BookAuthor>? BookAuthor { get; set; }
    #endregion

    #region [ CTor ]
    public Author() {

    }
    #endregion

    public override string ToString() {
        return this.FirstName + " " + this.LastName; 
    }
}
