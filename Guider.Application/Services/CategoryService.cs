using Guider.Application.Interfaces;
using Guider.Application.Models.Requests;
using Guider.Domain.Core.Repositories;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepositoryProvider _provider;

        public CategoryService(IBaseRepositoryProvider provider)
        {
            _provider = provider;
        }

        public async Task CreateAsync(CreateCategoryReq req)
        {
            var category = new Category(req.Name, req.Description);

            await _provider.Repository<Category>().AddAsync(category);
        }
    }
}
