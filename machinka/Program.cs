using System;

class Car
{
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Number { get; private set; }
    public string Color { get; private set; }

    private bool isRunning = false;
    private int speed = 0;
    private int gear = 0;

    public Car(string brand, string model, string number, string color)
    {
        Brand = brand;
        Model = model;
        Number = number;
        Color = color;
    }

    public void Start()
    {
        if (gear == 0 || gear == 1)
        {
            isRunning = true;
            Console.WriteLine($"{Brand} {Model} завелась.");
        }
        else
        {
            Console.WriteLine("Машина не заведется на этой передаче.");
        }
    }

    public void Stop()
    {
        isRunning = false;
        speed = 0;
        Console.WriteLine($"{Brand} {Model} заглохла.");
    }

    public void Jump()
    {
        if (speed >= 30)
        {
            Console.WriteLine("Ты выпрыгиваешь из машины на полной скорости, влетаешь в камень головой и умираешь.");
            Environment.Exit(0);
        }
        else if (speed >= 10 )
        {
            Console.WriteLine("Ты выходишь из машины которая едет. Она врезается в столб и загорается. Хорошая работа.");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Ты выходишь из машины.");
            Environment.Exit(0);
        }
    }

    public void PressGas()
    {
        if (!isRunning || gear == 0)
        {
            Console.WriteLine("Нельзя увеличить скорость.");
            return;
        }

        if ((gear == 1 && speed < 30) ||
            (gear == 2 && speed < 50) ||
            (gear == 3 && speed < 70) ||
            (gear == 4 && speed < 90) ||
            (gear == 5 && speed < 120))
        {
            speed += 10;
            Console.WriteLine($"Теперь ваша скорость: {speed} км/ч");
        }
        else
        {
            Console.WriteLine("Разогнаться еще больше не получится, нужно сменить передачу.");
        }
    }

    public void Brake()
    {
        if (speed > 0)
        {
            speed -= 10;
            Console.WriteLine($"Теперь ваша скорость: {speed} км/ч");
        }
        else
        {
            Console.WriteLine($"{Brand} {Model} И так стоит.");
        }
    }

    public void ChangeGear(int newGear)
    {
        if (newGear < 0 || newGear > 5)
        {
            Console.WriteLine("Такой передачи не существует.");
            return;
        }

        if ((newGear == 1 && speed <= 30) ||
            (newGear == 2 && speed >= 20 && speed <= 50) ||
            (newGear == 3 && speed >= 40 && speed <= 70) ||
            (newGear == 4 && speed >= 60 && speed <= 90) ||
            (newGear == 5 && speed >= 80) ||
            (newGear == 0))
        {
            gear = newGear;
            Console.WriteLine($"Передача изменена на {gear}");
        }
        else
        {
            Console.WriteLine("На этой скорости нельзя менять передачу на указанную.");
            Stop();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car[] cars = {
            new Car("Ford", "Mustang", "ZAZA123", "Ourple"),
            new Car("Toyota", "Corolla", "KEKW111", "Silver"),
            new Car("Honda", "Civic", "LULZ432", "Red"),
        };

        Console.WriteLine("Выберите машину, на которой поедете:");
        for (int i = 0; i < cars.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {cars[i].Brand} {cars[i].Model}");
        }

        int choice = Convert.ToInt32(Console.ReadLine()) - 1;
        Car selectedCar = cars[choice];

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Завести машину");
            Console.WriteLine("2. Выключить машину");
            Console.WriteLine("3. Ускориться");
            Console.WriteLine("4. Замедлиться");
            Console.WriteLine("5. Поменять передачу");
            Console.WriteLine("6. Выпрыгнуть из машины");

            int action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case 1:
                    selectedCar.Start();
                    break;
                case 2:
                    selectedCar.Stop();
                    break;
                case 3:
                    selectedCar.PressGas();
                    break;
                case 4:
                    selectedCar.Brake();
                    break;
                case 5:
                    Console.WriteLine("Выберите передачу(0-5):");
                    int gear = Convert.ToInt32(Console.ReadLine());
                    selectedCar.ChangeGear(gear);
                    break;
                case 6:
                    selectedCar.Jump();
                    break;
                default:
                    Console.WriteLine("Попробуй еще раз :3.");
                    break;
            }
        }
    }
}
