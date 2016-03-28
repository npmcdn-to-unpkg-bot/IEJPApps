using System.Linq;

namespace IEJPApps.Models
{
    public partial class Project
    {
        public decimal TimeTotal
        {
            get
            {
                if (TimeTransactions == null) return 0;
                return TimeTransactions.Sum(x => x.Time);
            }
        }

        public decimal ExpenditureTotal
        {
            get
            {
                if (ExpenditureTransactions == null) return 0;
                return ExpenditureTransactions.Sum(x => x.Amount);
            }
        }        
    }
}