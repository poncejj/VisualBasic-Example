Imports System.Data.Entity
Imports System.Threading.Tasks
Imports Example.API.Services.OnsiteCourseDetails

Namespace Services.OnsiteCourse
    Public Class OnsiteCourseService
        Inherits BaseService(Of OnsiteCourseModel)
        Implements IOnsiteCourseService

        Public Async Function GetAllOnsiteCourses() As Task(Of IEnumerable(Of OnsiteCourseDto)) Implements IOnsiteCourseService.GetAllOnsiteCourses
            Dim onlineCourses As IEnumerable(Of OnsiteCourseModel) = Await GetAll().AsNoTracking().ToListAsync()
            If onlineCourses Is Nothing OrElse onlineCourses.Count <= 0 Then
                Return Nothing
            End If

            Return onlineCourses.Map()
        End Function

        Public Async Function GetById(id As Integer) As Task(Of OnsiteCourseDto) Implements IOnsiteCourseService.GetById
            Dim onlineCourse As OnsiteCourseModel = Await GetByCondition(Function(c) c.CourseID.Equals(id)).
            Include(Function(c) c.Department).
            Include(Function(c) c.Instructors).
            FirstOrDefaultAsync()
            If onlineCourse Is Nothing Then
                Return Nothing
            End If

            Return onlineCourse.Map()
        End Function

        Public Async Function InsertAsync(onlineCourse As OnsiteCourseDto) As Task(Of Boolean) Implements IOnsiteCourseService.InsertAsync
            Dim newOnsiteCourse As OnsiteCourseModel = onlineCourse.Map()

            Return Await Insert(newOnsiteCourse)
        End Function

        Public Async Function UpdateAsync(onlineCourse As OnsiteCourseDto) As Task(Of Boolean) Implements IOnsiteCourseService.UpdateAsync
            Dim onlineCourseModel As OnsiteCourseModel = Await GetByCondition(Function(c) c.CourseID.Equals(onlineCourse.CourseID)).
            Include(Function(c) c.Instructors).
            FirstOrDefaultAsync()
            If onlineCourse Is Nothing Then
                Return False
            End If

            onlineCourseModel.Credits = onlineCourse.Credits
            onlineCourseModel.DepartmentID_FK = onlineCourse.DepartmentID
            onlineCourseModel.Instructors = onlineCourse.Instructors
            onlineCourseModel.Title = onlineCourse.Title
            onlineCourseModel.Details = onlineCourse.Details.Map()
            Return Await Update(onlineCourseModel)
        End Function

        Public Async Function DeleteAsync(id As Integer) As Task(Of Boolean) Implements IOnsiteCourseService.DeleteAsync
            Dim onlineCourse As OnsiteCourseModel = Await GetByCondition(Function(c) c.CourseID.Equals(id)).
            FirstOrDefaultAsync()
            If onlineCourse Is Nothing Then
                Return False
            End If

            Return Await Delete(onlineCourse)
        End Function
    End Class
End Namespace