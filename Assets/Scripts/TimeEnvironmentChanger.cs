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
    int[] layersIDS = { 0, -1, -2 };
    string stencilVariable = "_StencilMask";
    public GameObject sourceMap;
    public Transform grid;
    public List<VariableSprite> Sprites;
    List<GameObject> tilemapsObjs = new List<GameObject>();
    List<Tilemap> Tilemaps = new List<Tilemap>();
    List<TilemapRenderer> TilemapRenderers = new List<TilemapRenderer>();
    List<Collider2D> TilemapsColliders = new List<Collider2D>();
    private void Awake()
    {
        GameObject pastMap = Instantiate(sourceMap, grid);
        GameObject futureMap = Instantiate(sourceMap, grid);
        sourceMap.name = "Presente";
        pastMap.name = "Pasado";
        futureMap.name = "Futuro";
        tilemapsObjs.Add(pastMap);
        tilemapsObjs.Add(sourceMap);
        tilemapsObjs.Add(futureMap);

        for (int i = 0; i < tilemapsObjs.Count; i++)
        {
            Tilemaps.Add(tilemapsObjs[i].GetComponent<Tilemap>());
            TilemapRenderers.Add(tilemapsObjs[i].GetComponent<TilemapRenderer>());
            TilemapsColliders.Add(tilemapsObjs[i].GetComponent<Collider2D>());
        }
        TilemapRenderers[2].sortingOrder = -1;
        TilemapRenderers[0].sortingOrder = -2;
        for (int i = 0; i < Sprites.Count; i++)
        {
            Tilemaps[0].SwapTile(Sprites[i].presente, Sprites[i].pasado);
            Tilemaps[2].SwapTile(Sprites[i].presente, Sprites[i].Futuro);
        }
        
        TimeChange.UpdateLayers += UpdateLayers;
    }


    public void UpdateLayers()
    {
        TilemapRenderers[TimeChange.CurrentTime].sortingOrder = 0;
        TilemapRenderers[TimeChange.TimetoGo].sortingOrder = -1;
        TilemapRenderers[TimeChange.LeftOutTime].sortingOrder = -2;
    }

}
