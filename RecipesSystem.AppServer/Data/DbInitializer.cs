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


                new Recipe{Name="cake",Description="write description1",
                    PrepInstructions="instructions",
                    Ingredients="the ingridents",
                    TimeToMake="x min",ImageURL="https://realfood.tesco.com/media/images/1400x919-MargaritaPizza-555a4065-2573-4b41-bcf3-7193cd095d8f-0-1400x919.jpg",
                    CookingTime="z min",Diners=2,Tag=Tags.PIZZA,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.NICE},


                new Recipe{Name="banana cake ",Description="Breakfast banana cake ",
                    PrepInstructions="Preheat the oven to 190°C/fan 170°C/Gas Mark 5. Grease and line a 2lb (900g) loaf tin with nonstick baking paper. With an electric whisk, mix the eggs, sugar, cooled butter and a good pinch of salt together for 4 minutes until light and fluffy. Mash the banana and yogurt with a fork, add to the eggs with the vanilla extract and whisk again.  Add a spoonful of the flour to the blueberries and mix to coat. Stir the baking powder into the remaining flour and sift this over the top of the whisked eggs and banana. Fold through, then add the blueberries and fold again until everything’s just combined. Spoon into your prepared tin, even the top and sprinkle over the hazelnuts. Bake in the oven for 1 hour 10 minutes, until a skewer comes away clean.  Cool in the tin for 15 minutes, then turn out and cool completely on a wire rack. Serve with Greek yogurt and a drizzle of clear honey.",
                    Ingredients="2 medium eggs, 200g muscovado sugar, 100g butter, melted and cooled, 3 really ripe large bananas, 75g full fat Greek yogurt, 1tsp vanilla extract, 200g plain flour, 1tsp baking powder, 110g blueberries, 25g (1oz) chopped hazelnuts, Greek yogurt to serve, honey to serve",
                    TimeToMake="15 min",ImageURL="https://realfood.tesco.com/media/images/HE-BREAKFASTBANANABREAD-5c7f66e2-cb73-4af1-8f22-bb898fef0327-0-472x310.jpg",
                    CookingTime="45 min",Diners=2,Tag=Tags.CAKE,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.NICE},

                new Recipe{Name="soup vegan",Description="vegan soup",
                    PrepInstructions="Preheat the oven to gas 7, 220°C, fan 200°C. Put the carrots and swede on a large baking tray with ½ tbsp oil, the ground coriander and turmeric. Toss to coat, then roast for 20 mins, turning halfway.  Meanwhile, heat 1 tbsp oil in a large pan over a medium heat. Fry the onion and celery for 10 mins, stirring occasionally, until softened. Add the ginger and 2 of the crushed garlic cloves; fry for 1 min.  Transfer the carrots and swede to the pan and pour in the stock. Bring to the boil, then simmer for 15 mins until the veg is tender.  Use a stick blender to blitz until smooth, then season to taste; keep warm over a low heat.  For the chimichurri, mix the coriander, parsley, chilli and remaining garlic with the vinegar and remaining oil.  Divide the soup between between bowls and top top each with 1 tbsp chimichurri.",
                    Ingredients="3 large carrots chopped, 400g swede peeled and chopped, 3 tbsp olive oil, 1 tsp ground coriander , ½ tsp ground turmeric, 1 onion roughly chopped, 1 celery stick roughly chopped, 15g fresh ginger peeled and grated, 3 garlic  cloves crushed , 1 vegetable stock pot made up to 1.2ltrs, 20g fresh coriander, leaves picked and finely chopped, 20g fresh parsley, leaves picked and finely chopped, 1 red chilli deseeded and finely chopped, 2 tbsp red wine vinegar",
                    TimeToMake="20 min",ImageURL="https://realfood.tesco.com/media/images/1400x919-SpicedSwedeCarrotSoupChimichurri-661a74de-2712-4385-a775-607d4da95e9c-0-1400x919.jpg",
                    CookingTime="300 min",Diners=4,Tag=Tags.SOUP,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.COLD},

                new Recipe{Name="orange soup",Description="orange soup",
                    PrepInstructions="remove the skin from the vegetables.   cut them . and put them on the fire",
                    Ingredients="1 red onion roughly chopped,  1½ carrots roughly chopped, 1 stick celery roughly chopped, 400g tin chopped tomatoes, 1 low-salt vegetable stock cube made up to 500ml,  1 ciabatta roll toasted and cut into strips handful wild rocket",
                    TimeToMake="20 min",ImageURL="https://realfood.tesco.com/media/images/1400x919CarrotandTomatoSoupwithToastDippers-4d78fbbb-6032-423b-9e96-744be54c25cb-0-1400x919.jpg",
                    CookingTime="30 min",Diners=2,Tag=Tags.SOUP,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.COLD},


                new Recipe{Name="salad with clementine",Description="salad with clementine",
                    PrepInstructions="Preheat the oven to 220ºC/425ºF/gas 7. Finely grate the zest of 2 clementines into a jam jar, then squeeze in the juice from all three. Add 4 tablespoons of extra virgin olive oil and 2 tablespoons of vinegar, followed by the honey (if using). Strip in the thyme leaves, then season with a pinch of sea salt and black pepper. Secure the lid on the jar and give it a good shake.  Scatter the almonds over a large baking tray and roast in the oven for 5 minutes and then finely slice into slivers.  Pick the grapes, then toss in ½ a tablespoon of olive oil and 1 tablespoon of vinegar on the same large baking tray, then roast for 10 minutes, or until bursting open.  Trim the gem lettuces and click apart the leaves, then arrange nicely on a serving platter with the salad leaves and roasted grapes. Tear over the mozzarella, then drizzle over half the clementine dressing (save the rest for another recipe, see tip). Scatter with the roasted almonds, then serve.",
                    Ingredients="3 clementines, Extra virgin olive oil, red wine vinegar, 1 teaspoon runny honey or maple syrup, 2 sprigs of fresh thyme, 50g whole almonds, ½ a bunch of red or black seedless grapes (250g), olive oil, 2 little gem lettuce, 100g salad leaves such as watercress or spinach or  rocket, 1 x 125g ball of mozzarella cheese",
                    TimeToMake="20 min",ImageURL="https://realfood.tesco.com/media/images/Jam-jar-WINTER-SALAD-tipsmas-1400x919-f589b092-2620-4200-a02b-818830c68bae-0-1400x919.png",
                    CookingTime="0 min",Diners=7,Tag=Tags.SALAD,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.HOT},


                new Recipe{Name="salad with corn",Description="salad with corn",
                    PrepInstructions="Light the barbecue at least 40 mins before cooking or heat a griddle pan over a medium-high heat. Rub each corn cob with ½ tsp oil and season with salt. Griddle for 15-20 mins, turning every 2-3 mins until golden and charred, and the kernels are tender. Leave to cool until you can handle them.  Meanwhile, pierce the sweet potatoes all over with a fork and microwave on high in 2-min bursts for 10-15 mins on high (or in 2 batches for 6-10 mins) until tender throughout when pressed. Rub the sweet potato skins with ½ tbsp oil. While the sweetcorn is cooling, transfer the sweet potatoes to the barbecue or griddle pan and cook for 4-5 mins, turning every 1 min, until the skins are crisp and lightly charred.  Mix the remaining 1 tbsp oil, the lime juice, onion, chilli, beans and paprika in a bowl with some seasoning. Stand the corn cobs on a chopping board and use a sharp knife to slice off the kernels. Add the sweetcorn to the bowl with the parsley and most of the cheese. Toss everything together. Split the charred sweet potatoes using a sharp knife and spoon in the chilli sweetcorn. Scatter with the remaining cheese and a grind of black pepper, and serve with any remaining salad alongside.",
                    Ingredients="6 corn on the cobs, 6 small sweet potatoes, 2 ½ tbsp olive oil, ½ limed juiced, 1 red onion finely chopped, 1 to 2 red chillies (to taste) deseeded and finely chopped, 400g tin kidney beans drained and rinsed, 400g tin black beans drained and rinsed, 2 tsp smoked paprika, 30g pack fresh parsley finely chopped, 100g reduced-fat salad cheese crumbled",
                    TimeToMake="15 min",ImageURL="https://realfood.tesco.com/media/images/1400x919-Charred-chilli-corn-d76fcee9-39c6-4991-9a86-f44e77fae4e8-0-1400x919.jpg",
                    CookingTime="0 min",Diners=2,Tag=Tags.SALAD,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.HOT},


                new Recipe{Name="Greek salad",Description="refreshing salad",
                    PrepInstructions="To make the dressing, mix together the olive oil, lemon, dill (if using), oregano and onion. Season well.  Remove the leaves from the Fire Pit Triple Grain Salad. Finely slice these and place them over the base of a platter.  In a bowl, toss together the remains of the Fire Pit Triple Grain Salad with the red onion, cucumber and tomatoes. Toss through the dressing and top with the feta and black olives to serve.",
                    Ingredients="1 tub  450g Fire Pit Triple Grain Salad, 1 red onion finely chopped, 1 cucumber chopped into 1cm cubes, 250g cherry tomatoes halved, 200g feta sliced, 100g black olives pitted",
                    TimeToMake="20 min",ImageURL="https://realfood.tesco.com/media/images/1400x919-GREEK-SALAD-WITH-GRAINS-40043b8f-e26c-4c3b-a377-5f652cfd6526-0-1400x919.jpg",
                    CookingTime="0 min",Diners=2,Tag=Tags.SALAD,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.HOT},

                new Recipe{Name="Tropical fruit trifles",Description="Tropical fruit trifles",
                    PrepInstructions="Preheat the grill to high. Put the pineapple on a baking tray and grill for 10-15 mins, turning occasionally, until charred. Set aside to cool. Meanwhile, heat the ginger wine in a small pan for 5 mins on a medium heat to cook off some of the alcohol. Set aside. Divide the cake into 8, then crumble into 8 dessert glasses or small bowls, pushing down slightly to fill out the bottoms. Pour a little ginger wine into each glass so it soaks into the cake.  Arrange the grilled pineapple on top, then put the glasses in the fridge. Drain the mango and blend in a food processor until smooth. Set aside. Whisk the cream to soft peaks, then gently fold in half the passion fruit pulp and seeds.  Top the pineapple with a layer of custard, followed by a layer of mango purée (you might not need it all).  Top with the passion fruit cream and the remaining pulp and seeds.  Chill for at least 1 hr, or assemble up to 8 hrs ahead and chill until ready to serve.",
                    Ingredients="1 small pineapple cut into 1.5cm cubes , 150ml ginger wine,  200g Jaimaican ginger cake , 850g mango slices in light syrup , 300ml double cream alternative,  4 passion fruits halved pulp and seeds scooped into a bowl , 400ml fresh custard",
                    TimeToMake="50 min",ImageURL="https://realfood.tesco.com/media/images/RFO-1400x919-TropicalTrifle-28e410b2-02fa-4089-9f5a-1100aba60efa-0-1400x919.jpg",
                    CookingTime="10 min",Diners=5,Tag=Tags.DESERT,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.NICE},

                new Recipe{Name=" roll bread",Description=" roll bread",
                    PrepInstructions="Grease a large baking tray with oil. Sift the flour and salt into a large mixing bowl, then stir in the yeast and sugar, making sure the ingredients are well mixed.  Make a well in the middle and gradually add 300ml warm water. Using a wooden spoon, mix to form a soft dough. Sprinkle a little flour onto a clean work surface and tip the dough out onto it. Knead the dough by pushing down into the middle to flatten and stretch it out, then folding it in half and pushing down into the centre again. Continue kneading the dough for around 10 mins until soft and smooth.  Divide the dough into 8 pieces and roll gently to shape them into balls before placing them onto the baking tray. Cover the rolls loosely with lightly oiled clingfilm or a damp tea towel and leave to prove for around 45 mins in a warm place, or until they have doubled in size. Meanwhile, preheat the oven to gas 7, 220°C, fan 200°C.",
                    Ingredients=" vegetable oil for greasing, 500g strong white flour plus extra for dusting, 2 tsp salt, 2 x 7g sachets fast-action dried yeast, 2 tsp caster sugar",
                    TimeToMake="20 min",ImageURL="https://realfood.tesco.com/media/images/RFO-1400x919-BreadRolls-f2375e23-c14a-417e-ba88-7cbf26e5ba0f-0-1400x919.jpg",
                    CookingTime="30 min",Diners=5,Tag=Tags.BREADS,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.NICE},

                new Recipe{Name=" nice bread",Description=" very easy and tasty bread",
                    PrepInstructions="Grease a large baking tray with oil. Sift the flour and salt into a large mixing bowl, then stir in the yeast and sugar, making sure the ingredients are well mixed.  Make a well in the middle and gradually add 300ml warm water. Using a wooden spoon, mix to form a soft dough. Sprinkle a little flour onto a clean work surface and tip the dough out onto it. Knead the dough by pushing down into the middle to flatten and stretch it out, then folding it in half and pushing down into the centre again. Continue kneading the dough for around 10 mins until soft and smooth.  Divide the dough into 8 pieces and roll gently to shape them into balls before placing them onto the baking tray. Cover the rolls loosely with lightly oiled clingfilm or a damp tea towel and leave to prove for around 45 mins in a warm place, or until they have doubled in size. Meanwhile, preheat the oven to gas 7, 220°C, fan 200°C.",
                    Ingredients=" vegetable oil for greasing, 500g strong white flour plus extra for dusting, 2 tsp salt, 2 x 7g sachets fast-action dried yeast, 2 tsp caster sugar",
                    TimeToMake="20 min",ImageURL="https://realfood.tesco.com/Media/images/NoKneadBread-Final-f3a53c86-08e9-42d8-829c-d764fe453c2c-0-636x418.jpg",
                    CookingTime="50 min",Diners=3,Tag=Tags.BREADS,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.NICE},


                new Recipe{Name=" pasta",Description=" pasta in sauce of tomato",
                    PrepInstructions="Heat 2 tsp oil in a medium saucepan over a medium heat and fry the breadcrumbs for 3-4 mins, stirring often, until just turning golden brown.  Add half the garlic and a pinch of thyme, then cook for another 1 min until toasted and fragrant.  Tip into a bowl and set aside. Add the remaining 2 tsp oil to the pan and cook the onion over a medium heat for 5-6 mins until softened and slightly browning.  Add the remaining garlic and ½ tsp thyme, cook for 1 min, then add the pinch of thyme, the tomatoes and vinegar; season. Stir well and bring to a simmer.  Break the spaghetti in half and add to the pan with 500ml boiling water.  Cook over a medium heat for 10-12 mins until the pasta is al dente, adding a splash more water if it starts to stick. Divide between 2 bowls and scatter over the garlicky breadcrumbs to serve",
                    Ingredients=" 4 tsp olive oil, 4 tbsp fresh or dried breadcrumbs, 2 garlic cloves crushed or 1 tsp garlic granules , ½ tsp dried thyme, plus a pinch 1 onion peeled and finely sliced , 400g tin chopped tomatoes, 2 tsp red wine vinegar, 250g spaghetti",
                    TimeToMake="5 min",ImageURL="https://realfood.tesco.com/media/images/1400x919-tomato-pasta-6a5a3c8e-f111-490d-805c-9b62fbec8691-0-1400x919.jpg",
                    CookingTime="15 min",Diners=4,Tag=Tags.PASTA,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.NICE},


                new Recipe{Name="salad of pasta",Description=" fresh salad of pasta",
                    PrepInstructions="Cook the pasta in a large pan of salted water to pack instructions. Drain and leave to cool.  Place a large griddle pan on a high heat.  Thinly slice the courgettes lengthways, rub with a little oil and chargrill for 1-2 mins each side until tender – you may need to do this in batches. (These will keep perfectly covered in the fridge overnight.)  Wash, trim and finely slice the spring onions and chilli (deseed, if you like), then put on a serving platter.  Roughly chop the herb leaves and add to the mix, keeping any small, pretty leaves aside for later.  Halve the lemon and squeeze over the juice along with 1 tbsp oil.  Drain the chickpeas and scatter them over, along with the courgettes and pasta. Season to perfection and toss everything together.  Crumble over the feta, sprinkle over the reserved herb leaves and serve.",
                    Ingredients=" 150g dried farfalle, or a similar-sized pasta shape, 2 courgettes, 1 tbsp olive oil, plus a little extra bunch of spring onions, ½ fresh red chilli, 15g fresh mint or basil, 1 lemon, 400g tin chickpeas, 50g feta cheese",
                    TimeToMake="15 min",ImageURL="https://realfood.tesco.com/media/images/1400x919-CourgetteChickpeaSalad-26dbea5e-47ee-4b44-8b76-f5403aae27e2-0-1400x919.jpg",
                    CookingTime="10 min",Diners=7,Tag=Tags.PASTA,Nutriants=new List<Nutriant>(),Holiday=Holidays.NOTHOLIDAY,Weather=Weathers.NICE},



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


