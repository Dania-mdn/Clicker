using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    private static int LanguageID;
    private static List<TransleteblText> ListId = new List<TransleteblText>();

    #region ���� ����� [���������� ������]

    private static string[,] LineText =
    {
        #region ����������
        {
            "Ships",//0
            "Engine",//1
            "Body",//2
            "Team",//3
            "screw",//4
            "Revenue per click",//5
            "Income passive",//6
            "Pour in oil",//7
            "replacement",//8
            "motor housing",//9
            "Tank increase",//10
            "Amount of fuel",//11
            "Increase seia for money",//12
            "Safe of money",//13
            "Sheathing the hull",//14
            "Sheathing cabin",//15
            "Captain", //16
            "Boatswain", //17
            "Navigator", //18
            "Electromechanic", //19
            "Jung", //20
            "View ad for", //21
            "X2 income for 1 hour?", //22
            "Watch", //23
            "No thanks", //24
            "X2 per click for 1 hour?", //25
            "Gift for you!", //26
            "Get", //27
            "X12 income for 10sec?", //28
            "Accumulation in the absence", //29
            "Take x2", //30
            "Take", //31
            "Language", //32
            "New achievement", //33
            "to purchase you need:" //34
        },
        #endregion

        #region ������
        {
            "�������",//0
            "���������",//0
            "������",//0
            "�������",//0
            "����",//0
            "����� �� ����",//0
            "����� ��������",//0
            "������ �����",//0
            "��������",//0
            "������ ���������",//0
            "���������� ����",//0
            "���������� �������",//0
            "���������� ����� ��� �����",//0
            "���� �����",//0
            "������� �������",//0
            "������� �����",//0
            "�������", //0
            "������", //0
            "�������", //0
            "��������������", //0
            "����", //0
            "���������� ������� ��", //0
            "�2 ����� �� 1 ���?", //0
            "��������", //0
            "���, �������", //0
            "�2 �� ���� �� 1 ���?", //0
            "��� �������!", //0
            "��������", //0
            "�12 ����� �� 10���?", //0
            "���������� � ����������", //0
            "������� �2", //0
            "�������", //31
            "����", //32
            "����� ����������", //33
            "��� ������� ����������:" //34
        },
        #endregion

        #region ����������
        {
            "������",//0
            "������",//0
            "������",//0
            "�������",//0
            "�����",//0
            "����� �� ���",//0
            "����� ���������",//0
            "������ �������",//0
            "��������",//0
            "������ �������",//0
            "��������� ����",//0
            "ʳ������ �������",//0
            "��������� ����� ��� ������",//0
            "������� ������",//0
            "������� �������",//0
            "������� �����",//0
            "������", //0
            "������", //0
            "�������", //0
            "�������������", //0
            "����", //0
            "����������� ������� ��", //0
            "�2 ����� �� 1 ������?", //0
            "��������", //0
            "ͳ, �����", //0
            "�2 �� ��� �� 1 ������?", //0
            "��� ���������!", //0
            "��������", //0
            "�12 ����� �� 10���?", //0
            "����������� �� ���������", //0
            "������� �2", //0
            "�������", //31
            "����", //31
            "���� ����������", //32
            "��� ������� ���������:" //34
        },
        #endregion
    };
    #endregion

    static public void SelectLanguage(int id)
    {
        LanguageID = id;
        UpdateTexts();
    }
    static public string Get_text(int textKey) => (LineText[LanguageID, textKey]);
    static public void Add(TransleteblText idtext) => ListId.Add(idtext);
    static public void Delete(TransleteblText idtext) => ListId.Remove(idtext);
    static public void UpdateTexts()
    {
        for(int i = 0; i < ListId.Count; i++)
        {
            ListId[i].UItext.text = LineText[LanguageID, ListId[i].textID];
        }
    }
}
