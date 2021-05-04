using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;

public class FixPosition : MonoBehaviour
{
    [Button]
    void Do()
    {
        NetJsonExtConverter.RegisterAll();
        var obj = JsonConvert.DeserializeObject<Dictionary<string,RestaurantPreview.Config.CookwareProperty>>(File.ReadAllText(Application.dataPath + "/Res/Config/Client/Cookware.json"));
        foreach (var node in obj)
        {
            Debug.LogError(node.Value.Restaurant == RestaurantKey.Breakfast);
        }
    }
}
