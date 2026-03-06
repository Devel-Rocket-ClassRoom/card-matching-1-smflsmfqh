using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

class Card 
{
    //protected int[] Cards = {1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5 ,6 , 7, 8};
    protected LevelCards Cards;
    public int Cols { get; private set; }
    public int CardsLength { get; private set; }
    public int AnswerCount { get; private set; }

    public Card()
    {
        int level = LevelSelect();
        Cards = new LevelCards(level);
        SelectCols(level);
        CardsLength = Cards.cards.Length;
        Shuffle();
    }

    public int SelectCols(int level)
    {
        switch (level)
        {
            case 1:
                {
                    Cols = 4;
                }
                break;
            case 2:
                {
                    Cols = 4;
                }
                break;
            case 3:
                {
                    Cols = 6;
                }
                break;
            default:
                Cols = 4;
                break;
        }
        return Cols;
    }

    public int LevelSelect()
    {
        bool IsValidate = false;
        int level = 0;

        Console.WriteLine("=== 카드 짝 맞추기 게임 ===");
        Console.WriteLine();
        Console.WriteLine("1. 쉬움 (2x4)");
        Console.WriteLine("2. 보통 (4x4)");
        Console.WriteLine("3. 어려움 (4x6)");
        Console.Write("선택: ");
        do
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out level))
            {
                Array levels = Enum.GetValues(typeof(LevelEnum));
                foreach (LevelEnum levelEnum in levels)
                {
                    if (level == (int)levelEnum)
                    {
                        IsValidate = true;
                        break;
                    }
                    else { Console.WriteLine("1, 2, 3 중 하나를 선택하세요."); }
                }
                
            }
        } while (!IsValidate);
        return level;
    }

    // 카드를 셔플하는 메서드
    public void Shuffle()
    {
        Random random = new Random();
        for (int i = Cards.cards.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            int temp = Cards.cards[i];
            Cards.cards[i] = Cards.cards[j];
            Cards.cards[j] = temp;
        }
        Console.WriteLine("카드를 섞는 중...");
    }

    // 플레이어가 카드를 뽑을 때 카드 한 장 반환
    public int GetCard(int cardIndex)
    {
        return Cards.cards[cardIndex];
    }

    // 플레이어가 뽑은 카드 두 장이 같은 카드인지 검사
    public bool IsSameCard(int cardIndex1, int cardIndex2)
    {
       if (Cards.cards[cardIndex1] == Cards.cards[cardIndex2])
        {
            Console.WriteLine("짝을 찾았습니다!");
            AnswerCount++;
            return true;
        }
        Console.WriteLine("짝이 맞지 않습니다!");
       return false;
    }
}
