using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HotelReservationService
{
    class TravelAgency

    {
        // the travel agency threads are placing their order within this method

        static object lockobj = new object();
        static Random randamount = new Random();
        static Random randcardNo = new Random();
        static int numberOfRooms = 0;
    
        public static void agencyFunction()
        {
            try
            {
                while (true)
                {

                    Thread.Sleep(3000);
                    lock (lockobj)
                    {
                        if (HotelSupplier.roomPrice1 < HotelSupplier.oldRoomPrice1) // if there is a price drop then a certain range of room are booked.
                        {
                            numberOfRooms = randamount.Next(30, 50);
                        }
                        else
                        {
                            numberOfRooms = randamount.Next(20, 30);
                        }
                        int cardNumber = randcardNo.Next(5000, 7000); // uses a random functon to generate a creditcard number
                        OrderObject order = new OrderObject(Thread.CurrentThread.Name, cardNumber, numberOfRooms, DateTime.Now); //stores the order in the orderobject
                        string str = EncodeDecode.encode(order); 
                        Program.buffer1.SetCellOne(str); // stores the order in the multi cell buffer after encoding

                      //  MultiCellBuffer.SetCellOne(str);  
                      
                        Console.WriteLine("\n{0} sent an order of {1} rooms \nTime Stamp Of Order = {2}", Thread.CurrentThread.Name, numberOfRooms, DateTime.Now);
                        Thread.Sleep(500);
                    }
                    
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
        }

        public static void agencyFunction2()
        {
            try
            {
                while (true)
                {

                    Thread.Sleep(3000);
                    lock (lockobj)
                    {
                        if (HotelSupplier.roomPrice2 < HotelSupplier.oldRoomPrice2)
                        {
                            numberOfRooms = randamount.Next(30, 50);
                        }
                        else
                        {
                            numberOfRooms = randamount.Next(20, 30);
                        }

                        int cardNumber = randcardNo.Next(5000, 7000); // uses a random functon to generate a creditcard number
                        OrderObject order = new OrderObject(Thread.CurrentThread.Name, cardNumber, numberOfRooms, DateTime.Now);//stores the order in the orderobject
                        string str = EncodeDecode.encode(order);
                        Program.buffer1.SetCellOne(str); // stores the order in the multi cell buffer after encoding
                   
                      
                        //MultiCellBuffer.SetCellOne(str);
                        
                        Console.WriteLine("\n{0} sent an order of {1} rooms  \nTime Stamp Of Order = {2}", Thread.CurrentThread.Name, numberOfRooms, DateTime.Now);
                        Thread.Sleep(500);
                    }

                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
        }
        //event handler for the price cut event in hotel supplier 1
        public static void roomsOnOffer(int roomPrice)

        {
            
            try
            {
                Thread.Sleep(300);
                int oldRoomPrice = HotelSupplier.roomPrice1;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n----------------------------FLASH------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("{0} declares a price drop in room price from ${1} to ${2} ", Thread.CurrentThread.Name,oldRoomPrice, roomPrice);
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred in the event handler " + e.Message);
            }

        }

        //event handler for the price cut event in hotel supplier 2
        public static void roomsOnOffer2(int roomPrice)
        {
            Thread.Sleep(100);
            try
            {
                Thread.Sleep(300);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                int oldRoomPrice = HotelSupplier.roomPrice2;
                Console.WriteLine("\n----------------------------FLASH------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("{0} declares a price drop in room price from ${1} to ${2} ", Thread.CurrentThread.Name, oldRoomPrice, roomPrice);
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred in the event handler " + e.Message);
            }

        }
      
                        
        }
       /* public static void orderConfirmation(OrderObject orderObj)
        {

            try
            {
                Console.WriteLine("Time taken for processing in seconds : {0}" , (DateTime.Now - orderObj.creationTime).TotalSeconds);
                Console.WriteLine("-----------------------------------------\n");            
            }
            catch (Exception e)
            {
                Console.WriteLine("error order comfirm" + e.Message);
            }
        } */
    }

