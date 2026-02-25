using System;

// README.md를 읽고 코드를 작성하세요.
text();

GC.Collect();
GC.WaitForPendingFinalizers();

Seat.ShowStatus();

void text()
{
    Seat seat1 = new Seat("김민수");
    Seat seat2 = new Seat("이지영");
    Seat seat3 = new Seat("박서준");

    seat1.Study();
    seat2.Study();
    seat3.Study();

    Seat.ShowStatus();

    seat1 = null;
    seat2 = null;
    seat3 = null;
}

class Seat
{
    private static int totalEntries = 0;
    private static int currentSeatedCount = 0;
    private static int nextId = 1;
    private int _id;
    private string _name;

    public Seat(string name)
    {
        _name = name;
        _id = nextId++;
        totalEntries++;
        currentSeatedCount++;
        Console.WriteLine($"좌석 {_id}번 착석: {_name}");
    }

    public void Study()
    {
        Console.WriteLine($"{_name}이(가) 좌석 {_id}번에서 공부 중...");
    }

    public static void ShowStatus()
    {
        Console.WriteLine($"총 이용: {totalEntries}명, 현재 착석: {currentSeatedCount}명");
    }

    ~Seat()
    {
        currentSeatedCount--;
        Console.WriteLine($"좌석 {_id}번 반납: {_name}");
    }

}
