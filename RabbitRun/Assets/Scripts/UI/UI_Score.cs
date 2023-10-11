using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Score : MonoBehaviour {

    private TextMeshProUGUI txtScore;

    void Awake() {
        txtScore = this.GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        txtScore.text = $"Á¡¼ö: {GameManager.Instance.Score:N0}";
    }

}