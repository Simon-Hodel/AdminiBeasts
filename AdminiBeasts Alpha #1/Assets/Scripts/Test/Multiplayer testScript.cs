using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MultiplayertestScript : NetworkBehaviour
{
  public Object_Tier1_Unit unit_rn;
  public GameObject card_tier1;
  public GameObject area_player_spawn;
  public GameObject area_enemy_spawn;
  public void Unit_Choose(Object_Tier1_Unit value)
  {
    unit_rn = value;
  }
  public void OnClick(){
  CmdUnit_Spawn(unit_rn);
  }
  [Command]
  public void CmdUnit_Spawn(Object_Tier1_Unit Value)
  {
    
    
      Object_Tier1_Unit unit_Chosen = Value;
      GameObject unit_test = Instantiate(card_tier1, new Vector2(0, 0), Quaternion.identity);
      NetworkServer.Spawn(unit_test, connectionToClient) ;
      Script_ShowUnit s1 = unit_test.GetComponent<Script_ShowUnit>();
      s1.GoRequest(unit_Chosen);
      RpcShowUnit(unit_test);
    
    
    
      print("alles hat gut geklapt mit Spawn!!!");
  }
  [ClientRpc]
  void RpcShowUnit(GameObject Value)
  {
    if (hasAuthority)
    {
      Value.transform.SetParent(area_player_spawn.transform, false);
    }
    else
    {
      Value.transform.SetParent(area_enemy_spawn.transform, false);
    }
  }

}
