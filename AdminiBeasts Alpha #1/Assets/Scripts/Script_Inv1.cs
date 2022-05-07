using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Inv1 : MonoBehaviour
{
  
  public GameObject card_Tier1;
  private bool is_in_use = false;
  public void Unit_Choose(Object_Tier1_Unit Value)
  {
    if (!is_in_use)
    {
      Object_Tier1_Unit unit_Chosen = Value;
      GameObject current_card = Instantiate(card_Tier1, new Vector2(0, 0), Quaternion.identity);
      current_card.transform.SetParent(this.transform, false);

      Script_ShowUnit s1 = current_card.GetComponent<Script_ShowUnit>();
      s1.GoRequest(unit_Chosen);
      is_in_use = true;
    }
    else
      print("Inv Slot wird bereits bennutzt:");
  }
  public void Unit_Choose(Object_Tier2_Unit Value)
  {
   Object_Tier2_Unit unit_Chosen = Value;
    
  }
  
 
  
}
