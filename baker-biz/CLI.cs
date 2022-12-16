﻿using baker_biz_interfaces;
using bakerbiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baker_biz
{
    internal class CLI : IUserInterface
    {
        public IRecipe? SelectRecipe(IEnumerable<IRecipe> recipes)
        {
            Recipe? recipe = null;

            if (recipes.Count() > 0)
            {
                // Print List of recipes with a number to reference them by
                Console.WriteLine("The following Items are available to calculate:");

                int idx = 1;
                foreach (Recipe rec in recipes)
                {
                    Console.WriteLine($"{idx} - {rec.Name}");
                    idx++;
                }

                // Request input on which recipe to calculate
                bool selectionIsValid;
                do
                {
                    Console.WriteLine("Enter the number for the Recipe you wish to calculate (Enter 'q' to quit):");

                    string? response = Console.ReadLine();

                    // If they enter 'Q' or 'q', then quit!
                    if(String.Compare("Q", response, true) == 0)
                    {
                        Console.WriteLine("Exiting program");
                        return null;
                    }

                    // Otherwise, see if the value is valid!
                    bool valueIsInt = int.TryParse(response, out idx);
                    bool valueIsInRange = (idx > 0) && (idx <= recipes.Count());

                    selectionIsValid = valueIsInt && valueIsInRange;
                } while (!selectionIsValid);

                recipe = recipes.ElementAt(idx - 1) as Recipe;

                if (recipe != null)
                {
                    Console.WriteLine($"{recipe.Name} Selected, Processing Now...");

                    // Collect the availability of the Ingredients required by the selected recipe
                    CollectIngredients(recipe);
                }
            }
            else
            {
                Console.WriteLine("There are no Recipes to process. Please create some, and then run this program again!");
            }

            // Return the selected recipe from the list
            return recipe;
        }

        private void CollectIngredients(IRecipe recipe)
        {

        }

        public void ReportCalculationResults(IRecipe recipe)
        {
            throw new NotImplementedException();
            // Report Recipes possible with optional ingredients

            // Report Basic Recipes

            // Report leftover ingredients
        }
    }
}
