using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer local { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void Spawned()
    {
        //base.Spawned();
        if (Object.HasInputAuthority)
        {
            local = this;
            Debug.Log("Local player spawned");
        }
        else Debug.Log("Spawned Remote Player");
    }
    public void PlayerLeft(PlayerRef player)
    {
        //despawn player if it leaves
        if (player == Object.InputAuthority)
            Runner.Despawn(Object);
    }

}
