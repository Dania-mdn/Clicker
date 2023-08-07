using UnityEngine;

public class ManagerButton : MonoBehaviour
{
    public GameObject[] _buttonUpgrade;
    public GameObject[] _button;
    public void CloseButton(GameObject button) => button.SetActive(false);
    public void OpenButton(GameObject button)
    {
        CloseAllButton();
        for (int i = 0; i < _button.Length; i++)
        {
            if(_button[i].name == button.name)
            {
                _button[i].SetActive(true);
            }
        }
    }
    public void ChengeButton(GameObject button)
    {
        CloseAllButton();
        for (int i = 0; i < _buttonUpgrade.Length; i++)
        {
            if (_buttonUpgrade[i].name == button.name)
            {
                _buttonUpgrade[i].transform.position = new Vector3(0.1f, 0.07f, 0);
            }
        }
        EventManager.DoValue();
    }
    public void CloseAllButton()
    {
        for (int i = 0; i < _buttonUpgrade.Length; i++)
        {
            _buttonUpgrade[i].transform.position = new Vector3(-10, _buttonUpgrade[i].transform.position.y, _buttonUpgrade[i].transform.position.z);
        }
        for (int i = 0; i < _button.Length; i++)
        {
            _button[i].SetActive(false);
        }
    }
}
