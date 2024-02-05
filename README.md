Verilen Proje: Gringotts Bank için Kullanıcı girişler, oluşturulması ile ilgili API’lerin hazırlanması.
Database ve diğer araçlar: SQLlite,MS Identity Platform, Swagger
Pages:
•	Program.cs
•	UsersController.cs
•	ProductsController.cs
•	AppRole.cs
•	AppUser.cs
•	LoginDTO.cs
•	UserDTO.cs
•	ProductDTO.cs
•	ProductsContext.cs

Genel Görünüm:
Yeni Kullanıcı Oluşturulması:
•	Yeni kullanıcı özellikleri ve giriş bilgileri tanımlanabilir.
 

•	Tanımlama ile ilgili kısıtlar entegre edildi
 
Mevcut Kullanıcı Girişi:
•	Kullanıcı girişi onayı veya yanlış kullanıcı bilgisi hazırlandı
•	Kullanıcı bilgileri JWT token ile güven altına alındı
•	Token İşlemleri: User kayıt olduktan sonra, swagger üzerindeki                             
Authorize butonu ile token alabilmesi için, register olması gerekmektedir. 
Register olduğu anda ekranda token anahtarı belirecektir. 
Bu anahtarı kopyalayıp Authorize butonu ile açılan text e yapıştırıp onaylarsa güveli giriş yapabilir. 

Yapılan işlemlerin sonunda geri bildirim olarak http kodları belirlendi.


Teşekkürler,
Saygılarımla.
