using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI text;
    
    void Start()
    {
        text.text = "0";
    }

    public void setText(string value) {
        text.text = value;
    }
}
