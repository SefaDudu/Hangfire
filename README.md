# Hangfire

https://www.hangfire.io/
# Hangfire Nedir
Arka plan işleri (Background jobları) oluşturmamıza, yürütmemize ve yönetmemize kolaylık sağlayan açık kaynaklı kütüphanedir. Depolama alanı olarak birçok veritabanı (SQL Server, SQL Server + MSMQ, Redis ve daha fazlası), IoC Container ve UnitTest desteklemektedir.

İşler veritabanında tutulduğu için güvenilirdir. İş tamamlanmadıkça tamamlandı durumuna geçmez, kod bloğunun bitimine kadar çıkacak herhangi bir sorunda iş tekrar çalışacaktır.(Background jobların yarım kalması ve tekrarlanmaması)

![image](https://user-images.githubusercontent.com/77778888/216307379-c3e19ad9-a7fe-49b7-a0b1-b4cb84882659.png)


Hangfire, işleri yönetmek ve işleri zamanlamak için kullanılan bir kütüphanedir. Hangfire'da kullanabileceğiniz bazı kullanışlı attributeler şunlardır:

[AutomaticRetry]: Bir işin başarısız olması durumunda otomatik olarak tekrar denemesini sağlar. Örneğin, ağ kesintisi gibi geçici sorunlarda işi tekrar denemek için kullanılabilir.

[DisableConcurrentExecution]: Aynı işin eşzamanlı olarak birden fazla kez çalışmasını engeller. İşin tamamlanması beklenirken yeni bir iş oluşturulduğunda, bu öznitelik sayesinde yeni işin çalışması engellenir.

[Queue]: İşi belirli bir kuyruğa yerleştirmek için kullanılır. Birden fazla kuyruk oluşturabilir ve işleri belirli bir kuyruğa atanabilirsiniz. Bu özniteliği kullanarak farklı önceliklere sahip işleri düzenleyebilirsiniz.

[DisableConcurrentExecution(timeoutInSeconds)]: Aynı işin eşzamanlı olarak birden fazla kez çalışmasını engeller ve belirtilen süre boyunca işin tamamlanmasını bekler. Süre içinde iş tamamlanmazsa, bir sonraki işin çalışmasına izin verilir.

[JobDisplayName]: Hangfire arayüzünde işlerin adını özelleştirmek için kullanılır. İş adı, arayüzde görüntülenecek şekilde değiştirilebilir.

Bu öznitelikler, Hangfire ile işlerinizi yönetirken kullanabileceğiniz bazı yaygın olanlardır. Bu özniteliklerin yanı sıra daha fazla özelleştirme seçeneği ve özniteliği mevcut olabilir. Hangfire'ın resmi dokümantasyonu, daha fazla bilgi sağlayacaktır.
