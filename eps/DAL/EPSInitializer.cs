using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPS.Models;

namespace EPS.DAL
{
    public class EPSInitializer: DropCreateDatabaseIfModelChanges<EPSContext>
    {
        protected override void Seed(EPSContext context)
        {
            base.Seed(context);
            

            
        }
    }
}