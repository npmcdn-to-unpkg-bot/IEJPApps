using System;
using System.Web;
using Microsoft.Practices.Unity;

namespace IEJPApps.Infrastructure
{
    public class UnityPerSessionLifetimeManager : LifetimeManager
    {
        private readonly string _sessionKey = Guid.NewGuid().ToString();
        
        public override object GetValue()
        {
            return HttpContext.Current.Session[_sessionKey];
        }

        public override void RemoveValue()
        {
            HttpContext.Current.Session.Remove(_sessionKey);
        }

        public override void SetValue(object newValue)
        {
            System.Diagnostics.Trace.TraceInformation("UnityPerSessionLifetimeManager.SetValue({0}, {1})", _sessionKey, newValue);
            HttpContext.Current.Session[_sessionKey] = newValue;
        }
    }
}