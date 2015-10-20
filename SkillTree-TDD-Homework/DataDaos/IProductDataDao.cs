using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkillTree_TDD_Homework.Models;

namespace SkillTree_TDD_Homework.DataDaos
{
    internal interface IProductDataDao
    {
        IEnumerable<Product> GetProducts();
    }
}
