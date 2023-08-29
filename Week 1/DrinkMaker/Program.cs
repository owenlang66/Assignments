Tea Chai = new Tea(false, "chai");
Coffee Dark = new Coffee("dark", "small");
Wine Sangria = new Wine("Argentina", 1756);

List<Drink> AllBeverages = new List<Drink>();

AllBeverages.Add(Chai);
AllBeverages.Add(Dark);
AllBeverages.Add(Sangria);

foreach (Drink beverage in AllBeverages)
{
    beverage.ShowDrink();
}