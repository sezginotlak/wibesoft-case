## ÇALIŞMA ŞEKLİ
1. Mekanikleri Hayday oyunu ile aynıdır.
2. Landscape modunda çalışmaktadır.
3. Yeni bir bina veya tarla eklerken koyulabilir veya koyulamaz feedbacki eksiktir. Bunun için bir outline bulamadım. Ancak koyulamayacak yerlerde bırakırsanız, poola geri dönüyor. Console kısmında da koyulabilir veya koyulamaz yazıları çıkıyor.
4. Yeni bir tür ekin eklemek için:
   
   -Scripts/Enums/PlantType scriptine eklenecek ürün eklenir.
   
   -Object Pooling kullanıldığı için aynı yerde bulunan PoolObjectType scriptine de aynı şekilde ürün eklenir. Yazılışları aynı olmalıdır.
   
   -Hiyerarşide Managers/ObjectPoolManager'da gerekli atamalar yapılır.
   
   -Scripts/Seeds klasöründe o ekin için bir script açılır ve Seed'den miras alır.
   
   -Scripts/Plants klasöründe o ekin için bir script açılır ve Plant'tan miras alır.
   
   -Scripts/ScriptableObjects/PlantScriptables klasöründe o ekin için bir PlantSO oluşturulur ve ayarları yapılır.
   
   -Toplandığındaki feedback için ScriptableObjects klasöründe CollectibleSO dosyası düzenlenir.
   
   -Hiyerarşide Canvas/Seeds../Content içerisine görsel için bir Image oluşturulur ve oluşturulan Seed scripti atanır. Ayarları yapılır.

5. Yeni bir bina eklemek için:

   -ScriptableObject adımları dışında neredeyse aynıdır. Oluşturulması gerek dosyalar Scripts/Placables ve Scripts/Buildings klasörlerine oluşturulur.
   
   -Placable'dan miras alanlar Canvasta oluşturulan Image'e atanır ve ayarları yapılır.

## KULLANILAN TEKNOLOJİLER
1. Unity 6 versiyonu kullanılmıştır.
2. Object Pooling, Singleton sistemleri kullanılmıştır.
3. Tweening için DOTween kullanıldı.
4. Kamera sistemi için Cinemachine kuruldu.
5. Modüler bir sistem için Scriptable Object, Interface ve Abstract Classlar kullanıldı.

## GÖRSELLER
1. Görseller: (https://drive.google.com/drive/folders/1VfRcm6V5DcGkt9Rfqbt_2ppAn1h2bi5H?usp=sharing)

