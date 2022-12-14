using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Data;

namespace BudgetApp.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> AllCategories => context.Categories;
    }
}