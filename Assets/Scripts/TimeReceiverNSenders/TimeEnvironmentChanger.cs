using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TimeEnvironmentChanger : MonoBehaviour
{
    //Descripcion:
    /// <summary>
    /// Este script se encarga de cambiar el mapa en los saltos temporales. Como tambien se encarga de cambiar las layer
    /// para el escenario de otro tiempo que esta en el fondo.
    /// </summary>
    
    string stencilVariable = "_StencilMask";

    public List<SourceMapGenerator> SOURCEMAPS;
    public Transform grid;
    [SerializeField]
    Material inside2d;
    [SerializeField]
    Material inside2dv2;

    private void Awake()
    {
        //Crear otros tilemaps
        for (int i = 0; i < SOURCEMAPS.Count; i++)
        {
            GameObject pastMap = Instantiate(SOURCEMAPS[i].SourceMap, grid);
            GameObject futureMap = Instantiate(SOURCEMAPS[i].SourceMap, grid);
            SOURCEMAPS[i].SourceMap.name += "Presente";
            pastMap.name += "Pasado";
            futureMap.name += "Futuro";
            SOURCEMAPS[i].AddTilemapsobjs(pastMap,futureMap);
            for (int u = 0; u < SOURCEMAPS[i].TilemapsObjs.Count; u++)
            {
                SOURCEMAPS[i].AddOtherComponents(
                    SOURCEMAPS[i].TilemapsObjs[u].GetComponent<Tilemap>(),
                    SOURCEMAPS[i].TilemapsObjs[u].GetComponent<TilemapRenderer>(),
                    SOURCEMAPS[i].TilemapsObjs[u].GetComponent<Collider2D>());
            }
            SOURCEMAPS[i].SetLayers();
            SOURCEMAPS[i].Swaptiles();
        }
        TimeChange.UpdateLayers += UpdateLayers;
        TimeChange.MiniUpdate += UpdateLayers;
        UpdateLayers();
    }


    public void UpdateLayers()
    {
        for (int i = 0; i < SOURCEMAPS.Count; i++)
        {
            SOURCEMAPS[i].UpdateLayers();
            SOURCEMAPS[i].UpdateMaterials(inside2d, inside2dv2);
        }
    }

    private void OnDestroy()
    {
        TimeChange.UpdateLayers -= UpdateLayers;
        TimeChange.MiniUpdate -= UpdateLayers;
    }
}
