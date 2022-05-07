using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManagerTest : NetworkBehaviour
{
  public GameObject card_tier1;
  public GameObject area_player_spawn;
  public GameObject area_enemy_spawn;

  List<Object_Tier1_Unit> inventory_Unit = new List<Object_Tier1_Unit>();


  public override void OnStartClient()
  {
    base.OnStartClient();
    area_player_spawn = GameObject.Find("InGameUnitArea_PlayerSpawn");
    area_enemy_spawn = GameObject.Find("InGameUnitArea_EnemySpawn");
  }
  [Command]
  public void CmdUnit_Choose(Object_Tier1_Unit value)
  {
    inventory_Unit.Add(value);
    print(inventory_Unit);
  }

  public void OnClick_Inv0()
  {
    CmdUnit_Spawn(0);
  }
  public void OnClick_Inv1()
  {
    CmdUnit_Spawn(1);
  }
  public void OnClick_Inv2()
  {
    CmdUnit_Spawn(2);
  }
  public void OnClick_Inv3()
  {
    CmdUnit_Spawn(3);
  }

  [Command]
  public void CmdUnit_Spawn(int Index)
  {
    print("it gets to CmdUnit_Spawn");
    GameObject unit_test = Instantiate(card_tier1, new Vector2(0, 0), Quaternion.identity);
    NetworkServer.Spawn(unit_test, connectionToClient);
    Script_ShowUnit s1 = unit_test.GetComponent<Script_ShowUnit>();
    s1.GoRequest(inventory_Unit[Index]);
    print("alles hat gut geklapt mit Spawn!!!");
    RpcShowUnit(unit_test);



    
  }
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
