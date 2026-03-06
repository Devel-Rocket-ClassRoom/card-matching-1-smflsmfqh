using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

class Card 
{
    protected int[] Cards = {1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5 ,6 , 7, 8};
    public int AnswerCount { get; private set; }

    public Card()
    {
        Shuffle();
    }

    // 카드를 셔플하는 메서드
    public void Shuffle()
    {
        Random random = new Random();
        for (int i = Cards.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            int temp = Cards[i];
            Cards[i] = Cards[j];
            Cards[j] = temp;
        }
        Console.WriteLine("카드를 섞는 중...");
    }

    // 플레이어가 카드를 뽑을 때 카드 한 장 반환
    public int GetCard(int cardIndex)
    {
        return Cards[cardIndex];
    }

    // 플레이어가 뽑은 카드 두 장이 같은 카드인지 검사
    public bool IsSameCard(int cardIndex1, int cardIndex2)
    {
       if (Cards[cardIndex1] == Cards[cardIndex2])
        {
            Console.WriteLine("짝을 찾았습니다!");
            AnswerCount++;
            return true;
        }
        Console.WriteLine("짝이 맞지 않습니다!");
       return false;
    }
}
