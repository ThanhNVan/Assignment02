using Assignment02.SharedLibrary;
using System.ComponentModel.DataAnnotations;

namespace Assignment02.EntityProviders;

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
}
