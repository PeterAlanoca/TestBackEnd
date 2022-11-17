using System;
using Models;
using System.Threading.Tasks;
using Models.Response;
using Models.Request;

namespace DataAccess.Interfaces
{
	public interface IProductDataAccess
	{
        Task<Response<ProductsResponse>> GetAll();
        Task<Response<ProductResponse>> Get(int id);
        Task<Response<TransactionResponse>> Register(ProductRegisterRequest registerRequest);
        Task<Response<TransactionResponse>> Update(Product product);
        Task<Response<TransactionResponse>> Delete(int id);
    }
}

