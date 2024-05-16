using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.NetCore.Domain.Core
{
    public class BaseEntity
    {
        [NotMapped]
        public const int longVarcharLength = 200;
        [NotMapped]
        public const int shortVarcharLength = 50;

        [NotMapped]
        public const string standardDecimal = "decimal(18,2)";

        public int Id { get; set; }
        public int UId { get; set; }

        public DateTime? TransactionDate { get; set; }
        public DateTime? CreationDate { get; set; }

        [StringLength(shortVarcharLength)]
        public string ModifiedBy { get; set; }

        public bool IsActive { get; set; } = true;


        public BaseEntity()
        {
        }

        public BaseEntity(string modifiedBy, string transactionType)
        {
            ModifiedBy = modifiedBy;
        }

        [NotMapped]
        protected string _stringProperty;

        [NotMapped]
        public string StringProperty
        {
            get => _stringProperty ?? string.Empty; // Return empty string if null
            set => _stringProperty = value;
        }
    }
}