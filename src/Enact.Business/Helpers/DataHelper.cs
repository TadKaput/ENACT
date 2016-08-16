using System;

namespace Enact.Business.Helpers
{
    public static class DataHelper
    {
        public static string UniqueId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

  
    }
}
