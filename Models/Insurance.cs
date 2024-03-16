using System;
using System.Collections.Generic;

namespace MediPlan.Models;

public partial class Insurance
{
    public int InsuranceId { get; set; }

    public string PolicyNumber { get; set; } = null!;

    public DateOnly ExpirationDate { get; set; }

    public string InsuranceCompany { get; set; } = null!;

    public virtual Patient InsuranceNavigation { get; set; } = null!;
}
