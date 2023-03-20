using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerscript : MonoBehaviour
{
    public string tagstring;
    [SerializeField] float damage;
    public List<GameObject> targets;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count != 0)
        {
            if (cooldown<=0)
            {
                targets[0].GetComponent<agentscript>().damage(damage);
                cooldown = 1;
            }
            if (!targets[0])
            {
                Debug.Log(targets[0]);
                targets.Remove(targets[0]);
            }
        }

        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagstring)
        {
            Debug.Log(other.name);
            targets.Add(other.gameObject);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == tagstring)
        {
            Debug.Log(other.name);
            targets.Remove(other.gameObject);
        }

    }
}
