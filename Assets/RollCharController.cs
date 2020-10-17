using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RollCharController : MonoBehaviour
{
    public GameObject goRollStrength, goRollDexterity, goRollConstitution, goStrengthText, goDexterityText, goConstitutionText, gorace;
    public GameObject goRollIntelligence, goRollWisdom, goRollCharisma, goIntelligenceText, goWisdomText, goCharismaText, goClass;
    private GameObject goJsonOutText;

    protected Button rollStrengthButton, rollDexterityButton, rollConstitutionButton;
    protected Button rollIntelligenceButton, rollWisdomButton, rollCharismaButton;
    protected Button rollAllAbilities;
    protected Button mainMenu;

    protected TMP_Dropdown raceDropdown, classDropdown;

    public TMP_Text rollStrengthOutText, rollDexterityOutText, rollConstitutionOutText;
    public TMP_Text rollIntelligenceOutText, rollWisdomOutText, rollCharismaOutText;
    public TMP_Text selectedRaceText, selectedClassText;
    private TMP_InputField CharName;
    public Text jsonOutputText;

    protected List<Race> raceList;
    protected List<PlayerClass> playerClassList;

    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        goJsonOutText = GameObject.Find("JSON_OutText");
        jsonOutputText = goJsonOutText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IntiRollCharUI()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        CharName = GameObject.Find("CharacterName").GetComponent<TMP_InputField>();
        goRollStrength = GameObject.Find("RollStrength");
        goRollDexterity = GameObject.Find("RollDexterity");
        goRollConstitution = GameObject.Find("RollConstitution");
        goRollIntelligence = GameObject.Find("RollIntelligence");
        goRollWisdom = GameObject.Find("RollWisdom");
        goRollCharisma = GameObject.Find("RollCharisma");
        goStrengthText = GameObject.Find("StrengthOutput");
        goDexterityText = GameObject.Find("DexterityOutput");
        goConstitutionText = GameObject.Find("ConstitutionOutput");
        goIntelligenceText = GameObject.Find("IntelligenceOutput");
        goWisdomText = GameObject.Find("WisdomOutput");
        goCharismaText = GameObject.Find("CharismaOutput");
        rollStrengthButton = goRollStrength.GetComponentInChildren<Button>();
        rollStrengthOutText = goStrengthText.GetComponentInChildren<TMP_Text>();
        rollDexterityButton = goRollDexterity.GetComponentInChildren<Button>();
        rollDexterityOutText = goDexterityText.GetComponentInChildren<TMP_Text>();
        rollConstitutionButton = goRollConstitution.GetComponentInChildren<Button>();
        rollConstitutionOutText = goConstitutionText.GetComponentInChildren<TMP_Text>();
        rollIntelligenceButton = goRollIntelligence.GetComponentInChildren<Button>();
        rollIntelligenceOutText = goIntelligenceText.GetComponentInChildren<TMP_Text>();
        rollWisdomButton = goRollWisdom.GetComponentInChildren<Button>();
        rollWisdomOutText = goWisdomText.GetComponentInChildren<TMP_Text>();
        rollCharismaButton = goRollCharisma.GetComponentInChildren<Button>();
        rollCharismaOutText = goCharismaText.GetComponentInChildren<TMP_Text>();
        raceList = new List<Race>(){
        new Race() { Name = "Dragonborn", summary = "Your draconic heritage manifests in a variety of traits you share with other dragonborn.", alignment = "chaotic good",
            HP = 10, speedWalking = 10, speedRunning = 20, speedJumping = 20, languages = "Common, Draconic", nightVision = true},
        new Race() { Name = "Dwarf", summary = "Your dwarf character has an assortment of inborn abilitiles, part and parcel of dwarven nature.", alignment = "lawful good",
            HP = 10, speedWalking = 7, speedRunning = 10, speedJumping = 3, languages = "Common, Dwarvish", nightVision = true},
        new Race() {Name = "Elf", summary = "Your elf character has a variety of natural abilities, the result of thousands of years of elven refinement.", alignment = "chaotic good",
            HP = 12, speedWalking = 17, speedRunning = 22, speedJumping = 13, languages = "Common, Elvish", nightVision = true},
        new Race() {Name = "Gnome", summary = "Your gnome character has certain characteristics in common with all other gnomes.", alignment = "chaotic good",
        HP = 17, speedWalking = 9, speedRunning = 12, speedJumping = 13, languages = "Common, Gnomish", nightVision = false},
        new Race() {Name = "Human", summary = "It's hard to make generalizations about humans, but your human character has these traits.", alignment = "true neutral",
        HP = 10, speedWalking = 10, speedRunning = 20, speedJumping = 13, languages = "Common", nightVision = false},
        new Race() {Name = "Halfling", summary = "Your halfling character has a number of traits in common with all other halflings", alignment = "lawful good",
        HP = 10, speedWalking = 9, speedRunning = 12, speedJumping = 13, languages = "Common, Halfling", nightVision = false},
        new Race() {Name = "Half-Elf", summary = "Your half-elf character has some qualities in common with elves and some that are unique to half-elves.", alignment = "chaotic neutral",
        HP = 12, speedWalking = 17, speedRunning = 20, speedJumping = 13, languages = "Common, Elvish", nightVision = true},
        new Race() {Name = "Half-Orc", summary = "Your half-orc has certain traits deriving from your orc ancestry", alignment = "chaotic evil",
        HP = 12, speedWalking = 10, speedRunning = 20, speedJumping = 13, languages = "Common, Orc", nightVision = true},
        new Race() {Name = "Tiefling", summary = "Tieflings share certain racial traits as a result of their infernal descent", alignment = "chaotic neutral",
        HP = 10, speedWalking = 10, speedRunning = 20, speedJumping = 13, languages = "Common, Infernal"}
        };
        playerClassList = new List<PlayerClass>() {
            new PlayerClass() {Name = "Barbarian", armorClass = 11},
            new PlayerClass() {Name = "Bard", armorClass = 11},
            new PlayerClass() {Name = "Cleric", armorClass = 11},
            new PlayerClass() {Name = "Druid", armorClass = 11},
            new PlayerClass() {Name = "Fighter", armorClass = 14},
            new PlayerClass() {Name = "Monk", armorClass = 0},
            new PlayerClass() {Name = "Paladin", armorClass = 14},
            new PlayerClass() {Name = "Ranger", armorClass = 12},
            new PlayerClass() {Name = "Rogue", armorClass = 11},
            new PlayerClass() {Name = "Sorceror", armorClass = 0},
            new PlayerClass() {Name = "Warlock", armorClass = 11},
            new PlayerClass() {Name = "Wizard", armorClass = 0}
        };
        gorace = GameObject.Find("RaceDropdown");
        GameObject goorrdd = GameObject.FindGameObjectWithTag("RaceDropdown");
        selectedRaceText = GameObject.Find("selectedRaceText").GetComponent<TMP_Text>();

        goClass = GameObject.Find("ClassDropdown");
        GameObject goocdd = GameObject.FindGameObjectWithTag("ClassDropdown");
        selectedClassText = GameObject.Find("selectedClassText").GetComponent<TMP_Text>();

        raceDropdown = GameObject.Find("RaceDropdown").GetComponent<TMP_Dropdown>();
        raceDropdown.ClearOptions();
        List<string> newOptions = new List<string>();
        for(int i = 0; i < raceList.Count; i++)
        {
            newOptions.Add(raceList[i].Name);
        }
        raceDropdown.AddOptions(newOptions);
        raceDropdown_IndexChanged(0);

        classDropdown = GameObject.Find("ClassDropdown").GetComponent<TMP_Dropdown>();
        classDropdown.ClearOptions();
        List<string> newCOptions = new List<string>();
        for(int i = 0; i < playerClassList.Count; i++)
        {
            newCOptions.Add(playerClassList[i].Name);
        }
        classDropdown.AddOptions(newCOptions);
        classDropdownIndexChanged(0);

        rollStrengthButton.onClick.AddListener(RollStrengthAbility);
        rollDexterityButton.onClick.AddListener(RollDexterityAbility);
        rollConstitutionButton.onClick.AddListener(RollConstitutionAbility);
        rollIntelligenceButton.onClick.AddListener(RollIntelligenceAbility);
        rollWisdomButton.onClick.AddListener(RollWisdomAbility);
        rollCharismaButton.onClick.AddListener(RollCharismaAbility);
        raceDropdown.onValueChanged.AddListener(raceDropdown_IndexChanged);
        classDropdown.onValueChanged.AddListener(classDropdownIndexChanged);

        GameObject.Find("MakeCharButton").GetComponent<Button>().onClick.AddListener(()=>makeJsonCharacter());
    }

    private void makeJsonCharacter()
    {
        playerManager.player.playerName = CharName.text;
        jsonOutputText.text = "Player name" + playerManager.player.playerName;
        jsonOutputText.text = "Player race = " + playerManager.player.race + " . Player strength" + playerManager.player.strength + "...";
        jsonOutputText.text = "Player dexterity" + playerManager.player.dexterity + "...";
        jsonOutputText.text = "Player constitution" + playerManager.player.constitution + "...";
        jsonOutputText.text = "Player intelligence" + playerManager.player.intelligence + "...";
        jsonOutputText.text = "Player wisdom" + playerManager.player.wisdom + "...";
        jsonOutputText.text = "Player charisma" + playerManager.player.charisma + "...";
        jsonOutputText.text = JsonUtility.ToJson(playerManager.player);
    }

    void RollStrengthAbility()
    {
        Debug.Log("RollStrength called");
        int strengthValue = diceRoll();
        rollStrengthOutText.text = strengthValue.ToString();
        playerManager.player.strength = strengthValue;
    }

    void RollDexterityAbility()
    {
        Debug.Log("RollDexterity called");
        int dexterityValue = diceRoll();
        rollDexterityOutText.text = dexterityValue.ToString();
        playerManager.player.dexterity = dexterityValue;
    }

    void RollConstitutionAbility()
    {
        Debug.Log("RollConstitution called");
        int constitutionValue = diceRoll();
        rollConstitutionOutText.text = constitutionValue.ToString();
        playerManager.player.constitution = constitutionValue;
    }

    void RollIntelligenceAbility()
    {
        Debug.Log("RollIntelligence called");
        int intelligenceValue = diceRoll();
        rollIntelligenceOutText.text = intelligenceValue.ToString();
        playerManager.player.intelligence = intelligenceValue;
    }

    void RollWisdomAbility()
    {
        Debug.Log("RollWisdom called");
        int wisdomValue = diceRoll();
        rollWisdomOutText.text = wisdomValue.ToString();
        playerManager.player.wisdom = wisdomValue;
    }

    void RollCharismaAbility()
    {
        Debug.Log("RollCharisma called");
        int charismaValue = diceRoll();
        rollCharismaOutText.text = charismaValue.ToString();
        playerManager.player.charisma = charismaValue;
    }
    private int diceRoll()
    {
        int value;
        List<int> sixSidedList = new List<int>();
        List<int> fourSidedList = new List<int>();

        sixSidedList.Add(UnityEngine.Random.Range(1, 6));
        sixSidedList.Add(UnityEngine.Random.Range(1, 6));
        sixSidedList.Add(UnityEngine.Random.Range(1, 6));
        fourSidedList.Add(UnityEngine.Random.Range(1, 4));
        fourSidedList.Add(UnityEngine.Random.Range(1, 4));
        fourSidedList.Add(UnityEngine.Random.Range(1, 4));
        sixSidedList.Sort();
        fourSidedList.Sort();
        fourSidedList.RemoveAt(0);
        sixSidedList.RemoveAt(0);

        return value = fourSidedList.Sum() + sixSidedList.Sum() + 2;
    }

    [System.Serializable]
    public class Race
    {
        public string Name = "";
        public string summary = "";
        public string alignment = "neutral";
        public int HP = 0;
        public float speedWalking = 0;
        public float speedRunning = 0;
        public float speedJumping = 0;
        public string languages = "Common";
        public bool nightVision = false;
    }

    [System.Serializable]
    public class PlayerClass
    {
        public string Name = "";
        public int armorClass = 0;
    }

    public void raceDropdown_IndexChanged(int index)
    {
        Race selected = raceList[raceDropdown.value];
        playerManager.player.race = selected.Name;
        playerManager.player.alignment = selected.alignment;
        playerManager.player.walkingSpeed = selected.speedWalking;
        playerManager.player.runningSpeed = selected.speedRunning;
        playerManager.player.jumpHeight = selected.speedJumping;
        playerManager.player.maxHp = selected.HP;
        playerManager.player.maxXp = selected.HP;
        playerManager.player.currentHp = selected.HP;
        playerManager.player.nightVision = selected.nightVision;
        playerManager.player.languages = selected.languages;

        selectedRaceText.text = selected.Name + "- " + selected.summary
            + "\nalignment = " + selected.alignment
            + "\n HP = " + selected.HP.ToString()
            + "\n WalkingSpeed =" + selected.speedWalking.ToString()
            + "\n Languages =" + selected.languages.ToString();
    }

    public void classDropdownIndexChanged(int index)
    {
        PlayerClass selected = playerClassList[classDropdown.value];
        playerManager.player.playerClass = selected.Name;
        playerManager.player.armorClass = selected.armorClass;

        selectedClassText.text = selected.Name + "\narmor class: " + selected.armorClass.ToString();
    }
}
