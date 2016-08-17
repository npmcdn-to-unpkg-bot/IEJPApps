using System;
using IEJPApps.Resources;

namespace IEJPApps.Models
{
    public partial class Period
    {
        public bool IsOpened
        {
            get
            {
                return OpenedDate.HasValue && (!ClosedDate.HasValue || ClosedDate.Value.Date >= DateTime.Now.Date);
            }
        }
        
        public bool IsUninitialized
        {
            get { return !OpenedDate.HasValue && !ClosedDate.HasValue; }
        }
        
        public string Status
        {
            get
            {
                if (IsUninitialized)
                    return Strings.Period_Status_UnInitialized;

                if (!IsOpened)
                    return Strings.Period_Status_Closed;

                if (IsOpened)
                    return Strings.Period_Status_Opened;

                return Strings.Period_Status_UnInitialized;
            }
        }
    }
}