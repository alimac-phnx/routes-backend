using Bogus;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfiguration;

/*порядок нужно генерить не только на основе количества точек, которые тут генерятся,
 а ещё и на основе их принадлежности к одному трипу. То есть разбивать их по кучкам
 SELECT WHERE Place.TriPID = Place.TRIPID и тогда выбиратся порядок из количества вхождений
*/
internal class PlaceFaker
{
    public static ICollection<Place> GenerateMany(int count, ICollection<Point> points)
    {
        var randomOrders = Enumerable.Range(1, count)
            .OrderBy(x => Guid.NewGuid())
            .ToList();
        var orderIndex = 0;
        var imagesUrls = new[]
        {
            "https://my-travel-diary.by/wp-content/uploads/2021/05/imgonline-com-ua-Resize-jQ0vSdFhNsyyoIZ-min.jpg",
            "https://cdn.tripster.ru/thumbs2/9d08a8c2-baa8-11ee-bba1-aadc1a05e482.1220x600.jpeg",
            "https://static.aviasales.com/psgr-v2/ru/interesnye-goroda-belarusi/Vid_na_nochnoj_Grodno_a0952cc1d4.jpeg",
            "https://welcometobelarus.ru/images/blog/2023/%D0%94%D0%B5%D1%81%D1%8F%D1%82%D1%8C_%D1%81%D0%B0%D0%BC%D1%8B%D1%85_%D0%B4%D1%80%D0%B5%D0%B2%D0%BD%D0%B8%D1%85_%D0%B3%D0%BE%D1%80%D0%BE%D0%B4%D0%BE%D0%B2_%D0%91%D0%B5%D0%BB%D0%B0%D1%80%D1%83%D1%81%D0%B8/1.jpg",
            "https://34travel.me/media/upload/images/2019/july/pinsk-new/296A0194.jpg",
            "https://static.aviasales.com/psgr-v2/ru/interesnye-goroda-belarusi/Pinsk_25b13abdbd.jpeg",
            "https://www.belarus.by/dadvimages/s000393_614092.jpg",
            "https://lh5.googleusercontent.com/proxy/VYi3Im9V4xkwTDQDLKQ7-dvNy92iXjbSXbcd3YffL2Uh_EgjD_hTTo0vSypZhrJbap5yq2UHD6gArXyHYqXWLZn87awkuQps1TWZQkpi39UiGm5U-WtVelfBlBW8603Yx8Qofor296LdlCLD0F10CSVxCaqfg8gZXw_P-WjzQ2Q",
            "https://trakt.by/upload/resize_cache/webp/local/templates/travelsoft/img/belarus/info/7.webp",
            "https://i.pinimg.com/736x/3d/a4/58/3da45860965360b9c9c77c3fc80d7a3b.jpg",
            "https://www.belarus.by/dadvimages/000410_622134.jpg",
            "https://greenbelarus.info/files/1-7_0.jpg",
            "https://imgproxy.soyuz.by/_g-nNGCo0rPIeqAybn11eKxrdOuICTn-8F3Xao4_K2g/w:943/czM6Ly9zb3l1ei5ieS8zNzI5L2xha2UtaXJlbmUtMTY3OTcwOF8xOTIwLmpwZw.jpg",
            "https://ybis.ru/wp-content/uploads/2023/09/belorusskii-peizazh-2.webp",
            "https://problr.by/images/pro_belarus/priroda/priroda002.JPG",
            "https://vetliva.ru/upload/medialibrary/bcc/bccb2b0a1c422e9cdd4579fb135585d1.png",
            "https://kartinki.pibig.info/uploads/posts/2023-04/thumbs/1680697873_kartinki-pibig-info-p-kartinki-prirodi-belarusi-krasivie-arti-68.jpg",
            "https://gomel-forum.by/wp-content/uploads/2023/11/belorusskie-reki.jpg",
            "https://www.fotobel.by/images/pejzazh-belarusi/pejzazh_45.jpg",
            "https://34travel.me/media/upload/images/2023/JUNE/picnic-belarus/296A2430.jpg",
        };
        
        return new Faker<Place>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.RouteId, f => f.Random.Int(1, count))
            .RuleFor(p => p.Name, f => f.Address.City())
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(u => u.ImageUrl, f => f.PickRandom(imagesUrls))
            .RuleFor(p => p.PointId, f => points.Single(s => s.Id == f.IndexFaker + 1).Id)
            .FinishWith((f, p) => 
            {
                p.OrderOfVisit = randomOrders[orderIndex];
                orderIndex++;
            })
            .Generate(count);
    }
}