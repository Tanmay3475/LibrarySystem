using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DataModels;

[Table("Borrower")]
public partial class Borrower
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string? City { get; set; }

    [InverseProperty("Borrower")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
