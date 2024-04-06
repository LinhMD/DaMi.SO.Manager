using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DaMi.SO.Manager.Components;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ViewMode
{
    Detail,
    Create,
    Edit
}