// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EFConsole.Model
{
    [Table("CLIENT")]
    public partial class Client
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAMESURNAME")]
        [StringLength(150)]
        public string Namesurname { get; set; }
        [Column("BIRTHDATE", TypeName = "date")]
        public DateTime? Birthdate { get; set; }
        [Column("CITY")]
        [StringLength(100)]
        public string City { get; set; }
        [Column("TELNO")]
        [StringLength(50)]
        public string Telno { get; set; }
    }
}