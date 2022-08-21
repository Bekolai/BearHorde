using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameoverPanel, winPanel;
    [SerializeField] TMP_Text levelText;
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        setLevelText();
    }
    public void callGameOverUI()
    {
        Invoke("GameOverUI", 1f);
    }
    public void callWinUI()
    {
        Invoke("WinUI", 2f);
    }
    void GameOverUI()
    {
        gameoverPanel.SetActive(true) ;
    }
    void WinUI()
    {
        winPanel.SetActive(true);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1);
        AudioManager.Instance.PlayWinSFX();
    }
    public void setLevelText()
    {
        levelText.text="LEVEL "+(PlayerPrefs.GetInt("Level")+1).ToString();
    }
}
