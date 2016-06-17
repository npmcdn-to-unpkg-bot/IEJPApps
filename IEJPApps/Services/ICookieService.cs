namespace IEJPApps.Services
{
    public interface ICookieService
    {
        string Language { get; set; }
        string Role { get; set; }
        string SessionId { get; }
        void Clear();
    }
}