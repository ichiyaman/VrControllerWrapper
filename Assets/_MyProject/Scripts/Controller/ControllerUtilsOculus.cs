using UnityEngine;
using System.Collections;
using UnityEngineInternal;

#if OCULUS
namespace _MyProject.Scripts.Tricol.Controller
{
	public class ControllerUtilsOculus : IControllerUtils
	{
		//--------------- for Oculus ---------------
		const string LEFT_ANCHOR_PATH  = "OVRCameraRig/TrackingSpace/LeftHandAnchor";
		const string RIGHT_ANCHOR_PATH = "OVRCameraRig/TrackingSpace/RightHandAnchor";
		const string HEAD_ANCHOR_PATH  = "OVRCameraRig/TrackingSpace/CenterEyeAnchor";
		//--------------- Left Controller --------------
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
	
		enum LastBits
		{
			BitTrigger = 1 << 0,
			BitButton = 1 << 1
		}
	
		private static LastBits _flgRightLast;
		private static LastBits _flgLeftLast;
		
	//	static bool _flgTrgPushedRightLast ;
	//	static bool _flgTrgPushedLeftLast ;
		
		/// <summary>
		/// call on awake need mandatory
		/// </summary>
		public override void Init()
		{
			_rightHandAnchor= GameObject.Find(RIGHT_ANCHOR_PATH) ;
			_leftHandAnchor = GameObject.Find(LEFT_ANCHOR_PATH) ;
			_rightVelocityTracker = GameObject.Find (RIGHT_ANCHOR_PATH).GetComponent<VelocityTracker> ();
			_leftVelocityTracker = GameObject.Find (LEFT_ANCHOR_PATH).GetComponent<VelocityTracker> ();
	
			_leftHand = new LeftController() ; 
			_rightHand = new RightController() ;
			
			Debug.Assert(RightHandAnchor != null); 
			Debug.Assert(LeftHandAnchor != null); 
	
			Debug.Log(_leftHand); 
			Debug.Log(_rightHand); 
			Debug.Log("ControllerUtilsOculus Init() end."); 
		}
	
		/// <summary>
		/// 左手
		/// </summary>
		public class LeftController : IOneController 
		{
			public override void Haptics(AudioClip clip, MonoBehaviour behaviour) {
				OVRHapticsClip hapticsClip = new OVRHapticsClip(clip);
				OVRHaptics.OVRHapticsChannel hapticsChannel = OVRHaptics.LeftChannel;
				hapticsChannel.Clear();
				hapticsChannel.Queue(hapticsClip);
			}
	
			public override float Trigger {
				get
				{
					return OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.Touch);
				}
			}
	
			public override bool TriggerPress {
				get
				{
					bool ret = false; 
					bool flgPush = (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.Touch) > 0f) ;
	
					if (flgPush && !(_flgLeftLast.HasFlag(LastBits.BitTrigger))) ret = true;
	
					if(flgPush)  _flgLeftLast |= LastBits.BitTrigger;
					else _flgLeftLast &= ~LastBits.BitTrigger;
	
					return ret; 
				}
			}
	
			public override bool Button {
				get 
				{
					return OVRInput.Get(OVRInput.RawButton.X) | OVRInput.Get(OVRInput.RawButton.Y);
				}
			}
			
			public override bool ButtonPress {
				get 
				{
					return OVRInput.GetDown(OVRInput.RawButton.X) | OVRInput.GetDown(OVRInput.RawButton.Y);
				}
			}
			
			// diarect ---- 
			
			public override bool ButtonThree {
				get 
				{
					return OVRInput.GetDown(OVRInput.Button.Three, OVRInput.Controller.Touch);
				}
			}
	
			public override bool ButtonFour {
				get
				{
					return OVRInput.GetDown(OVRInput.Button.Four, OVRInput.Controller.Touch); 
				}
			}
	
			public override bool Start {
				get
				{
					return OVRInput.GetDown(OVRInput.Button.Start, OVRInput.Controller.Touch);
				}
			}
	
			public override float Grab {
				get {
					return	OVRInput.Get (OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.Touch);
				}
			}
	
			public override float Action {
				get {
					return OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.Touch);
				}
			}
	
			public override float Pointer {
				get {
					return	OVRInput.Get (OVRInput.Button.Four, OVRInput.Controller.Touch) ? 1.0f : 0.0f; 
				}
			}
	
			public override float Grip {
				get {
					return OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.Touch);
				}
			}
			
			public override Vector3 Velocity {
				get {
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
				get {
					return OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
				}
			}
			
			public override bool StickGetDown {
				get
				{
					return OVRInput.GetDown(OVRInput.RawButton.LThumbstick);
					
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
				get {
					return _leftHandAnchor;
				}
			}
		}
	
		/// <summary>
		/// 右手
		/// </summary>
		public class RightController : IOneController {
			public override void Haptics(AudioClip clip, MonoBehaviour behaviour) {
				OVRHapticsClip hapticsClip = new OVRHapticsClip(clip);
				OVRHaptics.OVRHapticsChannel hapticsChannel = OVRHaptics.RightChannel;
				hapticsChannel.Clear();
				hapticsChannel.Queue(hapticsClip);
			}
	
			public override float Trigger {
				get {
					return OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) ;
				}
			}
	
			/// <summary>
			/// TriggerのTrigger push
			/// </summary>
			public override bool TriggerPress {
				get
				{
					bool ret = false; 
					bool flgPush = (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) > 0f) ; 
	
					if (flgPush && !(_flgRightLast.HasFlag(LastBits.BitTrigger))) ret = true;
	
					if(flgPush)  _flgRightLast |= LastBits.BitTrigger;
					else _flgRightLast &= ~LastBits.BitTrigger;
	
					return ret; 
				}
			}
			
			public override bool Button {
				get 
				{
					return OVRInput.Get(OVRInput.RawButton.A)|OVRInput.Get(OVRInput.RawButton.B);
				}
			}
			
			public override bool ButtonPress {
				get 
				{
					return OVRInput.GetDown(OVRInput.RawButton.A)|OVRInput.GetDown(OVRInput.RawButton.B);
				}
			}
	
			// diarect ---- 
			
			public override bool ButtonOne {
				get {
					return OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.Touch);
				}
			}
	
			public override bool ButtonOnePress {
				get {
					return OVRInput.Get (OVRInput.Button.One, OVRInput.Controller.Touch) ;
				}
			}
	
			public override bool ButtonTwo {
				get {
					return OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.Touch) ;
				}
			}
	
			public override float Grab {
				get {
					return OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch);
				}
			}
	
			public override float Action {
				get {
					
					return OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch);
	
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
					return OVRInput.Get (OVRInput.Button.Two, OVRInput.Controller.Touch) ? 1.0f : 0.0f;
				}
			}
	
			public override float Grip {
				get {
					return OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch);
				}
			}
	
			public override Vector3 Velocity {
				get
				{
					Debug.Assert(_rightVelocityTracker != null); 
					return _rightVelocityTracker.TrackedLinearVelocity;
				}
			}
	
			public override Vector3 AngularVelocity {
				get {
					Debug.Assert(_rightVelocityTracker != null); 
					return _rightVelocityTracker.TrackedAngularVelocity;
				}
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
				get {
					return OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
				}
			}
			
			public override bool StickGetDown {
				get
				{
					return OVRInput.GetDown(OVRInput.RawButton.RThumbstick);
				}
			}
		}
	}
}
#endif