namespace RestaurantPreview.Config
{
    public partial class CustomerProperty
    {
        public static CustomerProperty Random()
        {
            var list = ReadList();
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
    }
}