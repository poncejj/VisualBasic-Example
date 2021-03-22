Imports Example.API.Services.Course
Imports Example.API.Services.OfficeAssignment
Imports Example.API.Services.Person

Namespace Services.Instructor
    Public Class InstructorDto
        Inherits PersonDto
        Public Property HireDate() As Date
        Public Overridable Property Courses() As ICollection(Of CourseDto)
        Public Overridable Property OfficeAssignment() As OfficeAssignmentDto
    End Class
End Namespace