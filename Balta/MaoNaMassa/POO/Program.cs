using POO.ContentContext;
using POO.SubscriptionContext;

var articles = new List<Article>();
articles.Add(new Article("Artigo sobre OOP", "Orientacao-objetos"));
articles.Add(new Article("Artigo sobre C#P", "csharp"));
articles.Add(new Article("Artigo sobre .NET", "dotnet"));

foreach (var article in articles)
{
    Console.WriteLine(article.Id);
    Console.WriteLine(article.Title);
    Console.WriteLine(article.Url);
}

var courses = new List<Course>();

var courseOOP = new Course("Fundamentos OOP", "fundamentos-oop");
var courseCsharp = new Course("Fundamentos C#", "fundamentos-csharp");
var courseAspNet = new Course("Fundamentos AspNet", "fundamentos-AspNet");

courses.Add(courseOOP);
courses.Add(courseCsharp);
courses.Add(courseAspNet);

var careers = new List<Career>();
var careerDotNet = new Career("Especialista ,Net", "Especialista-dotnet");
var careerItem2 = new CareerItem(2, "aprenda c#", "", courseCsharp);
var careerItem = new CareerItem(1, "aprenda OOP", "", null);
var careerItem3 = new CareerItem(3, "aprenda .net", "", courseAspNet);

careerDotNet.Items.Add(careerItem2);
careerDotNet.Items.Add(careerItem);
careerDotNet.Items.Add(careerItem3);
careers.Add(careerDotNet);

foreach (var career in careers)
{
    Console.WriteLine(career.Title);

    foreach (var item in career.Items.OrderBy(x => x.Order))
    {
        Console.WriteLine($"{item.Order} - {item.Title}");
        Console.WriteLine(item.Course?.Title);
        Console.WriteLine(item.Course?.Level);

        foreach (var notification in item.Notifications)
        {
            System.Console.WriteLine($"{notification.Property} - {notification.Messege}");
        }
    }
}

var paypalSubscription = new PaypalSubscription();
var student = new Student();
student.CreateSubscription(paypalSubscription);