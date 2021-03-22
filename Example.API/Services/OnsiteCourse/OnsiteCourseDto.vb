Imports Example.API.Services.Course
Imports Example.API.Services.OnsiteCourseDetails

Namespace Services.OnsiteCourse
    Partial Public Class OnsiteCourseDto
        Inherits CourseDto

        Public Sub New()
            Me.Details = New OnsiteCourseDetailsDto()
        End Sub

        Public Property Details() As OnsiteCourseDetailsDto
    End Class
End Namespace