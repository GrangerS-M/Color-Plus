using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	//I worked on this programming together with Zofia

	public GameObject cubePreFab;
	Vector3 cubePosition;
	GameObject [,] grid;
	int gridX, gridY;
	float gameLength = 60;
	float turnLength = 2.0f;
	int turns;
	int nextCubeX, nextCubeY;


	//spawns a new cube of a random color
	void SpawnNextCube () {
		Instantiate (cubePreFab, new Vector3 (nextCubeX, nextCubeY, 0), Quaternion.identity);

	}

	//	int FindEmptyColumn (int y) {
	//
	//	}

	void EndGame (){

	}

	//	int[] FindEmptySpace (){
	//
	//	}

	void ScoreSameColorPlus () {

	}

	void ScoreAllColorPlus () {

	}

	void ProcessClick (GameObject clickedCube, int x, int y) {

		//if clicked cube is colored an not active, activate it
		//if clicked cube is colored an active, deactivate it
		//if a cube is active and next cube clicked is adjacent and white, switch the cubes

	}


	//checks for keyboard inputs
	void ProcessKeyboard (){
		//check for 1-5
		//if 1-5 input, checks for empty space in that row
		//change cube color from white to color of current "next cube"
		//removes cube considered "next cube"
		//else if no open spaces end game


	}


	// Use this for initialization
	void Start () {

		turns = 0;
		gridX = 8;
		gridY = 5;
		grid = new GameObject[gridX, gridY];

		nextCubeX = -1;
		nextCubeY = 5;

		//spawns the grid of cubes
		for (int x=0; x < gridX; x++){
			for (int y = 0; y < gridY; y++) {
				cubePosition = new Vector3 (x * 2 - gridX, y * 2 - gridY, 0);
				grid [x,y] = (GameObject)Instantiate (cubePreFab, cubePosition, Quaternion.identity);
			}
		}
	}

	// Update is called once per frame
	void Update () {

		ProcessKeyboard ();
		ScoreSameColorPlus ();
		ScoreAllColorPlus ();


		//If the timer is up, end the game
		if (Time.time > gameLength) {

			EndGame ();
		}

		//a turn happens every turnLength seconds
		if (Time.time > turnLength * turns) {
			turns++;
			SpawnNextCube ();

			//			if (Next Cube Still exists){
			//
			//				SpawnBlackCube ();
			//				if it doesn't work because there are no white cubes, EndGame();
			//				DestroyNextCube
			//			}

			SpawnNextCube ();
		}

	}
}
