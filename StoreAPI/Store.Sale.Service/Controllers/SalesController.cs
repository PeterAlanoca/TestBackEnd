using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Request;
using Models.Response;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Store.Sale.Service.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SalesController : Controller
    {

        private ISaleLogic saleLogic;

        public SalesController(ISaleLogic saleLogic)
        {
            this.saleLogic = saleLogic;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<Response<BookingResponse>> Booking(BookingRequest bookingRequest)
        {
            try
            {
                return await saleLogic.Booking(bookingRequest);
            }
            catch (Exception e)
            {
                return Response<BookingResponse>.Error(e.Message);
            }
        }

        [HttpPatch]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<Response<DeliveryResponse>> Delivery(DeliveryRequest deliveryRequest)
        {
            try
            {
                return await saleLogic.Delivery(deliveryRequest);
            }
            catch (Exception e)
            {
                return Response<DeliveryResponse>.Error(e.Message);
            }
        }
    }
}