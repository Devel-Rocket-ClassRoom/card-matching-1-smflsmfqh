using System;
using System.Collections.Generic;
using System.Text;

class Player : Card
{
    private int[] _answerCards;
    public int[] AnswerCards { get { return _answerCards; } }
    
    public bool IsFind { get; private set; } = false;

    public Player()
    {
        _answerCards = new int[CardsLength];
    }

    public void PushCard(int index)
    {
        if (!IsAlreadyFind(index))
        {
            AnswerCards[index] = GetCard(index);
        }
    }

    public bool IsAlreadyFind(int index)
    {
        if (AnswerCards[index] != 0)
        {
            Console.WriteLine("이미 짝을 찾은 카드입니다. 다른 카드를 선택하세요.");
            Console.WriteLine();
            IsFind = true;
            return true;
        }
        IsFind = false;
        return false;
    }

    public void PushOrRemoveCard(int index1, int index2)
    {
        bool result = IsSameCard(index1, index2);
        if (!result)
        {
            AnswerCards[index1] = 0;
            AnswerCards[index2] = 0;
        }
        
    }

}
