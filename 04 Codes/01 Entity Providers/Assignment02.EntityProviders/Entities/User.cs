using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Assignment02.EntityProviders;

[Table(nameof(User))]
[Index(nameof(Email), IsUnique = true)]
public class User : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string FirstName { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    public string MiddleName { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime HiredDate { get; set; }
    #endregion

    #region [ FK Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string RoleId { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string PublisherId { get; set; }
    #endregion

    #region [ Virtual Entity FK Properties ]
    [JsonIgnore]
    [NotMapped]
    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role? Role { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    [ForeignKey("PublisherId")]
    [InverseProperty("Users")]
    public virtual Publisher? Publisher { get; set; }
    #endregion

    #region [ CTor ]
    public User() {

    }
    #endregion
}
