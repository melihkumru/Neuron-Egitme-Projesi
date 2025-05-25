using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Proje2
{
    internal class Deneme
    {
        public class Neuron
        {


            public double[,] data;

            public double calisma_agirlik;
            public double derse_devam_agirlik;

            public Neuron(double[,] data)
            {
                this.data = data;
                Random random = new Random();
                calisma_agirlik = random.NextDouble();
                derse_devam_agirlik = random.NextDouble();
            }

            public double[,] GetData()
            {
                return data;
            }
            public double Getcalisma_agirlik()
            {
                return calisma_agirlik;
            }

            public double Getderse_devam_agirlik()
            {
                return derse_devam_agirlik;
            }


            public void Setcalisma_agirlik(double calisma_agirlik)
            {
                this.calisma_agirlik = calisma_agirlik;
            }

            public void Setderse_devam_agirlik(double derse_devam_agirlik)
            {
                this.derse_devam_agirlik = derse_devam_agirlik;
            }


            //Çalışma ağırlığının her eğitim sırısındaki değişimi hesaplar ve yeni çalışma ağırlık olarak kaydeder.
            public void calisma_agırlik_degisim(double calisma_sure, double sınav_sonucu, double bulunan_deger, double ogrenme_katsayisi)
            {
                if (bulunan_deger != sınav_sonucu)
                {
                    double yeni_calisma_agirlik = Getcalisma_agirlik();
                    yeni_calisma_agirlik += ogrenme_katsayisi * (sınav_sonucu - bulunan_deger) * calisma_sure;
                    Setcalisma_agirlik(yeni_calisma_agirlik);
                }
            }

            //Derse devam ağırlığının her eğitim sırasındaki değişimi hesaplar ve yeni çalışma ağırlık olarak kaydeder.
            public void derse_devam_agirlik_degisim(double derse_devam_sure, double sınav_sonucu, double bulunan_deger, double ogrenme_katsayisi)
            {
                if (bulunan_deger != sınav_sonucu)
                {
                    double yeni_derse_devam_agirlik = Getderse_devam_agirlik();
                    yeni_derse_devam_agirlik += ogrenme_katsayisi * (sınav_sonucu - bulunan_deger) * derse_devam_sure;
                    Setderse_devam_agirlik(yeni_derse_devam_agirlik);
                }
            }

            //Neuron içerisindeki calışma suresi ve derse devam sürelerinin ağırlıklarıyla çarpımlarının toplamlarının değerini döndürür. Yani neuronun tahminlediği değeri.
            public double toplama_islevi(double calisma_suresi, double derse_devam_suresi)
            {
                return calisma_suresi * Getcalisma_agirlik() + derse_devam_suresi * Getderse_devam_agirlik();
            }

            //Neuronun eğitimini sağlayan metottur. Kullanıcının girdiği epok ve ogrenme_katsayisi ile eğitim sağlanır.
            public void egit(int epok = 10, double ogrenme_katsayisi = 0.05)
            {
                double[,] data = GetData();
                double bulunan_deger;
                for (int z = 0; z < epok; z++)
                {
                    for (int i = 0; i < data.GetLength(0); i++)
                    {

                        double sınav_sonuc = 0;
                        double calisma_suresi = 0;
                        double derse_devam_suresi = 0;
                        for (int j = 0; j < data.GetLength(1); j++)
                        {
                            if (j == 0)
                            {
                                calisma_suresi = data[i, j] / 10;
                            }
                            else if (j == 1)
                            {
                                derse_devam_suresi = data[i, j] / 15;
                            }
                            else
                            {
                                sınav_sonuc = data[i, j] / 100;
                            }
                        }
                        bulunan_deger = toplama_islevi(calisma_suresi, derse_devam_suresi);
                        derse_devam_agirlik_degisim(derse_devam_suresi, sınav_sonuc, bulunan_deger, ogrenme_katsayisi);
                        calisma_agırlik_degisim(calisma_suresi, sınav_sonuc, bulunan_deger, ogrenme_katsayisi);


                    }

                }




            }


            //Main Square Error işlemini yapar.
            public double mse_hesap(double[] bulunan_degerler)
            {
                double mse = 0;
                for (int i = 0; i < bulunan_degerler.Length; i++)
                {

                    mse += Math.Pow((GetData()[i, 2] / 100 - bulunan_degerler[i] / 100), 2);

                }
                return (mse / bulunan_degerler.Length) * 100;

            }

            public double[] GetBulunanDegerler()
            {
                double[,] data = GetData();
                double[] bulunan_degerler = new double[data.GetLength(0)];
                for (int i = 0; i < data.GetLength(0); i++)
                {

                    bulunan_degerler[i] = (toplama_islevi(data[i, 0] / 10, data[i, 1] / 15)) * 100;
                }
                return bulunan_degerler;
            }

            //Eğitilen neuronun bulduğu değerlerle beklenen değerleri karşılaştırır.
            public void bulunan_degerler_tablola()
            {
                double[,] data = GetData();
                double[] bulunan_degerler = new double[data.GetLength(0)];
                double bulunan_deger = 0;
                double calisma_suresi = 0;
                double derse_devam_suresi = 0;
                double sınav_sonuc = 0;
                System.Console.WriteLine($"Çalışma Süresi    Derse Devam Süresi    Sınav Sonucu    Tahminlenen Değer");
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if (j == 0)
                        {
                            calisma_suresi = data[i, j] / 10;
                        }
                        else if (j == 1)
                        {
                            derse_devam_suresi = data[i, j] / 15;
                        }
                        else
                        {
                            sınav_sonuc = data[i, j] / 100;
                        }

                    }
                    bulunan_deger = toplama_islevi(calisma_suresi, derse_devam_suresi);
                    bulunan_degerler[i] = bulunan_deger * 100;
                    System.Console.WriteLine($" ");
                    System.Console.Write($"{calisma_suresi * 10}".PadRight(27));
                    System.Console.Write($"{derse_devam_suresi * 15}".PadRight(18));
                    System.Console.Write($"{sınav_sonuc * 100}".PadRight(12));
                    System.Console.Write($"{bulunan_deger * 100}".PadRight(10));
                    System.Console.WriteLine();
                }
                Console.WriteLine($"Mean square Error-->{mse_hesap(bulunan_degerler)}");

            }


            // Kullanıcının girdiği veriyi 10 epok ve lamda değeri 0.05 olan bir eğitim aşamasından sonraki bulunan değerleri tablolar.
            public void veri_tahminleme()
            {
                egit();
                double[] calisma_sureleri = new double[5];
                double[] derse_devam_sureleri = new double[5];
                double[] sınav_sonuclari = new double[5];
                double[] tahmin_verileri = new double[5];
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i + 1 + ". Çalışma süresini giriniz: ");
                    double calisma_suresi = Convert.ToDouble(Console.ReadLine()) / 10;
                    Console.WriteLine(i + 1 + ". Derse devam süresini giriniz: ");
                    double derse_devam_suresi = Convert.ToDouble(Console.ReadLine()) / 15;
                    Console.WriteLine(i + 1 + ". Sınav sonucunu  giriniz: ");
                    double sınav_sonucu = Convert.ToDouble(Console.ReadLine()) / 100;
                    Console.WriteLine();
                    tahmin_verileri[i] = toplama_islevi(calisma_suresi, derse_devam_suresi);
                    calisma_sureleri[i] = calisma_suresi;
                    derse_devam_sureleri[i] = derse_devam_suresi;
                    sınav_sonuclari[i] = sınav_sonucu;

                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{calisma_sureleri[i] * 10} saatlik çalışma ve {derse_devam_sureleri[i] * 15} haftalık derse devam " +
                        $"sonucunda sınavdan alınan sonuç: {sınav_sonuclari[i] * 100}\nTahminlenen sonuç {tahmin_verileri[i] * 100}");

                }

            }

            // 3 farklı epok ve 3 farklı lamnda değerleri için bir 3x3 lük matris tablolanır.
            public void mse_degeleri_tablola()
            {
                Neuron n1 = new Neuron(GetData());
                Neuron n2 = new Neuron(GetData());
                Neuron n3 = new Neuron(GetData());

                int[] epok_degerleri = { 10, 40, 50 }; //Eğitim biçimi kümülatif bir biçimde ilerleriyor. Yani ilk 10 epokluk eğitim sonra 40 tane daha yapılıyor. Toplam 50 oluyor...
                double[] landa_degerleri = { 0.01, 0.25, 0.05 };
                double[,] mse_degerleri = new double[3, 3];

                for (int i = 0; i < 3; i++)
                {
                    double mse = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (i == 0)
                        {
                            n1.egit(epok_degerleri[j], ogrenme_katsayisi: landa_degerleri[i]);
                            mse = n1.mse_hesap(n1.GetBulunanDegerler());
                        }
                        else if (i == 1)
                        {
                            n2.egit(epok_degerleri[j], ogrenme_katsayisi: landa_degerleri[i]);
                            mse = n2.mse_hesap(n2.GetBulunanDegerler());
                        }
                        else
                        {
                            n3.egit(epok_degerleri[j], ogrenme_katsayisi: landa_degerleri[i]);
                            mse = n3.mse_hesap(n3.GetBulunanDegerler());
                        }
                        mse_degerleri[i, j] = mse;
                    }
                }
                int[] epok_degerlerii = { 10, 50, 100 };
                Console.Write($"                 {landa_degerleri[0]}                                  {landa_degerleri[1]}                                  {landa_degerleri[2]}");
                Console.WriteLine();

                for (int i = 0; i < 3; i++)
                {
                    Console.Write(epok_degerlerii[i]);
                    for (int j = 0; j < 3; j++)
                    {

                        Console.Write(($"        {mse_degerleri[i, j]}             ").PadLeft(10));

                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }

            }

        }



        static void Main(string[] args)
        {
            double[,] data = { { 7.6, 11, 77 }, {8,10,70 },{6.6,8,55 },{8.4,10,78 },
            {8.8,12,95 },{7.2,10,67 },{8.1,11,80 },{9.5,9,87 },{7.3,9,60 },{8.9,11,88},
            {7.5,11,72 },{7.6,9,58 },{7.9,10,70 },{8,10,76 },{7.2,9,58},{8.8,10,81},
            {7.6,11,74},{7.5,10,67},{9,10,82},{7.7,9,62},{8.1,11,82} };

            Neuron deneme2 = new Neuron(data);
            deneme2.mse_degeleri_tablola();




        }






    }
}
