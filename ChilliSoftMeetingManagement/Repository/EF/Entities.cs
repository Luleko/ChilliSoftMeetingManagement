using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChilliSoftMeetingManagement.EF
{
    public partial class Entities : DbContext
    {
        public Entities()
        {
        }

        public Entities(String connString)
          : base(connString)
        {
        }
    }
}