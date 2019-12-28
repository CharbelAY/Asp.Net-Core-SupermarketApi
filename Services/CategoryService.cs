using Supermarket.API.Domain.Services;
using System.Collections.Generic;
using Supermarket.API.Domain.Models;
using System.Threading.Tasks;
using Supermarket.API.Domain.Repositories;


namespace Supermarket.API.Services{

    public class CategoryService:ICategoryService{

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository){
            _categoryRepository=categoryRepository;
        }

        public Task<IEnumerable<Category>> ListAsync(){
            return  _categoryRepository.ListAsync();
        }

    }
}