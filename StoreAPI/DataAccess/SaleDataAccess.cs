using DataAccess.Interfaces;
using DataAccess.Tools;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Request;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SaleDataAccess : ISaleDataAccess
    {

        public string connectionString;

        public SaleDataAccess(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Response<BookingResponse>> Booking(BookingRequest bookingRequest, decimal unitCost, decimal cost, decimal ivaCost, decimal costTotal)
        {
            try
            {
                var storedProcedure = new StoredProcedure("SALES_Insert");
                storedProcedure.AddParameter("@PRODUCT_ID", bookingRequest.ProductId);
                storedProcedure.AddParameter("@QUANTITY", bookingRequest.Quantity);
                storedProcedure.AddParameter("@IVA_COST", ivaCost);
                storedProcedure.AddParameter("@UNIT_COST", unitCost);
                storedProcedure.AddParameter("@COST", cost);
                storedProcedure.AddParameter("@TOTAL_COST", costTotal);
                using var dataTable = await storedProcedure.Execute(connectionString);
                if (dataTable.Rows.Count > 0)
                {
                    return Response<BookingResponse>.Success(new BookingResponse
                    {
                        Id = Convert.ToInt64(dataTable.Rows[0]["IDENTITY"]),
                        DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        State = "PENDIENTE"
                    });
                }
                else
                    return Response<BookingResponse>.Error("No se pudo reservar la venta.");
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
                var storedProcedure = new StoredProcedure("SALES_Update");
                storedProcedure.AddParameter("@ID", deliveryRequest.SaleId);
                using var dataTable = await storedProcedure.Execute(connectionString);
                if (dataTable.Rows.Count > 0)
                {
                    return Response<DeliveryResponse>.Success(new DeliveryResponse
                    {
                        Id = deliveryRequest.SaleId,
                        Amount = Convert.ToDecimal(dataTable.Rows[0]["COST"]),
                        TotalAmount = Convert.ToDecimal(dataTable.Rows[0]["TOTAL_COST"]),
                        Iva = Convert.ToDecimal(dataTable.Rows[0]["IVA_COST"]),
                        Quantity = Convert.ToInt16(dataTable.Rows[0]["QUANTITY"]),
                        State = Convert.ToString(dataTable.Rows[0]["STATE"]),
                        DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                }
                else
                    return Response<DeliveryResponse>.Error("No se pudo entregar el producto.");
            }
            catch (Exception e)
            {
                return Response<DeliveryResponse>.Error(e.Message);
            }
        }

    }
}
