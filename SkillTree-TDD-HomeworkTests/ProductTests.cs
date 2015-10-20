﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SkillTree_TDD_Homework.Models;
using SkillTree_TDD_Homework.DataDaos;
using SkillTree_TDD_Homework.Services;
using ExpectedObjects;

namespace SkillTree_TDD_HomeworkTests
{
    [TestClass]
    public class ProductTests
    {
        private static Product[] _products;

        [ClassInitialize]
        public static void ProductInitialize(TestContext testContext)
        {
            _products = new Product[] 
            {
                new Product() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 },
                new Product() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 },
                new Product() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 },
                new Product() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 },
                new Product() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 },
                new Product() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 },
                new Product() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 },
                new Product() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 },
                new Product() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 },
                new Product() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 },
                new Product() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 }
            };
        }

        [ClassCleanup]
        public static void ProductCleanup()
        {
            _products = null;
        }

        [TestMethod]
        public void GetPropertyGroupSum_3筆一組_取Cost總和Test()
        {
            //arrange
            var size = 3;
            var property = ProductProperty.Cost;

            var stubDataDao = Substitute.For<IProductDataDao>();
            stubDataDao.GetProducts().Returns(_products);
            var target = new ProductService(stubDataDao);
            var excepted = new int[] { 6, 15, 24, 21 };

            //act
            var actual = target.GetPropertyGroupSum(property, size);

            //assert
            excepted.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void GetPropertyGroupSum_4筆一組_取Revenue總和Test()
        {
            //arrange
            var size = 4;
            var property = ProductProperty.Revenue;

            var stubDataDao = Substitute.For<IProductDataDao>();
            stubDataDao.GetProducts().Returns(_products);
            var target = new ProductService(stubDataDao);
            var excepted = new int[] { 50, 66, 60 };

            //act
            var actual = target.GetPropertyGroupSum(property, size);

            //assert
            excepted.ToExpectedObject().ShouldEqual(actual);
        }
    }
}