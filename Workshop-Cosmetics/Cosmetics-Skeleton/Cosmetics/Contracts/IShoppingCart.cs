namespace Cosmetics.Contracts
{
    using System.Collections.Generic;

    public interface IShoppingCart
    {
        ICollection<IProduct> ProductList { get; }

        void AddProduct(IProduct product);

        void RemoveProduct(IProduct product);

        decimal TotalPrice();
    }
}
