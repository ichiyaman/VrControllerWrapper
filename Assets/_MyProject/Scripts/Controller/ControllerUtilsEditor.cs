using UnityEngine;
using System.Collections;

#if UNITY_EDITOR

namespace _MyProject.Scripts.Tricol.Controller
{
	/// <summary>
	/// Editor controller Input
	/// refrerence
	/// </summary>
	public class ControllerUtilsEditor : IControllerUtils
	{
		//--------------- Left Controller --------------
		static VelocityTracker _leftVelocityTracker, _rightVelocityTracker;
		
		public override VelocityTracker LeftVelocityTracker { get { return _leftVelocityTracker; }}
		public override VelocityTracker RightVelocityTracker { get { return _rightVelocityTracker; }}
	
		public override IOneController LeftHand { get { return _leftHand; }}
		public override IOneController RightHand { get	{ return _rightHand; }}
		public override GameObject LeftHandAnchor { get  { return _leftHandAnchor;}}
		public override GameObject RightHandAnchor { get { return  _rightHandAnchor;}}
		
		const string RIGHT_ANCHOR_PATH = "_Player/EditorDummy/RightHand";
		const string LEFT_ANCHOR_PATH  = "_Player/EditorDummy/LeftHand";
	
		public static bool _isRevertController ;
		
	//	static VelocityTracker _leftVelocityTracker;
	//	static VelocityTracker _rightVelocityTracker ;
	
		static IOneController _leftHand ;
		static IOneController _rightHand ;
		static GameObject _leftHandAnchor ;
		static GameObject _rightHandAnchor ;
		
	//	static int _flgRightLast = 0x0 ;
	//	static int _flgLeftLast = 0x0 ;
	//
	//	private const int BitTrigger = 1 << 0 ;
	//	private const int BitButton = 1 << 1;
		
		enum LastBits
		{
			BitTrigger = 1 << 0,
			BitButton = 1 << 1
		}
	
		private static LastBits _flgRightLast;
		private static LastBits _flgLeftLast;
		
		/// <summary>
		/// 起動時に必ず呼び出し
		/// </summary>
		public override void Init()
		{
			_rightHandAnchor= GameObject.Find(RIGHT_ANCHOR_PATH) ;
			_leftHandAnchor = GameObject.Find(LEFT_ANCHOR_PATH) ;
			//_rightVelocityTracker = GameObject.Find (RIGHT_ANCHOR_PATH).GetComponent<VelocityTracker> ();
	
			_leftHand = new LeftController() ; 
			_rightHand = new RightController() ;
	
			_rightVelocityTracker = null ; 
			_leftVelocityTracker =	null ;
	
			Debug.Log(_leftHand); 
			Debug.Log(_rightHand); 
			Debug.Log("ControllerUtilsPs4 Init() end.");
		}
		
		/// <summary>
		/// 左手
		/// </summary>
		public class LeftController : IOneController
		{
			int slot = 0;
			int controller = 1;
			
			public override void Haptics(AudioClip clip, MonoBehaviour behaviour) {
				Debug.Log("LeftController Haptics called."); 
			
	/*
				OVRHapticsClip hapticsClip = new OVRHapticsClip(clip);
				OVRHaptics.OVRHapticsChannel hapticsChannel = OVRHaptics.LeftChannel;
				hapticsChannel.Clear();
				hapticsChannel.Queue(hapticsClip);
	*/
			}
	
			public override bool Button {
				get { return (Input.GetKey(KeyCode.A)) ; }
			}
			public override bool ButtonPress {
				get { return (Input.GetKeyDown(KeyCode.A)) ; }
			}
			
			public override float Trigger {
				get { return (Input.GetKey(KeyCode.Z)) ? 1.0f : 0.0f  ; }
			}
			public override bool TriggerPress {
				get { return (Input.GetKeyDown(KeyCode.Z)) ; }
			}
	
			// diarect ---- 
			
			public override bool ButtonOne {
				get { return (Input.GetKeyDown(KeyCode.Alpha1)) ; }
			}
	
			public override bool ButtonTwo {
				get { return (Input.GetKeyDown(KeyCode.Alpha2)) ; }
			}
	
			public override bool ButtonThree {
				get { return (Input.GetKeyDown(KeyCode.Alpha3)) ; }
			}
	
			public override bool ButtonThreePress {
				get { return ButtonThree ; }
			}
	
			public override bool ButtonFour {
				get { return (Input.GetKeyDown(KeyCode.Alpha4)) ; }
			}
	
			public override bool Start {
				get { return (Input.GetKeyDown(KeyCode.A)) ; }
			}
	
			public override float Grab {
				get { return Trigger ; }
			}
	
			public override float Grip {
				get { return Trigger; }
			}
	
			public override float Action {
				get { return Trigger; }
			}
	
			public override float Pointer
			{
				get { return Trigger; }
			}
	
	/*
			public override float Grip {
				get { return 0f; }
			}
	*/
			
			public override Vector3 Velocity {
				get
				{
					Vector3 value;
					value = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch); 
					return value;
				}
			}
	
			public override Vector3 AngularVelocity {
				get {
					return OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch);
				}
			}
	
			public override Vector2 Stick {
				get
				{
					return Vector2.zero; 
	//				return OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
				}
			}
			
			public override bool StickGetDown {
				get
				{
					return false; 
	//				return OVRInput.GetDown(OVRInput.RawButton.LThumbstick);
	
				}
			}
			
			public override Vector3 Position {
				get
				{
					Debug.Assert( _leftHandAnchor != null) ; 
					return _leftHandAnchor.transform.position;
				}
			}
	
			public override GameObject GameObject {
				get { return _leftHandAnchor; }
			}
		}
	
		/// <summary>
		/// 右手
		/// </summary>
		public class RightController : IOneController {
			int slot = 0;
			int controller = 0;
			
			public override void Haptics(AudioClip clip, MonoBehaviour behaviour)
			{
				Debug.Log("RightController Haptics called."); 
	
	//			OVRHapticsClip hapticsClip = new OVRHapticsClip(clip);
	//			OVRHaptics.OVRHapticsChannel hapticsChannel = OVRHaptics.RightChannel;
	//			hapticsChannel.Clear();
	//			hapticsChannel.Queue(hapticsClip);
			}
	
	
			public override float Trigger {
				get { return (Input.GetKey(KeyCode.X)) ? 1.0f : 0.0f  ; }
			}
			public override bool TriggerPress {
				get { return (Input.GetKeyDown(KeyCode.X)) ; }
			}
			
			public override bool Button {
				get { return (Input.GetKey(KeyCode.S)) ; }
			}
			public override bool ButtonPress {
				get { return (Input.GetKeyDown(KeyCode.S)) ; }
			}
	
	
			// diarect ---- 
			
			public override bool ButtonOne {
				get { return (Input.GetKeyDown(KeyCode.Alpha5)) ; }
			}
	
			public override bool ButtonOnePress {
				get { return ButtonOne; }
			}
	
			public override bool ButtonTwo {
				get { return (Input.GetKeyDown(KeyCode.Alpha6)) ; }
			}
			
			public override bool ButtonThree {
				get { return (Input.GetKeyDown(KeyCode.Alpha7)) ; }
			}
	
			public override bool ButtonThreePress {
				get { return ButtonThree ; }
			}
	
			public override bool ButtonFour {
				get { return (Input.GetKeyDown(KeyCode.Alpha8)) ; }
			}
	
			public override bool Start {
				get { return (Input.GetKeyDown(KeyCode.S)) ; }
			}
			
			public override float Grab {
				get { return Trigger ; }
			}
	
			public override float Grip {
				get { return Trigger;  }
			}
			
			public override float Action {
				get { return Trigger;  }
			}
	
			public override float Pointer {
				get { return Trigger; }
			}
	
			public override Vector3 Velocity {
				get { return _rightVelocityTracker.TrackedLinearVelocity; }
			}
	
			public override Vector3 AngularVelocity {
				get { return _rightVelocityTracker.TrackedAngularVelocity; }
			}
	
			public override Vector3 Position {
				get {
					Debug.Assert(_rightHandAnchor != null); 
					return _rightHandAnchor.transform.position;
				}
			}
	
			public override GameObject GameObject {
				get {
					Debug.Assert(_rightHandAnchor != null); 
					return _rightHandAnchor;
				}
			}
			
			public override Vector2 Stick {
				get { return Vector2.zero; }
			}
			
			public override bool StickGetDown {
				get { return false;  }
			}
		}
	}	
}
#endif