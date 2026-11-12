using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelText : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    void Start()
    {
        string levelName = SceneManager.GetActiveScene().name;
        levelText.text = levelName;
       
    }
}
