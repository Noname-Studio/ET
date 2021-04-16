using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Module.Panthea.Utils;
using UnityEngine;
using UnityEngine.Analytics;

public class TestAnalytics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string line =
                "$UNITY_PATH -projectPath $PROJECT_PATH -executeMethod JenkinsWorkflow.CommandLineExtenral [OutputPath:${Output_Path}][Platform:IOS][IsCompress:${IsCompress}][BundleName:{$BundleName}][IsMono:${IsMono}] -quit";
        var regex = Regex.Matches(line, @"\[(.*?)\]");
        foreach (Match node in regex)
        {
            var s = node.Value.TrimStart('[').TrimEnd(']').Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Log(s[0] + ":" + s[1]);
        }
        
        /*AnalyticsEvent.debugMode = true;
        var result = AnalyticsEvent.GameStart();
        Debug.Log(result);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
