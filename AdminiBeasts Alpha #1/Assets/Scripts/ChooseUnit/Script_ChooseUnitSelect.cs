using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ChooseUnitSelect : MonoBehaviour
{
  public GameObject btn_chooseUnitForInventory;
  public GameObject panel;
  public Object_Tier1_Unit object_bacteria;
  public Object_Tier1_Unit object_virus;
  public void OnBacteria(){
    Script_ChooseUnit_btn s1 = btn_chooseUnitForInventory.GetComponent<Script_ChooseUnit_btn>();
    s1.Choose_rn(object_bacteria);
    panel.SetActive(false);
  }
  public void OnVirus()
  {
    Script_ChooseUnit_btn s1 = btn_chooseUnitForInventory.GetComponent<Script_ChooseUnit_btn>();
    s1.Choose_rn(object_virus);
    panel.SetActive(false);

  }
  public void OnOpenPanel(){
    panel.SetActive(true);
  }
}
