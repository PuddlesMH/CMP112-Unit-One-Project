using UnityEngine;
using TMPro;

public class KeyDisplay : MonoBehaviour
{
    public TextMeshProUGUI keyText;

    //Displays the amount of keys the player has, calling in KeyScript to update the value
    void Update()
    {
        keyText.text = "Key: " + KeyScript.keyCollect;
    }
}
