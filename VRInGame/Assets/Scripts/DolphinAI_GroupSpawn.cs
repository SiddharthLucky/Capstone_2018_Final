using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DolphinAIObjects
{
    public string DolphinGroupName { get { return m_DolphinAIGroupname; } }
    public GameObject Dolphin_objectPrefab { get { return m_Dolphinprefab; } }

    // Uncomment below for dolphins group customizations.

    //public int Dolphin_maxAI { get { return m_maxAI; } }
    //public int Dolphin_spawnRate { get { return m_spawnRate; } }
    //public int Dolphin_spawnAmount { get { return m_maxSpawnAmount; } }
    //public bool Dolphin_randomizeStats { get { return m_randomizeStats; } }
    //public bool Dolphin_enableSpawner { get { return m_enableSpawner; } }

    [Header("Dolphin AI Stats")]
    [SerializeField]
    private string m_DolphinAIGroupname;
    [SerializeField]
    private GameObject m_Dolphinprefab;

    // Uncomment the below for dolphin group customization

    //[SerializeField]
    //[Range(0f, 30f)]
    //private int m_DolphinmaxAI;
    //[SerializeField]
    //[Range(0f, 20f)]
    //private int m_DolphinspawnRate;
    //[SerializeField]
    //[Range(0f, 10f)]
    //private int m_DolphinmaxSpawnAmount;
    //[SerializeField]
    //private bool m_DolphinrandomizeStats;
    //[SerializeField]
    //private bool m_DolphinenableSpawner;

    // Constructor for accessing AI values above
    public DolphinAIObjects(string fish_Name, GameObject fish_Prefab, int fish_MaxAI, int fish_SpawnRate, int fish_SpawnAmount, bool fish_RandomizeStats)
    {
        //this.m_fishAIGroupname = fish_Name;
        //this.m_prefab = fish_Prefab;
        //this.m_maxAI = fish_MaxAI;
        //this.m_spawnRate = fish_SpawnRate;
        //this.m_maxSpawnAmount = fish_SpawnAmount;
        //this.m_randomizeStats = fish_RandomizeStats;
    }

    public void fish_Setvalues(int set_fishMaxAI, int set_fishSpawnRate, int set_fishSpawnAmount)
    {
        //this.m_maxAI = set_fishMaxAI;
        //this.m_spawnRate = set_fishSpawnRate;
        //this.m_maxSpawnAmount = set_fishSpawnAmount;
    }

}


// You can use this script if you want to generate multiple dolphins.
public class DolphinAI_GroupSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
