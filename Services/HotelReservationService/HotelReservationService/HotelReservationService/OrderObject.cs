using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationService
{
    class OrderObject
    {
        //this class stores the order details and it used to transfer data btween methods

        private string senderId;
        private int cardNo;
        private int amount;
        
        private DateTime CreationTime;

        public OrderObject(string senderId,int cardNo,int amount , DateTime creationTime)
        {
            this.senderId = senderId;
            this.cardNo = cardNo;
            this.amount = amount;
            
            this.CreationTime = creationTime;
           
        }
        public DateTime creationTime
        {
            get { return CreationTime; }
            set { CreationTime = value; }
        }   
        public string GetSenderId()
        {
            return senderId;
        }
        public void SetSenderId(string senderId)
        {
            this.senderId = senderId;
        }

      
        
        public int GetCardNo()
        {
            return cardNo;
        }
        public void SetCardNo(int cardNo)
        {
            this.cardNo = cardNo;       
        }
        public int GetAmount()
        {
            return amount;
        }
        public void SetAmount(int amount)
        {
            this.amount = amount;
        }
    }
}