using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

    [RequireComponent(typeof (CharacterController))]
    [RequireComponent(typeof (AudioSource))]
    public class FirstPersonController : MonoBehaviour
    {

		//Crouching Variables
		[SerializeField] public float m_CrouchHeight;
		[SerializeField] public float m_StandardHeight;
		[SerializeField] public bool m_Crouching;

		//Walking & Running Variables
        [SerializeField] public bool m_IsWalking;
        [SerializeField] public float m_WalkSpeed;
        [SerializeField] public float m_RunSpeed;
        [SerializeField] [Range(0f, 1f)] public float m_RunstepLenghten;


        [SerializeField] public float m_StickToGroundForce;
        [SerializeField] public float m_GravityMultiplier;
        [SerializeField] public MouseLook m_MouseLook;

		//Head & Step Movemment Variables
        [SerializeField] public bool m_UseHeadBob;
        [SerializeField] public CurveControlledBob m_HeadBob = new CurveControlledBob();
        [SerializeField] public LerpControlledBob m_JumpBob = new LerpControlledBob();
        [SerializeField] public float m_StepInterval;

		//Audio Variables
        [SerializeField] public AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
		[SerializeField] public AudioClip m_CrawlingSound;

        public Camera m_Camera;
        public float m_YRotation;
        public Vector2 m_Input;
        public Vector3 m_MoveDir = Vector3.zero;
        public CharacterController m_CharacterController;
        public CollisionFlags m_CollisionFlags;
        public Vector3 m_OriginalCameraPosition;
        public float m_StepCycle;
        public float m_NextStep;
        public AudioSource m_AudioSource;

		public bool yes;

		// Use this for initialization
        public void Start()
        {
            m_CharacterController = GetComponent<CharacterController>();
            m_Camera = Camera.main;
            m_OriginalCameraPosition = m_Camera.transform.localPosition;
            m_HeadBob.Setup(m_Camera, m_StepInterval);
            m_StepCycle = 0f;
            m_NextStep = m_StepCycle/2f;
            m_AudioSource = GetComponent<AudioSource>();
			m_MouseLook.Init(transform , m_Camera.transform);

			//Crouching
			m_StandardHeight = m_CharacterController.height;
			m_CrouchHeight = m_CharacterController.height/2;
			m_Crouching = false;
			yes = true;
		
        }


        // Update is called once per frame
        public void Update()
        {
		
				RotateView ();
		

				if (m_CharacterController.isGrounded && !m_Crouching) {
					StartCoroutine (m_JumpBob.DoBobCycle ());
					m_MoveDir.y = 0f;
				}
				if (!m_CharacterController.isGrounded && !m_Crouching) {
					m_MoveDir.y = 0f;
				}

				if (Input.GetKeyDown ("c")) {
					if (m_Crouching) {
						m_CharacterController.height = m_StandardHeight;
						m_CharacterController.center = new Vector3 (0, 0, 0);
						m_OriginalCameraPosition.y += m_CrouchHeight;
						m_WalkSpeed = 3;
						m_Crouching = false;
						return;
					}
					if (!m_Crouching) {
						Crouch ();
					}
					
				}
		} 


		public void Crouch()
		{
			m_CharacterController.height = m_CrouchHeight;
			m_CharacterController.center = new Vector3 (0, -0.5f, 0);
			m_OriginalCameraPosition.y -= m_CrouchHeight;
			m_WalkSpeed = 1;
			m_Crouching = true;
			m_IsWalking = false;

		}


        public void FixedUpdate()
        {

			if (yes) 
			{
				float speed;
				GetInput (out speed);
				// always move along the camera forward as it is the direction that it being aimed at
				Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;

				// get a normal for the surface that is being touched to move along it
				RaycastHit hitInfo;
				Physics.SphereCast (transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
	                               m_CharacterController.height / 2f);
				desiredMove = Vector3.ProjectOnPlane (desiredMove, hitInfo.normal).normalized;

				m_MoveDir.x = desiredMove.x * speed;
				m_MoveDir.z = desiredMove.z * speed;


				if (m_CharacterController.isGrounded && !m_Crouching) {
					m_MoveDir.y = -m_StickToGroundForce;

				} else {
					m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
				}
				m_CollisionFlags = m_CharacterController.Move (m_MoveDir * Time.fixedDeltaTime);

				ProgressStepCycle (speed);
				UpdateCameraPosition (speed);
			} 
			else if (!yes) 
			{
				Debug.Log("Inspecting");
			}
			
	}

        public void ProgressStepCycle(float speed)
        {
            if (m_CharacterController.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
            {
                m_StepCycle += (m_CharacterController.velocity.magnitude + (speed*(m_IsWalking ? 1f : m_RunstepLenghten)))*
                             Time.fixedDeltaTime;
            }

            if (!(m_StepCycle > m_NextStep))
            {
                return;
            }

            m_NextStep = m_StepCycle + m_StepInterval;

            PlayFootStepAudio();
        }


        public void PlayFootStepAudio()
        {
            if (m_Crouching)
            {
				m_AudioSource.clip = m_CrawlingSound;
				m_AudioSource.PlayOneShot (m_AudioSource.clip);

            }
            // pick & play a random footstep sound from the array,
            // excluding sound at index 0
            if (m_CharacterController.isGrounded && !m_Crouching) 
			{
				int n = Random.Range (1, m_FootstepSounds.Length);
				m_AudioSource.clip = m_FootstepSounds [n];
				m_AudioSource.PlayOneShot (m_AudioSource.clip);
				// move picked sound to index 0 so it's not picked next time
				m_FootstepSounds [n] = m_FootstepSounds [0];
				m_FootstepSounds [0] = m_AudioSource.clip;
			}
        }


        public void UpdateCameraPosition(float speed)
        {
            Vector3 newCameraPosition;
            if (!m_UseHeadBob)
            {
                return;
            }
            if (m_CharacterController.velocity.magnitude > 0 && m_CharacterController.isGrounded && !m_Crouching)
            {
                m_Camera.transform.localPosition =
                    m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
                                      (speed*(m_IsWalking ? 1f : m_RunstepLenghten)));
                newCameraPosition = m_Camera.transform.localPosition;
                newCameraPosition.y = m_Camera.transform.localPosition.y - m_JumpBob.Offset();
            }
            else
            {
                newCameraPosition = m_Camera.transform.localPosition;
                newCameraPosition.y = m_OriginalCameraPosition.y - m_JumpBob.Offset();
            }
            m_Camera.transform.localPosition = newCameraPosition;
        }


        public void GetInput(out float speed)
        {
            // Read input
            float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            float vertical = CrossPlatformInputManager.GetAxis("Vertical");


#if !MOBILE_INPUT
            // On standalone builds, walk/run speed is modified by a key press.
            // keep track of whether or not the character is walking or running
            m_IsWalking = !Input.GetKey(KeyCode.LeftShift);
#endif
            // set the desired speed to be walking or running
            speed = m_IsWalking ? m_WalkSpeed : m_RunSpeed;
            m_Input = new Vector2(horizontal, vertical);

            // normalize input if it exceeds 1 in combined length:
            if (m_Input.sqrMagnitude > 1)
            {
                m_Input.Normalize();
            }

        }


        public void RotateView()
        {
			if (yes) {
				m_MouseLook.LookRotation (transform, m_Camera.transform);
			}
			else if (!yes) 
			{
				Debug.Log ("Inspecting");
			}
		}

		


//        public void OnControllerColliderHit(ControllerColliderHit hit)
//        {
//            Rigidbody body = hit.collider.attachedRigidbody;
//            //dont move the rigidbody if the character is on top of it
//            if (m_CollisionFlags == CollisionFlags.Below)
//            {
//                return;
//            }
//
//            if (body == null || body.isKinematic)
//            {
//                return;
//            }
//            body.AddForceAtPosition(m_CharacterController.velocity*0.1f, hit.point, ForceMode.Impulse);
//        }
	}
   
