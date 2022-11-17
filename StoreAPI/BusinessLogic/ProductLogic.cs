using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Models;
using Models.Response;
using BusinessLogic.Interfaces;
using Models.Request;

namespace BusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        private IProductDataAccess dataAccess;

        public ProductLogic(IProductDataAccess dataAccess)
		{
            this.dataAccess = dataAccess;
        }

        public async Task<Response<ProductsResponse>> GetAll()
        {
            try
            {
                return await dataAccess.GetAll();
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
                return await dataAccess.Get(id);
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
                return await dataAccess.Register(registerRequest);
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
                return await dataAccess.Update(product);
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
                return await dataAccess.Delete(id);
            }
            catch (Exception e)
            {
                return Response<TransactionResponse>.Error(e.Message);
            }
        }
    }
}

