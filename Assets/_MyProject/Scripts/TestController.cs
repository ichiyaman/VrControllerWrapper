using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _MyProject.Scripts.Tricol.Controller;

public class TestController : MonoBehaviour
{
	[SerializeField] private Text _textDebug; 
	
    // Start is called before the first frame update
    void Start()
    {
	    ControllerUtils.Init();
	    Debug.Log("Start end".Blue());	    
    }

    // Update is called once per frame
    void Update()
    {
	    string w = "" ;


        ///ebug.Log(ControllerUtils.RightHand.Position);


	    // Right --- 
	    if(ControllerUtils.RightHand.Trigger > 0f )
	    {
		    w += string.Format("RightHand.Trigger {0} \n" , ControllerUtils.RightHand.Trigger) ; 
	    }
	    if(ControllerUtils.RightHand.TriggerPress )
	    {
		    w += "RightHand.TriggerPress\n";
		    Debug.Log("Right TriggerPress");
	    }
	    if(ControllerUtils.RightHand.Button )
	    {
		    w += "RightHand.Button \n";
		    Debug.Log("Right Button");
	    }
	    if(ControllerUtils.RightHand.ButtonPress)
	    {
		    w += "RightHand.ButtonPress \n";
		    Debug.Log("RightHand.ButtonPress");
	    }
	    if(ControllerUtils.RightHand.Grip > 0f )
	    {
		    w += "RightHand.Grip \n";
		    Debug.Log("RightHand.Grip");
	    }
//	    if(ControllerUtils.RightHand.Action > 0f )
//	    {
//		    w += "RightHand.Action \n";
//		    ControllerUtils.RightHand.Haptics(null,null);
//		    Debug.Log("RightHand.Action");
//	    }
	    
	    // Left --- 
	    
	    if(ControllerUtils.LeftHand.Trigger > 0f )
	    {
		    w += string.Format("LeftHand.Trigger {0} \n" , ControllerUtils.LeftHand.Trigger) ; 
	    }
	    if(ControllerUtils.LeftHand.TriggerPress )
	    {
		    w += "LeftHand.TriggerPress\n"; 
		    Debug.Log("LeftHand.TriggerPress");
	    }
	    if(ControllerUtils.LeftHand.Button )
	    {
		    w += "LeftHand.Button\n"; 
		    Debug.Log("LeftHand.Button");
	    }
	    if(ControllerUtils.LeftHand.ButtonPress)
	    {
		    w += "LeftHand.ButtonPress\n"; 
		    Debug.Log("LeftHand.ButtonPress");
	    }
	    if(ControllerUtils.LeftHand.Grip > 0f)
	    {
		    w += "LeftHand.Grip \n";
		    Debug.Log("LeftHand.Grip");
	    }
//	    if(ControllerUtils.LeftHand.Action > 0f )
//	    {
//		    w += "LeftHand.Action \n";
//		    Debug.Log("LeftHand.Action");
//		    ControllerUtils.LeftHand.Haptics(null,null);
//	    }
	    _textDebug.text = w ; 


    }
}
