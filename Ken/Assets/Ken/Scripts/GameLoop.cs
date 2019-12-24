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

        Character _player = FactoryMng.Instance.GetCharacterFactory().CreatePlayer(EPlayer.Player, EWeapon.Sword, new Vector3(0, 5, 3.5f));

        FactoryMng.Instance.GetCharacterFactory().CreateMonster(EMonster.Skeleton, EWeapon.Sword, new Vector3(5, 5, 3.5f));

        //Create Gamemode
        GameInstance.Instance.CreateGameMdoe(_player.GetController() as PlayerController, _player);

        //Set the button numbers
        InputMng.Instance.SetButtonAmount(5);     
    }
}
