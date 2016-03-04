using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models.Repository
{
    public class Repository
    {
        private SportsStoreEntities context = new SportsStoreEntities();
        public IEnumerable<Products> Products
        {
            get { return context.Products; }
        }
    }
}