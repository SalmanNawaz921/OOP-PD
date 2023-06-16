namespace rms.BL
{
    public class Customer
    {

        private string customerName = "";
        private int customerId;
        private int customerQuantity;
        private int totalBill;
        private int leftQuantity;

        private List<Product> ordersList = new List<Product>();

        public List<Product> getOrderList()
        {
            return ordersList;
        }

        public void setOrderList(List<Product> ordersList)
        {
            this.ordersList = ordersList;
        }
        public void AddInOrderList(Product order)
        {
            ordersList.Add(order);
        }
        public void UpdateOrder(string orderToUpdate, int newQuantity, int newPrice)
        {
            Product order = getOrderList().Find(o => o.getItemName() == orderToUpdate);
            if (order != null)
            {
                int index = ordersList.IndexOf(order);
                order.setItemName(orderToUpdate);
                order.setItemQuantity(newQuantity);
                order.setItemPrice(newPrice);
                string name = order.getItemName();
                int quantity = order.getItemQuantity();
                int price = order.getItemPrice();
                ordersList.Insert(index, new Product(name, quantity, price));
                Console.WriteLine("Order '{0}' updated successfully!", orderToUpdate);
            }
            else
            {
                Console.WriteLine("Error: Order '{0}' not found for the customer.", orderToUpdate);
            }
        }

        public string getAllOrders()
        {
            string orderName = "";
            if (ordersList != null)
            {
                for (int i = 0; i < ordersList.Count; i++)
                {
                    if (i < ordersList.Count - 1)
                    {

                        orderName = orderName + ordersList[i].getItemName() + ",";
                    }
                    else
                    {
                        orderName = orderName + ordersList[i].getItemName();
                    }
                }
            }
            return orderName;
        }

        public Customer()
        {
            customerName = "No Name";
            this.ordersList = null;
            customerId = 0;
            customerQuantity = 0;
            totalBill = 0;
            leftQuantity = 0;
        }
        public Customer(string name, int id, List<Product> orderList, int quantity, int bill, int left)
        {
            customerName = name;
            this.ordersList = orderList;
            customerId = id;
            customerQuantity = quantity;
            totalBill = bill;
            leftQuantity = left;
        }
        public Customer(string name, int id, List<Product> orderList, int quantity, int bill)
        {
            customerName = name;
            this.ordersList = orderList;
            customerId = id;
            customerQuantity = quantity;
            totalBill = bill;
        }

        public string getCustomerName()
        {
            return this.customerName;
        }
        public int getCustomerID()
        {
            return this.customerId;
        }
        public int getCustomerQuantity()
        {
            return this.customerQuantity;
        }
        public int getCustomerBill()
        {
            return this.totalBill;
        }
        public int getLeftQuantity()
        {
            return this.leftQuantity;
        }
        public void setCustomerName(string customerName)
        {
            this.customerName = customerName;
        }

        public void setCustomerID(int customerId)
        {
            this.customerId = customerId;
        }
        public void setCustomerQuantity(int customerQuantity)
        {
            this.customerQuantity = customerQuantity;
        }
        public void setCustomerBill(int totalBill)
        {
            this.totalBill = totalBill;
        }
        public void setLeftQuantity(int leftQuantity)
        {
            this.leftQuantity = leftQuantity;
        }

        public new string toString()
        {

            return $"{getCustomerName(),-20}{getCustomerID(),-20}{getAllOrders(),-20}{getCustomerQuantity(),-20}{getCustomerBill(),-20}";

        }
    }
}