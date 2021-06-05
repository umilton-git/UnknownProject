using UnityEngine;

namespace InteractionSystem
{
    public interface Interactable
    {
        bool multipleUse { get; }

        bool isInteractable { get; }

        void OnInteract();
    }
}
