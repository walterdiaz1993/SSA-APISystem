using Services.NetCore.Crosscutting.Resources;
using System.ComponentModel.DataAnnotations.Schema;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.User
{
    [Table(nameof(User), Schema = SchemaTypes.Security)]
    public class User : BaseEntity
    {
        public string UserName { get; set; }
    }
}
