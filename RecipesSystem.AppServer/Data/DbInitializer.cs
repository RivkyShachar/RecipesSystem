using RecipesSystem.AppServer.Controllers;
using RecipesSystem.AppServer.Models;
using System.IO;
using static DP.ImaggaModel;
using static DP.USDAparamsDTO;
using static DP.WeatherModel;

namespace RecipesSystem.AppServer.Data
{
    public class DbInitializer
    {
        public static void Initialize(RecipesSystemAppServerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Recipe.Any())
            {
                return;   // DB has been seeded
            }
            //add the recipes to the database
            var recipes = new Recipe[]
            {

                new Recipe{Name="Quiche",Description="This is a perfect base quiche recipe and it’s all baked in a super flaky homemade pie crust. Use a combination of milk and heavy cream for the richest, creamiest filling and add your favorites such as bacon, feta cheese, ham, white cheddar cheese, crab meat or spinach.",
                    PrepInstructions="Prepare pie crust: I like to make sure my pie dough is prepared before I begin the quiche Make pie dough the night before because it needs to chill in the refrigerator for at least 2 hours before rolling out and blind baking (next step)." +
                    " Roll out the chilled pie dough: On a floured work surface, roll out one of the disks of chilled dough (use the 2nd pie crust for another recipe) Turn the dough about a quarter turn after every few rolls until you have a circle 12 inches in diameter Carefully place the dough into a 9-inch pie dish Tuck it in with your fingers, making sure it is completely smooth To make a lovely edge, I do not trim excess dough around the edges Instead, fold the excess dough back over the edge and use your hands to mold the edge into a rim around the pie Crimp the edges with a fork or use your fingers to flute the edges Chill the pie crust in the refrigerator for at least 30 minutes and up to 5 days Cover the pie crust with plastic wrap if chilling for longer than 30 minutes. While the crust is chilling, preheat oven to 375°F (190°C). " +
                    " Partially blind bake: Line the chilled pie crust with parchment paper Fill with pie weights or dried beans Make sure the weights are evenly distributed around the pie dish Bake until the edges of the crust are starting to brown, about 15-16 minutes. Remove pie from the oven and carefully lift the parchment paper (with the weights) out of the pie Prick holes all around the bottom crust with a fork Return the pie crust to the oven Bake until the bottom crust is just beginning to brown, about 7-8 minutes Remove from the oven and set aside (Crust can still be warm when you pour in the filling You can partially pre-bake the crust up to 3 days ahead of time Cover cooled crust tightly and refrigerate until ready to fill). " +
                    "Reduce oven temperature to 350°F (177°C). " +
                    "In a large bowl with a handheld or stand mixer fitted with a whisk attachment, beat the eggs, whole milk, heavy cream, salt, and pepper together on high speed until completely combined, about 1 minute Whisk in add-ins and then pour into crust. " +
                    "Bake the quiche until the center is just about set, about 45-55 minutes Don’t over-bake. Use a pie crust shield to prevent the pie crust edges from over-browning Allow to cool for 15 minutes Top with optional toppings before slicing and serving, if desired Or you can cool the quiche completely before serving– it’s fantastic at room temperature!. " +
                    "This quiche makes great leftovers! Cover tightly and store in the refrigerator for up to 4 days. ",
                    Ingredients="1 unbaked Flaky Pie Crust (what I used) or All Butter Pie Crust*, 4 large eggs, 1/2 cup whole milk*, 1/2 cup heavy cream or heavy whipping cream*, 1/4 teaspoon each salt and pepper*, 1 cup shredded or crumbled cheese such as feta,cheddar,goat cheese,or gruyere, up to 2 cups add-ins (see recipe note), optional toppings for serving: extra cheese,chopped herbs,hollandaise sauce,& freshly ground pepper to taste, ",
                    TimeToMake="2 hr and 40 min",ImageURL="https://sallysbakingaddiction.com/wp-content/uploads/2019/04/quiche-2.jpg",
                    CookingTime="1 hr and 20 min",Diners=8,Tag=Tags.QUICHE,Nutriants=new List<Nutriant>(),Holiday=Holidays.ROSH_HASHANA,Weather=Weathers.NICE},
                new Recipe{Name="Chicken",Description="Wings are always a supper go-to because they defrost and cook quickly. This will soon become a go-to for you as well! A few seconds of prep is all you need for these delicious crispy wings. Serve with yellow rice and salad and the meal is complete!",
                    PrepInstructions="Prepare the Wings:. Preheat the oven to 375 degrees Fahrenheit. Line a baking sheet with two sheets of Gefen Parchment Paper. Spread the wings out onto the baking sheet Shake a little of each spice on top of the wings, Do not mix, Leave as is and bake uncovered for 45 minutes or until the tops are crispy. If towards the end the top doesn’t look crispy enough raise the heat to 400 degrees Fahrenheit. " +
                    "Prepare the Yellow Rice:. In a pot heat the olive oil and add in the spices Allow to cook and become fragrant about for about 40 to 60 seconds.  Add in the rice and mix to coat in the spices Pour over the water and mix. Bring to boil uncovered. Once boiling, mix once more and lower to a simmer Cover the pot. Cook on low flame 15 to 20 minutes Turn off flame and keep covered another 10 minutes before fluffing with a fork. " +
                    "Prepare the Cucumber Salad:. Mix everything together Allow to sit for a little while before serving.",
                    Ingredients="Crispy Wings:, 2 and 1/2 pounds chicken wings, onion powder, garlic powder, Pereg Turmeric, Gefen Cumin, sweet paprika, smoked paprika" +
                    "Yellow Rice:, 2 tablespoons Tuscanini Olive Oil, 1 teaspoon onion powder, 1 teaspoon garlic powder, 1 and 1/4 teaspoons salt, 1/4 teaspoon Gefen Cumin, 3/4 teaspoon Pereg Turmeric, 2 cups jasmine rice, 4 and 1/2 cups water",
                    TimeToMake="1 hr ",ImageURL="https://www.kosher.com/resized/details.slide/t/u/Tuchinsky_Rena_Crispy_Wings_with_Yellow_Rice_and_Cucumber_Salad.jpg",
                    CookingTime="20 min",Diners=6,Tag=Tags.CHICKEN,Nutriants=new List<Nutriant>(),Holiday=Holidays.PESACH,Weather=Weathers.NICE},
                new Recipe{Name="Maple Salmon",Description="This maple glazed salmon is delicious and very easy to prepare. I love maple syrup in everything and decided to use it in the marinade. My husband totally loved it; he wasn't a salmon fan until now.",
                    PrepInstructions="Stir maple syrup, soy sauce, garlic, garlic salt, and pepper together in a small bowl. Cut salmon into 4 equal-sized fillets; place in a shallow glass baking dish and coat with maple syrup mixture Cover the dish and marinate salmon in the refrigerator for 30 minutes, turning once halfway. Preheat the oven to 400 degrees F (200 degrees C). Place the baking dish in the preheated oven and bake salmon uncovered until flesh easily flakes with a fork, about 20 minutes. ",
                    Ingredients="¼ cup maple syrup, 2 tablespoons soy sauce, 1 clove garlic, minced, ¼ teaspoon garlic salt, ⅛ teaspoon ground black pepper, 1 pound salmon",
                    TimeToMake="40 min",ImageURL="https://www.allrecipes.com/thmb/aos_70aMtlxbmU3HDv1_X6z9K2g=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/862371-cd7a4b6c481f444382e3f69273b982f9.jpg",
                    CookingTime="20 min",Diners=4,Tag=Tags.FISH,Nutriants=new List<Nutriant>(),Holiday=Holidays.SUKOT,Weather=Weathers.NICE},
                new Recipe{Name="Special Donuts",Description="There are never enough to last eight days! The sooner you eat these after making them, the better they are, although you will want to give them time to cool first!",
                    PrepInstructions="Combine ﬂour and 1/3 cup sugar in a large mixing bowl, and make a well in the center Place 1/4 cup warm water, 1 ounce fresh yeast, and 1 tablespoon sugar into the well, When yeast begins to bubble, add egg and margarine to the bowl. Begin to mix the dough and when the ingredients are somewhat blended, add the lemon rind, Mix well! Slowly add water, starting with 1/3 cup,  Knead the dough, and add more water, if necessary, to create a smooth, soft dough. Allow the dough to rise for 75 minutes, Roll out the dough on a lightly ﬂoured surface, to one inch thickness, Using a cup, cut out circles from the dough, Let rise for 20 minutes. Heat three to four inches of oil (See tip below) over a medium ﬂame in a four quart saucepan Drop in dough circles and deep-fry two to three minutes per side With a slotted spoon, remove doughnuts from oil and drain on paper towels, Cool. Decorate with confectioners’ sugar or ﬁll with custard, jelly, or caramel. ",
                    Ingredients="3 cups ﬂour, 1/3 cup sugar, 1/4 cup water, 1 ounce fresh yeast, 1 tablespoon sugar, 1 egg, 1/2 stick margarine softened, rind of 1 lemon, grated, 1/3 – 1/2 cup water, oil- for frying, ",
                    TimeToMake="1 hr and 30 min",ImageURL="https://www.kosher.com/resized/details.slide/s/u/sufganiyot.kosher-09742-D.jpg",
                    CookingTime="1 hr and 30 min",Diners=25,Tag=Tags.DESERT,Nutriants=new List<Nutriant>(),Holiday=Holidays.CHANUKA,Weather=Weathers.NICE},
                new Recipe{Name="Meat",Description="",
                    PrepInstructions="Sauté the onion in oil until golden brown. Add meat and cook covered over a low flame for half an hour. Add one cup of water and seasoning and cook until tender. ",
                    Ingredients="2 pounds beef chuck shoulder steak or veal chops, 1 medium onion diced, 1 tablespoon oil or chicken fat, 1 teaspoon salt, dash of pepper (optional), dash of paprika (optional), ",
                    TimeToMake="30 min",ImageURL="https://www.kosher.com/resized/details.slide/t/a/Tasty-Yom-Tov-Meat-(2)-H_preview.jpeg",
                    CookingTime="2  and ahalf hr",Diners=4,Tag=Tags.MEAT,Nutriants=new List<Nutriant>(),Holiday=Holidays.PURIM,Weather=Weathers.NICE},
           
            };
            foreach (Recipe r in recipes)
            {
                context.Recipe.Add(r);
            }
            context.SaveChanges();


            //nutriants for the recipes
            USDAadapter Uadapter = new USDAadapter();
           
            foreach(Recipe r in recipes)
            {

                List<Nutrient> nutriants = Uadapter.Check(r.Name, r.Tag.ToString());
                r.Nutriants = new List<Nutriant>();               
                foreach (Nutrient nutr in nutriants)
                {
                    Nutriant nutrient = new Nutriant();
                    nutrient.Value = nutr.Value;
                    nutrient.Name = nutr.Name;
                    nutrient.UnitOfMesurment = nutr.UnitName;//לא בטוחה שזה המקביל שלו אבל נבדוק
                    r.Nutriants.Add(nutrient);
                }
            }
            context.SaveChanges();
        }
    }
}


