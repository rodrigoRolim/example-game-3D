using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int lifes;
    public void decreasingLife(int lifes) {
        lifes--;
        setLifes(lifes);
    }
    public void setLifes(int lifes) {
        this.lifes = lifes;
        GameObject.Find("Lifes").GetComponent<Text>().text = lifes.ToString();
    }
    public int getLifes() {
        return this.lifes;
    }
}
