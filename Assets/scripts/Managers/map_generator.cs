using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;

public class map_generator : MonoBehaviour
{
    Dictionary<int, GameObject> tileset;
    Dictionary<int, GameObject> tile_groups;
    public GameObject prefab_plains;
    public GameObject prefab_water;
    public GameObject prefab_forest;
    public GameObject prefab_rocky;
    public GameObject prefab_nest_rex;
    public GameObject prefab_nest_raptor;
    public GameObject prefab_nest_dodo;
    public GameObject prefab_tree;
    public GameObject prefab_bush;

    [SerializeField] int map_width = 160;
    [SerializeField] int map_height = 90;

    List<List<int>> noise_grid = new List<List<int>>();
    List<List<GameObject>> tile_grid = new List<List<GameObject>>();

    float magnification = 10.0f;

    float x_offset; // <- +>
    float y_offset; // v- +^

    void Start()
    {
        x_offset = Random.Range(0.0f, 9.82f); // <- +>
        y_offset = Random.Range(0.0f, 9.82f); // v- +^
        CreateTileset();
        CreateTileGroups();
        GenerateMap();
    }
    void CreateTileset()
    {
        /** Collect and assign ID codes to the tile prefabs, for ease of access. Best ordered to match land elevation **/

        tileset = new Dictionary<int, GameObject>();
        tileset.Add(0, prefab_water);
        tileset.Add(1, prefab_plains);
        tileset.Add(2, prefab_forest);
        tileset.Add(3, prefab_rocky);
    }

    void CreateTileGroups()
    {
        /** Create empty gameobjects for grouping tiles of the same type, ie forest tiles **/

        tile_groups = new Dictionary<int, GameObject>();
        foreach(KeyValuePair<int, GameObject> prefab_pair in tileset)
        {
            GameObject tile_group = new GameObject(prefab_pair.Value.name);
            tile_group.transform.parent = gameObject.transform;
            tile_group.transform.localPosition = new Vector3(0, 0, 0);
            tile_groups.Add(prefab_pair.Key, tile_group);
        }
    }

    void GenerateMap()
    {
        /** Generate a 2D grid using the Perlin noise function, storing it as both raw ID values
         * and tile gameobjects **/
        for (int x = 0; x < map_width; x++)
        {
            //add rows to be filled out in the next inner loop for both the noise grid and tile grip maps
            noise_grid.Add(new List<int>());
            tile_grid.Add(new List<GameObject>());
            for (int y = 0; y < map_height; y++)
            {
                int tile_id = GetIdUsingPerlin(x, y);
                noise_grid[x].Add(tile_id);
                CreateTile(tile_id, x, y);
            }
        }
    }

    int GetIdUsingPerlin(int x, int y)
    {
        //** Using a grid coordinate input, generate a Perlin noise value to be
        // converted into a tile ID code. Rescale the normalized perlin value to the # of tiles available  **//
        //send x,y, but adjust them to give function a nice float.
        float raw_perlin = Mathf.PerlinNoise(
            (x - x_offset) / magnification,
            (y - y_offset) / magnification
        );
        float clamp_perlin = Mathf.Clamp(raw_perlin, 0.0f, 1.0f); //normalize between 0-1.
        if (raw_perlin < 0.10f)
            return 0; //water
        if (raw_perlin < 0.40f)
            return 1; //plains
        if (raw_perlin < 0.76f)
            return 2; //forest
       
            return 3; //rocky
    }

    void CreateTile(int tile_id, int x, int y)
    {
        //** This function creates a new tile using the type id code, group it with common tiles, set its position and store the game object. **//
        GameObject tile_prefab = tileset[tile_id];
        GameObject tile_group = tile_groups[tile_id];
        GameObject tile = Instantiate(tile_prefab, tile_group.transform);

        tile.name = string.Format("tile_x{0}_y{1}", x, y);

        tile.name = string.Format("tilex{0}_y{1}", x, y);
        tile.transform.localPosition = new Vector3(x, y, 0);

        tile_grid[x].Add(tile);

        //random chance of spawning a nest
        float random_value = UnityEngine.Random.Range(0.0f, 1.0f);
        if(tile_id == 2 && random_value > 0.96)
        {
            SpawnTree(tile);
        }
        else if(tile_id == 1)
        {
            if(random_value > 0.98)
            {
                SpawnTree(tile);
            }
            else if(random_value < 0.30 &&  random_value > 0.05)
            {
                SpawnBush(tile);
            }
        }
        if(random_value < 0.01)
        {
            SpawnNest(tile);
        }
    }
    void SpawnNest(GameObject tile)
    {
        float rand = Random.Range(0.0f, 1.0f);
        GameObject nest;
        if(rand < 0.33f)
            nest = Instantiate(prefab_nest_rex, tile.GetComponent<Transform>());
        else if (rand > 0.33f && rand < 0.67f)
            nest = Instantiate(prefab_nest_raptor, tile.GetComponent<Transform>());
        else
            nest = Instantiate(prefab_nest_dodo, tile.GetComponent<Transform>());
    }
    void SpawnTree(GameObject tile)
    {
        GameObject nest = Instantiate(prefab_tree, tile.GetComponent<Transform>());
    }
    void SpawnBush(GameObject tile)
    {
        GameObject bush = Instantiate(prefab_bush, tile.GetComponent<Transform>());
    }
}
