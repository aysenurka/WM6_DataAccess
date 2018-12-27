using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlisverisSepeti.ViewModels;

namespace AlisverisSepeti.BLL
{
    public class OrderBusiness
    {
        public int MakeOrder(CartViewModel cartViewModel)
        {
            NorthwindSabahEntities db = new NorthwindSabahEntities();
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var order = new Order()
                    {
                        CustomerID = cartViewModel.CustomerID,
                        EmployeeID = cartViewModel.EmployeeID,
                        ShipVia = cartViewModel.ShipVia,
                        Freight = cartViewModel.Freight,
                        ShipAddress = cartViewModel.Address,
                        RequiredDate = cartViewModel.RequiredDate.Date,
                        OrderDate = cartViewModel.OrderDate
                    };
                    db.Orders.Add(order);
                    db.SaveChanges();

                    foreach (var item in cartViewModel.CartModel)
                    {
                        if(item.ProductID==1)
                            throw  new Exception("Bir hata olustu");
                        db.Order_Details.Add(new Order_Detail()
                        {
                            OrderID = order.OrderID,
                            ProductID = item.ProductID,
                            UnitPrice = item.UnitPrice,
                            Quantity = item.Quantity,
                            Discount = item.Discount
                        });
                    }

                    db.SaveChanges();
                    tran.Commit();
                    return order.OrderID;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }
    }
}
