using System;

namespace projemizz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ogrenciSayisi;

            while (true)
            {
                try
                {
                    Console.Write("Öğrenci Sayısını Giriniz: ");
                    ogrenciSayisi = Convert.ToInt32(Console.ReadLine().Trim());

                    if (0 >= ogrenciSayisi)
                    {
                        Console.WriteLine("Öğrenci Sayısı 0'dan Büyük Olmalıdır!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Bu Sayı Çok Fazla, Lütfen Geçerli Bir Değer Giriniz");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lütfen Öğrenci Sayısını, Rakamlar İle Giriniz");
                }
                catch
                {
                    Console.WriteLine("Lütfen Geçerli Bir Değer Giriniz");
                }
            }

            double toplamOrtalama = 0.0;
            double enYuksek = double.MinValue;
            double enDusuk = double.MaxValue;

            string[] ogrenciNumarasi = new string[ogrenciSayisi];
            string[] ad = new string[ogrenciSayisi];
            string[] soyad = new string[ogrenciSayisi];
            double[] vize = new double[ogrenciSayisi];
            double[] final = new double[ogrenciSayisi];
            double[] ortalama = new double[ogrenciSayisi];
            string[] harfNotu = new string[ogrenciSayisi];
            

        
                for (int i = 1; i <= ogrenciSayisi; i++)
                {
                    Console.WriteLine($"\n{i}. Öğrenci");

                    while (true)
                    {
                        try
                        {
                            Console.Write("Öğrenci Numarası: ");
                            ogrenciNumarasi[i - 1] = Console.ReadLine().Trim();

                            long.Parse(ogrenciNumarasi[i - 1]); 
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Öğrenci numarası sadece rakamlardan oluşmalıdır!");
                        }
                    }

                    while (true)
                    {
                        Console.Write("Öğrenci Adı: ");
                        ad[i - 1] = Console.ReadLine().Trim();

                        if (ad[i - 1] == "")
                        {
                            Console.WriteLine("İsim boş bırakılamaz!");
                        }
                        else
                        {
                            try
                            {
                                int.Parse(ad[i - 1]);
                                Console.WriteLine("İsim sadece harflerden oluşmalıdır!");
                            }
                            catch (FormatException)
                            {
                                break;
                            }
                        }
                    }

                    while (true)
                    {
                        Console.Write("Öğrenci Soyadı: ");
                        soyad[i - 1] = Console.ReadLine().Trim();

                        if (soyad[i - 1] == "")
                        {
                            Console.WriteLine("Soyad boş bırakılamaz!");
                        }
                        else
                        {
                            try
                            {
                                int.Parse(soyad[i - 1]); 
                                Console.WriteLine("Soyad sadece harflerden oluşmalıdır!");
                            }
                            catch (FormatException)
                            {
                                break; 
                            }
                        }
                    }

                    while (true)
                    {
                        try
                        {
                            Console.Write("Vize Notu: ");
                            vize[i - 1] = double.Parse(Console.ReadLine());

                            if (vize[i - 1] < 0 || vize[i - 1] > 100)
                            {
                                Console.WriteLine("Hatalı Giriş! 0-100 Arasında Değer Giriniz!");
                                continue;
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Vize Notunu Rakamlar İle Giriniz!");
                        }
                        catch
                        {
                            Console.WriteLine("Hatalı İşlem Tekrar Deneyin!");
                        }
                    }

                    while (true)
                    {
                        try
                        {
                            Console.Write("Final Notu: ");
                            final[i - 1] = double.Parse(Console.ReadLine());

                            if (final[i - 1] < 0 || final[i - 1] > 100)
                            {
                                Console.WriteLine("Hatalı Giriş! 0-100 Arasında Değer Giriniz!");
                                continue;
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Final Notunu Rakamlar İle Giriniz!");
                        }
                        catch
                        {
                            Console.WriteLine("Hatalı İşlem Tekrar Deneyin!");
                        }
                    }

                    ortalama[i - 1] = vize[i - 1] * 0.40 + final[i - 1] * 0.60;
                    toplamOrtalama += ortalama[i - 1];

                    Console.Write("Yıl Sonu Ortalaması: ");
                    Console.WriteLine(ortalama[i - 1]);

                    if (ortalama[i - 1] > enYuksek) enYuksek = ortalama[i - 1];
                    if (ortalama[i - 1] < enDusuk) enDusuk = ortalama[i - 1];

                    string harf;
                    if (ortalama[i - 1] >= 85) harf = "AA";
                    else if (ortalama[i - 1] >= 70) harf = "BA";
                    else if (ortalama[i - 1] >= 60) harf = "BB";
                    else if (ortalama[i - 1] >= 50) harf = "CB";
                    else if (ortalama[i - 1] >= 40) harf = "CC";
                    else if (ortalama[i - 1] >= 30) harf = "DC";
                    else if (ortalama[i - 1] >= 20) harf = "DD";
                    else if (ortalama[i - 1] >= 10) harf = "FD";
                    else harf = "FF";

                    harfNotu[i - 1] = harf;

                    Console.Write("Harf Notu: ");
                    Console.WriteLine(harf);


                
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("No\t\tAd\t\tSoyad\t\tVize\t\tFinal\t\tOrtalama\t\tHarf Notu");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");

            for (int j = 0; j < ogrenciSayisi; j++)
            {
                Console.WriteLine($"{ogrenciNumarasi[j],-8}\t{ad[j],-8}\t{soyad[j],-8}\t{vize[j],-8}\t{final[j],-8}\t{ortalama[j],-8:F2}\t\t{harfNotu[j]}");
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Sınıf ortalaması: {(toplamOrtalama / ogrenciSayisi):F2}");
            Console.WriteLine($"En yüksek ortalama: {enYuksek:F2}");
            Console.WriteLine($"En düşük ortalama: {enDusuk:F2}");

            
        }
    }
}
