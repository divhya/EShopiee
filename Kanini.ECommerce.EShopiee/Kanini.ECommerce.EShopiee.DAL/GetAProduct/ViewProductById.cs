﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Kanini.ECommerce.EShopiee.Model;

namespace Kanini.ECommerce.EShopiee.DAL.GetAProduct
{
   public class ViewProductById:IViewProductById
   {
        IBaseRepo baseRepo;
        public ViewProductById(IBaseRepo repo)
        {
            baseRepo = repo;
        }
        public List<Product> GetProductById(Product prod)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(baseRepo.CreateParameter("@ProductId", prod.ProductId, DbType.Int32));
            List<Product> products = new List<Product>();
            Product product = null;
            var produc = baseRepo.GetData("[dbo].[ViewProducts]", CommandType.StoredProcedure,parameters.ToArray());
            foreach (DataRow data in produc.Tables[0].Rows)
            {
                product = new Product();
                product.Name = data[1].ToString();
                product.Rating = Convert.ToDecimal(data[2].ToString());
                product.ManufactureDate = Convert.ToDateTime(data[3].ToString());
                product.CartDescription = data[4].ToString();
                product.ShortDescription = data[5].ToString();
                product.Image = data[6].ToString();
                product.MRP = Convert.ToDecimal(data[7].ToString());
                product.DealPrice = Convert.ToDecimal(data[8].ToString());
                product.SavePrice = Convert.ToDecimal(data[9].ToString());
                product.NoOfStock = Convert.ToInt32(data[10].ToString());
                product.ProductIsActive = Convert.ToBoolean(data[11].ToString());
                products.Add(product);
            }
            return products;
        }
    
   }
}