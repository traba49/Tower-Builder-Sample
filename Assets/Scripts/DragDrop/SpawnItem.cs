using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DragDrop
{
    public class SpawnItem : MonoBehaviour
    {
        [SerializeField] GameObject _item;

        private void OnEnable()
        {
            Spawn();
        }

        public void Spawn()
        {
            if (transform.childCount == 0)
            {
                Instantiate(_item, transform);
            }
        }
    }
}