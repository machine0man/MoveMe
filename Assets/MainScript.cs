/*
I consume Input
*/
using UnityEngine;

namespace machineman.Game
{
	public class MainScript : MonoBehaviour
	{
		static MainScript s_Instance;

		public RectTransform gridPanParent, gridPanel;
		float screenWidth;


		public static int[] unitValues;
		public int score = 0;
		bool WasSomethingChanged = true; //shifting or Addition , true for first time

		public static int n = 4;     //default layout units
		public int[] positionsX, positionsY;

		public static RectTransform GridPanParent => s_Instance.gridPanParent;
		public static RectTransform GridPanel => s_Instance.gridPanel;

		#region Unity Methods
		void Awake()
		{
			s_Instance = this;
		}
		void OnDestroy()
		{
			s_Instance = null;
		}

		#endregion




		void StartGame()
		{
			score = 0;
			WasSomethingChanged = true;
			InitializeLevel(n);
			AddNewValue();                      //Create new Random Value
			UpdateGridView();
		}


		void InitializeLevel(int m)
		{
			screenWidth = gridPanParent.rect.width;  //Screen.Height
			Debug.Log("screeen Width : " + screenWidth);
			// gridPanel.sizeDelta = new Vector2 (screenWidth, screenWidth);
			//CalculatePositions(n);

			//Assuming n = 4
			unitValues = new int[n * n];
			for (int i = 0; i < n * n; i++)
			{
				unitValues[i] = 0;
			}
		}

		void CalculatePositions(int n)
		{
			positionsX = new int[n * n];
			positionsY = new int[n * n];

			float unitWidth = screenWidth / (float)n;


			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					positionsX[i * n + j] = 56;
					positionsY[i * n + j] = 56;



				}

			}


		}

		void Update()
		{
			if (InputManager.SwipeDir != ESwipeDir.None)
			{
				HandleSwipe(InputManager.SwipeDir);   //Changes UnitValues        
				InputManager.SwipeDir= ESwipeDir.None;   //SwipeConsumed


				AddNewValue();//Create new Random Value

				UpdateGridView();                   //Updates UI acc. to UnitValues
			}

			if (Input.GetKeyDown(KeyCode.R))
			{
				// admanScript.RunAd();
			}
		}
		void HandleSwipe(ESwipeDir swipeDir)
		{
			int[] tempArray = new int[n];  //To pass to SolvetheRow function

			switch (swipeDir)
			{
				case ESwipeDir.Up:
					for (int j = 0; j < n; j++)
					{
						for (int i = 0; i < n; i++) tempArray[i] = unitValues[j + i * n];  //creating n columns

						SolveTheRow(tempArray, swipeDir);

						for (int i = 0; i < n; i++) unitValues[j + i * n] = tempArray[i];
					}
					break;

				case ESwipeDir.Down:
					for (int j = 0; j < n; j++)
					{
						for (int i = 0; i < n; i++) tempArray[n - 1 - i] = unitValues[j + i * n];  //creating n columns

						SolveTheRow(tempArray, swipeDir);

						for (int i = 0; i < n; i++) unitValues[j + i * n] = tempArray[n - 1 - i];
					}
					break;

				case ESwipeDir.Left:
					for (int j = 0; j < n; j++)
					{
						for (int i = 0; i < n; i++) tempArray[i] = unitValues[i + j * n];  //creating n rows

						SolveTheRow(tempArray, swipeDir);

						for (int i = 0; i < n; i++) unitValues[i + j * n] = tempArray[i];
					}
					break;

				case ESwipeDir.Right:
					for (int j = 0; j < n; j++)
					{
						for (int i = 0; i < n; i++) tempArray[n - 1 - i] = unitValues[i + j * n];  //creating n rows

						SolveTheRow(tempArray, swipeDir);

						for (int i = 0; i < n; i++) unitValues[i + j * n] = tempArray[n - 1 - i];
					}
					break;
			}
		}

		void SolveTheRow(int[] uValues, ESwipeDir dir)  //or solve the column
		{
			// Algo
			int emptyIndex, needyIndex, Addend;
			emptyIndex = needyIndex = Addend = -1;

			for (int i = 0; i < n; i++)
			{
				if (uValues[i] != 0)   //unit has number
				{
					if (needyIndex != -1)   //someone needy
					{
						if (Addend == uValues[i])
						{
							//Add
							uValues[needyIndex]++;
							uValues[i] = 0;
							SetScore(Addend);
							WasSomethingChanged = true;
							Addend = -1;
							//Debug.Log(i + " one");

							if (emptyIndex == -1) //Note:there is no empty unit bw i and needyIndex
							{
								emptyIndex = needyIndex + 1;
								//Debug.Log(i + " two");
							}

							needyIndex = -1;
						}
						else//if (Addend != uValues[i])
						{
							if (emptyIndex == -1)
							{
								Addend = uValues[i];
								needyIndex = i;
								//Debug.Log(i + " three");
							}
							else    //empty space : shift to empty
							{
								uValues[emptyIndex] = uValues[i];
								WasSomethingChanged = true;
								uValues[i] = 0;

								//change needy
								needyIndex = emptyIndex;
								Addend = uValues[needyIndex];
								emptyIndex++;
								//Debug.Log(i + " four");
							}
						}
					}
					else //there is no needy ,  add new needy or shift
					{
						if (emptyIndex == -1)
						{
							needyIndex = i;
							Addend = uValues[i];
							//Debug.Log(i + " five");
						}
						else //shift and add new need
						{
							uValues[emptyIndex] = uValues[i];
							WasSomethingChanged = true;
							uValues[i] = 0;

							needyIndex = emptyIndex;
							emptyIndex++;
							Addend = uValues[needyIndex];
							//Debug.Log(i + " six");
						}
					}
				}
				else  //unit empty
				{
					if (emptyIndex == -1)
					{
						emptyIndex = i;
						//Debug.Log(i + " seven");  
					}
				}
			}



		}

		void SetScore(int addend)
		{
			score += (2 * addend);
			UIManager.UpdateScore(score);
		}

		void UpdateGridView()
		{
			//this.gameObject.GetComponent<UnitsTexts>().TextAllUnits();
			this.gameObject.GetComponent<UnitsColors>().ColorAllUnits();

		}

		void AddNewValue()
		{
			if (IsGridFull())
			{ if (!AnyMoveLeft()) GameOver(); }
			else
			{
				if (WasSomethingChanged)
				{
					Debug.Log("new value adding");
					int rIndex = GetRandomIndex();
					int rValue = GetRandomNumber();

					unitValues[rIndex] = rValue;
					WasSomethingChanged = false;
				}
			}
		}

		bool IsGridFull()
		{
			for (int i = 0; i < n * n; i++)
			{
				if (unitValues[i] == 0) return false;
			}
			Debug.Log("GRID FULL !");
			return true;
		}

		bool AnyMoveLeft()
		{
			//check any move in rows
			for (int i = 0; i < n * n; i++)
			{
				if (i % n != 3)
					if (unitValues[i] == unitValues[i + 1]) return true;
			}
			Debug.Log("no row move");
			//check any move in columns
			for (int i = 0; i < n - 1; i++)
				for (int j = 0; j < n; j++)
				{ if (unitValues[i * n + j] == unitValues[(i + 1) * n + j]) return true; }
			Debug.Log("no  move left");

			return false;


		}

		int GetRandomIndex()
		{
			int r;
			bool isUnitEmpty = false;
			do
			{
				r = Random.Range(0, n * n);
				if (unitValues[r] == 0) isUnitEmpty = true;

			} while (!isUnitEmpty);

			return r;
		}

		int GetRandomNumber()
		{
			int r = Random.Range(0, 20);
			if (r < 1) return 2;
			else return 1;
		}

		void GameOver()
		{

			Debug.Log("Game Over");
			UIManager.OnGameOver(score);
			//admanScript.RunAd();
		}

		void ResetGrid()
		{
			StartGame();
			UIManager.UpdateScore(0);



		}



		//Commands to UI
		public void StartNewGame()
		{
			ResetGrid();
			UIManager.OpenGamePanel();
		}

		//right now there is only one level
		public void OnPlayAgainButtonClick() => StartNewGame();

		public void OnHomeButtonClick()
		{
			ResetGrid();
			UIManager.OpenHomePanel();
		}

		public void OnSettingsButtonClick()
		{
			UIManager.OpenSettingsPanel();
		}

		public void OnBackButtonClick()
		{
			UIManager.OpenBackPanel();
		}
	}
}