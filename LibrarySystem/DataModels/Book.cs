using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DataModels;

[Table("Book")]
public partial class Book
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string? BookName { get; set; }

    [StringLength(20)]
    public string? Author { get; set; }

    public int? BorrowerId { get; set; }

    public DateOnly? DateOfIssue { get; set; }

    [StringLength(20)]
    public string? City { get; set; }

    [StringLength(20)]
    public string? Genere { get; set; }

    [StringLength(20)]
    public string? BorrowerName { get; set; }

    [ForeignKey("BorrowerId")]
    [InverseProperty("Books")]
    public virtual Borrower? Borrower { get; set; }
}
