using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroy object derrived interaction system

namespace InteractionSystem
{
    public class DestroyObject : InteractableBase
    {
        public override void OnInteract()
        {
            base.OnInteract();
            Destroy (gameObject);
        }
    }
}
