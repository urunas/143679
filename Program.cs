
using System;

class Program
{
    static int InputInt(string prompt)
    {
        while (true)
        {
            try
            {
                Console.Write(prompt);
                return int.Parse(Console.ReadLine() ?? "");
            }
            catch (FormatException)
            {
                Console.WriteLine("Hatalı giriş! Lütfen sayı giriniz.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Hatalı giriş! Lütfen geçerli bir sayı giriniz.");
            }
        }
    }

    static int InputIntInRange(string prompt, int minVal, int maxVal)
    {
        while (true)
        {
            try
            {
                Console.Write(prompt);
                int v = int.Parse(Console.ReadLine() ?? "");

                if (v >= minVal && v <= maxVal)
                    return v;

                Console.WriteLine($"Hatalı değer! {minVal}-{maxVal} arasında olmalı.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Hatalı giriş! Lütfen sayı giriniz.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Hatalı giriş! Lütfen geçerli bir sayı giriniz.");
            }
        }
    }

    static string InputNonEmptyStr(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string s = (Console.ReadLine() ?? "").Trim();
            if (!string.IsNullOrEmpty(s))
                return s;

            Console.WriteLine("Boş bırakılamaz. Tekrar giriniz.");
        }
    }

    static string HarfNotuBul(double ortalama)
    {
        if (ortalama >= 85) return "AA";
        else if (ortalama >= 70) return "BA";
        else if (ortalama >= 60) return "BB";
        else if (ortalama >= 50) return "CB";
        else if (ortalama >= 40) return "CC";
        else if (ortalama >= 30) return "DC";
        else if (ortalama >= 20) return "DD";
        else if (ortalama >= 10) return "FD";
        else return "FF";
    }

    static void Main()
    {
        // Öğrenci sayısı isteniyor
        int ogrenciSayisi;
        while (true)
        {
            ogrenciSayisi = InputInt("Öğrenci sayısını giriniz: ");
            if (ogrenciSayisi > 0)
                break;

            Console.WriteLine("Öğrenci sayısı 0'dan büyük olmalıdır.");
        }

        double toplamOrtalama = 0.0;
        double? enYuksek = null;
        double? enDusuk = null;

        for (int i = 1; i <= ogrenciSayisi; i++)
        {
            Console.WriteLine($"\n--- {i}. Öğrenci ---");

            int numara = InputInt("Öğrenci numarası: ");
            string adSoyad = InputNonEmptyStr("Öğrenci adı soyadı: ");

            int vize = InputIntInRange("Vize notu (0-100): ", 0, 100);
            int final = InputIntInRange("Final notu (0-100): ", 0, 100);

            // Ortalama ve harf notu
            double ortalama = vize * 0.40 + final * 0.60;
            string harfNotu = HarfNotuBul(ortalama);

            Console.WriteLine($"Ortalama: {ortalama:F2} | Harf Notu: {harfNotu}");

            // İstatistik güncelleme
            toplamOrtalama += ortalama;

            if (enYuksek == null || ortalama > enYuksek.Value)
                enYuksek = ortalama;

            if (enDusuk == null || ortalama < enDusuk.Value)
                enDusuk = ortalama;
        }

        // Son olarak
        double sinifOrtalamasi = toplamOrtalama / ogrenciSayisi;

        Console.WriteLine("\n=== SINIF SONUÇLARI ===");
        Console.WriteLine($"Sınıf ortalaması: {sinifOrtalamasi:F2}");
        Console.WriteLine($"En yüksek not (ortalama): {enYuksek.Value:F2}");
        Console.WriteLine($"En düşük not (ortalama): {enDusuk.Value:F2}");
    }
}