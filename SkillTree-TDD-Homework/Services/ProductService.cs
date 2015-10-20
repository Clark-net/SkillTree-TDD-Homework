using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkillTree_TDD_Homework.DataDaos;
using SkillTree_TDD_Homework.Models;

namespace SkillTree_TDD_Homework.Services
{
    class ProductService : IProductService
    {
        private IProductDataDao _dataDao;

        public ProductService(IProductDataDao dataDao)
        {
            this._dataDao = dataDao;
        }

        public int[] GetPropertyGroupSum(ProductProperty property, int size)
        {
            if (size <= 0 || !Enum.IsDefined(typeof(ProductProperty), property))
                return new int[] { };

            var products = this._dataDao.GetProducts();

            if (products == null || !products.Any())
                return new int[] { };

            IEnumerable<int> propertyValues;

            switch (property)
            {
                case ProductProperty.Id:
                    propertyValues = products.Select(p => p.Id);
                    break;
                case ProductProperty.Cost:
                    propertyValues = products.Select(p => p.Cost);
                    break;
                case ProductProperty.Revenue:
                    propertyValues = products.Select(p => p.Revenue);
                    break;
                case ProductProperty.SellPrice:
                    propertyValues = products.Select(p => p.SellPrice);
                    break;
                default:
                    return new int[] { };
            }

            return propertyValues.Select((p, i) => new { p, Index = i }).GroupBy(p => p.Index / size).Select(p => p.Select(s => s.p).Sum()).ToArray();
        }
    }
}
