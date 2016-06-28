using System;

namespace IEJPApps.Services
{
    public interface ICookieService
    {
        string Language { get; set; }
        string Role { get; set; }
        string SessionId { get; }
        Guid EmployeeId { get; set; }
        void Clear();
    }
}