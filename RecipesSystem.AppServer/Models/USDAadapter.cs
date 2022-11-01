using RestSharp;

namespace RecipesSystem.AppServer.Models
{
    public class USDAadapter
    {
        public List<DP.USDAparamsDTO.Nutrient> Check(string Title,string KeyWord)
        {        //this class will ask the gateway server for nutriants values about food
                 //conect to gateway server
            //string Url = $"http://localhost:5149/api/USDA?title={Title}&keyWord={KeyWord}";

            //var client = new RestClient(Url);

            //var request = new RestRequest(new Uri(Url), Method.Get);

            //RestResponse response = client.Execute(request);
            //return response.Content;
            GetwayServer.Controllers.USDAController controller = new GetwayServer.Controllers.USDAController();

            //send the title of the recipe to the server
            return controller.Get(Title,KeyWord);

            
        }

    }
}
//new Recipe{Name="Easy Hamantaschen", 
//    Description="Hamantaschen are a favorite treat for the Purim holiday! It has always worked better for me if I cover the dough and refrigerate it overnight.", 
//    PrepInstructions="Preheat the oven to 350 degrees F (175 degrees C). Lightly grease cookie sheets.  Combine eggs and sugar in a large bowl; beat with an electric mixer until smooth and creamy. Stir in oil, orange juice, and vanilla. Combine flour and baking powder; stir into batter to form a stiff dough, adding more flour if needed.  Turn dough out onto a lightly floured surface and roll out into a 1/2-inch thickness. Cut into circles using a cookie cutter or the rim of a drinking glass; place 2 inches apart onto the prepared cookie sheets. Spoon about 2 teaspoons of preserves into center of each cookie. Pinch edges to form three corners.  Bake in the preheated oven until lightly browned, 12 to 15 minutes. Cool on the cookie sheets for 1 minute; transfer to a wire rack to cool completely.", 
//    Ingredients="3 large eggs, 1 cup granulated sugar, ¾ cup vegetable oil, ½ cup orange juice, 2 ½ teaspoons vanilla extract, 5 ½ cups all-purpose flour, 1 tablespoon baking powder, 1 cup fruit preserves, any flavor", 
//    TimeToMake="27 mins", 
//    ImageURL="https://img.mako.co.il/2012/02/23/JHBJSF8_c.jpg", 
//    CookingTime="12 mins", 
//    Diners= 24, 
//    Tag=Tags.COOKIES, 
//    Nutriants=new List<Nutriant>(), 
//    Holiday=Holidays.PURIM, 
//    Weather=Weathers.NICE},
//new Recipe{Name="Matzo Ball Soup",
//    Description="This is an easy, short-cut version of Matzo Ball Soup, a warm and comforting Jewish Soup served during Passover.",
//    PrepInstructions="Mince the garlic and dice the onion, celery, and carrots. Sauté the garlic, onion, celery, and carrots with the vegetable oil in a large pot over medium heat until the onions are soft and transparent (about five minutes).  Add the chicken breast, chicken broth, 2 cups water, some freshly cracked pepper, and one or two sprigs of dill to the pot. Place a lid on the pot and let it come up to a boil. Once it reaches a boil, turn the heat down to low and let it simmer for 30 minutes.  While the soup is simmering, mix the matzo ball dough. In a medium bowl, whisk together the eggs and vegetable oil. Add the matzo meal, salt, baking powder, and a little freshly cracked pepper to the eggs and oil. Stir until well combined. Finally, add 3 Tbsp water and stir until smooth again. Refrigerate the mixture for 30 minutes to allow the matzo meal time to absorb the moisture.  After the chicken soup has simmered, carefully remove the chicken breast and shred it with a fork. Return the shredded chicken to the soup. Taste the broth and adjust the salt if needed.  Once the matzo ball mix has refrigerated and stiffened up, begin to form it into ping pong sized balls. Drop the balls into the simmering soup as they are formed, returning the lid to the pot after each one. Once all the matzo balls are in the soup, let them simmer for 20 minutes without removing the lid. Make sure the soup is gently simmering the entire time.  Add a couple sprigs of fresh dill just before serving.",
//    Ingredients="SOUp nutrients, 1 Tbsp vegetable or canola oil, 2 cloves garlic, 1 yellow onion, 3 carrots, 3 stalks celery, 1 chicken breast (about 3/4 lb.), 6 cups chicken broth, 2 cups water, Freshly cracked pepper, Few sprigs fresh dill, MATZO BALLS nutrients, 3 large eggs, 3 Tbsp vegetable or canola oil, 3/4 cup matzo meal, 1 tsp salt, 1/2 tsp baking powder, Freshly cracked pepper, 3 Tbsp water",
//    TimeToMake="1 hr 40 mins",
//    ImageURL="https://img.apmcdn.org/ad486d405c3014f90fdcd01924701a605c52d6f2/uncropped/62f97d-splendid-table-classic-matzo-ball-soup-lede.jpg",
//    CookingTime="1 hr 30 mins",
//    Diners= 5,
//    Tag=Tags.SOUP,
//    Nutriants=new List<Nutriant>(),
//    Holiday=Holidays.PESACH,
//    Weather=Weathers.COLD},
//new Recipe{Name="Shopska Salata Bulgarian Tomato Salad",
//    Description="Shopska salata is a salad that originated in the Shopluk region of Bulgaria. It is said to have been invented in the 1950s as part of a tourism promotion by the socialist party to highlight local ingredients. Different salads, from other Bulgarian regions, were also created, but only the shopska survived, and it's now considered a national dish.\r\n\r\nIn a practice common among Balkan countries like Serbia and Macedonia, this salad highlights the colors of the Bulgarian flag with bright red tomatoes, green cucumbers, red or green bell peppers, and onions. A light dressing of red wine vinaigrette is usually served on the side, but a generous amount of sirene cheese, similar to feta, is crumbled on top.\r\n\r\nThere are slight variations on the standard recipe, as every household has its take on the salad, but in general the basic ingredients remain unaltered. Since olive trees are not as plentiful ​in Bulgaria as they are elsewhere, sunflower oil is used in most cooking and salad dressings.",
//    PrepInstructions="Gather the ingredients.  In a large bowl, place the tomatoes, cucumbers, peppers, onions, and parsley. Toss well to mix.  Place the oil, vinegar, salt and pepper in a screw-top jar. Close and shake until well incorporated.  Pour the dressing on top of the vegetables, turn into a serving bowl, and refrigerate until ready to serve. Alternatively, refrigerate the salad and dressing separately and allow each guest to add the desired amount on top of their salads.  When ready to serve, top the salad with crumbled cheese. Enjoy!",
//    Ingredients="For the Salad:, 4 medium tomatoes- chopped, 1 large cucumber- unpeeled and chopped, 4 green or red bell peppers-roasted or raw- chopped, 1 large yellow onion-chopped, 2 tablespoons chopped fresh parsley, For the Dressing:, 1/2 cup sunflower oil, 1/4 cup red wine vinegar, Salt, to taste, Freshly ground black pepper- to taste, For Topping the Salad:, 1/2 cup Bulgarian Sirene cheese or feta cheese-crumbled",
//    TimeToMake="20 mins",
//    ImageURL="https://www.deliciousmeetshealthy.com/wp-content/uploads/2020/04/Shopska-Salad-7.jpg",
//    CookingTime="0 mins",
//    Diners= 6,
//    Tag=Tags.SALAD,
//    Nutriants=new List<Nutriant>(),
//    Holiday=Holidays.SHAVUOT,
//    Weather=Weathers.NICE},
//new Recipe{Name="Ring doughnuts recipe",
//    Description="The most delicous food in the world!",
//    PrepInstructions="Sift the flour into a large bowl, add the salt, sugar and yeast and mix together. Place the butter, milk and vanilla extract together into a small pan and warm over a very gentle heat until the butter has melted and the milk is just warm but not boiling (you should be able to put your finger in it without burning it).  Stir in the egg. Make a well in the middle of the dry mix and gradually add the milk mixture and stir with a wooden spoon to form a rough dough. Tip out onto a floured surface and knead for 10 minutes adding more flour as necessary or until the dough is not sticky and slightly springy to touch. Place back into a clean, lightly oiled bowl, cover with a piece of greased cling film and leave to rise in a warm place for 1 ½ hours or until doubled in volume.  Punch down the dough with your fist, knead lightly then divide into 12 equal pieces. Roll them between your palms to form balls and then place on baking sheets well spaced apart. Cover with a piece of greased cling film and leave to rise again 45 minutes (check time) or until doubled in size. (This will make the doughnuts light and fluffy once cooked).  Roll over the top of the doughnuts to make them approx. 3cm in height – otherwise they will be huge! – and then using a lightly oiled 4cm pastry cutter, stamp out the middle of each doughnut and set aside. You can use these to make mini jam doughnuts later.  Pour the oil into a large saucepan to the depth of 10cm and heat to 180-190°C or when a small piece of dough dropped into it sizzles immediately and floats to the surface. Carefully lower 2 or 3 doughnuts at a time on a slotted spoon and fry for 30 seconds on each side or until golden brown.  Remove with a slotted spoon and drain on kitchen paper then roll in the cinnamon sugar to coat. Keep warm in a low oven. Repeat while you fry the rest of the doughnuts and then serve warm.",
//    Ingredients="200g strong white bread flour+ extra for dusting, pinch fine salt, 15g caster sugar, 7g dried fast action yeast, 50g unsalted butter, 100ml whole milk, tsp vanilla extract, 1 medium free-range egg-beaten, sunflower or groundnut oil for deep-frying+ extra for greasing the bowl, 50g caster sugar (to mix the cinnamon with), 1 tsp ground cinnamon",
//    TimeToMake="3 hr 30 mins",
//    ImageURL="https://realfood.tesco.com/media/images/HE-RINGDOUGHNUT-893e5c58-5a90-44b5-b1f3-1c3a32d9cf72-0-472x310.jpg",
//    CookingTime="5 mins",
//    Diners= 12,
//    Tag=Tags.COOKIES,
//    Nutriants=new List<Nutriant>(),
//    Holiday=Holidays.CHANUKA,
//    Weather=Weathers.NICE}
////new Recipe{Name="",
////    Description="",
////    PrepInstructions="",
////    Ingredients="",
////    TimeToMake="",
////    ImageURL="",
////    CookingTime="",
////    Diners=,
////    Tag=Tags.,
////    Nutriants=new List<Nutriant>,
////    Holiday=Holidays.,
////    Weather=Weathers.}
