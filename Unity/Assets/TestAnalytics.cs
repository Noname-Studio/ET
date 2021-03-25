using System.Collections;
using System.Collections.Generic;
using Module.Panthea.Utils;
using UnityEngine;
using UnityEngine.Analytics;

public class TestAnalytics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FileUtils.EncodeAllTextAndWrite("11", "11");
        /*AnalyticsEvent.debugMode = true;
        var result = AnalyticsEvent.GameStart();
        Debug.Log(result);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
