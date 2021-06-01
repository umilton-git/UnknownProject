using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VHS
{
    public class InteractionController : MonoBehaviour
    {
        #region Variables
        [Header("Data")]
        public InteractionInputData interactionInputData;
        public InteractionData interactionData;

        [Space]
        [Header("Ray Settings")]
        public float rayDistance;
        public float raySphereRadius;
        public LayerMask interactableLayer;
        public RectTransform Image;
        private Camera m_cam;
        #endregion
          
        #region Built In Methods
        void Awake()
        {
            m_cam = FindObjectOfType<Camera>();
        }

        void Update()
        {
            CheckForInteractable();
            CheckForInteractableInput();
        }
        #endregion

        #region Custom methods
        void CheckForInteractable()
        {
            Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
            RaycastHit _hitInfo;

            bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius, out _hitInfo, rayDistance, interactableLayer);

            if(_hitSomething)
            {
                InteractableBase _interactable = _hitInfo.transform.GetComponent<InteractableBase>();
                Image.sizeDelta = new Vector2(15, 15);

                if(_interactable != null)
                {
                    if(interactionData.IsEmpty())
                    {
                        interactionData.Interactable = _interactable;
                    }
                    else
                    {
                        if(interactionData.IsSameInteractable(_interactable))
                        {
                            return;
                        }
                        else
                        {
                            interactionData.Interactable = _interactable;
                        }
                    }
                }
            }
            else
            {
                Image.sizeDelta = new Vector2(5, 5);
                interactionData.ResetData();
            }
            Debug.DrawRay(_ray.origin, _ray.direction * rayDistance, _hitSomething ? Color.green : Color.red);
        }

        void CheckForInteractableInput()
        {

        }
        #endregion
    }
}
