using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChewTimeTimer : MonoBehaviour
{

    public const float MaxChewTime = 1000;
    public float CurrentChewTime;

    public RectTransform ChewBar;

    public bool HasEnabledOrDisabled = false;
    public List<GameObject> ListOfSpawnedFood;

    public void Chew()
    {
        ChewBar.sizeDelta = new Vector2(CurrentChewTime, ChewBar.sizeDelta.y);
        StartCoroutine("Chewing");
        //ChewBar.sizeDelta = new Vector2(CurrentChewTime, ChewBar.sizeDelta.y);
    }

    public IEnumerator Chewing()
    {
        while (CurrentChewTime > 0)
        {
            CurrentChewTime -= 10;
            yield return new WaitForSeconds(.1f);
        }
    }

    private void Update()
    {
        ChewBar.sizeDelta = new Vector2(CurrentChewTime, ChewBar.sizeDelta.y);

        if (!HasEnabledOrDisabled)
        {
            if (CurrentChewTime > 0)
            {
                ListOfSpawnedFood.ForEach(m => m.GetComponent<Collider>().enabled = false);
                HasEnabledOrDisabled = true;
            }
            else if (CurrentChewTime == 0)
            {
                HasEnabledOrDisabled = true;
                ListOfSpawnedFood.ForEach(m => m.GetComponent<Collider>().enabled = true);
            }
        }

        if (HasEnabledOrDisabled && CurrentChewTime > 0)
        {
            HasEnabledOrDisabled = false;
        }
    }
}