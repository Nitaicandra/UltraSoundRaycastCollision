using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public string Taglookup = "raycaster";
    public GameObject[] raycasters;
    public CollisionReverseRaycast[] script_list;
    public float pressure_threshold=0.003f;
    // Start is called before the first frame update
    void Start()
    {
        
        raycasters = GameObject.FindGameObjectsWithTag(Taglookup);
        script_list = new CollisionReverseRaycast[raycasters.Length];
        for(int i = 0; i< raycasters.Length;i++) {
            script_list[i] = raycasters[i].GetComponent<CollisionReverseRaycast>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < script_list.Length; i++)
        {
            if (script_list[0] != null)
            {   
                if (script_list[i].pressure > pressure_threshold)
                {
                    Debug.Log("VEIN COLLAPSED " + "Pressure " +
                        script_list[i].pressure + " OBJECT " + script_list[i].gameObject);
                }
            }   
        }
    }
}
