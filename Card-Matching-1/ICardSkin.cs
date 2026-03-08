using System;

// --- 카드 스킨 인터페이스 ---
interface ICardSkin
{
    string GetDisplay(int cardValue);
    ConsoleColor GetColor(int cardValue);
}