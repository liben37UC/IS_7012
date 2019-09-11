using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CoreCrud.Models;

namespace CoreCrud.DAL
{
    public class ManuInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ManuContext>
    {
        protected override void Seed(ManuContext context)
        {
            var collectibles = new List<Collectible>
            {

            };

            collectibles.ForEach(s => context.Collectibles.Add(s));
            context.SaveChanges();
            var manufacturers = new List<Manufacturer>
            {
            };
            manufacturers.ForEach(s => context.Manufacturers.Add(s));
            context.SaveChanges();
        }
    }
}