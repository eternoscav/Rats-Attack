
Screen.SetResolution (Screen.currentResolution.width, Screen.currentResolution.height, true);
var width : int = 924; //Reference resolution
var height : int = 468; //Reference resolution
Screen.SetResolution (924, 468, false);
//Screen.fullScreen = true;


private var showGraphicsDropDown = false;
public static function AutoResize(screenWidth:int, screenHeight:int):void
{
    var resizeRatio:Vector2 = Vector2(Screen.width / parseFloat(screenWidth), Screen.height / parseFloat(screenHeight));
    GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3(resizeRatio.x, resizeRatio.y, 1.0));
    }

