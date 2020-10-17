using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PlayerManager : MonoBehaviour
{
    [Serializable]
    public class Player
    {
        public string playerName;

        public float strength;
        public float dexterity;
        public float constitution;
        public float intelligence;
        public float wisdom;
        public float charisma;

        public string race;
        public string playerClass;

        public string alignment;
        public int maxXp;
        public int currentXp;
        public int maxHp;
        public int currentHp;
        public int armorClass;
        public float walkingSpeed;
        public float runningSpeed;
        public float jumpHeight;
        public bool nightVision;

        public string languages;
        public List<string> items;
    };
    private static PlayerManager instance;

    public Player player;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
            player = new Player();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
