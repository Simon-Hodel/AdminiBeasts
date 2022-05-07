using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_ShowUnit: MonoBehaviour
{
  public Object_Tier1_Unit Unit_Tier1;
  //von Unit
  public Text unit_name;
  public Text unit_description;

  public Image unit_image;

  public Text unit_attack;
  public Text unit_health;
  public Text unit_cost;
  public Text unit_ability;
  //von Karte
  public Color card_tier1_color = Color.gray;
  
  public void GoRequest(Object_Tier1_Unit unit)
  {
    unit.Display_Request(this);
   
    
  }
  //public void GoRequest(Object_Tier2_Unit unit)
  //{
  //  unit.Display_Request(this);
  //}
  public void Display(string name,string description,Sprite image,int attack,int health,int cost,string ability)
  {
    unit_name.text = name;
   // unit_description.text = description;
    unit_image.sprite = image;
    unit_attack.text = attack.ToString();
    unit_health.text = health.ToString();
   // unit_cost.text = cost.ToString();
   // unit_ability.text = ability.ToString();
  }
}

