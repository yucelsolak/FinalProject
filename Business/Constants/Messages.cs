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
        internal static string ProductNameAlreadyExist="Aynı isimde bir ürün mevcuttur.";
        internal static string CategoryCountError="Kategori sayısı aşıldı";
    }
}
