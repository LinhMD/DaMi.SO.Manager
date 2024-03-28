using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaMi.SO.Manager.Services;
public static class MappingConfig
{
    public static void ConfigMapping(this IServiceCollection services)
    {
        OrderMasterSimpleView.InitMapper();
    }
}