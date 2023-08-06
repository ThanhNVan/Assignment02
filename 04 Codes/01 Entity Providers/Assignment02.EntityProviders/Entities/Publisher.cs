using Assignment02.SharedLibrary;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Assignment02.EntityProviders;

[Table(nameof(Publisher))]
public class Publisher : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Address { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string City { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string State { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Country { get; set; }
    #endregion

    #region [ Virtual Properties ]
    [JsonIgnore]
    public virtual ICollection<User>? Users { get; set; }

    [JsonIgnore]
    public virtual ICollection<Book>? Books{ get; set; }
    #endregion
}
