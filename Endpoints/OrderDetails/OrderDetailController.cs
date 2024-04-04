using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Endpoints.OrderDetails.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DaMi.SO.Manager.Endpoints.OrderDetails;

[ApiController]
[Route("[controller]")]
public class OrderDetailController : ControllerBase
{

}
public class OrderDetailModifyModel
{
    public IEnumerable<OrderDetailSimpleView> OrderDetails { get; set; } = [];

    public Dictionary<string, ViwItem> Items { get; set; } = [];

    public IEnumerable<ViwItemType> ItemTypes { get; set; } = [];

    public IEnumerable<TaxCode> TaxCodes { get; set; } = [];
}