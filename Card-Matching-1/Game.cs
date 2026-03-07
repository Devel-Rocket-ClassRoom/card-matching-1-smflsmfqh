using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

// --- card 매칭 게임 플레이하는 클래스 ---
class Game : Player
{
    private int CardIndex1;
    private int CardIndex2;
    private int _turnCount = 1;
    private string input = string.Empty;
    public Game() { }

    // --- 카드 매칭 게임 플레이하는 메서드 ---
    public void Play()
    {
        Thread.Sleep(1000);

        DisplayPreview(SkinMode);

        while ((_turnCount / 2) < TrialCount)
        {
            Console.Clear();
            Console.WriteLine();
            SelectAndPrint(SkinMode);
            if (AnswerCount == AnswerCards.Length / 2) { break; }
            FirstTurn();
            SecondTurn();
            Thread.Sleep(1000);
           

        }
        if (AnswerCount == AnswerCards.Length / 2)
        {
            Console.WriteLine();
            Console.WriteLine("=== 게임 클리어! ===");
            Console.WriteLine($"총 시도 횟수: {_turnCount / 2}");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("=== 게임 오버! ===");
            Console.WriteLine("시도 횟수를 모두 사용했습니다");
            Console.WriteLine($"찾은 쌍: {AnswerCount} / {AnswerCards.Length / 2}");
            Console.WriteLine();
        }
    }

    // --- 첫 번째 카드 뽑는 턴 메서드 ---
    public void FirstTurn()
    {
        Console.WriteLine();

        do
        {
            UserInput();
            CardIndex1 = CalculateIndex(input);
            PushCard(CardIndex1);
        } while (IsFind);
        _turnCount++;
        Console.Clear();
        SelectAndPrint(SkinMode);

    }

    // --- 두 번째 카드 뽑는 턴 메서드 ---
    public void SecondTurn()
    {
        Console.WriteLine();

        do
        {
            UserInput();
            CardIndex2 = CalculateIndex(input);
            PushCard(CardIndex2);
        } while (IsFind);
        _turnCount++;
        Console.Clear();
        SelectAndPrint(SkinMode);
        PushOrRemoveCard(CardIndex1, CardIndex2);

    }

    // --- 사용자 입력 받기 ---
    // _turnCount로 첫 번째, 두 번째 입력 분기 및 유효한 입력 받기
    // 유효한 입력일 시 문자열 반환
    public string UserInput()
    {
        string firstInput = string.Empty;
        string secondInput = string.Empty;

        while (true)
        {
            switch (_turnCount % 2)
            {
                case 1:
                    {
                        Console.Write("첫 번째 카드를 선택하세요 (행 열): ");
                        firstInput = Console.ReadLine();
                        input = firstInput;
                    }
                    break;
                case 0:
                    {
                        do
                        {
                            Console.Write("두 번째 카드를 선택하세요 (행 열): ");
                            secondInput = Console.ReadLine();
                            if (input != secondInput)
                            {
                                input = secondInput;
                                break;
                            }
                            Console.Write("이미 선택된 카드입니다. 다른 카드를 선택하세요\n");
                        } while (true);
                    }
                    break;
            }

            // 유효한 입력 검증
            if (!int.TryParse(input.Replace(" ", ""), out int num1) || input.Length !=3)
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요. ");
            }
            else if (input[1] == ' ' && int.TryParse(input.Replace(" ", ""), out int num2))
            {
                num2 = (input[0] - '0') * (input[2] - '0');
                if (num2 <= AnswerCards.Length)
                {
                    break;
                }
                else { Console.WriteLine("범위를 벗어났습니다. 다시 입력해주세요."); }
            }
            else if (input[1] != ' ')
            {
                Console.WriteLine("행과 열 사이에 공백을 입력해주세요.");
                Console.WriteLine();
            }

        }

        return input;
    }

    // --- 사용자에게 입력 받은 문자열 카드 인덱스로 계산 메서드 ---
    // 2차원 행렬 인덱스 -> 1차원 배열 인덱스로 변환
    public int CalculateIndex(string input)
    {
        int i = (int)Char.GetNumericValue(input[0]) - 1;
        int j = (int)Char.GetNumericValue(input[2]) - 1;

        return i * Cols + j;
    }

    public void DisplayPreview(int skinmode)
    {
        int previewTime = 0;
        Console.Write("    ");
        for (int i = 0; i < EntireCards.Length / Cols; i++)
        {
            Console.Write($"{i + 1}열  ");
        }
        Console.WriteLine();
        for (int i = 0; i < EntireCards.Length / Cols; i++)
        {
            Console.Write($"{i + 1}행 ");
            for (int j = 0; j < Cols; j++)
            {
                if (skinmode == 1)
                {
                    Console.Write($"[{EntireCards[i * Cols + j]}]  ");
                }
                else if (skinmode == 2)
                {
                    GetColor(EntireCards[i * Cols + j]);
                    char alphaCard = (char)(EntireCards[i * Cols + j] + 65);
                    Console.Write($"[{alphaCard}]  ");
                    Console.ResetColor();
                }
                else
                {
                    GetColor(EntireCards[i * Cols + j]);
                    string emojiCard = GetDisplay(EntireCards[i * Cols + j]);
                    Console.Write($"[{emojiCard}]  ");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
        }
        if (TrialCount == 10) { previewTime = 5; }
        else if (TrialCount == 20) { previewTime = 3; }
        else { previewTime = 2; }
        Console.WriteLine();
        Console.WriteLine($"잘 기억하세요! ({previewTime}초 후 뒤집힙니다)");
        Thread.Sleep(previewTime * 1000);
    }
    public void SelectAndPrint(int skinmode)
    {
        if (skinmode == 1) { PrintBasicCards(); }
        else if (skinmode == 2) { PrintAlphaCards(); }
        else { PrintEmojiCards(); }
    }

    // --- 카드판 출력 메서드 ---
    public void PrintBasicCards()
    {
        Console.WriteLine("=== 카드 짝 맞추기 게임 ===");
        Console.WriteLine();
        Console.Write("    ");
        for (int i = 0; i < Cols; i++)
        {
            Console.Write($"{i + 1}열  ");
        }
        Console.WriteLine();
        for (int i = 0; i < AnswerCards.Length / Cols; i++)
        {
            Console.Write($"{i + 1}행 ");
            for (int j = 0; j < Cols; j++)
            {
                if (AnswerCards[i * Cols + j] == 0)
                {
                    string star = "**";
                    Console.Write(star.PadRight(5));
                }
                else
                {
                    Console.Write($"[{AnswerCards[i * Cols + j]}]  ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"시도 횟수: {_turnCount / 2}/{TrialCount} | 찾은 쌍: {AnswerCount}/{AnswerCards.Length / 2}");
        Console.WriteLine();
    }

    public void PrintAlphaCards()
    {
        Console.WriteLine("=== 카드 짝 맞추기 게임 ===");
        Console.WriteLine();
        Console.Write("    ");
        for (int i = 0; i < Cols; i++)
        {
            Console.Write($"{i + 1}열  ");
        }
        Console.WriteLine();
        for (int i = 0; i < AnswerCards.Length / Cols; i++)
        {
            Console.Write($"{i + 1}행 ");
            for (int j = 0; j < Cols; j++)
            {
                if (AnswerCards[i * Cols + j] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string star = "**";
                    Console.Write(star.PadRight(5));
                    Console.ResetColor();
                }
                else
                {
                    GetColor(AnswerCards[i * Cols + j]);
                    char alphaCard = (char)(EntireCards[i * Cols + j] + 65);
                    Console.Write($"[{alphaCard}]  ");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"시도 횟수: {_turnCount / 2}/{TrialCount} | 찾은 쌍: {AnswerCount}/{AnswerCards.Length / 2}");
        Console.WriteLine();
    }
    public void PrintEmojiCards()
    {
        Console.WriteLine("=== 카드 짝 맞추기 게임 ===");
        Console.WriteLine();
        Console.Write("    ");
        for (int i = 0; i < Cols; i++)
        {
            Console.Write($"{i + 1}열  ");
        }
        Console.WriteLine();
        for (int i = 0; i < AnswerCards.Length / Cols; i++)
        {
            Console.Write($"{i + 1}행 ");
            for (int j = 0; j < Cols; j++)
            {
                if (AnswerCards[i * Cols + j] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string star = "**";
                    Console.Write(star.PadRight(5));
                    Console.ResetColor();
                }
                else
                {
                    GetColor(AnswerCards[i * Cols + j]);
                    string emojiCard = GetDisplay(AnswerCards[i * Cols + j]);
                    Console.Write($"[{emojiCard}]  ");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"시도 횟수: {_turnCount / 2}/{TrialCount} | 찾은 쌍: {AnswerCount}/{AnswerCards.Length / 2}");
        Console.WriteLine();
    }
}
