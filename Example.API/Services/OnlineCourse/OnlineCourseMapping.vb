Imports System.Runtime.CompilerServices
Namespace Services.OnlineCourse
    Module OnlineCourseMapping

        <Extension()>
        Public Function Map(onlineCourse As OnlineCourseDto) As OnlineCourseModel
            Dim newOnlineCourse = New OnlineCourseModel()
            newOnlineCourse.Credits = onlineCourse.Credits
            newOnlineCourse.DepartmentID_FK = onlineCourse.DepartmentID
            newOnlineCourse.Instructors = onlineCourse.Instructors
            newOnlineCourse.Title = onlineCourse.Title
            newOnlineCourse.URL = onlineCourse.URL
            Return newOnlineCourse
        End Function

        <Extension()>
        Public Function Map(onlineCourse As OnlineCourseModel) As OnlineCourseDto
            Dim newOnlineCourse = New OnlineCourseDto()
            newOnlineCourse.CourseID = onlineCourse.CourseID
            newOnlineCourse.Credits = onlineCourse.Credits
            newOnlineCourse.DepartmentID = onlineCourse.DepartmentID_FK
            newOnlineCourse.Instructors = onlineCourse.Instructors
            newOnlineCourse.Title = onlineCourse.Title
            Return newOnlineCourse
        End Function

        <Extension()>
        Public Function Map(onlineCourses As IEnumerable(Of OnlineCourseModel)) As IEnumerable(Of OnlineCourseDto)
            Return onlineCourses.Select(Function(onlineCourse) onlineCourse.Map())
        End Function
    End Module
End Namespace