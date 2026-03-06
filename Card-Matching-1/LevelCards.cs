using System;
using System.Collections.Generic;
using System.Text;


// --- 레벨에 따른 카드 배열 담은 구조체 ---
struct LevelCards
{
    public int[] cards;

    public LevelCards(int level)
    {
        // 쉬움 레벨 카드 (2x4)
        if (level == 1)
        {
            cards = new int[] { 1, 2, 3, 4, 1, 2, 3, 4 };
        }
        // 보통 레벨 카드 (4x4)
        else if (level == 3)
        {
            cards = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        }
        // 어려움 레벨 카드 (4x6)
        else if (level == 2)
        {
            cards = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };
        }
        else { cards = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 }; }
    }

}