using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField]
    XRRayInteractor interactor;

    [SerializeField] RawImage icon;

    private void Start()
    {
        
        interactor = GameObject.Find("Right Grab Ray").GetComponent<XRRayInteractor>();
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        if (icon.isActiveAndEnabled)
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            icon.raycastTarget = false;
        }
        else
        {
            return;
        }
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        interactor.TryGetCurrentUIRaycastResult(out RaycastResult hit);
        transform.position = hit.worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        icon.raycastTarget = true;
       
    }

   
}
