using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.SecurityManagement
{
    public class RoleRequest: RequestBase
    {
        public RoleDto Role { get; set; }
    }
}
