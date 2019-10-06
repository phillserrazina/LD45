using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] private ResultsCalculator results = null;

    public void ShowResults() {
        results.gameObject.SetActive(true);
    }
}
