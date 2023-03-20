using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace DragDrop
{
    public class DragItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private RectTransform _transform;
        private Transform _oldParent;
        private Image _gfx;
        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
            _gfx = GetComponent<Image>(); // Ideally graphics are in a child transform
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            _oldParent = transform.parent;
            _transform.SetParent(transform.root);
            _gfx.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _transform.position = Pointer.current.position.ReadValue();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (transform.parent.name == "Canvas")
            {
                _gfx.raycastTarget = true;
                SetInSlot(_oldParent);
            }
            else
            {
                _oldParent.GetComponent<SpawnItem>().Spawn();
            }
        }

        public void SetInSlot(Transform slot)
        {
            transform.SetParent(slot);
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
        }

    }
}