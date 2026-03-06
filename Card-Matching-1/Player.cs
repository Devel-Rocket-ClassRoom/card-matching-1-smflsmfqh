using System;
using System.Collections.Generic;
using System.Text;

// --- 플레이어 클래스 ---
// 플레이어가 선택한 카드를 관리하는 클래스
class Player : Card
{
    private int[] _answerCards;
    public int[] AnswerCards { get { return _answerCards; } } // 짝을 맞춘 카드를 담는 배열
    public int TrialCount { get { return SetTrialCount; } } // 레벨에 따른 시도 횟수 속성
    public bool IsFind { get; private set; } = false;

    // --- 생성자 ---
    // 카드 클래스에서 생성된 카드 배열에 따라 플레이어가 선택한 카드를 담을 배열 생성
    public Player()
    {
        _answerCards = new int[CardsLength];
    }

    // --- 플레이어 카드 배열에 플레이어가 선택한 카드 넣는 메서드 ---    
    public void PushCard(int index)
    {
        if (!IsAlreadyFind(index))
        {
            AnswerCards[index] = GetCard(index);
        }
    }

    // --- 플레이어 카드 배열에 이미 있는 카드인지 검사하는 메서드 ---
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

    // --- 플레이어 카드 배열에 요소를 넣을지 최종 검사하는 메서드 ---
    // 짝이 맞으면 -> 카드 두 장 요소에 추가
    // 짝이 맞지 않으면 -> 해당 카드가 있는 인덱스의 요소를 다시 0으로 초기화
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
