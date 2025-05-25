# 🎓 Neuron-Egitme-Projesi

## 📌 Proje Açıklaması  
Bu proje, öğrencilerin **çalışma süresi** ve **derse devam sürelerini** analiz ederek sınavdan alacakları başarıyı tahmin etmeyi amaçlayan basit bir yapay sinir ağı modelidir.  
C# dili ile geliştirilen bu model, **tek katmanlı bir nöron** üzerinden öğrenme sağlar ve eğitim sonrası tahminlerde bulunur.  

Kullanıcıdan alınan verilerle eğitim yapan model, **Mean Square Error (MSE)** hesaplaması ile başarım düzeyini analiz eder.  
Ayrıca kullanıcıdan veri alarak **tahminleme yapılmasına** olanak sağlar.

---

## 🧠 Kullanılan Teknolojiler
- ✔ **Geliştirme Dili:** C#
- ✔ **IDE:** Visual Studio
- ✔ **Veri İşleme:** Tek nöronlu perceptron mantığı
- ✔ **Arayüz:** Konsol tabanlı

---

## ⚙ Özellikler
- ✔ Öğrenci başarı tahmini yapma  
- ✔ Epok ve öğrenme katsayısı ile eğitim  
- ✔ MSE (Mean Square Error) hesaplama  
- ✔ 3x3 matris ile farklı parametreler için başarım analizi  
- ✔ Kullanıcıdan veri alarak yeni tahminler yapma

---

## 📊 Girdi Verisi
Modelin eğitimi için kullanılan veri:
- Çalışma Süresi (saat cinsinden)  
- Derse Devam Süresi (hafta)  
- Sınav Sonucu (0-100 arası puan)

---

## 🚀 Çalıştırmak İçin  
Projeyi **Visual Studio** ile açın ve aşağıdaki adımları takip edin:

1. `Main()` metodundaki hazır veri seti ile model otomatik olarak çalışır.
2. Eğitim sonrası aşağıdaki metodları kullanarak analiz yapabilirsiniz:
   - `mse_degeleri_tablola()` → 3x3 parametre matrisinde MSE değerlerini analiz eder.  
   - `bulunan_degerler_tablola()` → Eğitim sonrası modelin tahmin ettiği değerleri tablolar.  
   - `veri_tahminleme()` → Kullanıcıdan veri alarak sınav sonucu tahmini yapar.

---

## 📌 Notlar
- 📎 Bu proje **temel seviye sinir ağı** prensiplerini öğretmek amacıyla geliştirilmiştir.  
- 📎 Kodun daha ileri modellerle genişletilmesi mümkündür.  
  Örneğin:
  - Çok katmanlı yapay sinir ağları (MLP)
  - Grafiksel kullanıcı arayüzü (GUI) entegrasyonu
- 📎 Eğitim ve tahminler **konsol tabanlıdır** ve gerçek zamanlı kullanıcı girişi ile etkileşimlidir.

---
