using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

class Game : Player
{
    protected int CardIndex1;
    protected int CardIndex2;
    private int _turnCount = 1;
    private int _cols = 4;
    private string input = string.Empty;

    //private Player player;
    public int Cols { get { return _cols; } }
    
    public Game() 
    {
        
    }

    public void Play()
    {
        Thread.Sleep(1000);
        //Console.WriteLine();

        while (AnswerCount < 8)
        {
            Console.Clear();
            Console.WriteLine();
            PrintCards();
            FirstTurn();
            SecondTurn();
            Thread.Sleep(1000);
            
        }

        Console.WriteLine();
        Console.WriteLine("=== 게임 클리어! ===");
        Console.WriteLine($"총 시도 횟수: {_turnCount / 2}");
    }
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
        PrintCards();
        
    }

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
        PrintCards();
        PushOrRemoveCard(CardIndex1, CardIndex2);
    }
  
    
    public string UserInput()
    {
        bool IsValidate = false;
        string firstInput = string.Empty;
        string secondInput = string.Empty;

        while (!IsValidate)
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
                        Console.Write("두 번째 카드를 선택하세요 (행 열): ");
                        secondInput = Console.ReadLine();
                        while (true)
                        {
                            if (input != secondInput)
                            {
                                input = secondInput;
                                break;
                            }
                            Console.Write("이미 선택된 카드입니다. 다른 카드를 선택하세요\n");
                            Console.WriteLine();
                        }
                    }
                    break;
            }

            // To do: 숫자 문자열이 아닌 다른 문자를 넣었을 때 유효한 입력 처리 추가
            if (input.Length != 3)
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요. 3자리 아님");
            }
            
            else if (input[1] == ' ')
            {
                IsValidate = true;
            }
            else if (input[1] != ' ')
            {
                Console.WriteLine("행과 열 사이에 공백을 입력해주세요.");
                Console.WriteLine();
            }
        }

        return input;
    }

    public int CalculateIndex(string input)
    {
        int i = (int)Char.GetNumericValue(input[0]) - 1;
        int j = (int)Char.GetNumericValue(input[2]) - 1;

        return i * Cols + j;
    }

    public void PrintCards()
    {
        Console.WriteLine("=== 카드 짝 맞추기 게임 ===");
        Console.WriteLine();
        Console.Write("    ");
        for (int i = 0; i < Cols; i++)
        {
            Console.Write($"{i + 1}열 ");
        }
        Console.WriteLine();
        for (int i = 0;i < Cols; i++)
        {
            Console.Write($"{i + 1}행 ");
            for (int j = 0; j < AnswerCards.Length / Cols; j++)
            {
                if (AnswerCards[i * Cols + j] == 0)
                {
                    Console.Write("**  ");
                }
                else { Console.Write($"[{AnswerCards[i * Cols + j]}]  "); }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"시도 횟수: {_turnCount / 2} | 찾은 쌍: {AnswerCount}/8");
        Console.WriteLine();
    }
}
