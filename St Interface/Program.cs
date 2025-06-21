using System.Reflection.Metadata;
class App
{
    static void Main()
    {
        System.Console.WriteLine($@"Choose version:
1.Basic
2.Pro
3.Expert");
        string secim = Console.ReadLine();
        SənədProqrami proqram;

        if (secim == "1")
        {
            proqram = new SənədProqrami();
        }
        else if (secim == "2")
        {
            proqram = new ProSənədProqrami();
        }
        else if (secim == "3")
        {
            proqram = new EkspertSənəd();
        }
        else
        {
            Console.WriteLine("Yanlış seçim!");
            return;
        }

        string[] menyu = { "Sənədi Aç", "Sənədi Redaktə Et", "Sənədi Yadda Saxla", "Çıxış" };
        int secilmis = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Yuxarı/Aşağı oxlarla hərəkət edin və Enter ilə seçin:\n");

            for (int i = 0; i < menyu.Length; i++)
            {
                if (i == secilmis)
                    Console.WriteLine($"> {menyu[i]}");
                else
                    Console.WriteLine($"  {menyu[i]}");
            }

            ConsoleKeyInfo klik = Console.ReadKey(true);

            if (klik.Key == ConsoleKey.UpArrow)
            {
                secilmis--;
                if (secilmis < 0) secilmis = menyu.Length - 1;
            }
            else if (klik.Key == ConsoleKey.DownArrow)
            {
                secilmis++;
                if (secilmis >= menyu.Length) secilmis = 0;
            }
            else if (klik.Key == ConsoleKey.Enter)
            {
                Console.Clear();

                if (secilmis == 0)
                {
                    proqram.Ac();
                }
                else if (secilmis == 1)
                {
                    proqram.RedakteEt();
                }
                else if (secilmis == 2)
                {
                    proqram.YaddaSaxla();
                }
                else if (secilmis == 3)
                {
                    Console.WriteLine("Çıxılır...");
                    return;
                }

                Console.WriteLine("\nDavam etmək üçün istənilən düyməyə bas...");
                Console.ReadKey();
            }
        }
    }

    public class SənədProqrami
    {
        public void Ac()
        {
            System.Console.WriteLine("Sənəd açıldı");
        }
        public virtual void RedakteEt()
        {
            System.Console.WriteLine("Yalnız Pro və Ekspert versiyalarda redaktə mümkündür");
        }
        public virtual void YaddaSaxla()
        {
            System.Console.WriteLine("Yalnız Pro və Ekspert versiyalarda yadda saxlamaq mümkündür");
        }
    }

    public class ProSənədProqrami : SənədProqrami
    {
        public void Ac()
        {
            System.Console.WriteLine("Sənəd açıldı");
        }
        public sealed override void RedakteEt()
        {
            System.Console.WriteLine("Sənəd redaktə olundu");
        }
        public override void YaddaSaxla()
        {
            System.Console.WriteLine("Sənəd doc formatında yadda saxlanıldı, pdf üçün Ekspert paketi alın");
        }
    }

    public class EkspertSənəd : ProSənədProqrami
    {
        public void Ac()
        {
            System.Console.WriteLine("Sənəd açıldı");
        }
        public void RedakteEt()
        {
            System.Console.WriteLine("Sənəd redaktə olundu");
        }
        public override void YaddaSaxla()
        {
            System.Console.WriteLine("Sənəd pdf formatında yadda saxlanıldı");
        }
    }
}
