using System;

// README.md를 읽고 아래에 코드를 작성하세요.

test();
Console.WriteLine("=== GC 실행 ===");
GC.Collect();
GC.WaitForPendingFinalizers();
Console.WriteLine("=== 정리 완료 ===");





void test()
{
    Car car1 = new Car("검정");
    car1.Drive();

    Car car2 = new Car("하얀");
    car2.Drive();

    Car car3 = new Car("파랑");
    car3.Drive();

    // 참조 해제
    car1 = null;
    car2 = null;
    car3 = null;
}
class Car
{
    private string _color;

    public Car(string color)
    {
        _color = color;
        Console.WriteLine($"{_color}색 자동차 조립");
    }

    public void Drive()
    {
        Console.WriteLine($"{_color}색 자동차가 달림");
    }

    ~Car()
    {
        Console.WriteLine($"{_color}색 자동차 폐차");
    }
}
