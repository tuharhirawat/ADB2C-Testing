using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyWebApplicationDemo.Models
{
    [Index("Email", Name = "UQ__Users__A9D10534B795F0FB", IsUnique = true)]
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string FullName { get; set; } = null!;
        [StringLength(100)]
        public string Email { get; set; } = null!;
        [StringLength(255)]
        public string PasswordHash { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
    }
}
