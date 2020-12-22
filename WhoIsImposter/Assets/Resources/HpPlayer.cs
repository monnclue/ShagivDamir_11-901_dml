using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPlayer : MonoBehaviour
{

    [SerializeField]
    private int check;
    public int hp { get; private set; }
    public int fullHp { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        //default
        fullHp = 100;
        hp = fullHp;
    }

    // Update is called once per frame
    void Update()
    {
        check = hp;
    }

    public void SetDamage(int damage)
    {
        hp -= damage;
    }
}
