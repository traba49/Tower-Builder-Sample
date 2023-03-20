using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavespawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefs;
    [SerializeField] int range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void nextwave()
    {
        int x = Random.Range(3,6);
        for (int i=0; i <=x; i++)
        {
            Vector3 loc = Random.insideUnitCircle * range ;
            loc.z = loc.y;
            loc.y = 0;
            int y = Random.Range(0, prefs.Length);
            Instantiate(prefs[y],transform.position + loc,Quaternion.Euler(0,0,0));
        }
    }
}
