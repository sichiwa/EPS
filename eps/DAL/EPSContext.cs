using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EPS.Models;

namespace EPS.DAL
{
    public class EPSContext:DbContext
    {
        public DbSet<EPSUSER> EPSUSERS { get; set; }
        public DbSet<EPSROLE> EPSROLES { get; set; }
        public DbSet<ROLEFUNCMAPPING> ROLEFUNCMAPPINGS { get; set; }
        public DbSet<ROLEAUTHORITYLIST> ROLEAUTHORITYLISTS { get; set; }
        public DbSet<CHECKCLASS> CHECKCLASSES { get; set; }
        public DbSet<CHECKSHIFT> CHECKSHIFTS { get; set; }
        public DbSet<FUNC> FUNCS { get; set; }
        public DbSet<SYSTEMLOG> SYSTEMLOG { get; set; }
        public DbSet<CHECKLIST> CHECKLISTS { get; set; }
        public DbSet<CHECKPROCESS> CHECKPROCESSES { get; set; }
        public DbSet<CHECKPROCESSDETAIL> CHECKPROCESSDETAILS { get; set; }
        public DbSet<CHECKTITLE> CHECKTITLES { get; set; }
        public DbSet<MAILSERVER> MAILSERVERS { get; set; }
        public DbSet<MAILTEMPLATE> MAILTEMPLATES { get; set; }
        public DbSet<REVIEWPROFILE> REVIEWPROFILES { get; set; }
    }
}