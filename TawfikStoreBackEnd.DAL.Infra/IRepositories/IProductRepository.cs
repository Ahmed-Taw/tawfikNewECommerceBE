using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TawfikStoreBackEnd.Entities.Entities;
using TawfikStoreBackEnd.Entities.Helpers;

namespace TawfikStoreBackEnd.DAL.Infra.IRepositories
{
    interface IProductRepository
    {
        IEnumerable<Product> getProducts(string search);

        IEnumerable<Product> getProducts(ProductQueryData queryData);
        int GetTotalProductsCount(ProductQueryData queryData);

        Product getProduct(int id);

        void addProduct(Product product);

        void updateProduct(Product product);

        void deleteProduct(Product product);

        //IEnumerable<Photo> GetProductPhotos(int productId);

        //void AddPhoto(Product product, Photo photo);
        void save();
    }
}
