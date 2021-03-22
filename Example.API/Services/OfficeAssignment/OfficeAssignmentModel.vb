Imports Example.API.Services.Instructor

Namespace Services.OfficeAssignment
    Public Class OfficeAssignmentModel
        Public Property InstructorID() As Integer

        Public Property Location() As String
        Public Property Timestamp() As Byte()

        Public Overridable Property Instructor() As InstructorModel
    End Class
End Namespace