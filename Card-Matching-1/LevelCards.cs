using System;
using System.Collections.Generic;
using System.Text;


struct LevelCards
{
    public int[] cards;

    public LevelCards(int level)
    {
        if (level == 1)
        {
            cards = new int[] { 1, 2, 3, 4, 1, 2, 3, 4 };
        }
        else if (level == 3)
        {
            cards = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        }
        else if (level == 2)
        {
            cards = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };
        }
        else { cards = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 }; }
    }
    
}