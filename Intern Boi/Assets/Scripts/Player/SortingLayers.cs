using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayers : MonoBehaviour
{
    private Renderer mRenderer;

    /// <summary>
    /// The starting order number for the sprites
    /// </summary>
    [SerializeField] private int sortingOrder = 5000;

    [Header("Offset")]
    [SerializeField] private int yOffset = 0;
    [SerializeField] private int xOffset = 0;

    [Header("For Non-moving Object")]
    [SerializeField] private bool runOnce = false;
    [SerializeField] private bool highlight = false;

    /// <summary>
    /// The higher the number the greater the change will be in the sortingOrder of the sprites
    /// </summary>
    private readonly int resolution = 10;

    private void Awake()
    {
        mRenderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        //Check if the object is a highlightable overlay
        if (highlight)
        {
            xOffset += 1;
            yOffset -= 1;
            gameObject.SetActive(false);
        }

        //Determine the layering order of the sprite baased on its position in the gameview
        mRenderer.sortingOrder = (int)(sortingOrder - transform.position.y * resolution - yOffset + transform.position.x * resolution + xOffset);

        //Check if the item is not able to move and the script will be deleted after the script is being run once
        if (runOnce)
        {
            Destroy(this);
        }
    }
}
