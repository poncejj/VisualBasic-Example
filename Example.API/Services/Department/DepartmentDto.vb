Imports Example.API.Services.Course
Namespace Services.Department
    Public Class DepartmentDto
        Public Property DepartmentID() As Integer
        Public Property Name() As String
        Public Property Budget() As Decimal
        Public Property StartDate() As Date
        Public Property Administrator() As Integer?
        Public Overridable Property Courses() As ICollection(Of CourseDto)
    End Class
End Namespace