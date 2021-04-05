using System;
using UnityEngine;

namespace Module.Panthea.Utils
{
    public static class NativeUtils
    {
        /// <summary>
        /// 获取平台上键盘的高度
        /// </summary>
        /// <returns></returns>
        public static int GetKeyboardHeight()
        {
#if UNITY_EDITOR
            return 0;//0; //pad=539 
#elif UNITY_ANDROID
            int keyboardHeight = 0;
            using(AndroidJavaClass UnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject view = UnityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView");
                using(AndroidJavaObject rect = new AndroidJavaObject("android.graphics.Rect"))
                {
                    view.Call("getWindowVisibleDisplayFrame", rect);
                    //Debugger.Log($"Rct = { Rct.Call<int>("height")},{ Rct.Call<int>("width")}, View.height={View.Call<int>("getHeight") }");
                    keyboardHeight = view.Call<int>("getHeight") - rect.Call<int>("height");
                }
                if(keyboardHeight == 0)
                    return 0;
                var dialog = UnityClass.GetStatic<AndroidJavaObject>("currentActivity")
                    .Get<AndroidJavaObject>("mUnityPlayer")
                    .Get<AndroidJavaObject>("b");
                var decorHeight = 0;
                try
                {
                    if (dialog != null)
                    {
                        AndroidJavaObject decorView = dialog.Call<AndroidJavaObject>("getWindow").Call<AndroidJavaObject>("getDecorView");
                        decorHeight = decorView.Call<int>("getHeight");
                        //Debugger.LogError("DecorHeight:" + decorHeight);
                    }
                }
                catch(Exception e)
                {
                    Debug.LogError(e);
                }

                //Debugger.Log("Dialog:" + dialog + "    KeyboardHeight:" + keyboardHeight);
                return keyboardHeight + decorHeight;
            }

#elif UNITY_IOS
         return (int)TouchScreenKeyboard.area.height;
#endif

        }
    }
}