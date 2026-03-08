using System;

// --- 메인: 게임 실행 ---

string input = "y";
do
{
    Console.Clear();
    Game game = new Game();
    game.Play();
    Console.Write("새 게임을 하겠습니까? (Y/N): ");

    while (true)
    {
        input = Console.ReadLine();
        if (input != null && (input.ToLower() == "n" || input.ToLower() == "y")) break;
        Console.Write("Y 아니면 N을 입력해주세요: ");
    }

} while (input.ToLower() == "y");