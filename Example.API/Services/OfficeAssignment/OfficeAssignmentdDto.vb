Imports Example.API.Services.Instructor

Namespace Services.OfficeAssignment
    Public Class OfficeAssignmentDto
        Public Property InstructorID() As Integer

        Public Property Location() As String
        Public Property Timestamp() As Byte()

        Public Overridable Property Instructor() As InstructorDto
    End Class
End Namespace