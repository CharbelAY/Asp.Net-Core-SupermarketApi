using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Supermarket.API.Domain.Services;
using System.Collections.Generic;
using Supermarket.API.Domain.Models;
using AutoMapper;
using Supermarket.API.Resources;
using Supermarket.API.Extensions;


namespace Supermarket.API.Controllers{

    [Route("/api/[Controller]")]
    public class CategoriesController:Controller{

        private readonly IMapper _mapper;

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoriesService, IMapper mapper){
            _categoryService = categoriesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync(){

            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category> , IEnumerable<CategoryResource>>(categories);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource){
            if(!ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<SaveCategoryResource,Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
		    return BadRequest(result.Message);

	        var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
	        return Ok(categoryResource);
        }
    }
}