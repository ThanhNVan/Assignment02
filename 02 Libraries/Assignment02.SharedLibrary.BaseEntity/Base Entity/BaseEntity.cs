﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment02.SharedLibrary;

public abstract class BaseEntity
{
    #region [ Properties ]
    [Key]
    [Required]
    public string Id { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime LastUpdatedAt { get; set; }

    [Required]
    public bool IsDeleted{ get; set; }
	#endregion

	#region [ CTor ]
	public BaseEntity() {
		Id = Guid.NewGuid().ToString();
		CreatedAt = DateTime.UtcNow;
        LastUpdatedAt = DateTime.UtcNow;
		IsDeleted = false;
	}
	#endregion
}