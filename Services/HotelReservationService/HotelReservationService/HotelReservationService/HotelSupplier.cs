using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HotelReservationService
{
    /*This class acts as a server and processes the order placed by the travel agencies. It Calls the orderprocessing method.
         An event Handler is called from the travel agency class for when a price cut occurs*/
    class HotelSupplier
    {
        public delegate void PriceCutEvent(int price); //initializing the delegate
        public event PriceCutEvent priceCutEvent;    //initializing the event for when drop in room price occurs
        static object lockObject = new object();
        public static int roomPrice1 = 150;
        public static int roomPrice2 = 150;
        public static int oldRoomPrice1 = 150;
        public static int oldRoomPrice2 = 150;
        static int counter = 0;
        static object obj = new object();

        public void HotelSuppliers()
        {
            Console.WriteLine("{0}  --- current room price $150 \n ---------------------------------", Thread.CurrentThread.Name);
            if (Thread.CurrentThread.Name == "hotel supplier 1")
            {
                // creates 5 travel agency threads
                Thread[] agencyThread = new Thread[5];
                for (int i = 0; i < 5; i++)
                {
                    agencyThread[i] = new Thread(new ThreadStart(TravelAgency.agencyFunction));
                    agencyThread[i].Name = "agency " + (i + 1).ToString();
                    agencyThread[i].Start();

                }
                try
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        lock (lockObject)
                        {
                            if (counter >= 20)
                            {
                             
                                break;
                            }
                            // gets the order object from the multicellbuffer and decodes it
                            OrderObject orderObject = EncodeDecode.decode(Program.buffer1.GetCellOne());

                            //  Console.WriteLine("{0}-----------", Thread.CurrentThread.Name);
                            int newRoomPrice1 = PricingModel.calculatePrice(roomPrice1); // calls the pricing model to generate a new price
                            PriceChange(newRoomPrice1); // checks the new room price using the price change function
                          //  Console.WriteLine("reciept from {0}", Thread.CurrentThread.Name);
                            Thread processingThread = new Thread(() => OrderProcessing.orderProcess(orderObject, roomPrice1)); // creates the order processing threads
                            processingThread.Start();
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Error in hotel supplier " + e.Message);
                }
            }
            else
            {
                // creates 5 travel agency threads
                Thread[] agencyThread = new Thread[5];
                for (int i = 0; i < 5; i++)
                {
                    agencyThread[i] = new Thread(new ThreadStart(TravelAgency.agencyFunction2));
                    agencyThread[i].Name = "agency " + (i + 1).ToString();
                    agencyThread[i].Start();

                }


                try
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        lock (lockObject)
                        {
                            if (counter >= 20)
                            {
                                Thread.Sleep(4500);
                                Console.WriteLine("------------EXCEEDED MAXIMUM ALLOWED PRICE CUTS------------- ");
                                break;
                            }
                            // gets the order object from the multicellbuffer and decodes it
                            OrderObject orderObject = EncodeDecode.decode(Program.buffer1.GetCellOne());

                            //  Console.WriteLine("{0}-----------", Thread.CurrentThread.Name);
                            int newRoomPrice2 = PricingModel.calculatePrice(roomPrice2); // calls the pricing model to generate a new price
                            PriceChange2(newRoomPrice2); // checks the new room price using the price change function 
                          //  Console.WriteLine("reciept from {0}", Thread.CurrentThread.Name);
                            Thread processingThread = new Thread(() => OrderProcessing.orderProcess(orderObject, roomPrice2)); // creates the order processing threads
                            processingThread.Start();
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Error in hotel supplier " + e.Message);
                }
            }
           
        }

        public void PriceChange(int newRoomPrice1)  // changes the price of the room if the new price is lower that the current price
        {
            if (newRoomPrice1 < roomPrice1)
            {
                counter++;
                priceCutEvent(newRoomPrice1); //generates an event when a price cut occurs
                oldRoomPrice1 = roomPrice1;
                roomPrice1 = newRoomPrice1;
            }
        }
        public void PriceChange2(int newRoomPrice2)  // changes the price of the room if the new price is lower that the current price
        {
            if (newRoomPrice2 < roomPrice2)
            {
                counter++;
                priceCutEvent(newRoomPrice2); //generates an event when a price cut occurs
                oldRoomPrice2 = roomPrice2;
                roomPrice2 = newRoomPrice2;
            }
        }
    }
}
