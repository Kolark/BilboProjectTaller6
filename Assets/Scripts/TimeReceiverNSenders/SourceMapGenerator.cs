using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[System.Serializable]
public class SourceMapGenerator
{
    public int OrderInTileMaps = 0;
    public GameObject SourceMap;
    public List<VariableSprite> Sprites;
    
    List<GameObject> tilemapsObjs = new List<GameObject>();
    public List<GameObject> TilemapsObjs { get => tilemapsObjs; }

    List<TilemapRenderer> tileMapRenderers = new List<TilemapRenderer>();
    List<Tilemap> Tilemaps = new List<Tilemap>();
    List<Collider2D> TilemapsColliders = new List<Collider2D>();

    //public int size { get => TilemapsObjs.Count;}
    

        
    public void AddTilemapsobjs(GameObject past, GameObject Future)
    {
        TilemapsObjs.Add(past);
        TilemapsObjs.Add(SourceMap);
        TilemapsObjs.Add(Future);
    }

    public void AddOtherComponents(Tilemap _tilemap,TilemapRenderer _tlRend,Collider2D _col2d)
    {
        Tilemaps.Add(_tilemap);
        tileMapRenderers.Add(_tlRend);
        TilemapsColliders.Add(_col2d);
    }
    public void SetLayers()
    {
        tileMapRenderers[2].sortingOrder = -1;
        tileMapRenderers[0].sortingOrder = -2;
    }
    public void Swaptiles()
    {
        for (int i = 0; i < Sprites.Count; i++)
        {
            Tilemaps[0].SwapTile(Sprites[i].presente, Sprites[i].pasado);
            Tilemaps[2].SwapTile(Sprites[i].presente, Sprites[i].Futuro);
        }
    }

    public void UpdateLayers()
    {
        tileMapRenderers[TimeChange.CurrentTime].sortingOrder = TimeChange.layersIDS[0]+OrderInTileMaps;
        tileMapRenderers[TimeChange.TimetoGo].enabled = true;
        tileMapRenderers[TimeChange.TimetoGo].sortingOrder = TimeChange.layersIDS[1]+ OrderInTileMaps;
        tileMapRenderers[TimeChange.LeftOutTime].sortingOrder = TimeChange.layersIDS[2]+ OrderInTileMaps;

        tileMapRenderers[TimeChange.LeftOutTime].enabled = false;
    }
    public void UpdateMaterials(Material inside2d, Material inside2dV2)
    {
        tileMapRenderers[TimeChange.CurrentTime].material = inside2d;
        tileMapRenderers[TimeChange.TimetoGo].material = inside2dV2;
    }

}
