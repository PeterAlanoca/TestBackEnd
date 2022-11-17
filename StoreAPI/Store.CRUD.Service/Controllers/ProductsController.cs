using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Request;
using Models.Response;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Store.CRUD.Service.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {

        private IProductLogic productLogic;

        public ProductsController(IProductLogic productLogic)
        {
            this.productLogic = productLogic;
        }

        [HttpGet]
        [Route("all")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<Response<ProductsResponse>> GetAll()
        {
            try
            {
                return await productLogic.GetAll();
            }
            catch (Exception e)
            {
                return Response<ProductsResponse>.Error(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<Response<ProductResponse>> Get(int id)
        {
            try
            {
                return await productLogic.Get(id);
            }
            catch (Exception e)
            {
                return Response<ProductResponse>.Error(e.Message);
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<Response<TransactionResponse>> Register(ProductRegisterRequest registerRequest)
        {
            try
            {
                return await productLogic.Register(registerRequest);
            }
            catch (Exception e)
            {
                return Response<TransactionResponse>.Error(e.Message);
            }
        }

        [HttpPatch]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<Response<TransactionResponse>> Update(Product product)
        {
            try
            {
                return await productLogic.Update(product);
            }
            catch (Exception e)
            {
                return Response<TransactionResponse>.Error(e.Message);
            }
        }

        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<Response<TransactionResponse>> Delete(int id)
        {
            try
            {
                return await productLogic.Delete(id);
            }
            catch (Exception e)
            {
                return Response<TransactionResponse>.Error(e.Message);
            }
        }
    }
}
