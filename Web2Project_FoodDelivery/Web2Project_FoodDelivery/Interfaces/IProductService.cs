using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;

namespace Web2Project_FoodDelivery.Interfaces
{
    public interface IProductService
    {
        bool DeleteProduct(long productId);
        bool UpdateProduct(ProductDto updateProduct);
        ProductDto FindById(long productId);
        List<ProductDto> RetreveProducts();
    }
}
