using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Supermarket.API.Domain.Services;
using System.Collections.Generic;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Controllers{

    [Route("/api/[Controller]")]
    public class CategoriesController:Controller{

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoriesService){
            _categoryService = categoriesService;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync(){

            var categories = await _categoryService.ListAsync();
            return categories;
        }
    }
}