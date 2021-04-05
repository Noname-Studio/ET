using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShaderHelper
{
    public static int Alpha = Shader.PropertyToID("_Alpha");
    public static int Brightness = Shader.PropertyToID("_Brightness");
    public static int AlphaCut = Shader.PropertyToID("_Cutoff");
    public static int MainTexture = Shader.PropertyToID("_MainTex");
    public static int Color = Shader.PropertyToID("_Color");
}