using BLayer.DTOS.Categories;
using BLayer.DTOS.Products;
using DALayer.Data.Models;
using DALayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Managers.Products
{
    public class ProductManager:IProductManager
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductManager(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        public int add(ProductAddDto productAddDto)
        {
            var product = new Product {
                name = productAddDto.name ,
                description = productAddDto.description ,
                imgUrl = productAddDto.imgUrl ,
                price =productAddDto.price ,
                quantity = productAddDto.quantity ,
                CategoryId = productAddDto.CategoryId ,
                BrandId = productAddDto.BrandId 

                };
            unitOfWork.iproduct.add(product);
            unitOfWork.SaveChanges();
            return product.Id;
        }

        public void deleteById(int id)
        {
            var product = unitOfWork.iproduct.GetById(id);
            if (product == null)
            {
                return;
            }
            unitOfWork.iproduct.remove(id);
            unitOfWork.SaveChanges();
        }

        public List<ProductReadDto> getAll()
        {
            var products = unitOfWork.iproduct.GetAll();
            return products.Select(d => new ProductReadDto
            {
                id = d.Id,
                name = d.name,
                description = d.description,
                imgUrl = d.imgUrl ,
                price = d.price ,
                catId = d.CategoryId 
            }).ToList();
        }

        public ProductReadDto? getById(int id)
        {
            var product = unitOfWork.iproduct.GetById(id);
            if (product == null)
            {
                return null;
            }
            return new ProductReadDto
            {
                id = product.Id,
                name = product.name,
               description = product.description,
               imgUrl = product.imgUrl ,
               price = product.price
            };
        }

        public List<ProductReadDto> getPrdsByCatId(int catId)
        {
            return unitOfWork.iproduct.getProductsByCatId(catId).Select(d => new ProductReadDto
            {
                id=d.Id ,
                name = d.name,
                description = d.description,
                imgUrl = d.imgUrl,
                price = d.price
            }).ToList();
        }

        public ProductWithCategory? getPrdWithCat(int id)
        {
            var product = unitOfWork.iproduct.getPrdByCategoryObject(id);
            if (product != null)
            {
                return new ProductWithCategory
                {
                    id = product.Id,
                    name = product.name,
                    description = product.description,
                    imgUrl = product.imgUrl,
                    price = product.price,
                    catId = product.CategoryId,
                    category = new CategoryReadDto
                    {
                        Id = product.Category.Id ,
                        Name = product.Category.Name 
                    }
                };

            }
            return null;
        }

        public bool update(ProductUpdateDto productUpdateDto)
        {
            var product = unitOfWork.iproduct.GetById(productUpdateDto.Id);
            if (product == null)
            {
                return false;
            }
            product.name = productUpdateDto.name;
            product.price = productUpdateDto.price;
            product.quantity = productUpdateDto.quantity;
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
