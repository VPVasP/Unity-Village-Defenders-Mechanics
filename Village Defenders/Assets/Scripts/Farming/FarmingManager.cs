using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingManager : MonoBehaviour
{
    public static FarmingManager instance;
    public LayerMask mudMask;
    public RaycastHit hit;
    public ScriptableVegetables[] vegetableScriptable;
    [SerializeField] private Vector3 ypos = new Vector3(0, 2, 0);
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mudMask))
            {
                Mud mud = hit.collider.GetComponent<Mud>();
                if (mud != null && mud.CanBePlanted())
                {
                    PlantVegetable(0);
                    mud.canBePlanted = false; 
                }
            }

        }

    }
    public void PlantVegetable(int id)
    {
        if (hit.collider != null)
        {


            Vector3 pos = hit.collider.bounds.center + ypos;
            GameObject vegetable = Instantiate(vegetableScriptable[id].veggiePrefab, pos, Quaternion.identity);


        }
    }
}