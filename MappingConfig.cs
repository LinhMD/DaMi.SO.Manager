
using BlazorMinimalApis.Lib.Validation;
using CrudApiTemplate.CustomException;
using DaMi.SO.Manager.Endpoints.OrderDetails.DTO;
using DaMi.SO.Manager.Endpoints.OrderMasters.DTO;
using DaMi.SO.Manager.Endpoints.OrderStatuses.DTO;
using Mapster;

namespace DaMi.SO.Manager.Services;
public static class MappingConfig
{
    public static void ConfigMapping(this IServiceCollection services)
    {
        OrderMasterSimpleView.InitMapper();
        OrderMasterDetailView.InitMapper();
        OrderStatusSView.InitMapper();
        OrderDetailSimpleView.InitMapper();
        TypeAdapterConfig<ValidationError, ValidationMember>.NewConfig();
        TypeAdapterConfig<ValidationMember, ValidationError>.NewConfig();
    }
}