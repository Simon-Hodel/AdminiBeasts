using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Tier1 Unit", menuName = "Tier1/Unit")]
public class Object_Tier1_Unit : ScriptableObject
{

  public string unit_name;
  public string unit_description;
  
  public Sprite unit_image;
  
  public int unit_attack;
  public int unit_health;
  public int unit_cost;
  public string unit_tier1_ability;

  public void Display_Request(Script_ShowUnit sender)
  {
   sender.Display(unit_name, unit_description, unit_image, unit_attack, unit_health, unit_cost, unit_tier1_ability);
  }


  }
