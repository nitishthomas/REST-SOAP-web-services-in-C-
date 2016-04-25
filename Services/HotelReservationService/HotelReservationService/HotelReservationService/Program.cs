using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace HotelReservationService
{
    class Program
    {
        //instantiate the objects, create threads, and start threads

        public static MultiCellBuffer buffer1 = new MultiCellBuffer(); // creates an object of the multicell buffer
    
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n     ------------------HOTEL BLOCK BOOKING SYSTEM------------------");
            Console.WriteLine("     2 HOTEL SUPPLIERS     5 TRAVEL AGENCIES       BUFFER SIZE = 3");
            Console.WriteLine("     ---------------------------------------------------------------\n\n");
            Console.ResetColor();
            
            HotelSupplier supplier1 = new HotelSupplier();  // creates a supplier 1 object for the hotel supplier
            HotelSupplier supplier2 = new HotelSupplier();  // creates a supplier 2 object for the hotel supplier
            Console.SetBufferSize(100, 1000);
            try
            {
                Thread hotelSupplier = new Thread(new ThreadStart(supplier1.HotelSuppliers)); // creates a thread for one hotel supplier
                supplier1.priceCutEvent += new HotelSupplier.PriceCutEvent(TravelAgency.roomsOnOffer); // links the event creator in the hotel supplier and the event handler in the travel agency
                hotelSupplier.Name = "hotel supplier 1";

                Thread hotelSupplier2 = new Thread(new ThreadStart(supplier2.HotelSuppliers)); // creates a thread for one hotel supplier
                supplier2.priceCutEvent += new HotelSupplier.PriceCutEvent(TravelAgency.roomsOnOffer2); // links the event creator in the hotel supplier and the event handler in the travel agency
                hotelSupplier2.Name = "hotel supplier 2";
                hotelSupplier.Start();               
                hotelSupplier2.Start();                
                hotelSupplier.Join();
                hotelSupplier2.Join();
           
                
                

                 
            }
            catch (Exception e)
            {
                Console.WriteLine("error in main" + e.Message);
            }

        }
    }
}
