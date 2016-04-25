using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HotelReservationService
{
    class MultiCellBuffer
    {
        const Int32 bufferSize = 2;
        static string[] bufferCell = new string[bufferSize]; // buffer of size 3
        static Int32 write = -1;
        static Int32 read = -1;
        static object objectLock = new object();
        static Semaphore fullSema = new Semaphore(2, 2); //buffer size < no. of agencies
        static Semaphore emptySema = new Semaphore(0, 2);
      

        public void SetCellOne(string str) //sets buffer cells in sequential order
        {
            try{
                fullSema.WaitOne();
                lock (objectLock)
                {
                 write = (write + 1) % bufferSize;
                 bufferCell[write] = str;         

                }
                emptySema.Release();
            }
            catch (Exception e)
            {                        
           }
        }

        public string GetCellOne()   //reads buffer cells in sequential order
        {
            string str = string.Empty;
            try
            {
                emptySema.WaitOne();
                lock (objectLock)
                {
                    read = (read+1) % bufferSize;
                    str = bufferCell[read];
                }
                fullSema.Release();
                return str;
            }
            catch(Exception e)
            {
                return string.Empty;
            }
        }                
    }
}
