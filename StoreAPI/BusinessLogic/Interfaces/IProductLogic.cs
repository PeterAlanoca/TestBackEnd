using System;
using Models;
using Models.Response;
using System.Threading.Tasks;
using Models.Request;

namespace BusinessLogic.Interfaces
{
	public interface IProductLogic
	{
        Task<Response<ProductsResponse>> GetAll();
        Task<Response<ProductResponse>> Get(int id);
        Task<Response<TransactionResponse>> Register(ProductRegisterRequest registerRequest);
        Task<Response<TransactionResponse>> Update(Product product);
        Task<Response<TransactionResponse>> Delete(int id);
    }
}

