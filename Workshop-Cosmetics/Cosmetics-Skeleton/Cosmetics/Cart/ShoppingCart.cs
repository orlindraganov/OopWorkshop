namespace Cosmetics.Cart
{
    using System;
    using System.Collections.Generic;

    using Common;
    using Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.ProductList = null;
        }

        public ShoppingCart(ICollection<IProduct> productList)
        {
            this.ProductList = productList;
        }

        public ICollection<IProduct> ProductList
        {
            get
            {
                return new List<IProduct>(this.productList);
            }
            set
            {
                productList = value;
            }
        }

        public void AddProduct(IProduct product)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(IProduct product)
        {
            throw new NotImplementedException();
        }

        public bool ContainsProduct(IProduct product)
        {
            throw new NotImplementedException();
        }

        public decimal TotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
