# DNS Spoofing Simulyatoru

Bu layihə DNS spoofing hücumlarının necə baş verdiyini anlamaq və öyrənmək məqsədilə hazırlanmışdır. Layihə, istifadəçinin DNS sorğularını saxtalaşdırılmış cavablarla əvəzləməyə imkan verən sadə bir simulyator və analiz üçün Wireshark nəticələrini əhatə edir.

## 📌 Layihənin Məqsədi

DNS spoofing hücumlarını daha yaxşı anlamaq üçün praktik bir simulyasiya təqdim etmək. Bu simulyasiya nəticəsində istifadəçi real DNS cavabları əvəzinə saxta IP ünvanlarına yönləndirilir.

## 🔧 Tətbiqin İşləmə Prinsipi

- `google.com` kimi domen adlarına DNS sorğusu göndərildikdə, simulyator 6.6.6.6 kimi saxta IP cavabı qaytarır.
- Bu cavab Wireshark vasitəsilə izlənilə və analiz edilə bilər.
- Kestrel serverində DNS sorğularına cavab verilməsi müşahidə edilir.

## 🧪 İstifadə Qaydası

1. Tətbiqi çalışdırın.
2. Wireshark-da `dns` filtri ilə DNS trafikini izləyin.
3. DNS cavab paketində `google.com A 6.6.6.6` kimi spoofed cavabı müşahidə edin.
4. Simulyatorun düzgün işlədiyini və spoofed cavab verdiyini təsdiqləyin.

## 📂 Fayllar

- `spoofed_response.pcapng`: Wireshark tərəfindən qeyd olunan spoofed DNS cavab nümunəsi  
- `Program.cs`: Simulyatorun mənbə kodu  
- `README.md`: Bu sənəd  

## 🛡️ Təhlükəsizlik Tövsiyələri

DNS spoofing kimi hücumlara qarşı qorunmaq üçün aşağıdakı tədbirləri görmək vacibdir:

- **DNSSEC** (DNS Security Extensions) istifadə edin.
- DNS serverlərinizi güncəlləyin və zəif konfiqurasiyalardan çəkinin.
- TLS/HTTPS istifadəsini təşviq edin.
- DNS-over-HTTPS (DoH) və DNS-over-TLS (DoT) texnologiyalarına keçid edin.


## 📜 Qeyd

Bu layihə yalnız tədris və tədqiqat məqsədləri üçün nəzərdə tutulub. Real dünyada icazəsiz DNS spoofing fəaliyyəti qanunsuzdur və etik deyildir.
