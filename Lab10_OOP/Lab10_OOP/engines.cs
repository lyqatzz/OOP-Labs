using System;

namespace Lab10_OOP
{
    public interface IInit
    {
        void Init();
        void RandomInit();
    }

    public abstract class Engine : IInit, IComparable
    {
        protected string name;
        protected int power;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Power
        {
            get => power;
            set
            {
                if (value < 0) power = 0;
                else power = value;
            }
        }

        public Engine()
        {
            Name = "Неизвестный";
            Power = 0;
        }

        public Engine(string n, int p)
        {
            Name = n;
            Power = p;
        }

        public Engine(Engine other)
        {
            Name = other.Name;
            Power = other.Power;
        }

        public virtual void Show()
        {
            Console.WriteLine($"[Двигатель] Название: {Name}, Мощность: {Power} л.с.");
        }

        public virtual void Init()
        {
            Console.Write("Введите название: ");
            Name = Console.ReadLine();
            Console.Write("Введите мощность: ");
            Power = int.Parse(Console.ReadLine());
        }

        public virtual void RandomInit()
        {
            Random rnd = new Random();
            Name = "Двигатель-" + rnd.Next(1, 100);
            Power = rnd.Next(50, 500);
        }

        public int CompareTo(object obj)
        {
            Engine other = obj as Engine;
            if (other == null) throw new ArgumentException("Объект не является двигателем");
            return this.Power.CompareTo(other.Power);
        }

        public override bool Equals(object obj)
        {
            if (obj is Engine other)
                return this.Name == other.Name && this.Power == other.Power;
            return false;
        }
    }

    public class ICE : Engine
    {
        protected double volume;

        public double Volume
        {
            get => volume;
            set => volume = value;
        }

        public ICE() : base() 
            { Volume = 0; }
        public ICE(string n, int p, double v) : base(n, p) 
            { Volume = v; }
        public ICE(ICE other) : base(other) 
            { Volume = other.Volume; }

        public override void Show()
        {
            Console.WriteLine($"[ДВС] Название: {Name}, Мощность: " +
                $"{Power} л.с., Объем: {Volume} л.");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите объем (л): ");
            Volume = double.Parse(Console.ReadLine());
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Random rnd = new Random();
            Volume = Math.Round(rnd.NextDouble() * 5 + 1, 1);
        }
    }

    public class Diesel : ICE
    {
        private int torque;

        public int Torque
        {
            get => torque;
            set => torque = value;
        }

        public Diesel() : base() 
            { Torque = 0; }
        public Diesel(string n, int p, double v, int t) : base(n, p, v) 
            { Torque = t; }
        public Diesel(Diesel other) : base(other) 
            { Torque = other.Torque; }

        public override void Show()
        {
            Console.WriteLine($"[Дизель] Название: {Name}, Мощность: {Power} л.с.," +
                $" Объем: {Volume} л., Момент: {Torque} Н·м");
        }
    }

    public class Turbojet : Engine
    {
        private int thrust;

        public int Thrust
        {
            get => thrust;
            set => thrust = value;
        }

        public Turbojet() : base() { Thrust = 0; }
        public Turbojet(string n, int p, int t) : base(n, p) { Thrust = t; }
        public Turbojet(Turbojet other) : base(other) { Thrust = other.Thrust; }

        public override void Show()
        {
            Console.WriteLine($"[Турбореактивный] Название: {Name}, " +
                $"Мощность: {Power} л.с., Тяга: {Thrust} кН");
        }
    }

    public class Car : IInit
    {
        public string Brand { get; set; }

        public void Init()
        {
            Console.Write("Введите марку машины: ");
            Brand = Console.ReadLine();
        }

        public void RandomInit()
        {
            Brand = "Машина-" + new Random().Next(1, 10);
        }

        public void Show()
        {
            Console.WriteLine($"[Машина] Марка: {Brand}");
        }
    }
}