using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HotelReservationService
{
    class OrderProcessing
    {
        // the class processes the room booking order and sends the confirmation to the retailer 
        static int tax = 10 ;
        static int locationCharge = 20;
        static object lockObject = new object();

        public static void orderProcess(OrderObject orderObject,int currentRoomPrice)
        {
            Thread.Sleep(700);
            try
            {
                lock (lockObject)
                {
                    if (orderObject.GetCardNo() >= 5000 && orderObject.GetCardNo() <= 7000) // checks for a valid credit card number
                    {
                        int totalPrice = orderObject.GetAmount() * currentRoomPrice + tax + locationCharge; // calculates the total price including tax and location charge and return
                       
                        Console.WriteLine("\nOrder processed for {0}. \nTotal price for {1} rooms with tax and location charge  = ${2} ", orderObject.GetSenderId(), orderObject.GetAmount(), totalPrice);
                        Console.WriteLine("Time taken for processing in seconds : " + (DateTime.Now - orderObject.creationTime).TotalSeconds + "\n");
                       // TravelAgency.orderConfirmation(orderObject);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred in process order method " + e.Message);
            }
        }
    }
}
