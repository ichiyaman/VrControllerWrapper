using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngineInternal;
using Valve.VR;

//using Valve.VR;

#if STEAM_VR

namespace _MyProject.Scripts.Tricol.Controller
{
	/// <summary>
	/// ControllerUtilsSteamVR
	///   Plugin version2
	///
	/// https://www.vive.com/jp/support/vive/category_howto/about-the-controllers.html
	///
	/// 1	menu button 	   = Menu,ButtonFour
	/// 2	track pad		   = TouchPad
	/// 3	system button	   = Start,ButtonThree
	/// 4	status light	   =
	/// 5	micro-USB port	   =
	/// 6	tracking sensor    =
	/// 7	trigger 		   = Trigger,Action
	/// 8	grip			   = Grip
	/// </summary>
	public class ControllerUtilsSteamVR : IControllerUtils
	{
		const string LEFT_ANCHOR_PATH = "[CameraRig]/Controller (left)";
		const string RIGHT_ANCHOR_PATH = "[CameraRig]/Controller (right)";
		const string HEAD_ANCHOR_PATH = "[CameraRig]/Camera";

		private bool _flgTrgPushedLast;


		SteamVR_TrackedObject viveTrackedObjectRight, viveTrackedObjectLeft;

		public override VelocityTracker LeftVelocityTracker { get { return _leftVelocityTracker; } }
		public override VelocityTracker RightVelocityTracker { get { return _rightVelocityTracker; } }

		public override IOneController LeftHand { get { return _leftHand; } }
		public override IOneController RightHand { get { return _rightHand; } }
		public override GameObject LeftHandAnchor { get { return _leftHandAnchor; } }
		public override GameObject RightHandAnchor { get { return _rightHandAnchor; } }

		static VelocityTracker _leftVelocityTracker;
		static VelocityTracker _rightVelocityTracker;

		static IOneController _leftHand;
		static IOneController _rightHand;
		static GameObject _leftHandAnchor;
		static GameObject _rightHandAnchor;

		//	  const float VIVE_CONTROLLER_VELOCITY_MULTI = 1.6f;
		//----------------------------------------


		//static void ControllerUtilsSteamVR() // << static class constructor not working

		/// <summary>
		/// 起動時に必ず呼び出し
		/// </summary>
		public override void Init() 
		{
			_leftHandAnchor = GameObject.Find(LEFT_ANCHOR_PATH);
			_rightHandAnchor = GameObject.Find(RIGHT_ANCHOR_PATH);

			Debug.Assert(_leftHandAnchor!=null, "_leftHandAnchor!=null"); 
			Debug.Assert(_rightHandAnchor!=null, "_rightHandAnchor!=null"); 

			_leftVelocityTracker = _leftHandAnchor.GetComponent<VelocityTracker>();
			_rightVelocityTracker = _rightHandAnchor.GetComponent<VelocityTracker>();

			viveTrackedObjectRight = RightHandAnchor.GetComponent<SteamVR_TrackedObject>();
			//viveDeviceRight = SteamVR_Controller.Input((int)viveTrackedObjectRight.index);

			viveTrackedObjectLeft = LeftHandAnchor.GetComponent<SteamVR_TrackedObject>();
			//viveDeviceLeft = SteamVR_Controller.Input((int)viveTrackedObjectLeft.index);

			_leftHand = new LeftController();
			_rightHand = new RightController();

			Debug.Assert(RightHandAnchor != null, "RightHandAnchor != null");
			Debug.Assert(LeftHandAnchor != null, "LeftHandAnchor != null");

			Debug.Assert(_rightVelocityTracker != null, "_rightVelocityTracker != null");
			Debug.Assert(_leftVelocityTracker != null, "_leftVelocityTracker != null");

			Debug.Assert(_leftHand != null, "_leftHand != null");
			Debug.Assert(_rightHand != null, "_rightHand != null");

			Debug.Log("ControllerUtilsSteamVR Init() end.");
		}


		public class CommonController : IOneController
		{
			protected SteamVR_Action_Vibration haptic = SteamVR_Actions._default.Haptic;
			protected SteamVR_Input_Sources HandType = SteamVR_Input_Sources.Any;

			public override void Haptics(AudioClip clip, MonoBehaviour behaviour)
			{
				//OVRHapticsClip hapticsClip = new OVRHapticsClip(clip);
				//OVRHaptics.OVRHapticsChannel hapticsChannel = OVRHaptics.LeftChannel;
				//hapticsChannel.Clear();
				//hapticsChannel.Queue(hapticsClip);

				haptic.Execute(0, 0.1f, 60, 1, HandType);
			}

			public override bool Button {
				get 
				{
					return SteamVR_Actions._default.Teleport.GetState(HandType);
				}
			}
			
			public override bool ButtonPress {
				get 
				{
					return SteamVR_Actions._default.Teleport.GetStateDown(HandType);
				}
			}

			
			public override bool ButtonThree
			{
				get
				{
					//return SteamVR_Actions._default.Menu.GetStateDown(HandType);
					return false;
				}
			}

			public override bool ButtonThreePress
			{
				get
				{
					//return SteamVR_Actions._default.Menu.GetState(HandType);
					return false;
				}
			}

			public override bool ButtonFour
			{
				get
				{
					return false;
				}
			}

			public override bool Start
			{
				get
				{
					return false;
				}
			}

			public override float Action
			{
				get
				{
					//Debug.Log("teleport:" + SteamVR_Actions._default.Teleport.GetStateDown(HandType));
					//return teleportAction.GetStateUp(HandType);?1f:0f;
					//return SteamVR_Actions.default_Teleport.GetState(HandType)?1f:0f;
					return SteamVR_Actions._default.Teleport.GetStateDown(HandType)?1f:0f;
				}
			}

			// same Grab,Trigger,Pointer
			public override float Grab
			{
				get
				{
					return SteamVR_Actions._default.Squeeze.GetAxis(HandType);
				}
			}

			// same Grab,Trigger,Pointer
			public override float Pointer
			{
				get
				{
					return SteamVR_Actions._default.Squeeze.GetAxis(HandType);
				}
			}

			// same Grab,Trigger,Pointer
			public override float Trigger
			{
				get
				{
					return SteamVR_Actions._default.Squeeze.GetAxis(HandType);
				}
			}

			public override float Grip
			{
				get
				{
					//Debug.Log("Left Grip" + SteamVR_Actions._default.GrabGrip.GetStateDown(HandType));
					return SteamVR_Actions._default.GrabGrip.GetStateDown(HandType) ? 1.0f : 0.0f;
				}
			}

			public override Vector3 Velocity
			{
				get
				{
					return _leftVelocityTracker.TrackedLinearVelocity;
				}
			}

			public override Vector3 AngularVelocity
			{
				get
				{
					return _leftVelocityTracker.TrackedAngularVelocity;
				}
			}

			public override Vector3 Position
			{
				get
				{
					return _leftHandAnchor.transform.position;
				}
			}

	   }
		
		public class LeftController : CommonController
		{
			public LeftController()
			{
				HandType = SteamVR_Input_Sources.LeftHand;
			}
			
			public override GameObject GameObject
			{
				get
				{
					return _leftHandAnchor;
				}
			}
			
		}

		public class RightController : CommonController
		{
			public RightController()
			{
				HandType = SteamVR_Input_Sources.RightHand;
			}
			
			public override GameObject GameObject
			{
				get
				{
					return _rightHandAnchor;
				}
			}
			
		}
	}
}

#endif
