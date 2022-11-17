using Models;
using Models.Request;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISaleLogic
    {
        Task<Response<BookingResponse>> Booking(BookingRequest bookingRequest);
        Task<Response<DeliveryResponse>> Delivery(DeliveryRequest deliveryRequest);
    }
}
