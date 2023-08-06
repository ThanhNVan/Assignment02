using Assignment02.SharedLibrary;
using System.ComponentModel.DataAnnotations;

namespace Assignment02.EntityProviders;

public class Role : BaseEntity
{
    #region [ Properties ]
    [DataType(DataType.Text)]
    public string Description { get; set; }
    #endregion
}
