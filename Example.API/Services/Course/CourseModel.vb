Imports Example.API.Services.Department
Imports Example.API.Services.Instructor

Namespace Services.Course
    Public Class CourseModel
        Public Sub New()
            Me.Instructors = New HashSet(Of InstructorModel)()
        End Sub

        Public Property CourseID() As Integer
        Public Property Title() As String
        Public Property Credits() As Integer

        Public Property DepartmentID_FK() As Integer

        Public Overridable Property Department() As DepartmentModel
        Public Overridable Property Instructors() As ICollection(Of InstructorModel)
    End Class
End Namespace
