using BLayer.DTOS.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Managers.Categories
{
    public interface ICategoryManager
    {
        public List<CategoryReadDto> getAll();
        public CategoryReadDto getById(int id);
        public int add(CategoryAddDto categoryAddDto);
        public Boolean update(CategoryUpdateDto categoryUpdateDto);
        public void delete(int id);
    }
}
