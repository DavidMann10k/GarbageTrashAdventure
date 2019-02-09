//using UnityEngine;
//using System.Collections;

//[BoltGlobalBehaviour(BoltNetworkModes.Server)]
//public class ServerCallbacks : Bolt.GlobalEventListener
//{
//    public override void OnEvent(DestroyCanEvent evnt)
//    {
//        var ent = BoltNetwork.FindEntity(evnt.NetworkId);

//        BoltNetwork.Destroy(ent.gameObject);
//    }
//}