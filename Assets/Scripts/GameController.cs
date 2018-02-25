using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{

	public GameObject canvasObj;
    public GameObject levelHolder;
    public const int X = 22;
    public const int Y = 13;
    public GameObject[,] level = new GameObject[X, Y];


	public static GameController instance;
	void Awake(){
		if (instance == null)
			instance = this;
	}

    // Use this for initialization
    void Start()
    {
        LevelScan();
    }

    public void LevelScan()
    {
        var objects = levelHolder.GetComponentsInChildren<Transform>();

        foreach (var child in objects)
        {
            level[(int)child.position.x, (int)child.position.y] = child.gameObject;
        }

        level[0, 0] = null;
    }

	public void RestartGame(){
		StartCoroutine (RestartGame_Async());
	}
	IEnumerator RestartGame_Async(){
		yield return new WaitForSeconds (1.0f);
		canvasObj.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
