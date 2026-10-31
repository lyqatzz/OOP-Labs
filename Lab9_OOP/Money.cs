using System;

namespace Lab9_OOP
{
    public class Money
    {
        private int rubles;
        private int kopeks;

        public static int count = 0;

        public int Rubles
        {
            get => rubles;
            set
            {
                if (value < 0) rubles = 0;
                else rubles = value;
            }
        }

        public int Kopeks
        {
            get => kopeks;
            set
            {
                if (value >= 100)
                {
                    rubles += value / 100;
                    kopeks = value % 100;
                }
                else if (value < 0) kopeks = 0;
                else kopeks = value;
            }
        }

        public Money(int r, int k)
        {
            Rubles = r;
            Kopeks = k;
            count++;
        }

        public Money() : this(0, 0) { }

        public void Print()
        {
            Console.WriteLine($"{Rubles} руб. {Kopeks} коп.");
        }

        public bool CompareMethod(Money other)
        {
            return (this.Rubles * 100 + this.Kopeks) == (other.Rubles * 100 + other.Kopeks);
        }

        public static bool CompareStatic(Money m1, Money m2)
        {
            return (m1.Rubles * 100 + m1.Kopeks) == (m2.Rubles * 100 + m2.Kopeks);
        }

        public static Money operator ++(Money m)
        {
            m.Kopeks++;
            return m;
        }

        public static Money operator --(Money m)
        {
            if (m.rubles == 0 && m.kopeks == 0) return m;
            m.kopeks--;
            if (m.kopeks < 0) 
            {
                m.rubles--;
                m.kopeks = 99;
            }
            return m;
        }

        public static implicit operator int(Money m)
        {
            return m.Rubles;
        }

        public static explicit operator double(Money m)
        {
            return m.Kopeks / 100.0;
        }

        public static Money operator -(Money m, int k)
        {
            int total = (m.Rubles * 100 + m.Kopeks) - k;
            if (total < 0) total = 0;
            return new Money(total / 100, total % 100);
        }

        public static Money operator -(int k, Money m)
        {
            int total = k - (m.Rubles * 100 + m.Kopeks);
            if (total < 0) total = 0;
            return new Money(total / 100, total % 100);
        }
    }
}