using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    void Awake()
    {
        OnInit();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameInstance.Instance.OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        GameInstance.Instance.OnUpdate(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        GameInstance.Instance.OnFixedUpdate(Time.fixedDeltaTime);
    }

    private void OnInit()
    {
        GameObject _playerPawn = (GameObject)Resources.Load("Model/PlayerPawn");
        
        //Create Gamemode
        GameInstance.Instance.CreateGameMdoe(new PlayerController(), new Character(Instantiate(_playerPawn)));

        //Set the button numbers
        InputManager.Instance.SetButtonAmount(3);     
    }
}
