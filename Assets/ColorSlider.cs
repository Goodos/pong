using UnityEngine;
using UnityEngine.UI;

public class ColorSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Image sliderHandle;
    [SerializeField] Image sliderBg;

    private Texture2D colorTex;

    void Awake()
    {
        colorTex = ColorStrip(360);
        var rect = new Rect(0, 0, colorTex.width, colorTex.height);
        slider.onValueChanged.AddListener(OnValueChanged);
        sliderBg.sprite = Sprite.Create(colorTex, rect, rect.center);
        slider.value = SaveController.GetBallColor();
        OnValueChanged(SaveController.GetBallColor());
    }

    private void OnValueChanged(float value)
    {
        sliderHandle.color = Color.HSVToRGB(value, 1, 1);
    }

    private Texture2D ColorStrip(int density)
    {
        var hueTex = new Texture2D(density, 1);
        var colors = new Color[density];
        for (int k = 0; k < density; k++)
        {
            colors[k] = Color.HSVToRGB((1.0f * k) / density, 1, 1);
        }
        hueTex.SetPixels(colors);
        hueTex.Apply();
        return hueTex;
    }
}