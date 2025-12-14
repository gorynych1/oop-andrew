using NUnit.Framework;
using System;
using Classroom;

namespace ClassroomTests
{
    [TestFixture]
    public class PupilTests
    {
        [Test]
        public void Test1_ClassRoomCreationWithFourPupils_Success()
        {
            // Arrange & Act
            var classroom = new ClassRoom(
                new ExcellentPupil(),
                new GoodPupil(),
                new BadPupil(),
                new GoodPupil()
            );

            // Assert
            Assert.IsNotNull(classroom);
        }

        [Test]
        public void Test2_ClassRoomCreationWithThreePupils_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => 
                new ClassRoom(new ExcellentPupil(), new GoodPupil(), new BadPupil()));
        }

        [Test]
        public void Test3_ClassRoomCreationWithFivePupils_ThrowsException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => 
                new ClassRoom(
                    new ExcellentPupil(),
                    new GoodPupil(), 
                    new BadPupil(),
                    new GoodPupil(),
                    new ExcellentPupil()
                ));
        }

        [Test]
        public void Test4_ExcellentPupilGrade_InRange()
        {
            // Arrange
            var pupil = new ExcellentPupil();

            // Act
            var grade = pupil.GetCurrentGrade;

            // Assert
            Assert.That(grade, Is.InRange(2, 5));
        }

        [Test]
        public void Test5_GoodPupilGrade_InRange()
        {
            // Arrange
            var pupil = new GoodPupil();

            // Act
            var grade = pupil.GetCurrentGrade;

            // Assert
            Assert.That(grade, Is.InRange(2, 5));
        }

        [Test]
        public void Test6_BadPupilGrade_InRange()
        {
            // Arrange
            var pupil = new BadPupil();

            // Act
            var grade = pupil.GetCurrentGrade;

            // Assert
            Assert.That(grade, Is.InRange(2, 5));
        }

        [Test]
        public void Test7_ClassRoomAverageGrade_InRange()
        {
            // Arrange
            var classroom = new ClassRoom(
                new ExcellentPupil(),
                new GoodPupil(),
                new BadPupil(),
                new GoodPupil()
            );

            // Act
            var average = classroom.GetRoundGrade;

            // Assert
            Assert.That(average, Is.InRange(2.0, 5.0));
        }

        [Test]
        public void Test8_PupilNameAssignment_WorksCorrectly()
        {
            // Arrange
            var pupil = new ExcellentPupil();

            // Act
            pupil.Name = "Анна";

            // Assert
            Assert.That(pupil.Name, Is.EqualTo("Анна"));
        }

        [Test]
        public void Test9_PupilDefaultName_IsCorrect()
        {
            // Arrange
            var pupil = new GoodPupil();

            // Act & Assert
            Assert.That(pupil.Name, Is.EqualTo("Ученик"));
        }
    }
}