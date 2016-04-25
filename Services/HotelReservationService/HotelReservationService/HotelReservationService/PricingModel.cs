using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationService
{
    class PricingModel
    {
        // this class uses a fixed set of values to either increase or decrease the room price and returns

        static Random changeInPrice = new Random();
        static int[] prices = {-4, 1,-3, 5, -5, -3, 6, 4, -1, 5, -3, 2, -4, 2, 1, 5, -3, -1, -3, 2,-5, 2, 3,-1,-2,-3,-4,-5,-5,-5,-4,5,-5,-5,-5};
        static int count = 1 ;

        public static int calculatePrice(int roomPrice)
        {
            try
            {
               return roomPrice + prices[count++];
                //return changeInPrice.Next(100, 200);
            }
            catch (Exception e)
            {
                Console.WriteLine("error " + e);
                return roomPrice;
            }
        }

    }
}
