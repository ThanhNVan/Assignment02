using Assignment02.SharedLibrary;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment02.EntityProviders;

[Table(nameof(Role))]
public class Role : BaseEntity
{
    #region [ Properties ]
    [DataType(DataType.Text)]
    public string Description { get; set; }
    #endregion
}
