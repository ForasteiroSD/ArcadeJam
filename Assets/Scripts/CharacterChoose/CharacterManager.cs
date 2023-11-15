using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterManager : MonoBehaviour
{
    [SerializeField] CharacterDataBase characterDB;
    
   
    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }

    public void UpButton()
    {
        selectedOption++;

        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();
    }
    public void teste(){
        Debug.Log("apertei");
    }
    public void DownButton()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        RemoveNonUIGameObjects();
        Debug.Log(character.character);
        Instantiate(character.character, new Vector3(0,0,0), Quaternion.identity);
    }


    private void RemoveNonUIGameObjects()
    {
        GameObject[] allObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject obj in allObjects)
        {
            if (obj != gameObject && obj.GetComponent<Canvas>() == null && obj.GetComponent<Camera>() == null)
            {
                Destroy(obj);
            }
        }
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("SelectedOption", selectedOption);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
