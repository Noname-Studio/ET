using Common;
using FairyGUI;

[UIWidget(GetControl = true,DontDestroyOnLoad = true,Pool = true,IngoreBack = true)]
public class UI_BlackBackground: UIBase<View_BlackBackground>
{
    public int SortingOrder
    {
        get
        {
            return View.sortingOrder;
        }
        set
        {
            View.sortingOrder = value;
        }
    }

    public UI_BlackBackground()
    {
        View.MakeFullScreen();
        View.Center();
        View.AddRelation(GRoot.inst,RelationType.Size);
    }
}