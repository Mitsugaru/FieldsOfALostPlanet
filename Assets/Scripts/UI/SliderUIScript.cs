using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class SliderUIScript : MonoBehaviour
{

	public string labelText = "";
	public Color color = Color.white;

    public Slider slider;

	public Text label;

    public Text percent;

    public Image fillArea;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fillArea.enabled = slider.value > 0;
		fillArea.color = color;
		label.text = labelText;
		StringBuilder sb = new StringBuilder();
		sb.Append(slider.value);
		sb.Append(" / ");
		sb.Append(slider.maxValue);
		percent.text = sb.ToString();
    }
}
