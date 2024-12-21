using Microsoft.Extensions.Configuration;

namespace MySandboxApp.Dal.Options
{
    public class DbOptions
    {
        [ConfigurationKeyName("DefaultConnection")]
        public string DefaultConnection { get; set; }
    }
}
