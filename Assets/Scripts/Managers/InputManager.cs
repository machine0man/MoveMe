/*
This Script is a Producer Script . It produces variables to be consumed by other scripts.
*/
using UnityEngine;

namespace machineman.Game
{
	public class InputManager : MonoBehaviour
	{
		static InputManager s_Instance;

		[SerializeField] float m_minScreenSwipePrcnt = 0.02f;
		[SerializeField] bool m_debugInputs;

		ESwipeDir m_SwipeDir = ESwipeDir.None;

		Touch m_touch;
		Vector2 m_position0, m_position1;
		float m_minDist;
		bool m_IsSwipeDone = false;

		public static ESwipeDir SwipeDir
		{
			get =>  s_Instance.m_SwipeDir;
			set => s_Instance.m_SwipeDir = value;
		}
		void Awake()
		{
			s_Instance = this;
			m_minDist = m_minScreenSwipePrcnt * Screen.height;
		}
		void OnDestroy()
		{
			s_Instance = null;
		}
		void Update()
		{
			//Keyboard Inputs for testing in editor
#if UNITY_EDITOR
			HandleKeyboardInputs();
#else
			//Touch Inputs
			if (Input.touchCount == 1)
				GetSwipeDirection();
#endif
		}

		/*
		Change Swipe.none to swipe.direction after user swiped "minpercent" height of the screen even if user 
		didn't picked his finger up from the screen
		*/
		void GetSwipeDirection()
		{
			m_touch = Input.GetTouch(0);
			if (m_touch.phase == TouchPhase.Began)
			{
				m_position0 = m_touch.position;
				m_position1 = m_touch.position;
			}
			else if (m_touch.phase == TouchPhase.Moved)
			{
				if (!m_IsSwipeDone)
				{
					m_position1 = m_touch.position;
					float l_distX = m_position1.x - m_position0.x;
					float l_distY = m_position1.y - m_position0.y;
					if (Mathf.Abs(l_distX) > m_minDist || Mathf.Abs(l_distY) > m_minDist)  //swiped more than min dist
					{
						if (Mathf.Abs(l_distX) > Mathf.Abs(l_distY)) // horizontal swipe
						{
							if (l_distX < 0) m_SwipeDir = ESwipeDir.Left;
							else m_SwipeDir = m_SwipeDir = ESwipeDir.Right;
						}
						else  //Vertical Swipe
						{
							if (l_distY < 0) m_SwipeDir = ESwipeDir.Down;
							else m_SwipeDir = m_SwipeDir = ESwipeDir.Up;
						}
						m_IsSwipeDone = true;
					}
				}
			}
			else if (m_touch.phase == TouchPhase.Ended)
			{
				m_IsSwipeDone = false;
			}
		}
		void HandleKeyboardInputs()
		{
			if (Input.GetKeyDown(KeyCode.UpArrow)) { m_SwipeDir = ESwipeDir.Up; if (m_debugInputs) Debug.Log("up"); }
			else if (Input.GetKeyDown(KeyCode.DownArrow)) { m_SwipeDir = ESwipeDir.Down; if (m_debugInputs) Debug.Log("down"); }
			else if (Input.GetKeyDown(KeyCode.LeftArrow)) { m_SwipeDir = ESwipeDir.Left; if (m_debugInputs) Debug.Log("left"); }
			else if (Input.GetKeyDown(KeyCode.RightArrow)) { m_SwipeDir = ESwipeDir.Right; if (m_debugInputs) Debug.Log("right"); }
		}
	}
}