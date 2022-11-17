using Models;
using Models.Request;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ISaleDataAccess
    {
        Task<Response<BookingResponse>> Booking(BookingRequest bookingRequest, decimal unitCost, decimal cost, decimal ivaCost, decimal costTotal);
        Task<Response<DeliveryResponse>> Delivery(DeliveryRequest deliveryRequest);
    }
}
