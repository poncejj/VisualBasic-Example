Imports Example.API.Services.Instructor

Namespace Services.Course
    Public Class CourseDto
        Public Property CourseID() As Integer
        Public Property Title() As String
        Public Property Credits() As Integer
        Public Property DepartmentID() As Integer
        Public Overridable Property Instructors() As ICollection(Of InstructorModel)
    End Class
End Namespace