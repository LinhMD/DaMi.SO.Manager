using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DaMi.SO.Manager
{
    public static class Helper
    {
        public static T? GetAttribute<T>(this PropertyInfo property) where T : Attribute
        {
            return property.GetCustomAttribute<T>();
        }

        public static string? GetDisplayName(this PropertyInfo property)
        {
            return property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
        }

        public static void Dump(this object? o, [CallerArgumentExpression("o")] string? name = "")
        {
            Console.WriteLine($"{name}: {o}");
        }
    }
}