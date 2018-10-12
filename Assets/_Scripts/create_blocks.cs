using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_blocks : MonoBehaviour
{
    public GameObject ground;
    public GameObject block_prefab;
    public GameObject blocks_manager;

    private int first_layer_prob = 4;
    private int second_layer_prob = 2;

    // Use this for initialization
    void Start() {

        // Tracks the first layer of blocks 
        List<GameObject> blocks = new List<GameObject>();

        // Gets bound of ground object dynamically
        Vector3 bounds = ground.GetComponent<Renderer>().bounds.size;
        int x_bound = (int) bounds.x/2 - 1;
        int z_bound = (int) bounds.z/2 - 1;

        // Creates first layer of blocks within bounds w/ probability of 1/4
        for (int i = -1*x_bound; i < x_bound; i++){
            for (int j = -1*z_bound; j < z_bound; j++){
                if (Random.Range(0, first_layer_prob) == 0) {
                    GameObject new_block = Instantiate(block_prefab, new Vector3((float)i, .5f, (float)j), Quaternion.identity);
                    new_block.transform.parent = blocks_manager.transform;
                    blocks.Add(new_block);
                }
            }
        }

        // Creates second layer of blocks w/ probability of 1/2
        foreach(GameObject block in blocks){
            if(Random.Range(0, second_layer_prob) == 0){
                GameObject new_block = Instantiate(block_prefab, block.transform.position + 1f * Vector3.up, Quaternion.identity);
                new_block.transform.parent = blocks_manager.transform;
            }
        }
    }
}
