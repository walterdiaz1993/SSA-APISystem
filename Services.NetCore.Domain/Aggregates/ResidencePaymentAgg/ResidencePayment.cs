﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.ResidencePaymentAgg
{
    [Table(nameof(ResidencePayment), Schema = SchemaTypes.Payment)]
    public class ResidencePayment : BaseEntity
    {
        [Required, StringLength(30)]
        public string PaymentNo { get; set; }
        public int ResidenceId { get; set; }
        public DateTime InitialPaymentDate { get; set; }
    }
}
