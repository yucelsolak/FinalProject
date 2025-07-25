using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün adı geçersiz.";
        public static string ProductCountByCategoryError="Bir kategoriye en fazla 10 ürün eklenebilir.";
        public static string ProductNameAlreadyExist ="Aynı isimde bir ürün mevcuttur.";
        public static string CategoryCountError ="Kategori sayısı aşıldı";
        public static string AuthorizationDenied = "Bu işlem için yetkiniz yoktur.";
        public static string UserRegistered="Kullanıcı kayıt edildi.";
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten kayıtlı.";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
