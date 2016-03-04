using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportsStore.Models;
using SportsStore.Models.Repository;

namespace SportsStore
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        private int pageSize = 4;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<Products> GetProducts()
        {
            return repository.Products.OrderBy(p => p.ProductID).Skip((CurrentPage - 1)*pageSize).Take(pageSize);
        }

        protected int CurrentPage
        {
            get
            {
                int page;
                page = int.TryParse(Request.QueryString["page"], out page) ? page : 1;
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                return (int)
                Math.Ceiling((decimal)repository.Products.Count() / pageSize);
            }
        }
    }
}