using BLayer.DTOS.Products;
using DALayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Managers.Products
{
    public interface IProductManager
    {
        public List<ProductReadDto> getAll();
        public List<ProductReadDto> getPrdsByCatId(int catId);
        public ProductReadDto? getById(int id);
        public int add(ProductAddDto productAddDto);
        public Boolean update(ProductUpdateDto productUpdateDto);
        public void deleteById(int id);

        public ProductWithCategory getPrdWithCat(int id);

    }
}
