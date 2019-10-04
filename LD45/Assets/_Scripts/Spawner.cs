using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn = null;

    private void Start() {
        GetComponent<Button>().onClick.AddListener(() => { SpawnObject(); } );
    }

    public void SpawnObject() {
        if (objectToSpawn == null) return;
        Instantiate(objectToSpawn);
        Destroy(gameObject);
    }
}
