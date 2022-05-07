using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Script_ChooseUnit_btn : NetworkBehaviour
{
  public Object_Tier1_Unit unit_rn;
  public GameObject btn_choose;
  public GameObject inv1;
  public GameObject inv2;
  public GameObject inv3;
  public GameObject inv4;
  List<GameObject> inv_list = new List<GameObject>();
  private int inv_slot = 0;
  private bool ifunitselected = false;
  public PlayerManagerTest playerManager;

  private void Start()
  {
    inv_list.Add(inv1);
    inv_list.Add(inv2);
    inv_list.Add(inv3);
    inv_list.Add(inv4);
   
  }
  public void Choose_rn(Object_Tier1_Unit value){
  unit_rn = value;
   btn_choose.GetComponent<Image>().sprite = unit_rn.unit_image;
   ifunitselected = true;
  }
  public void Onclick() {
    if (ifunitselected) {
      NetworkIdentity networkIdentity = NetworkClient.connection.identity;
      playerManager = networkIdentity.GetComponent<PlayerManagerTest>();
      Script_Inv1 s_inv1 = inv_list[inv_slot].GetComponent<Script_Inv1>();
      s_inv1.Unit_Choose(unit_rn);
      playerManager.CmdUnit_Choose(unit_rn);
      inv_slot++;
    if (inv_slot == 4)
    {
      inv_slot = 0;
    }

  }
  }
}
