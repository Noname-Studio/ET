using System.Collections.Generic;

namespace Kitchen
{
    public interface ICookware : IDisplay
    {
        CookwareState State { get; }
        string FoodId { get; }
        void DoWork();
        string TakeFood();
        List<string> PutIn(List<string> list);
    }
}