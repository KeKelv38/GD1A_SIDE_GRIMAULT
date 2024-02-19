using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int journalCount;
    public Text journalCountText;
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }
    
    public void AddJournal(int count)
    {
        journalCount += count;
        journalCountText.text = journalCount.ToString();
    }
}
