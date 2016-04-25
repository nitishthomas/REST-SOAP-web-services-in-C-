using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationService
{
    //This class is used to encode or decode the message
    class EncodeDecode
    {
        static object encodeLock = new object();
        static object decodelock = new object();

        public static String encode(OrderObject orderObject) // encodes the message and sends it back to the user
        
        {
            try
            {
                lock (encodeLock)
                {
                    byte[] encodebyte ;
                    string order = orderObject.GetSenderId().ToString() + "#" + orderObject.GetCardNo().ToString() + "#" + orderObject.GetAmount().ToString() + "#" + orderObject.creationTime;
                    encodebyte = ASCIIEncoding.ASCII.GetBytes(order);
                    return Convert.ToBase64String(encodebyte);
                }
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public static OrderObject decode(string str) //decodes the received string 
        {
            try
            {
                lock (decodelock)
                {
                    byte[] encodedbyte = Convert.FromBase64String(str);
                    string[] decodedbyte = ASCIIEncoding.ASCII.GetString(encodedbyte).Split('#');
                    return new OrderObject(decodedbyte[0], Convert.ToInt32(decodedbyte[1]), Convert.ToInt32(decodedbyte[2]),Convert.ToDateTime(decodedbyte[3]));
                }
            }
            catch (Exception e)
            {
                return new OrderObject(string.Empty, 0, 0,DateTime.Now);
            }
        }

    }
} 
    