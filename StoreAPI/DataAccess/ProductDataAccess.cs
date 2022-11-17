using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Tools;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Request;
using Models.Response;

namespace DataAccess
{
	public class ProductDataAccess : IProductDataAccess
    {

        public string connectionString;

        public ProductDataAccess(IConfiguration configuration)
		{
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Response<ProductsResponse>> GetAll()
        {
            try
            {
                var storedProcedure = new StoredProcedure("PRODUCTS_GetAll");
                using var dataTable = await storedProcedure.Execute(connectionString);
                if (dataTable.Rows.Count > 0)
                {
                    var products = new List<Product>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        products.Add(new Product
                        {
                            Id = Convert.ToInt64(row["ID"]),
                            Name = Convert.ToString(row["NAME"]),
                            Code = Convert.ToString(row["CODE"]),
                            Currency = Convert.ToString(row["CURRENCY"]),
                            Quantity = Convert.ToInt16(row["QUANTITY"]),
                            UnitCost = Convert.ToDecimal(row["UNIT_COST"]),
                        });
                    }
                    var productsResponse = new ProductsResponse
                    {
                        Products = products
                    };
                    return Response<ProductsResponse>.Success(productsResponse);
                }
                else
                    return Response<ProductsResponse>.Error("No hay productos registrados.");
            }
            catch (Exception e)
            {
                return Response<ProductsResponse>.Error(e.Message);
            }
        }

        public async Task<Response<ProductResponse>> Get(int id)
        {
            try
            {
                var storedProcedure = new StoredProcedure("PRODUCTS_Get");
                storedProcedure.AddParameter("@ID", id);
                using var dataTable = await storedProcedure.Execute(connectionString);
                if (dataTable.Rows.Count > 0)
                {
                    var row = dataTable.Rows[0];

                    var productResponse = new ProductResponse
                    {
                        Product = new Product
                        {
                            Id = Convert.ToInt64(row["ID"]),
                            Name = Convert.ToString(row["NAME"]),
                            Code = Convert.ToString(row["CODE"]),
                            Currency = Convert.ToString(row["CURRENCY"]),
                            Quantity = Convert.ToInt16(row["QUANTITY"]),
                            UnitCost = Convert.ToDecimal(row["UNIT_COST"]),
                        }
                    };
                    return Response<ProductResponse>.Success(productResponse);
                }
                else
                    return Response<ProductResponse>.Error("El producto no se encuentra registrado.");
            }
            catch (Exception e)
            {
                return Response<ProductResponse>.Error(e.Message);
            }
        }

        public async Task<Response<TransactionResponse>> Register(ProductRegisterRequest registerRequest)
        {
            try
            {
                var storedProcedure = new StoredProcedure("PRODUCTS_Insert");
                storedProcedure.AddParameter("@NAME", registerRequest.Name);
                storedProcedure.AddParameter("@CODE", registerRequest.Code);
                storedProcedure.AddParameter("@QUANTITY", registerRequest.Quantity);
                storedProcedure.AddParameter("@UNIT_COST", registerRequest.UnitCost);
                using var dataTable = await storedProcedure.Execute(connectionString);
                if (dataTable.Rows.Count > 0)
                {
                    return Response<TransactionResponse>.Success(new TransactionResponse
                    {
                        Id = Convert.ToInt64(dataTable.Rows[0]["IDENTITY"]),
                        DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                }
                else
                    return Response<TransactionResponse>.Error("No se pudo realizar el registar el producto.");
            }
            catch (Exception e)
            {
                return Response<TransactionResponse>.Error(e.Message);
            }
        }

        public async Task<Response<TransactionResponse>> Update(Product product)
        {
            try
            {
                var storedProcedure = new StoredProcedure("PRODUCTS_Update");
                storedProcedure.AddParameter("@ID", product.Id);
                storedProcedure.AddParameter("@NAME", product.Name);
                storedProcedure.AddParameter("@CODE", product.Code);
                storedProcedure.AddParameter("@QUANTITY", product.Quantity);
                storedProcedure.AddParameter("@UNIT_COST", product.UnitCost);
                using var dataTable = await storedProcedure.Execute(connectionString);
                if (dataTable.Rows.Count > 0)
                {
                    var rowCount = Convert.ToInt16(dataTable.Rows[0]["ROW_COUNT"]);
                    if (rowCount > 0)
                    {
                        return Response<TransactionResponse>.Success(new TransactionResponse
                        {
                            Id = product.Id,
                            DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        });
                    }
                    else
                        return Response<TransactionResponse>.Error("No se pudo actualizar el producto.");
                }
                else
                    return Response<TransactionResponse>.Error("No se pudo actualizar el producto.");
            }
            catch (Exception e)
            {
                return Response<TransactionResponse>.Error(e.Message);
            }
        }

        public async Task<Response<TransactionResponse>> Delete(int id)
        {
            try
            {
                var storedProcedure = new StoredProcedure("PRODUCTS_Delete");
                storedProcedure.AddParameter("@ID", id);
                using var dataTable = await storedProcedure.Execute(connectionString);
                if (dataTable.Rows.Count > 0)
                {
                    var rowCount = Convert.ToInt16(dataTable.Rows[0]["ROW_COUNT"]);
                    if (rowCount > 0)
                    {
                        return Response<TransactionResponse>.Success(new TransactionResponse
                        {
                            Id = id,
                            DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        });
                    }
                    else
                        return Response<TransactionResponse>.Error("No se pudo a eliminar el producto.");
                }
                else
                    return Response<TransactionResponse>.Error("No se pudo a eliminar el producto.");
            }
            catch (Exception e)
            {
                return Response<TransactionResponse>.Error(e.Message);
            }
        }
    }
}



