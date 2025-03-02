## ÇALIŞMA ŞEKLİ
1. Mekanikleri Hayday oyunu ile aynıdır.
2. Yeni bir tür ekin eklemek için:
   
   -Scripts/Enums/PlantType scriptine eklenecek ürün eklenir.
   
   -Object Pooling kullanıldığı için aynı yerde bulunan PoolObjectType scriptine de aynı şekilde ürün eklenir. Yazılışları aynı olmalıdır.
   
   -Hiyerarşide Managers/ObjectPoolManager'da gerekli atamalar yapılır.
   
   -Scripts/Seeds klasöründe o ekin için bir script açılır ve Seed'den miras alır.
   
   -Scripts/Plants klasöründe o ekin için bir script açılır ve Plant'tan miras alır.
   
   -Scripts/ScriptableObjects/PlantScriptables klasöründe o ekin için bir PlantSO oluşturulur ve ayarları yapılır.
   
   -Toplandığındaki feedback için ScriptableObjects klasöründe CollectibleSO dosyası düzenlenir.
   
   -Hiyerarşide Canvas/Seeds../Content içerisine görsel için bir Image oluşturulur ve oluşturulan Seed scripti atanır. Ayarları yapılır.

