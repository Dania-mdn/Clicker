using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    private static int LanguageID;
    private static List<TransleteblText> ListId = new List<TransleteblText>();

    #region ВЕСЬ ТЕКСТ [двухмерный массив]

    private static string[,] LineText =
    {
        #region АНГЛИЙСКИЙ
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

        #region РУСКИЙ
        {
            "Корабли",//0
            "Двигатель",//0
            "Корпус",//0
            "Команда",//0
            "Винт",//0
            "Доход за клик",//0
            "Доход пасивний",//0
            "Залить масло",//0
            "Проводка",//0
            "Корпус двигателя",//0
            "Увеличение бака",//0
            "Количество топлива",//0
            "Увеличение сейфа для денег",//0
            "Сейф денег",//0
            "Обшивка корпуса",//0
            "Обшивка рубки",//0
            "Капитан", //0
            "Боцман", //0
            "Штурман", //0
            "Электромеханик", //0
            "Юнга", //0
            "Посмотреть рекламу за", //0
            "Х2 доход на 1 час?", //0
            "Смотреть", //0
            "Нет, спасибо", //0
            "Х2 за клик на 1 час?", //0
            "Вам подарок!", //0
            "Получить", //0
            "Х12 доход на 10сек?", //0
            "Накопления в отсутствие", //0
            "Забрать х2", //0
            "Забрать", //31
            "Язык", //32
            "Новое достижение", //33
            "для покупки необходимо:" //34
        },
        #endregion

        #region УКРАИНСКИЙ
        {
            "Кораблі",//0
            "Двигун",//0
            "Корпус",//0
            "Команда",//0
            "Гвинт",//0
            "Дохід за клік",//0
            "Дохід пассивний",//0
            "Залити мастило",//0
            "Проводка",//0
            "Корпус двигуна",//0
            "Збільшення баку",//0
            "Кількість топлива",//0
            "Збільшення сейфу для грошей",//0
            "Сховище грошей",//0
            "Обшивка корпусу",//0
            "Обшивка рубки",//0
            "Капітан", //0
            "Боцман", //0
            "Штурман", //0
            "Єлектромеханік", //0
            "Юнга", //0
            "Переглянути рекламу за", //0
            "Х2 дохід на 1 годину?", //0
            "Дивитися", //0
            "Ні, дякую", //0
            "Х2 за клік на 1 годину?", //0
            "Вам подарунок!", //0
            "Отримати", //0
            "Х12 дохід на 10сек?", //0
            "Накопичення за відсутності", //0
            "Забрати х2", //0
            "Забрати", //31
            "Мова", //31
            "Нове досягнення", //32
            "для покупки необхідно:" //34
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
