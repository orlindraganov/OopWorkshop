namespace Cosmetics.Categories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using Contracts;

    public class Category : ICategory
    {
        #region Fields, Ctors, Props
        private const int CategoryMinLength = 2;
        private const int CategoryMaxLength = 15;

        private string name;
        private ICollection<IProduct> productsList;


        public Category(string name)
        {
            this.Name = name;
            productsList = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    CategoryMaxLength,
                    CategoryMinLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength,
                    this.GetType().Name + "name", CategoryMinLength, CategoryMaxLength));
                this.name = value;
            }
        }

        public ICollection<IProduct> ProductsList
        {
            get
            {
                return new List<IProduct>(this.productsList);
            }
            private set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(GlobalErrorMessages.ObjectCannotBeNull,
                    this.GetType().Name + "name"));
                this.productsList = value;
            }
        }
        #endregion

        public void AddCosmetics(IProduct cosmetics)
        {
            this.ProductsList.Add(cosmetics);
        }

        public string Print()
        {
            var output = new StringBuilder();
            var sortedList = from product in this.ProductsList
                             orderby product.GetType(),
                                     product.Brand,
                                     product.Name
                             select product;
            output.AppendFormat(" {0} category - {1} products/product in total", this.Name, this.ProductsList.Count);
            output.AppendLine();
            foreach (var product in sortedList)
            {
                output.Append(product.Print());
            }
            return output.ToString();

        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            this.ProductsList.Remove(cosmetics);
        }
    }
}
