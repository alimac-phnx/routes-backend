using Bogus;
using WebRoutes.Enums;
using WebRoutes.Models;

namespace WebRoutes.Infrastructure.TestDataConfiguration;

internal static class AdditionalPlaceFaker
{
    public static ICollection<AdditionalPlace> GenerateMany(int count, ICollection<Point> points)
    {
        var imagesUrls = new[]
        {
            "https://s5.afisha.ru/mediastorage/48/a8/aa1abad98919435199dfe22aa848.jpg",
            "https://bestbelarus.by/upload/resize_cache/webp/resize_cache/iblock/70d/362_228_2/z5rfktd1sg5wmxabchpdrucptjy9f206.webp",
            "https://bestbelarus.by/upload/resize_cache/webp/medialibrary/a3e/a3e090b49bf8de46bcfee259f2cfdfcc.webp",
            "https://bestbelarus.by/upload/resize_cache/webp/medialibrary/460/460dcd3778de35395eec5334a31d580e.webp",
            "https://smapse.ru/storage/2018/11/converted/225_190_maxresdefault-1.jpg",
            "https://imgproxy.soyuz.by/E_DPlL9w2zSRoq_KGHKZXjHbiFMrYUbKA_MCWo_Flr8/w:943/czM6Ly9zb3l1ei5ieS8zMTU2OS8wMDAwMjJfMTY5NjQyNjY1N181OTE5NDJfYmlnLmpwZw.jpg",
            "https://belmart.ru/templates/belmart/resource/img/showroom.jpg",
            "https://stat2.city-dog.by/content/editor_images/2023/06_june/18_32773/347402286_737527498374246_2018042664728694889_n.jpeg",
            "https://belfranchising.by/assets/content/catalog/%D0%9A%D0%BE%D1%84%D0%B5%20%D0%A1%D0%B0%D1%83%D0%BD%D0%B4/12.10.2022/%D0%BA%D0%BE%D1%84%D0%B5%D0%B8%CC%86%D0%BD%D1%8F1.jpeg",
            "https://irecommend.ru/sites/default/files/imagecache/copyright1/user-images/2353411/RuWQ9TI5aYTZFzklJK6jg.jpg",
            "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/2a/ab/4d/d5/caption.jpg?w=500&h=500&s=1",
            "https://1prof.by/wp-content/uploads/2023/04/1682493784594.jpg",
            "https://www.holiday.by/files/byblog/9ec0bc8855550ef8b3e8dbea02a13097-thumb-1400x1500-w.jpg",
            "https://artfolk.by/wp-content/uploads/2017/01/news-020318-1032772567.jpg",
            "https://planetabelarus.by/upload/medialibrary/b52/z9bmd6tla8ky7ypr5cvi22ato1qr13wc.jpg",
            "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0b/57/e9/3b/caption.jpg?w=500&h=500&s=1"
        };
        
        return new Faker<AdditionalPlace>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.RouteId, f => f.Random.Int(1, count))
            .RuleFor(p => p.Name, f => f.Company.CompanyName())
            .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
            .RuleFor(p => p.PointId, f => points.Single(s => s.Id == f.IndexFaker + 1 + count).Id)
            .RuleFor(p => p.Type, f => f.PickRandom<AdditionalPlaceType>())
            .RuleFor(u => u.ImageUrl, f => f.PickRandom(imagesUrls))
            .Generate(count);
    }
}