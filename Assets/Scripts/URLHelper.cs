using UnityEngine;

using System.Collections;



// Prevents the use of this class in Flash-export, though due to bug in 4.0 b11, compilation is

// done anyway, so if you use something not supported in Flash here, be sure to wrap these tag around it:

// #if !UNITY_FLASH

// ... unsupported code ..

// #endif



[NotConverted]

[NotRenamed]

public static class URLHelper : object
{



    [NotRenamed]

    public static void navigateTo(string url)
    {

        Application.OpenURL(url);



    }



}
