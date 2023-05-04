using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
   

    enum TextColor
    {
        Blue,
        Red,
        Green
    }
    [SerializeField] TextColor TxtColor = new TextColor();


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)|| Input.GetKey("enter"))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }

    void NextLine()
    {
        if (index < lines.Length -1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        textComponent.overrideColorTags = true;
        if (TxtColor == TextColor.Red)
        {
            textComponent.color = new Color32(255, 0, 0, 255);
        }
        if (TxtColor == TextColor.Green)
        {
            textComponent.color = new Color32(0, 255, 0, 255);
        }
        if (TxtColor == TextColor.Blue)
        {
            textComponent.color = new Color32(0, 0, 255, 255);
        }
    }
}
