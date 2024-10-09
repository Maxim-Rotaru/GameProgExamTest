using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject star;
    Vector3 pos;
    float minX = -24;
    float maxX = 24;
    float minZ = -24;
    float maxZ = 24;
    float score = 0;
    public TextMeshProUGUI text;
    public float repeat = 5;
    // Start is called before the first frame update
    void Start()
    { 
        InvokeRepeating("createStar", 1.0f, repeat);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createStar() {
        pos.x = Random.Range(minX, maxX);
        pos.z = Random.Range(minZ, maxZ);
        pos.y = 0;
        Instantiate(star, pos, Quaternion.identity);
        
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        score += 100;
        text.text = "Score: " + score;
    }
}
