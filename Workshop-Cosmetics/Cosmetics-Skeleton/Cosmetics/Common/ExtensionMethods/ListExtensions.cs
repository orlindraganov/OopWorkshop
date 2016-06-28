namespace Cosmetics.Common.ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ListExtensions
    {
        public static string PrintIngredients(this IList<string> ingredients)
        {
            const int IngredLengthMinValue = 4;
            const int IngredLengthMaxValue = 12;

            var output = new StringBuilder();
            foreach (var ingred in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(
                    ingred,
                    IngredLengthMaxValue,
                    IngredLengthMinValue,
                    string.Format(GlobalErrorMessages.InvalidStringLength,
                    ingred.GetType().Name + " name", IngredLengthMinValue, IngredLengthMaxValue));

                output.Append(ingred);
                output.Append(", ");
            }
            return output.ToString().TrimEnd(new char[] { ' ', ',' });
        }
    }
}
