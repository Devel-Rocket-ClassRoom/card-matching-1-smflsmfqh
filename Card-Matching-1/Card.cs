using System;

// --- 카드 관리하는 클래스 ---
class Card : ICardSkin
{
    protected LevelCards Cards;
    public int Cols { get; private set; }
    public int CardsLength { get; private set; }
    protected int AnswerCount { get; private set; } = 0;
    protected virtual int TrialCount { get; private set; } = 0;
    protected virtual int SkinMode { get; private set; }

    // --- 카드 생성자 ---
    // 레벨 선택 후, 레벨에 맞는 카드 배열 생성한 뒤 셔플
    public Card()
    {
        int level = SelectLevel();
        Cards = new LevelCards(level);
        SetCols(level);
        SetTryCount(level);
        SelectSkin();
        CardsLength = Cards.cards.Length;
        Shuffle();
    }
    
    // --- 레벨에 따라 시도횟수 초기화 메서드 ---
    private int SetTryCount(int level)
    {
        switch (level)
        {
            case 1:
                {
                    TrialCount = 10;
                }
                break;
            case 2:
                {
                    TrialCount = 20;
                }
                break;
            case 3:
                {
                    TrialCount = 30;
                }
                break;
            default:
                { TrialCount = 30; }
                break;
        }
        return TrialCount;
    }

    // --- 레벨 선택에 따라 출력 열 초기화 메서드 ---
    private int SetCols(int level)
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

    // --- 레벨 선택 메서드 ---
    // 사용자의 입력을 받아 정수 변환 및 레벨 열거형에 맞는지 검토 후 반환
    private int SelectLevel()
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
                }
                if (!IsValidate) { Console.WriteLine("1 (쉬움), 2 (보통), 3 (어려움) 중 하나를 선택하세요."); }
            }
        } while (!IsValidate);

        return level;
    }

    private int SelectSkin()
    {
        int skin = 0;
        Console.WriteLine("카드 스킨을 선택하세요.: ");
        Console.WriteLine("1. 숫자 (기본)");
        Console.WriteLine("2. 알파벳 (컬러)");
        Console.WriteLine("3. 기호 (컬러)");
        Console.Write("선택: ");
        do
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out skin))
            {
                if (skin >= 1 && skin <= 3)
                {
                    break;
                }
            }
            else { Console.WriteLine("1 (숫자 - 기본), 2 (알파벳 - 컬러), 3 (기호 - 컬러) 중 하나를 선택해주세요."); }
        } while (true);

        SkinMode = skin;
        return SkinMode;
    }

    // --- 카드를 셔플하는 메서드 ---
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

    // --- 플레이어가 카드를 뽑을 때 카드 한 장 반환 ---
    protected int GetCard(int cardIndex)
    {
        return Cards.cards[cardIndex];
    }

    public virtual string GetDisplay(int cardValue)
    {
        switch (cardValue)
        {
            case 1:
                { return "○"; }
                break;
            case 2:
                { return "☐"; }
                break;
            case 3:
                { return "△"; }
                break;
            case 4:
                { return "⭐︎"; }
                break;
            case 5:
                { return "✧"; }
                break;
            case 6:
                { return "♡"; }
                break;
            case 7:
                { return "♢"; }
                break;
            case 8:
                { return "♘"; }
                break;
            case 9:
                { return "♔"; }
                break;
            case 10:
                { return "⚾︎"; }
                break;
            case 11:
                { return "☘"; }
                break;
            case 12:
                { return "☻"; }
                break;
            default:
                { return "☓"; }
                break;
        }
    }
    public virtual ConsoleColor GetColor(int cardValue)
    {
        switch (cardValue)
        {
            case 1:
                { return Console.ForegroundColor = ConsoleColor.Blue; }
                break;
            case 2:
                { return Console.ForegroundColor = ConsoleColor.Black; }
                break;
            case 3:
                { return Console.ForegroundColor = ConsoleColor.Magenta; }
                break;
            case 4:
                { return Console.ForegroundColor = ConsoleColor.Yellow; }
                break;
            case 5:
                { return Console.ForegroundColor = ConsoleColor.DarkCyan; }
                break;
            case 6:
                { return Console.ForegroundColor = ConsoleColor.Red; }
                break;
            case 7:
                { return Console.ForegroundColor = ConsoleColor.Cyan; }
                break;
            case 8:
                { return Console.ForegroundColor = ConsoleColor.DarkMagenta; }
                break;
            case 9:
                { return Console.ForegroundColor = ConsoleColor.DarkRed; }
                break;
            case 10:
                { return Console.ForegroundColor = ConsoleColor.DarkBlue; }
                break;
            case 11:
                { return Console.ForegroundColor = ConsoleColor.Green; };
                break;
            case 12:
                { return Console.ForegroundColor = ConsoleColor.DarkGreen; }
                break;
            default:
                { return Console.ForegroundColor = ConsoleColor.White; }
                break;
        }
    }

    // --- 플레이어가 뽑은 카드 두 장이 같은 카드인지 검사 ---
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
