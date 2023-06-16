
using System;
using System.IO;
using RMS;
using rms.DL;
using rms.UI;

namespace rms.BL
{
    public class Product
    {
        private string foodName = "";
        private int foodPrice;
        private int foodQuantity;
        public Product()
        {
            foodName = "No Name";
            foodPrice = 0;
            foodQuantity = 0;
        }

        public Product(string name, int price, int quantity)
        {
            foodName = name;
            foodPrice = price;
            foodQuantity = quantity;
        }

        public string getItemName()
        {
            return this.foodName;
        }
        public int getItemPrice()
        {
            return this.foodPrice;
        }
        public int getItemQuantity()
        {
            return this.foodQuantity;
        }
        public void setItemName(string foodName)
        {
            this.foodName = foodName;
        }
        public void setItemPrice(int foodPrice)
        {
            this.foodPrice = foodPrice;
        }
        public void setItemQuantity(int foodQuantity)
        {
            this.foodQuantity = foodQuantity;
        }


        public string toString()
        {
            return ($"{getItemName(),-20}{getItemPrice(),-15}" +
                                  $"{getItemQuantity(),-20}");
        }
    }
}