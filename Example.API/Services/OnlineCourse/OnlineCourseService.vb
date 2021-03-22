Imports System.Data.Entity
Imports System.Threading.Tasks

Namespace Services.OnlineCourse
    Public Class OnlineCourseService
        Inherits BaseService(Of OnlineCourseModel)
        Implements IOnlineCourseService

        Public Async Function GetAllOnlineCourses() As Task(Of IEnumerable(Of OnlineCourseDto)) Implements IOnlineCourseService.GetAllOnlineCourses
            Dim onlineCourses As IEnumerable(Of OnlineCourseModel) = Await GetAll().AsNoTracking().ToListAsync()
            If onlineCourses Is Nothing OrElse onlineCourses.Count <= 0 Then
                Return Nothing
            End If

            Return onlineCourses.Map()
        End Function

        Public Async Function GetById(id As Integer) As Task(Of OnlineCourseDto) Implements IOnlineCourseService.GetById
            Dim onlineCourse As OnlineCourseModel = Await GetByCondition(Function(c) c.CourseID.Equals(id)).
            Include(Function(c) c.Department).
            Include(Function(c) c.Instructors).
            FirstOrDefaultAsync()
            If onlineCourse Is Nothing Then
                Return Nothing
            End If

            Return onlineCourse.Map()
        End Function

        Public Async Function InsertAsync(onlineCourse As OnlineCourseDto) As Task(Of Boolean) Implements IOnlineCourseService.InsertAsync
            Dim newOnlineCourse As OnlineCourseModel = onlineCourse.Map()

            Return Await Insert(newOnlineCourse)
        End Function

        Public Async Function UpdateAsync(onlineCourse As OnlineCourseDto) As Task(Of Boolean) Implements IOnlineCourseService.UpdateAsync
            Dim onlineCourseModel As OnlineCourseModel = Await GetByCondition(Function(c) c.CourseID.Equals(onlineCourse.CourseID)).
            Include(Function(c) c.Instructors).
            FirstOrDefaultAsync()
            If onlineCourse Is Nothing Then
                Return False
            End If

            onlineCourseModel.Credits = onlineCourse.Credits
            onlineCourseModel.DepartmentID_FK = onlineCourse.DepartmentID
            onlineCourseModel.Instructors = onlineCourse.Instructors
            onlineCourseModel.Title = onlineCourse.Title
            onlineCourseModel.URL = onlineCourse.URL
            Return Await Update(onlineCourseModel)
        End Function

        Public Async Function DeleteAsync(id As Integer) As Task(Of Boolean) Implements IOnlineCourseService.DeleteAsync
            Dim onlineCourse As OnlineCourseModel = Await GetByCondition(Function(c) c.CourseID.Equals(id)).
            FirstOrDefaultAsync()
            If onlineCourse Is Nothing Then
                Return False
            End If

            Return Await Delete(onlineCourse)
        End Function
    End Class
End Namespace