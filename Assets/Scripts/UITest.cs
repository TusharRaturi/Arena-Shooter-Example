using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public Button testButton;
    public TextMeshProUGUI testText;
    public Slider slider;

    private float health = 100.0f;

    private void Awake()
    {
        slider.GetComponent<Animator>().SetTrigger("Appear");
    }

    // Start is called before the first frame update
    void Start()
    {
        testButton.onClick.AddListener(OnTestButtonPressed);
    }

    private void OnTestButtonPressed()
    {
        Debug.Log("TEST PRESSED!");
        testText.text = health.ToString();
    }

    private void Update()
    {
        health -= 5 * Time.deltaTime;
        slider.value = health / 100.0f;
    }
}
