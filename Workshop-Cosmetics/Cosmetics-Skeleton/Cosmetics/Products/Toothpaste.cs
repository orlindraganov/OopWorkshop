namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Common;
    using Contracts;

    class Toothpaste : Product, IProduct, IToothpaste
    {
        #region Fields, Ctors, Props
        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients) : base(name, brand, price, gender)
        {
            this.Ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(GlobalErrorMessages.ObjectCannotBeNull, this.GetType().Name + " ingredient"));
                this.Ingredients = value;
            }
        }
        #endregion

        public override string Print()
        {
            var output = new StringBuilder();
            output.Append(base.Print());
            output.AppendFormat("  * Ingredients: {0}", this.Ingredients);
            output.AppendLine();
            return output.ToString();
        }
    }
}
