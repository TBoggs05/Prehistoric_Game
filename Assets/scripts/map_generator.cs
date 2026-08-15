using UnityEngine;
using System.Collections;

public class map_generator : MonoBehaviour
{
    //width and heigh of the texture in pixels
    public int pixWidth;
    public int pixHeight;

    //The origin of the sampled area in the plane.
    public float xOrg;
    public float yOrg;


    // The number of cycles of the basic noise apttern that are repeated
    // over the width and height of the texture.
    public float scale = 1.0f;

    public Texture2D noiseTex;
    private Color[] pix;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        //Set up the texture and a Color array to hold pixels during processing.
        noiseTex = new Texture2D(pixWidth, pixHeight);
        pix = new Color[noiseTex.width * noiseTex.height];
        rend.material.mainTexture = noiseTex;
        CalcNoise();
    }
    void CalcNoise()
    {
        //For each pixel in the texture...
        for (float y = 0.0f; y < noiseTex.height; y++)
        {
            for (float x = 0.0f; x < noiseTex.width; x++)
            {
                float xCoord = xOrg + x / noiseTex.width * scale;
                float yCoord = yOrg + y / noiseTex.height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                pix[(int)y * noiseTex.width + (int)x] = new Color(sample, sample, sample);
            }
        }

        //Copy the pixel data to the texture and load it into the GPU.
        noiseTex.SetPixels(pix);
        noiseTex.Apply();
    }

    void Update()
    {
       
    }
}
