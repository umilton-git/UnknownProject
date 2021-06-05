using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creator for the InteractionData for the interaction system; be sure to make data
// objects from this if not already in project, interactablebase needs it!

namespace InteractionSystem
{
    [CreateAssetMenu(fileName = "Interaction Data", menuName = "InteractionSystem/InteractionData")]
    public class InteractionData : ScriptableObject
    {
        private InteractableBase m_interactable;

        public InteractableBase Interactable
        {
            get => m_interactable;
            set => m_interactable = value;
        }

        public void Interact()
        {
            m_interactable.OnInteract();
            ResetData();
        }

        public bool IsSameInteractable(InteractableBase _newInteractable) => m_interactable == _newInteractable;

        public void ResetData() => m_interactable = null;

        public bool IsEmpty() => m_interactable == null;
    }
}
