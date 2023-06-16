using BLayer.DTOS.Categories;
using DALayer.Data.Models;
using DALayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Managers.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryManager(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public int add(CategoryAddDto categoryAddDto)
        {
            var category = new Category
            {
                Name = categoryAddDto.Name
            };
            return 5;
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryReadDto> getAll()
        {
            return unitOfWork.icategory.GetAll().Select(d => new CategoryReadDto
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
        }

        public CategoryReadDto getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(CategoryUpdateDto categoryUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
