
using BlazorMinimalApis.Lib.Validation;
using CrudApiTemplate.CustomException;
using CrudApiTemplate.Model;
using DaMi.SO.Manager.Endpoints.OrderDetails.DTO;
using DaMi.SO.Manager.Endpoints.OrderMasters.DTO;
using DaMi.SO.Manager.Endpoints.OrderStatuses.DTO;
using Mapster;

namespace DaMi.SO.Manager.Services;
public static class MappingConfig
{
    public static void ConfigMapping(this IServiceCollection services)
    {

        TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);
        TypeAdapterConfig.GlobalSettings.RequireDestinationMemberSource = false;
        AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IDto).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            .ToList()
            .ForEach(x =>
            {
                try
                {
                    x.GetMethod("InitMapper")?.Invoke(null, null);
                }
                catch
                {
                }
            });
    }
}