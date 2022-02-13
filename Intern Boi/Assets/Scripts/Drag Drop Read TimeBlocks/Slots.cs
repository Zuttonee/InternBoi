using UnityEngine;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour, IDropHandler
{
    [Header("Available Blocks")]
    [SerializeField] private GameObject[] blocks = new GameObject[4];

    private void Start()
    {
        SpawnItem();
    }

    /// <summary>
    /// Deletes old block 
    /// then Spawn block based on a random generator
    /// </summary>
    public void SpawnItem()
    {
        //Checks and destroy existing blocks in the slot
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        //Spawns the type of block to be place in the slotss
        if (blocks.Length != 0)
        {
            GameObject block = Instantiate(blocks[Random.Range(0, blocks.Length - 1)], transform.position, Quaternion.identity);
            block.transform.SetParent(transform);
        }
    }

    //Gets the type of block that is in the slot
    public GameObject item
    {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {   
            DropHandeler.itemDragged.transform.SetParent(transform);
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
        }
    }
}
