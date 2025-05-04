using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Tests.Queries;

[TestClass]
public class StudentQueriesTests
{
    private readonly IList<Student> _students;

    public StudentQueriesTests()
    {
        var students = new List<Student>();
        
        for (int i = 0; i < 10; i++)
        {
            students.Add(new Student(new Name("Aluno,", i.ToString()), new Document("1111111111" + i.ToString(), EDocumentType.CPF), new Email(i.ToString() + "@balta.io")));
        }
        _students = students;
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
        var expression = StudentQueries.GetStudentInfo("12345678911");
        var student = _students.AsQueryable().Where(expression).FirstOrDefault();

        Assert.AreEqual(null, student);
    }

    [TestMethod]
    public void ShouldReturnStudentWhenDocumentExists()
    {
        var expression = StudentQueries.GetStudentInfo("11111111111");
        var student = _students.AsQueryable().Where(expression).FirstOrDefault();

        Assert.AreNotEqual(null, student);
    }
}