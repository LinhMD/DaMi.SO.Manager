using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Keyless]
public class CustomerBalance
{

    [DisplayName("Mã TK")]
    public string AccountID { get; set; } = string.Empty;
    public string Address1 { get; set; } = string.Empty;
    public decimal CnvAccumCredit { get; set; }
    public decimal CnvAccumDebit { get; set; }

    public decimal CnvBegCredit { get; set; }
    public decimal CnvBegDebit { get; set; }


    public decimal CnvCredit { get; set; }
    public decimal CnvDebit { get; set; }


    public decimal CnvEndCredit { get; set; }
    public decimal CnvEndDebit { get; set; }

    public string CustomerID { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string GrpDebitID { get; set; } = string.Empty;
    public string GrpDebitName { get; set; } = string.Empty;

    public decimal OrgAccumCredit { get; set; }
    public decimal OrgAccumDebit { get; set; }

    public decimal OrgBegCredit { get; set; }
    public decimal OrgBegDebit { get; set; }


    public decimal OrgCredit { get; set; }
    public decimal OrgDebit { get; set; }

    public decimal OrgEndCredit { get; set; }
    public decimal OrgEndDebit { get; set; }

    [DisplayName("STT")]
    public long RowNumber { get; set; }
    public string SubCompanyID { get; set; } = string.Empty;
    public string TaxCode { get; set; } = string.Empty;
    public int TranMonth { get; set; }
    public short TranYear { get; set; }

    public Guid? OrderID { get; set; }
    public string? OrderNo { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? OverDate { get; set; }
    public int NumDaysDebit { get; set; }
    public int NumDaysOverDate { get; set; }

}