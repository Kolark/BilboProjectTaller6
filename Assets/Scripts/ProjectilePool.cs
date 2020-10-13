using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour,IPool<Projectile>
{
    private static ProjectilePool instance;
    public static ProjectilePool Instance { get => instance; }
    [SerializeField] Transform placetoStoreBullets;

    [SerializeField] Projectile[] projectilePrefabs= new Projectile[3];
    [SerializeField] int[] amountPertime = new int[3];
    private List<Projectile>[] projectiles = new List<Projectile>[3];

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;

        for (int i = 0; i < projectiles.Length; i++)
        {
            projectiles[i] = new List<Projectile>();
        }
    }

    private void Start()
    {
        Fill();
    }

    public void Fill()
    {
        for (int u = 0; u < projectiles.Length; u++)
        {
            for (int i = 0; i < amountPertime[u]; i++)
            {
                CreateProjectile(u);
            }
        }
    }

    void CreateProjectile(int index)
    {
        Projectile _projectile = Instantiate(projectilePrefabs[index], placetoStoreBullets);
        _projectile.init();
        Recycle(_projectile,index);
    }

    public Projectile GetObject()
    {
        Projectile _projectile;
        if(projectiles[TimeChange.CurrentTime].Count > 0)
        {
            _projectile = projectiles[TimeChange.CurrentTime][0];
            projectiles[TimeChange.CurrentTime].RemoveAt(0);
            return _projectile;
        }
        else
        {
            CreateProjectile(TimeChange.CurrentTime);
            return GetObject();
        }
    }

    public void Recycle(Projectile poolObject,int index)
    {
        poolObject.FreezeState();
        poolObject.transform.position = placetoStoreBullets.position;
        projectiles[index].Add(poolObject);
    }
}
