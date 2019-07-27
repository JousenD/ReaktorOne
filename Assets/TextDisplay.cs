using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] Text[] textDisplays;
    // Start is called before the first frame update
    void Start()
    {
        textDisplays = GetComponentsInChildren<Text>();
        textDisplays[0].text = "Level 1";
        textDisplays[1].text = Time.time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textDisplays[1].text = "Time:\n" + Mathf.Round(500 - Time.time).ToString();
    }
}
