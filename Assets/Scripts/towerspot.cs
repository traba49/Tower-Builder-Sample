using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerspot : MonoBehaviour
{
    private BoxCollider coll;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponentInChildren<BoxCollider>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    public void placetower(GameObject tower)
    {
        Instantiate(tower, transform);
        coll.enabled = false;
        sprite.enabled = false;
    }
}
