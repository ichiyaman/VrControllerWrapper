using UnityEngine;
using System.Collections;
using UnityEngineInternal;

namespace _MyProject.Scripts.Tricol.Controller
{
	public static class ControllerUtils
	{
		public static IOneController PtrLeftHand
		{
			get { return _controllerUtils.LeftHand; }
		}
		public static IOneController PtrRightHand
		{
			get { return _controllerUtils.RightHand; }
		}

		private static IControllerUtils _controllerUtils ;	
		
		/// <summary>
		/// call on awake need mandatory
		/// </summary>
		public static void Init()
		{
#if OCULUS
			_controllerUtils = new ControllerUtilsOculus() ; 
#elif STEAM_VR
			_controllerUtils = new ControllerUtilsSteamVR() ;
#elif UNITY_EDITOR
			// PSVR not work on Editor 
			_controllerUtils = new ControllerUtilsEditor();
#elif UNITY_PS4
			_controllerUtils = new ControllerUtilsPs4();
#else
			_controllerUtils = new ControllerUtilsOpen() ;
#endif
	
			Debug.Assert(_controllerUtils != null); 
			
			_controllerUtils.Init();
			
			Debug.LogFormat("_controllerUtils.LeftHand {0}", _controllerUtils.LeftHand);
			Debug.LogFormat("_controllerUtils.RightHand {0}", _controllerUtils.RightHand);
			Debug.Log("ControllerUtils.Init() end.");
		}

		/// <summary>
		/// Left Hand
		/// </summary>
		public static class LeftHand  {
			
			public static void Haptics(AudioClip clip, MonoBehaviour behaviour) {
				_controllerUtils.LeftHand.Haptics(clip, behaviour);
			}
	
			// common ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- 
	
			public static bool Button {
				get { return _controllerUtils.LeftHand.Button;}
			}
			
			public static bool ButtonPress {
				get { return _controllerUtils.LeftHand.ButtonPress;}
			}
			
			public static float Trigger {
				get {
					return _controllerUtils.LeftHand.Trigger ;
				}
			}
	
			/// TriggerのTrigger push
			public static bool TriggerPress {
				get { return _controllerUtils.LeftHand.TriggerPress ; }
			}
	
			// diarect ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- 
			
			public static bool ButtonOne {
				get { return _controllerUtils.LeftHand.ButtonOne;}
			}
			
			public static bool ButtonOnePress {
				get { return _controllerUtils.LeftHand.ButtonOnePress;}
			}
	
			public static bool ButtonTwo {
				get { return _controllerUtils.LeftHand.ButtonTwo;}
			}
			
			public static bool ButtonThree {
				get { return _controllerUtils.LeftHand.ButtonThree;}
			}
			
			public static bool ButtonThreePress {
				get { return _controllerUtils.LeftHand.ButtonThreePress; }
			}
			
			public static bool ButtonFour {
				get{ return _controllerUtils.LeftHand.ButtonFour; }
			}
	
			public static bool Start {
				get　{ return _controllerUtils.LeftHand.Start; }
			}
	
			public static float Grab {
				get {return  _controllerUtils.LeftHand.Grab ; }
			}
	
			public static float Grip {
				get {return  _controllerUtils.LeftHand.Grip ; }
			}
	
			public static float Action {
				get { return _controllerUtils.LeftHand.Action; }
			}
	
			public static float Pointer {
				get { return _controllerUtils.LeftHand.Pointer ; }
			}
	
	
	/*	 mean Grab ? 
			public static float Grip { 
				get { return _controllerUtils.LeftHand.Grip ; }
			}
	*/
		
			public static Vector3 Velocity {
				get { return _controllerUtils.LeftHand.Velocity ; }
			}
	
			public static Vector3 AngularVelocity {
				get { return _controllerUtils.LeftHand.AngularVelocity ; }
			}
	
			public static Vector2 Stick {
				get { return _controllerUtils.LeftHand.Stick ; }
			}
			
			public static bool StickGetDown {
				get { return _controllerUtils.LeftHand.StickGetDown ; }
			}
			
			public static Vector3 Position {
				get { return _controllerUtils.LeftHand.Position ; }
			}
	
			public static GameObject GameObject {
				get { return _controllerUtils.LeftHand.GameObject ; }
			}
		}
	
		/// <summary>
		/// Right hand
		/// </summary>
		public static class RightHand {
			public static void Haptics(AudioClip clip, MonoBehaviour behaviour) {
				_controllerUtils.RightHand.Haptics(clip, behaviour);
			}
	
			// common ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- 
	
			public static float Trigger {
				get { return _controllerUtils.RightHand.Trigger; }
			}
	
			/// TriggerのTrigger push
			public static bool TriggerPress {
				get { return _controllerUtils.RightHand.TriggerPress; }
			}
	
			public static bool Button {
				get { return _controllerUtils.RightHand.Button; }
			}
	
			public static bool ButtonPress {
				get { return _controllerUtils.RightHand.ButtonPress; }
			}
			
			// diarect ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- 
			
			public static bool ButtonOne {
				get { return _controllerUtils.RightHand.ButtonOne; }
			}
	
			public static bool ButtonOnePress {
				get { return _controllerUtils.RightHand.ButtonOnePress; }
			}
	
			public static bool ButtonTwo {
				get { return _controllerUtils.RightHand.ButtonTwo; }
			}
	
			public static bool ButtonThree {
				get { return _controllerUtils.RightHand.ButtonThree;}
			}
			
			public static bool ButtonThreePress {
				get { return _controllerUtils.RightHand.ButtonThreePress; }
			}
			
			public static bool ButtonFour {
				get{ return _controllerUtils.RightHand.ButtonFour; }
			}
	
			public static bool Start {
				get　{ return _controllerUtils.RightHand.Start; }
			}
			
			public static float Grab {
				get { return _controllerUtils.RightHand.Grab; }
			}
	
			public static float Grip {
				get { return _controllerUtils.RightHand.Grip; }
			}
	
			public static float Action {
				get { return _controllerUtils.RightHand.Action; }
			}
	
			public static float Pointer {
				get { return _controllerUtils.RightHand.Pointer; }
			}
	
	/* Grab?
			public static float Grip {
				get { return _controllerUtils.RightHand.Grip; }
			}
	*/
	
			public static Vector3 Velocity {
				get { return _controllerUtils.RightHand.Velocity; }
			}
	
			public static Vector3 AngularVelocity {
				get { return _controllerUtils.RightHand.AngularVelocity; }
			}
	
			public static Vector3 Position {
				get { return _controllerUtils.RightHand.Position; }
			}
	
			public static GameObject GameObject {
				get { return _controllerUtils.RightHand.GameObject; }
			}
			
			public static Vector2 Stick {
				get { return _controllerUtils.RightHand.Stick; }
			}
			
			public static bool StickGetDown {
				get { return _controllerUtils.RightHand.StickGetDown; }
			}
		}
	}
}
