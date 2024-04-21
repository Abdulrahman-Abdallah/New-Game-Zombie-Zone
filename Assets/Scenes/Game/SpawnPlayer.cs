using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject playerPrefab;
    public GameObject player;
    private bool IsGameOver=false;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    [Header("Zombies")]
    public AIMovement ZombiePrefab;
    public Transform ZombieSpawn;
    public int NumZombies; 

    private void Awake()
    {
        GameOverScreen.SetActive(false);
        Vector2 randomPostion = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        player = PhotonNetwork.Instantiate(playerPrefab.name,randomPostion, Quaternion.identity);
        for (int i = 0; i < NumZombies; i++)
        {
            AIMovement ai = Instantiate(ZombiePrefab,ZombieSpawn);
            ai.playerTransform = player.transform;
            ai.spawnPlayer = this;
        }


    }
    public void GameOver() // Gave over function
    {
        if (IsGameOver) { return; }
        player.GetComponent<PlayerMovement>().enabled = false;
        GameOverScreen.SetActive(true);
        IsGameOver = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
