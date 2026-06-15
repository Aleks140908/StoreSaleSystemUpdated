using Microsoft.EntityFrameworkCore;
using StoreSaleSystemUpdated.Application.Interfaces;
using StoreSaleSystemUpdated.Application.Services;
using StoreSaleSystemUpdated.ConsoleUI;
using StoreSaleSystemUpdated.Domain.Entities;
using StoreSaleSystemUpdated.Infrastructure.JSON;
using StoreSaleSystemUpdated.Infrastructure.SQL;
using System;

namespace StoreSaleSystemUpdated
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var storage = new FileStorage("Data/storage.json").Load();
            //storage.Save();

            //// Repositories
            //var productRepo = new FileProductRepository(storage);
            //var categoryRepo = new FileCategoryRepository(storage);
            //var customerRepo = new FileCustomerRepository(storage);
            //var saleRepo = new FileSaleRepository(storage);
            //var saleItemRepo = new FileSaleItemRepository(storage);
            //var promoRepo = new FilePromoRepository(storage);

            //// Services
            //var productService = new ProductService(productRepo, categoryRepo);
            //var categoryService = new CategoryService(categoryRepo, productRepo);
            //var promoService = new PromoService(promoRepo);
            //var saleService = new SaleService(productRepo, categoryRepo, customerRepo, saleRepo, saleItemRepo, promoRepo);

            //// UI
            //var ui = new SaleUI(productService, categoryService, promoService, saleService);

            //ui.Run();


           using var context = new StoreDbContext();

            // repositories
            IProductRepository productRepo = new SQLProductRepository(context);
            ICategoryRepository categoryRepo = new SQLCategoryRepository(context);
            ICustomerRepository customerRepo = new SQLCustomerRepository(context);
            ISaleRepository saleRepo = new SQLSaleRepository(context);
            ISaleItemRepository saleItemRepo = new SQLSaleItemRepository(context);
            IPromoCodeRepository promoRepo = new SQLPromoRepository(context);

            // Services
            var productService = new ProductService(productRepo, categoryRepo);
            var categoryService = new CategoryService(categoryRepo, productRepo);
            var promoService = new PromoService(promoRepo);
            var saleService = new SaleService(productRepo, categoryRepo, customerRepo, saleRepo, saleItemRepo, promoRepo);

            // UI
            var ui = new SaleUI(productService, categoryService, promoService, saleService);
            ui.Run();
            
        }
    }
}
