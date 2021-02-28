using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarInvalid = "Araba adı 2 karekter ve günlük fiyat 0 dan büyük olmalı !";
        public static string CarAdded = "Araç başarıyla eklendi";
        public static string CarsListed = "Araçlar listelendi";
        public static string BrandsListed = "Markalar listelendi";
        public static string CarImageAdded = "Araç resimi eklendi";
        public static string CarImageUpdated = "Araç resimi güncellendi";
        public static string CarImageDeleted= "Araç resimi silindi";
        public static string CarImagesListed = "Araç resimleri listelendi";
        public static string CarImagesLimitExceeded = "En fazla 5 resim yüklenebilir";
    }
}
