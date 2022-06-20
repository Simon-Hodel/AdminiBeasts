using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ChooseUnitSelect : MonoBehaviour
{
  public GameObject btn_chooseUnitForInventory;
  public GameObject panel;
  public Object_Tier1_Unit object_bacteria;
  public Object_Tier1_Unit object_virus;
 /// <summary>
 /// OnBacteria and OnVirus may decide what unit you want to hover in your ChooseForInventory slot.
 /// This whole Programm will be deleted or drasticly altered at some point and only serves the porpuse of not having to Programm an complicated inventory and shop system yet.
 /// </summary>
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
