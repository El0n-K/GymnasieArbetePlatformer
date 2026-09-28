using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string levelName;
    int numberOfDeaths;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Level: " + levelName + "\n Deaths " + numberOfDeaths;
    }

    public void UpdateDeaths()
    {
        numberOfDeaths += 1;
    }
}
