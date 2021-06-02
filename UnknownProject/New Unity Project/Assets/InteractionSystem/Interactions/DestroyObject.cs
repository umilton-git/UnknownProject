using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
public class DestroyObject : InteractableBase
{
   public override void OnInteract()
   {
       base.OnInteract();
       Destroy(gameObject);
   }
}
}
