using AdsOnline.Models.Data.Abstract;
using AdsOnline.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdsOnline.Models.Data.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AdsContext context) : base (context)
        {
                
        }
    }
}