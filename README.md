## VrControllerWrappter
  
# Usage
  
・Basically use only 4 propety and 1 method.  
public static float Trigger 	 // trigger 0.0f ～ -1.0f  
public static bool TriggerPress  // trigger press  
public static bool Button		 // button	
public static bool ButtonPress	 // button press  
public static void Haptics(AudioClip clip, MonoBehaviour behaviour)  // Vibration  
  
・Refer and call same work on any platforms.

if(ControlUtils.LeftHand.Button )
	// 
}  

・Call Init method once on awake mandatory.
ControllerUtils.Init() ;   

# Attention
 This project has not been fully tested yet.  
 Works with OCULUS and STEAM_VR.  
 If any error occured on Oculus or Vive, Please reinstall SDK and check harwaresetting.

# Platfomrs
Define Keywords each platforms.
OCULUS - Oculus
STEAM_VR - Steam plugin version2 (no support plugin version1)
VIVE - Vive platform (not work)
UNITY_PS4 - PlayStation VR.automatically defined.manually set need not. (not work)

# Contact
 @ydo_1 on twitter  
 
