Imports Example.API.Services.Course
Imports Example.API.Services.OfficeAssignment
Imports Example.API.Services.Person

Namespace Services.Instructor
    Public Class InstructorModel
        Inherits PersonModel

        Public Sub New()
            Me.Courses = New List(Of CourseModel)()
        End Sub

        Public Property HireDate() As Date
        Public Overridable Property Courses() As ICollection(Of CourseModel)
        Public Overridable Property OfficeAssignment() As OfficeAssignmentModel
    End Class
End Namespace