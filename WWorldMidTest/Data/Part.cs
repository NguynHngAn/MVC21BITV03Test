using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WWorldMidTest.Data;

public partial class Part
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required!")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters long.")]
    public string Name { get; set; } = null!;

    [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]

    public double? Price { get; set; }
    [Required(ErrorMessage = "Quantity is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]

    public int Quantity { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Supplier is required!")]
    public int SupplierId { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
