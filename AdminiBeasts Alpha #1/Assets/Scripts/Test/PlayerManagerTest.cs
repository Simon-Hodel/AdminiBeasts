using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerManagerTest : NetworkBehaviour
{
  public GameObject card_tier1;
  public GameObject area_player_spawn;
  public GameObject area_enemy_spawn;

  List<GameObject> inventory_Unit = new List<GameObject>();

  /// <summary>
  /// OnStartClient is beeing run when a client joins the server.
  /// </summary>
  public override void OnStartClient()
  {
    base.OnStartClient();
    area_player_spawn = GameObject.Find("InGameUnitArea_PlayerSpawn");
    area_enemy_spawn = GameObject.Find("InGameUnitArea_EnemySpawn");
  }
 /// <summary>
 /// Commands are beeing run by the server
 /// this method is currently beeing unused because we keept seaching for a better solution to get the desired Gameobject.
 /// </summary>
  [Command]
  public void CmdUnit_Choose()
  {
    GameObject unit = GameObject.Find("Button_PlayerInventory_Slot1").transform.GetChild(0).gameObject;
    inventory_Unit.Add(unit);
    print(">"+unit.transform.Find("Unit_Attack_Displayed").GetComponent<Text>().text+"<dass interressiert uns");
  }


/// <summary>
/// This is suposed to spawn the desired Unit.
/// </summary>

  [Command]
  public void CmdUnit_Spawn(GameObject unit)
  {
    print("it gets to CmdUnit_Spawn");
    //GameObject unit = GameObject.Find("Button_PlayerInventory_Slot1").transform.GetChild(0).gameObject;
    print("here" + unit);
    GameObject unit_test = Instantiate(unit , new Vector2(0, 0), Quaternion.identity);
    NetworkServer.Spawn(unit_test, connectionToClient);



    print("alles hat gut geklapt mit Spawn!!!");
    RpcShowUnit(unit_test);




  }
  /// <summary>
  /// ClientRpc are run by the Client.
  /// Here Authority has a big impact and it diesides what actions ore changes are beeing made.
  /// This code for instance spawns a Unit on your side if you have authority to let it look like its on your team, whilst for the opponent is shows as an Enemy.
  /// </summary>
  
  [ClientRpc]
  void RpcShowUnit(GameObject Value)
  {
    if (hasAuthority)
    {
      Value.transform.SetParent(area_player_spawn.transform, false);
      print("has authority");
    }
    else
    {
      Value.transform.SetParent(area_enemy_spawn.transform, false);
      print("does not have authority");
    }
  }

}
