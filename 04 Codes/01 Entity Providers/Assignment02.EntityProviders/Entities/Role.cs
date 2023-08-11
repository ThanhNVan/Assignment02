using Assignment02.SharedLibrary;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Assignment02.EntityProviders;

[Table(nameof(Role))]
public class Role : BaseEntity
{
    #region [ Properties ]
    [DataType(DataType.Text)]
    public string? Description { get; set; }
    #endregion

    #region [ Virtual Entity FK Properties ]
    [JsonIgnore]
    [InverseProperty("Role")]
    public virtual ICollection<User>? Users { get; set; }
    #endregion

    #region [ CTor ]
    public Role() {

    }
    #endregion
}
