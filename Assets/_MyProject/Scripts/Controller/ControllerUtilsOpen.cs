using UnityEngine;
using System.Collections;
using UnityEngineInternal;

namespace _MyProject.Scripts.Tricol.Controller
{
	public class ControllerUtilsOpen : IControllerUtils
	{
		const string LEFT_ANCHOR_PATH  = "SteamCameraRig/Controller (left)";
		const string RIGHT_ANCHOR_PATH = "SteamCameraRig/Controller (right)";
		const string HEAD_ANCHOR_PATH  = "SteamCameraRig/Controller (eye)";
		
		public override VelocityTracker LeftVelocityTracker { get { return _leftVelocityTracker; }}
		public override VelocityTracker RightVelocityTracker { get { return _rightVelocityTracker;}}
	
		public override IOneController LeftHand { get { return _leftHand; }}
		public override IOneController RightHand { get	{ return _rightHand; }}
		public override GameObject LeftHandAnchor { get  { return _leftHandAnchor;}}
		public override GameObject RightHandAnchor { get { return  _rightHandAnchor;}}
	
		static VelocityTracker _leftVelocityTracker;
		static VelocityTracker _rightVelocityTracker ;
	
		static IOneController _leftHand ;
		static IOneController _rightHand ;
		static GameObject _leftHandAnchor ;
		static GameObject _rightHandAnchor ;
		
		bool _flgTrgPushedRightLast ;
		bool _flgTrgPushedLeftLast ;
	
		/// <summary>
		/// call on awake need mandatory
		/// </summary>
		public override void Init()
		{
			_rightHandAnchor= GameObject.Find(RIGHT_ANCHOR_PATH) ;
			_leftHandAnchor = GameObject.Find(LEFT_ANCHOR_PATH) ;
			
			_leftVelocityTracker = GameObject.Find (LEFT_ANCHOR_PATH).GetComponent<VelocityTracker> ();
			_leftHandAnchor = GameObject.Find(LEFT_ANCHOR_PATH);
			
			_rightVelocityTracker = GameObject.Find (RIGHT_ANCHOR_PATH).GetComponent<VelocityTracker> ();
			
			_leftHand = new LeftController() ; 
			_rightHand = new RightController() ;
			
			Debug.Assert(RightHandAnchor != null); 
			Debug.Assert(LeftHandAnchor != null); 
			Debug.Assert(_rightVelocityTracker != null);
	
			Debug.Log(_leftHand); 
			Debug.Log(_rightHand); 
			Debug.Log("ControllerUtilsOpen Init() end."); 
			
		}
		//--------------- Left Controller --------------
		public class LeftController : IOneController {
			public override  void Haptics(AudioClip clip, MonoBehaviour behaviour) {
				// not implement
			}
	
			public override bool ButtonThree {
				get {
					return	Input.GetButtonDown ("OpenVR_LTouchPadClick");
				}
			}
	
			public override bool ButtonThreePress {
				get {
					return Input.GetButton ("OpenVR_LTouchPadClick");
				}
			}
	
			public override bool ButtonFour {
				get {
					return Input.GetButtonDown ("OpenVR_LAppMenu");
				}
			}
	
			public override bool Start {
				get {
					return Input.GetButtonDown ("OpenVR_LAppMenu");
				}
			}
	
			public override float Grab {
				get {
	//				float value = PlatformManager.instance.deviceType == PlatformManager.DeviceType.RiftTouch ? OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.Touch) : Input.GetAxis ("OpenVR_LTrigger");
					return Input.GetAxis ("OpenVR_LTrigger");
				}
			}
	
			public override float Action {
				get {
	
					return Input.GetButton ("OpenVR_LTouchPadClick") ? 1.0f : 0.0f;
	
	//				bool value;
	//				if (PlatformManager.instance.platformType == PlatformManager.PlatformType.Oculus) {
	//					value = OVRInput.Get (OVRInput.Button.Four, OVRInput.Controller.Touch);
	//				} else {
	//					value = PlatformManager.instance.deviceType == PlatformManager.DeviceType.RiftOpenVR ? Input.GetButton ("OculusTouch_ButtonFour") : Input.GetButton ("OpenVR_LTouchPadClick");
	//				}
	//				return value ? 1.0f : 0.0f;
				}
			}
	
			public override float Pointer {
				get {
					return Input.GetButton ("OpenVR_LTouchPadClick") ? 1.0f : 0.0f;
				}
			}
	
			public override float Trigger {
				get {
					return Input.GetAxis("OpenVR_LTrigger");
				}
			}
	
			public override float Grip {
				get {
					return Input.GetAxis ("OpenVR_LGrip");
				}
			}
	
	
			public override Vector3 Velocity {
				get {
					return _leftVelocityTracker.TrackedLinearVelocity;
				}
			}
	
			public override Vector3 AngularVelocity {
				get {
					return _leftVelocityTracker.TrackedAngularVelocity;
				}
			}
	
			public override Vector3 Position {
				get {
					return _leftHandAnchor.transform.position;
				}
			}
	
			public override GameObject GameObject {
				get {
					return _leftHandAnchor;
				}
			}
		}
	
		public class RightController  : IOneController {
			public override  void Haptics(AudioClip clip, MonoBehaviour behaviour) {
				OVRHapticsClip hapticsClip = new OVRHapticsClip(clip);
				OVRHaptics.OVRHapticsChannel hapticsChannel = OVRHaptics.LeftChannel;
				hapticsChannel.Clear();
				hapticsChannel.Queue(hapticsClip);
			}
	
			public override bool ButtonOne {
				get {
					return Input.GetButtonDown ("OpenVR_RTouchPadClick");
				}
			}
	
			public override bool ButtonOnePress {
				get {
					return Input.GetButton ("OpenVR_RTouchPadClick");
				}
			}
	
			public override bool ButtonTwo {
				get {
					return Input.GetButtonDown ("OpenVR_RAppMenu");
				}
			}
	
			public override float Grab {
				get {
	//				float value = PlatformManager.instance.deviceType == PlatformManager.DeviceType.RiftTouch ? OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) : Input.GetAxis ("OpenVR_RTrigger");
					return Input.GetAxis ("OpenVR_RTrigger");
				}
			}
	
			public override float Action {
				get {
					return Input.GetButton ("OpenVR_RTouchPadClick") ? 1.0f : 0.0f;
	
	//				bool value;
	//				if (PlatformManager.instance.platformType == PlatformManager.PlatformType.Oculus) {
	//					value = OVRInput.Get (OVRInput.Button.Two, OVRInput.Controller.Touch);
	//				} else {
	//					value = PlatformManager.instance.deviceType == PlatformManager.DeviceType.RiftOpenVR ? Input.GetButton ("OculusTouch_ButtonTwo") : Input.GetButton ("OpenVR_RTouchPadClick");
	//				}
	//				return value ? 1.0f : 0.0f;
				}
			}
	
			public override float Pointer {
				get {
					return Input.GetButton ("OpenVR_RTouchPadClick") ? 1.0f : 0.0f;
				}
			}
	
			public override float Trigger {
				get {
					return Input.GetAxis ("OpenVR_RTrigger");
				}
			}
	
			public override float Grip {
				get {
					return Input.GetAxis ("OpenVR_RGrip");
				}
			}
	
			public override Vector3 Velocity {
				get
				{
					Debug.Assert(_rightVelocityTracker!=null);
					return _rightVelocityTracker.TrackedLinearVelocity;
				}
			}
	
			public override Vector3 AngularVelocity {
				get {
					Debug.Assert(_rightVelocityTracker!=null);
					return _rightVelocityTracker.TrackedAngularVelocity;
				}
			}
	
			public override Vector3 Position {
				get {
					Debug.Assert(_rightHandAnchor!=null);
					return _rightHandAnchor.transform.position;
				}
			}
	
			public override GameObject GameObject {
				get {
					Debug.Assert(_rightHandAnchor!=null);
					return _rightHandAnchor;
				}
			}
		}
	}
}
