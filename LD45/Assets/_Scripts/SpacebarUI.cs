using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarUI : MonoBehaviour
{
    private void Update() {
        if (Input.GetMouseButton(0)) {
            GetComponent<Animator>().Play("Spacebar_Fade_Out");
        }
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }
}
