using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_blocks : MonoBehaviour
{
    public GameObject ground;
    public GameObject block_prefab;
    public GameObject blocks_manager;

    public int block_fill_denominator = 4;

    // Use this for initialization
    void Start()
    {

        // Tracks the first layer of blocks 
        List<GameObject> blocks = new List<GameObject>();

        // Gets bound of ground object dynamically
        Vector3 bounds = ground.GetComponent<Renderer>().bounds.size;
        int x_bound = (int)bounds.x / 2 - 1;
        int z_bound = (int)bounds.z / 2 - 1;

        // Creates first layer of blocks within bounds w/ given probability
        for (int i = -1 * x_bound; i < x_bound; i++)
        {
            for (int j = -1 * z_bound; j < z_bound; j++)
            {
                if (Random.Range(0, block_fill_denominator) == 0)
                {
                    GameObject new_block = MakeBlock(new Vector3((float)i, .5f, (float)j));
                    new_block.transform.parent = blocks_manager.transform;
                    blocks.Add(new_block);
                }
            }
        }

        // Creates second layer of blocks w/ probability of 1/2 of first layer
        foreach (GameObject block in blocks)
        {
            if (Random.Range(0, block_fill_denominator * 2) == 0)
            {
                GameObject new_block = MakeBlock(block.transform.position + 1f * Vector3.up);
                new_block.transform.parent = blocks_manager.transform;
            }
        }
    }

    // Creates block and assigns it a color from a range of half black to chosen color
    private GameObject MakeBlock(Vector3 placement)
    {
        GameObject new_block = Instantiate(block_prefab, placement, Quaternion.identity);
        new_block.GetComponent<MeshRenderer>().material.SetColor("_Color",
            Color.Lerp(Color.black, Color.white, Random.Range(0.5f, 1f)));

        return new_block;

    }
}
