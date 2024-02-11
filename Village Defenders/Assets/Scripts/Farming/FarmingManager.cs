using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FarmingManager : MonoBehaviour
{
    public static FarmingManager instance;
    public LayerMask mudMask;
    public LayerMask npcMask;
    public RaycastHit hit;
    public ScriptableVegetables[] vegetableScriptable;
    [SerializeField] private Vector3 ypos = new Vector3(0,0.5f, 0);
    [SerializeField]  private bool canPlantVegetable;
    public NPC npcMovement;
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
    private void Start()
    {
        foreach(ScriptableVegetables scriptableVegetables in vegetableScriptable)
        {
            scriptableVegetables.quantity = 0;
        }
     
    }

    private void Update()
    {
        
            if (Input.GetMouseButtonDown(1))
            {
                Ray FarmRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(FarmRay, out hit, Mathf.Infinity, mudMask))
                {
                    Mud mud = hit.collider.GetComponent<Mud>();
                    if (mud != null && mud.CanBePlanted())
                    {

                        ShopUI.instance.EnableVeggiesShopPanel();
                        //npcMovement.navMeshAgent.
                    }
                }

            }

        }
    
   
   
    public void PlantVegetable(int id)
    {
        if (hit.collider != null)
        {

            Mud mud = hit.collider.GetComponent<Mud>();
            if (mud != null && mud.CanBePlanted())
            {
                Vector3 pos = hit.collider.bounds.center + ypos;
                GameObject vegetable = Instantiate(vegetableScriptable[id].veggiePrefab, pos, Quaternion.identity);

                mud.canBePlanted = false;

                Debug.Log("farmed veggie");
            }
              

        }
    }
}