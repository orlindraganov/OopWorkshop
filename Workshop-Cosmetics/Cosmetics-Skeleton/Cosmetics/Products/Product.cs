namespace Cosmetics.Products
{
    using System.Text;

    using Common;

    public abstract class Product
    {
        #region Fields, Ctors, Props
        protected const int NameLengthMinValue = 3;
        protected const int NameLengthMaxValue = 10;
        protected const int BrandLengthMinValue = 2;
        protected const int BrandLengthMaxValue = 10;

        private decimal price;
        private string name;
        private string brand;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    NameLengthMaxValue,
                    NameLengthMinValue,
                    string.Format(GlobalErrorMessages.InvalidStringLength,
                    this.GetType().Name + " name", NameLengthMinValue, NameLengthMaxValue));
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    BrandLengthMaxValue,
                    BrandLengthMinValue,
                    string.Format(GlobalErrorMessages.InvalidStringLength,
                    this.GetType().Name + " name", BrandLengthMinValue, BrandLengthMaxValue));
                this.brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(GlobalErrorMessages.ObjectCannotBeNull, this.GetType().Name + " name"));
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(GlobalErrorMessages.ObjectCannotBeNull, this.GetType().Name + " name"));
                this.gender = value;
            }
        }
        #endregion

        public virtual string Print()
        {
            var output = new StringBuilder();
            output.AppendFormat("- {0} - {1}:", this.Brand, this.Name);
            output.AppendLine();
            output.AppendFormat("  * Price: ${0}", this.Price);
            output.AppendLine();
            output.AppendFormat("  * For gender: {0}", this.Gender);
            output.AppendLine();
            return output.ToString();
        }
    }
}
