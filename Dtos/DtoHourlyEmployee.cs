using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class DtoHourlyEmployee: DtoEmployee
    {
        public override double AnnualSalary { get { return 120 * HourlySalary * 12; } }
    }
}
