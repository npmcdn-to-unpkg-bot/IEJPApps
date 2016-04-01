namespace IEJPApps.Models
{
    public partial class Employee
    {
        public string FullName
        {
            get { return FirstName + ", " + LastName; }
        }
    }
}