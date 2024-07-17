using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new BlogDataContext())
{
    // var tag = new Tag(){
    //     Name = ".NET",
    //     Slug = "dotnet"
    // };
    // context.Tags.Add(tag);
    // context.SaveChanges();

    // var tag = context.Tags.FirstOrDefault(x => x.Id == 3);
    // tag.Name = ".NET";
    // tag.Slug = "dotnet";
    // context.Tags.Update(tag);
    // context.SaveChanges();

    // var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    // context.Tags.Remove(tag);
    // context.SaveChanges();

    // var tags = context.Tags.AsNoTracking().Where(x => x.Name.Contains(".NET")).ToList();
    // foreach (var tag in tags)
    // {
    //     Console.WriteLine(tag.Name);
    // }
    // var tag = context.Tags.FirstOrDefault(x=> x.Id == 3);
    // System.Console.WriteLine(tag.Name);

    // var user = new User(){
    //     Name = "André Baltieri",
    //     Slug = "andrebaltieri",
    //     Email = "andre@balta.io",
    //     Bio = "9x Microsoft MVP",
    //     Image = "https://balta.io",
    //     PasswordHash = "123098457"
    // };
    // var category = new Category(){
    //     Name = "Backend",
    //     Slug = "backend"
    // };
    // var post = new Post(){
    //     Author = user,
    //     Category = category,
    //     Body = "<p>Hello World</p>",
    //     Slug = "comecando-com-ef-core",
    //     Summary = "Neste artigo vamos aprender EF Core",
    //     Title = "Começando com EF Core",
    //     CreateDate = DateTime.Now,
    //     LastUpdateDate = DateTime.Now
    // };

    // context.Posts.Add(post);
    // context.SaveChanges(); // isso vai criar um post no banco de dados e além disso, vai criar automaticamente um user e uma category


    // var posts = context
    // .Posts
    // .AsNoTracking()
    // .Include(x => x.Author)
    // .Include(x=> x.Category)
    // .OrderByDescending(x => x.LastUpdateDate)
    // .ToList();

    // foreach (var item in posts)
    // {
    //     Console.WriteLine($"{item.Title} - escrito por: {item.Author?.Name} em {item.Category.Name}");
    // }

    var post = context.Posts
    .Include(x => x.Author)
    .Include(x => x.Category)
    .OrderByDescending(x => x.LastUpdateDate)
    .FirstOrDefault();
    
    post.Author.Name = "Teste";
    
    context.Posts.Update(post);
    context.SaveChanges();
}