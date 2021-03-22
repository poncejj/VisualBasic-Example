Imports System.Threading.Tasks

Namespace Services.OnlineCourse
    Public Class OnlineCourseController
        Inherits Controller
        Private _service As IOnlineCourseService

        Public Sub New(ByVal service As IOnlineCourseService)
            _service = service
        End Sub

        Public Function GetAll() As ActionResult
            Dim onlineCourses = _service.GetAllOnlineCourses()
            Return View(onlineCourses)
        End Function

        Public Function GetById(ByVal onlineCourseId As Integer) As ActionResult
            Dim onlineCourse = _service.GetById(onlineCourseId)
            Return View(onlineCourse)
        End Function

        <HttpPost()>
        Public Async Function Insert(onlineCourse As OnlineCourseDto) As Task(Of ActionResult)
            Dim result = Await _service.InsertAsync(onlineCourse)
            Return View(result)
        End Function

        <HttpPut()>
        Public Async Function Update(onlineCourse As OnlineCourseDto) As Task(Of ActionResult)
            Dim result = Await _service.UpdateAsync(onlineCourse)
            Return View(result)
        End Function

        <HttpDelete()>
        Public Async Function Delete(onlineCourseId As Integer) As Task(Of ActionResult)
            Dim result = Await _service.DeleteAsync(onlineCourseId)
            Return View(result)
        End Function
    End Class
End Namespace