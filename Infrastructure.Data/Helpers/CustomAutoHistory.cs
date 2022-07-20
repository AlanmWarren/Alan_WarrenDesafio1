using EntityFrameworkCore.AutoHistory;

namespace Infrastructure.Data.Helpers
{
    public class CustomAutoHistory : AutoHistory
    {
        public string CustomField { get; set; }
    }
}
