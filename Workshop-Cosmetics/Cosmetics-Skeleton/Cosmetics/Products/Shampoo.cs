
namespace Cosmetics.Products
{
    using System.Text;

    using Common;
    using Contracts;

    public class Shampoo : Product, IShampoo, IProduct
    {
        #region Fields, Ctors, Props
        private uint milliliters;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }
            set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(GlobalErrorMessages.ObjectCannotBeNull, this.GetType().Name + " name"));
                this.milliliters = value;
            }

        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(GlobalErrorMessages.ObjectCannotBeNull, this.GetType().Name + " name"));
                this.usage = value;
            }
        }
        #endregion

        public override string Print()
        {
            var output = new StringBuilder();
            output.Append(base.Print());
            output.AppendFormat("  * Quantity: {0} ml", this.Milliliters);
            output.AppendLine();
            output.AppendFormat("  * Usage: {0}", this.Usage);
            output.AppendLine();
            return output.ToString();
        }
    }
}
