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
  public GameObject card_tier1;
  List<GameObject> inv_list = new List<GameObject>();
  private int inv_slot = 0;
  private bool ifunitselected = false;
 

  private void Start()
  {
    inv_list.Add(inv1);
    inv_list.Add(inv2);
    inv_list.Add(inv3);
    inv_list.Add(inv4);
   
  }
  /// <summary>
  /// Choose_rn is activated once the player has choosen either Bacteria or Virus form the panel.
  /// Then for that the goRequest method is beeing called.
  /// The unit_rn which is seen several times over the whole Project at this time, is descided throught this action.
  /// </summary>
  
  public void Choose_rn(Object_Tier1_Unit value){
  unit_rn = value;
   btn_choose.GetComponent<Image>().sprite = unit_rn.unit_image;
   ifunitselected = true;
  }
  /// <summary>
  /// If the choose unit for inventory field is Clicked, several things happen.
  /// the scriptable object will try to display its invormation through a Gameobject called card_tier1.
  /// after the programm finds the playermanager for the current client and runns the method CmdUnit_Spawn.
  /// </summary>
  public void Onclick() 
  {
    print("Script Choose Unit btn "+ unit_rn);
  if (ifunitselected) {
      NetworkIdentity networkIdentity = NetworkClient.connection.identity;
      PlayerManagerTest playerManager = networkIdentity.GetComponent<PlayerManagerTest>();
      Script_Inv1 s_inv1 = inv_list[inv_slot].GetComponent<Script_Inv1>();
      s_inv1.Unit_Choose(unit_rn);

      Script_ShowUnit s1 = card_tier1.GetComponent<Script_ShowUnit>();
      s1.GoRequest(unit_rn);

      playerManager.CmdUnit_Spawn(card_tier1);
      print(playerManager + " " + unit_rn);
      inv_slot++;
    if (inv_slot == 4)
    {
      inv_slot = 0;
    }

  }
  }
}  //public void OnClick_Inv0()
   //{
   //  CmdUnit_Spawn(0);
   //}
   //public void OnClick_Inv1()
   //{
   //  CmdUnit_Spawn(1);
   //}
   //public void OnClick_Inv2()
   //{
   //  CmdUnit_Spawn(2);
   //}
   //public void OnClick_Inv3()
   //{
   //  CmdUnit_Spawn(3);
   //}
