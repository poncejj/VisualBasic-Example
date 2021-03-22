Imports Example.API.Services.Course
Imports Example.API.Services.OnsiteCourseDetails

Namespace Services.OnsiteCourse
    Partial Public Class OnsiteCourseModel
        Inherits CourseModel

        Public Sub New()
            Details = New OnsiteCourseDetailsModel()
        End Sub

        Public Property Details() As OnsiteCourseDetailsModel
    End Class
End Namespace