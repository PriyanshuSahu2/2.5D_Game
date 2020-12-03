using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] tiles;
    
    void Start()
    {
        LineRenderer ln = GetComponent<LineRenderer>();
        Transform[] parent = this.transform.GetComponentsInChildren<Transform>();
        
        for(int j= 1; j<parent.Length;j++)
        {
            tiles[j] = parent[j].gameObject;
        }
            for (int i = 0; i < tiles.Length; i++)
            {
                ln.SetPosition(i, tiles[i].transform.position);
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnPostRender()
    {
       
    }
}
