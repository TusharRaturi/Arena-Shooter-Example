using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisualNovelController : MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI bottomTextMesh;

    public List<Sprite> listOfImages;
    public List<string> listOfTexts;

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            counter++;

            background.sprite = listOfImages[counter];
            bottomTextMesh.text = listOfTexts[counter];
        }
    }
}
