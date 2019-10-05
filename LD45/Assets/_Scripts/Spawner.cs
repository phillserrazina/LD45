using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour, IPointerExitHandler
{
    [SerializeField] private GameObject objectToSpawn = null;
    private Button b;

    private void Start() {
        b = GetComponent<Button>();
        b.onClick.AddListener(() => { SpawnObject(); } );
    }

    public void SpawnObject() {
        if (objectToSpawn == null) return;
        Instantiate(objectToSpawn);

        UpdateAllObjects();

        b.interactable = false;
        Destroy(b.GetComponentInChildren<Text>());
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (b.interactable == false) {
            var et = GetComponent<EventTrigger>();
            if (et != null) Destroy(et);
        }
    }

    private void UpdateAllObjects() {
        var objs = FindObjectsOfType<WorldObject>();

        foreach (var obj in objs) {
            obj.UpdateObject();
        }
    }
}
