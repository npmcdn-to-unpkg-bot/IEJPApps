namespace IEJPApps.Services.Interfaces
{
    public interface ICookieService
    {
        string Language { get; set; }
        string Role { get; set; }
        void Save();
        void Load();
    }
}