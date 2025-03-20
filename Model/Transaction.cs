﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaDeRecarga.Model
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdUser")]
        public int IdUser { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Type { get; set; } // "Recarga" ou "Débido"

        [MaxLength(255)]
        public string Description { get; set; }

        public DateTime TransactionDate { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}
