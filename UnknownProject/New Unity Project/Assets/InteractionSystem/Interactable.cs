using UnityEngine;

namespace VHS 
{
public interface Interactable
{
    bool multipleUse{ get; }
    bool isInteractable{ get; }

    void OnInteract();
}
}

