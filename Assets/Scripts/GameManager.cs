using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public GameObject player;
    private UIManager uIManager;
    // if game over true and space key pressed  
    // spawn the player and start the game and hide the title scree

    private void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOver = false;
                Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
                uIManager.HideTitleScreen();
            }
        }
    }
}
