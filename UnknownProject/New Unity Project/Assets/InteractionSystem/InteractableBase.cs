using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS 
{
public class InteractableBase : MonoBehaviour, Interactable
{
#region Variables
  [Header("Interactable Settings")]
 
  [Space]
  public bool IsInteractable;
  public bool MultipleUse;
#endregion

#region Properties
  public bool isInteractable => IsInteractable;
  public bool multipleUse => MultipleUse;
#endregion

#region Methods

  public void OnInteract()
  {
      Debug.Log("INTERACTED: " + gameObject.name);
  }
  #endregion
}
}
