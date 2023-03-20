using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TowerCreatorNS;

namespace DragDrop
{
    public class ModSlot : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            GameObject item = eventData.pointerDrag;
            if (item != null)
            {
                item.GetComponent<DragItem>().SetInSlot(transform);
                TowerCreator.Instance.AddModule(item.GetComponent<ModuleHolder>(), transform.GetSiblingIndex());
            }
            if (transform.childCount > 1)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
        }
    }
}