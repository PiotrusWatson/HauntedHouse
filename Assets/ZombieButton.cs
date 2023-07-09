using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ZombieButton : MonoBehaviour
{
    SpawnerManager manager;
    public Morale zombieSpawnCooldown;
    Button zombieButton;
    UIDocument doc;
    // Start is called before the first frame update

    IEnumerator CountdownButton(){
        while (zombieSpawnCooldown.amount > 0){
            yield return new WaitForSeconds(1);
            zombieButton.text = zombieSpawnCooldown.amount.ToString();
        }
        zombieButton.text = "ZOMB";
    }
    void Start()
    {
        manager = Camera.main.GetComponent<SpawnerManager>();
        doc = GetComponent<UIDocument>();
        zombieButton = doc.rootVisualElement.Query<Button>("ZombieButton");
        zombieButton.RegisterCallback<ClickEvent>(ev => ReleaseZombie());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReleaseZombie(){
        manager.Spawn();
        StartCoroutine(CountdownButton());
    }
}
