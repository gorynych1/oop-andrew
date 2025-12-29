using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StudentDecisionTests
{
    [TestMethod]
    public void ProgrammingBelowThree_Expelled()
    {
        var student = Student.CreateForTest(2, 5, 5, 5);
        Assert.IsFalse(student.GetDecision());
    }

    [TestMethod]
    public void TwoBadSubjects_Expelled()
    {
        var student = Student.CreateForTest(4, 2, 2, 5);
        Assert.IsFalse(student.GetDecision());
    }

    [TestMethod]
    public void OneBadSubject_Stay()
    {
        var student = Student.CreateForTest(4, 2, 5, 5);
        Assert.IsTrue(student.GetDecision());
    }

    [TestMethod]
    public void AllGoodMarks_Stay()
    {
        var student = Student.CreateForTest(5, 5, 5, 5);
        Assert.IsTrue(student.GetDecision());
    }

    [TestMethod]
    public void BorderCase_ProgrammingThree_Stay()
    {
        var student = Student.CreateForTest(3, 3, 4, 4);
        Assert.IsTrue(student.GetDecision());
    }
}