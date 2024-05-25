﻿using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Domain.Aggregates;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Infraestructure.Mapping.Commons
{
    public class CommonsProfile : GenericProfileBase<BaseEntity, ResponseBase>
    {
        public CommonsProfile()
        {
        }
    }
}
