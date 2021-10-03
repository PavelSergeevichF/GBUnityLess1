using UnityEngine;
using UnityEditor;

public class MyAdvancedGUI : MonoBehaviour
{
    [SerializeField]
    [Header("Отладочная переменная")]
    [Range(0, 100)]
    [Tooltip("Значение находится в диапазоне от 0 до 100")]
    private float mySlayder = 1.0f;
    [SerializeField]
    [TextArea(5,10)]
    private string my2Slider;
    [SerializeField]
    private int my3Slider;

    public Color myColor;
    public MeshRenderer GO;

    [Header("Параметры уровня")]
    [Range(20, 200)] public int value1;
    [Range(-50, 50)] public int value2;
    public float value3;

    [Header("Параметры слайдера")]
    [Range(0, 200)] public int valueX;
    [Range(0, 200)] public int valueY;

    [Header("Заголовок")]
    [TextArea(5, 10)]
    public string value4;

    [Header("Количиство золота")]
    public int value5;
    [SerializeField] private int value6;

    public Material newMat;

    private void OnGUI()
    {
        mySlayder = LabelSlider(new Rect(10, 10, 200, 20), mySlayder, 5.0f, 0.1f, "My Slider");
        myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor);
        GO.material.color = myColor;
        if (GO.material != null)
        {
            GO.material.color = myColor;
        }
    }
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, float sliderMinValue, string labelText)
    {
        Rect labelRect = new Rect(screenRect.x, screenRect.y+100, screenRect.width / 2, screenRect.height);
        GUI.Label(labelRect, labelText);
        Rect sliderRect = new Rect(screenRect.x+ valueX + screenRect.width / 2, screenRect.y+ valueY+100, screenRect.width / 2, screenRect.height);
        sliderValue = GUI.HorizontalScrollbar(sliderRect, sliderValue,0, sliderMinValue, sliderMaxValue);
        return sliderValue;
    }
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f,0.0f, "Red");
        screenRect.y += 20;

        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, 0.0f, "Green");
        screenRect.y += 20;

        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, 0.0f, "Blue");
        screenRect.y += 20;

        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, 0.0f, "Alfa");
        screenRect.y += 20;
        return rgb;
    }
}
