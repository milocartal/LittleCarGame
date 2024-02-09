// Alan Zucconi
// www.alanzucconi.com
using UnityEngine;

public enum ColorBlindMode
{
    Normal = 0,
    Protanopia = 1,
    Protanomaly = 2,
    Deuteranopia = 3,
    Deuteranomaly = 4,
    Tritanopia = 5,
    Tritanomaly = 6,
    Achromatopsia = 7,
    Achromatomaly = 8,

    //On garde Deuteranopia 4 / Protanopia 1 / tritanpia 6 
}

[ExecuteInEditMode]
public class ColorBlindFilter : MonoBehaviour
{
    public ColorBlindMode mode = ColorBlindMode.Normal;
    private ColorBlindMode previousMode = ColorBlindMode.Normal;

    public bool showDifference = false;

    private Material material;

    private static Color[,] RGB =
    {
        { new Color(1f,0f,0f),   new Color(0f,1f,0f), new Color(0f,0f,1f) },    // Normal
        { new Color(.56667f, .43333f, 0f), new Color(.55833f, .44167f, 0f), new Color(0f, .24167f, .75833f) },    // Protanopia
        { new Color(.81667f, .18333f, 0f), new Color(.33333f, .66667f, 0f), new Color(0f, .125f, .875f)    }, // Protanomaly
        { new Color(.625f, .375f, 0f), new Color(.70f, .30f, 0f), new Color(0f, .30f, .70f)    },   // Deuteranopia
        { new Color(.80f, .20f, 0f), new Color(.25833f, .74167f, 0), new Color(0f, .14167f, .85833f)    },    // Deuteranomaly
        { new Color(.95f, .05f, 0), new Color(0f, .43333f, .56667f), new Color(0f, .475f, .525f) }, // Tritanopia
        { new Color(.96667f, .03333f, 0), new Color(0f, .73333f, .26667f), new Color(0f, .18333f, .81667f) }, // Tritanomaly
        { new Color(.299f, .587f, .114f), new Color(.299f, .587f, .114f), new Color(.299f, .587f, .114f)  },   // Achromatopsia
        { new Color(.618f, .32f, .062f), new Color(.163f, .775f, .062f), new Color(.163f, .320f, .516f)  }    // Achromatomaly
    };

    private void Start()
    {
        switch (PlayerPrefs.GetInt("ColorBlindMode"))
        {
            case 1:
                mode = ColorBlindMode.Protanopia;
                break;
            case 2:
                mode = ColorBlindMode.Protanomaly;
                break;
            case 3:
                mode = ColorBlindMode.Deuteranopia;
                break;
            case 4:
                mode = ColorBlindMode.Deuteranomaly;
                break;
            case 5:
                mode = ColorBlindMode.Tritanopia;
                break;
            case 6:
                mode = ColorBlindMode.Tritanomaly;
                break;
            case 7:
                mode = ColorBlindMode.Achromatopsia;
                break;
            case 8:
                mode = ColorBlindMode.Achromatomaly;
                break;
            default:
                mode = ColorBlindMode.Normal;
                break;
        }
    }

    void Awake()
    {
        material = new Material(Shader.Find("Hidden/ChannelMixer"));
        material.SetColor("_R", RGB[0, 0]);
        material.SetColor("_G", RGB[0, 1]);
        material.SetColor("_B", RGB[0, 2]);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // No effect
        if (mode == ColorBlindMode.Normal)
        {
            Graphics.Blit(source, destination);
            return;
        }

        // Change effect
        if (mode != previousMode)
        {
            material.SetColor("_R", RGB[(int)mode, 0]);
            material.SetColor("_G", RGB[(int)mode, 1]);
            material.SetColor("_B", RGB[(int)mode, 2]);
            previousMode = mode;
        }

        // Apply effect
        Graphics.Blit(source, destination, material, showDifference ? 1 : 0);
    }

    public void SelectColorBlindMode(int ColorMode)
    {
        PlayerPrefs.SetInt("ColorBlindMode", ColorMode);
        switch (ColorMode)
        {
            case 1:
                previousMode = mode;
                mode = ColorBlindMode.Protanopia;
                break;
            case 2:
                previousMode = mode;
                mode = ColorBlindMode.Protanomaly;
                break;
            case 3:
                previousMode = mode;
                mode = ColorBlindMode.Deuteranopia;
                break;
            case 4:
                previousMode = mode;
                mode = ColorBlindMode.Deuteranomaly;
                break;
            case 5:
                previousMode = mode;
                mode = ColorBlindMode.Tritanopia;
                break;
            case 6:
                previousMode = mode;
                mode = ColorBlindMode.Tritanomaly;
                break;
            case 7:
                previousMode = mode;
                mode = ColorBlindMode.Achromatopsia;
                break;
            case 8:
                previousMode = mode;
                mode = ColorBlindMode.Achromatomaly;
                break;
            default:
                previousMode = mode;
                mode = ColorBlindMode.Normal;
                break;
        }
    }
}