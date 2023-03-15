using UnityEngine;

public class ManagerButton : MonoBehaviour
{
    public GameObject[] Button;
    public GameObject[] ButtonUpgrade;
    public void CloseButton(GameObject button) => button.SetActive(false);
    public void OpenButton(GameObject button)
    {
        CloseAllButton();
        for (int i = 0; i < Button.Length; i++)
        {
            if(Button[i].name == button.name)
            {
                Button[i].SetActive(true);
            }
        }
    }
    public void ChengeButton(GameObject button)
    {
        CloseAllButton();
        for (int i = 0; i < ButtonUpgrade.Length; i++)
        {
            if (ButtonUpgrade[i].name == button.name)
            {
                ButtonUpgrade[i].transform.position = new Vector3(0.1f, 0.07f, 0);
            }
        }
    }
    public void CloseAllButton()
    {
        for (int i = 0; i < ButtonUpgrade.Length; i++)
        {
            ButtonUpgrade[i].transform.position = new Vector3(-10, ButtonUpgrade[i].transform.position.y, ButtonUpgrade[i].transform.position.z);
        }
        for (int i = 0; i < Button.Length; i++)
        {
            Button[i].SetActive(false);
        }
    }
}
