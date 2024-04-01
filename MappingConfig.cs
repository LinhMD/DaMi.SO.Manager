using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMinimalApis.Lib.Validation;
using CrudApiTemplate.CustomException;
using DaMi.SO.Manager.Endpoints.OrderMasters.DTO;
using Mapster;

namespace DaMi.SO.Manager.Services;
public static class MappingConfig
{
    public static void ConfigMapping(this IServiceCollection services)
    {
        OrderMasterSimpleView.InitMapper();
        TypeAdapterConfig<ValidationError, ValidationMember>.NewConfig();
        TypeAdapterConfig<ValidationMember, ValidationError>.NewConfig();
    }
}