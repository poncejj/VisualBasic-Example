Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports Example.API.Services.Course
Imports Example.API.Services.Department
Imports Example.API.Services.Instructor
Imports Example.API.Services.OfficeAssignment
Imports Example.API.Services.OnlineCourse
Imports Example.API.Services.OnsiteCourse
Imports Example.API.Services.OnsiteCourseDetails
Imports Example.API.Services.Person

Public Class SchoolContext
    Inherits DbContext

    Public Property OfficeAssigments() As DbSet(Of OfficeAssignmentModel)
    Public Property Instructors() As DbSet(Of InstructorModel)
    Public Property Courses() As DbSet(Of CourseModel)
    Public Property Departments() As DbSet(Of DepartmentModel)
    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
        modelBuilder.ComplexType(Of OnsiteCourseDetailsModel)()
        modelBuilder.Entity(Of OfficeAssignmentModel)().ToTable("t_OfficeAssignment")
        modelBuilder.Entity(Of PersonModel)().
            Map(Of PersonModel)(Function(t) t.Requires("Type").
                HasValue("Person")).
                Map(Of InstructorModel)(Function(t) t.Requires("Type").
                HasValue("Instructor"))

        modelBuilder.Entity(Of CourseModel)().ToTable("Course")
        modelBuilder.Entity(Of OnsiteCourseModel)().ToTable("OnsiteCourse")
        modelBuilder.Entity(Of OnlineCourseModel)().ToTable("OnlineCourse")
        modelBuilder.Entity(Of OfficeAssignmentModel)().
            HasKey(Function(t) t.InstructorID)
        modelBuilder.Entity(Of DepartmentModel)().Property(Function(t) t.Name).
            HasMaxLength(60)
        modelBuilder.Entity(Of DepartmentModel)().Property(Function(t) t.Name).
            IsRequired()
        modelBuilder.Entity(Of CourseModel)().Property(Function(t) t.CourseID).
            HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
        modelBuilder.Entity(Of DepartmentModel)().
            Ignore(Function(t) t.Administrator)
        modelBuilder.Entity(Of DepartmentModel)().Property(Function(t) t.Budget).
            HasColumnName("DepartmentBudget")
        modelBuilder.Entity(Of DepartmentModel)().Property(Function(t) t.Name).
            HasColumnType("varchar")
        modelBuilder.Entity(Of OnsiteCourseModel)().Property(Function(t) t.Details.Days).
            HasColumnName("Days")
        modelBuilder.Entity(Of OnsiteCourseModel)().Property(Function(t) t.Details.Location).
            HasColumnName("Location")
        modelBuilder.Entity(Of OnsiteCourseModel)().Property(Function(t) t.Details.Time).
            HasColumnName("Time")

        modelBuilder.Entity(Of OfficeAssignmentModel)().
            HasRequired(Function(t) t.Instructor).
            WithOptional(Function(t) t.OfficeAssignment)


        modelBuilder.Entity(Of CourseModel)().
            HasMany(Function(t) t.Instructors).
            WithMany(Function(t) t.Courses)

        modelBuilder.Entity(Of CourseModel)().
            HasMany(Function(t) t.Instructors).
            WithMany(Function(t) t.Courses).
            Map(Sub(m)
                    m.ToTable("CourseInstructor")
                    m.MapLeftKey("CourseID")
                    m.MapRightKey("InstructorID")
                End Sub)


        modelBuilder.Entity(Of CourseModel)().
            HasRequired(Function(t) t.Department).
            WithMany(Function(t) t.Courses).
            HasForeignKey(Function(t) t.DepartmentID_FK)


        modelBuilder.Entity(Of CourseModel)().
            HasRequired(Function(t) t.Department).
            WithMany(Function(t) t.Courses).
            HasForeignKey(Function(d) d.DepartmentID_FK).
            WillCascadeOnDelete(False)
    End Sub
End Class
