using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Models;
using Models.Dictionary;
using Models.Request;
using Models.Response;
using System;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SaleLogic : ISaleLogic
    {
        private IProductDataAccess productDataAccess;
        private ISaleDataAccess saleDataAccess;

        public SaleLogic(IProductDataAccess productDataAccess, ISaleDataAccess saleDataAccess)
        {
            this.productDataAccess = productDataAccess;
            this.saleDataAccess = saleDataAccess;
        }

        public async Task<Response<BookingResponse>> Booking(BookingRequest bookingRequest)
        {
            try
            {
                var productResult = await productDataAccess.Get(bookingRequest.ProductId);
                if (productResult.State == State.SUCCESS)
                {
                    var product = productResult.Data.Product;
                    if (product.Quantity >= bookingRequest.Quantity)
                    {
                        var unitCost = product.UnitCost;
                        var cost = unitCost * bookingRequest.Quantity;
                        var ivaCost = cost * Convert.ToDecimal(0.13);
                        var costTotal = ivaCost + cost;
                        return await saleDataAccess.Booking(bookingRequest, unitCost, cost, ivaCost, costTotal);
                    }
                    else
                    {
                        var message = product.Quantity == 0 ? "El producto se encuentra agotado." : "Solo nos quedan " + product.Quantity + " " + product.Name;
                        return Response<BookingResponse>.Error(message);
                    }
                }
                else
                    return Response<BookingResponse>.Error(productResult.Message);
            }
            catch (Exception e)
            {
                return Response<BookingResponse>.Error(e.Message);
            }
        }

        public async Task<Response<DeliveryResponse>> Delivery(DeliveryRequest deliveryRequest)
        {
            try
            {
                return await saleDataAccess.Delivery(deliveryRequest);
            }
            catch (Exception e)
            {
                return Response<DeliveryResponse>.Error(e.Message);
            }
        }
    }
}
