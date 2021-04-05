public static class IngredientHelper
{
    public static bool IsFood(string key)
    {
        return key.StartsWith("F_");
    }

    public static bool IsIngredient(string key)
    {
        return key.StartsWith("I_");
    }

    public static bool IsFood(BaseIngredient property)
    {
        return property.Key.StartsWith("F_");
    }

    public static bool IsIngredient(BaseIngredient property)
    {
        return property.Key.StartsWith("I_");
    }
}