using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	//I worked on this programming with Zofia

	public GameObject cubePreFab;
	Vector3 cubePosition;
	GameObject [,] grid;
	GameObject nextCube;
	int gridX, gridY;
	float gameLength = 60;
	float turnLength = 2.0f;
	int turns;
	int nextCubeX, nextCubeY;
	Color[] cubeColors = { Color.blue, Color.red, Color.green, Color.yellow, Color.magenta };
	int playerScore;
	int sameColorPoints = 10;
	int allColorPoints = 5;


	//spawns a new cube of a random color every turn
	void SpawnNextCube () {
		if (nextCube == null) {
			nextCube = Instantiate (cubePreFab, new Vector3 (nextCubeX, nextCubeY, 0), Quaternion.identity);
		}
		nextCube.GetComponent<Renderer> ().material.color = cubeColors [Random.Range (0, cubeColors.Length)];

	}

	//	int FindEmptyColumn (int y) {
	//
	//	}

	void EndGame (bool win){
		//make all other processes stop, thereby ending the game
		print ("Game Over");
		if (win == false) {
			print ("You Lost");
		} else {
			print ("Your final score is: " + playerScore);
		}
	}

	//	int[] FindEmptySpace (){
	//
	//	}

	void ScoreSameColorPlus () {
		//add sameColorPoints to playerScore
		playerScore = playerScore + sameColorPoints;
		//turn cubes in plus black and deactivate them
	}

	void ScoreAllColorPlus () {
		//add allColorPoints to playerScore
		playerScore = playerScore + allColorPoints;
		//turn cubes in plus black and deactivate them
	}

	void ProcessClick (GameObject clickedCube, int x, int y) {

		//if clicked cube is colored an not active, activate it
		//if clicked cube is colored an active, deactivate it
		//if a cube is active and next cube clicked is adjacent and white, switch the cubes

	}

	int FindAvailableCube (int x){
		//find random open space in row selected
		//if there are no open spaces, return -1

		//placeholder
		return 1;
	}

	void PlaceCube (int x){
		int y = FindAvailableCube (x);
		if (y == -1) {
			EndGame (false);
		}
		else {
			//place colored cube in random open space
		}
	}

	void SpawnBlackCube(){
		//find a random empty space to place a black cube
		//if no empty spaces are availabele, end the game
	}

	//checks for keyboard inputs
	void ProcessKeyboard (){
		int rowNum = 0;

		//check for 1-5
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			rowNum = 1;
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			rowNum = 2;
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			rowNum = 3;
		}

		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			rowNum = 4;
		}

		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			rowNum = 5;
		}
			
		if (nextCube != null && rowNum > 0) {
			PlaceCube (rowNum - 1);
		}
		//if 1-5 input, checks for empty space in that row
		//change cube color from white to color of current "next cube"
		//removes cube considered "next cube"
		//else if no open spaces end game


	}


	// Use this for initialization
	void Start () {

		playerScore = 0;

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

//		if (cubes of the same color are in a plus){
//			ScoreSameColorPlus ();
//	}
//		if (cube of all different colors are in a plus){
//			ScoreAllColorPlus ();
//	}


		//If the timer is up, end the game
		if (Time.time > gameLength) {

			EndGame (true);
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

		//if a plus is made of all five colors, start ScoreAllColorPlus
		//if a plus is made of one single color, start ScoreSameColorPlus

	}
}
