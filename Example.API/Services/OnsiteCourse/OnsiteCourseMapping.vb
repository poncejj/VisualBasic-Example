Imports System.Runtime.CompilerServices
Imports Example.API.Services.OnsiteCourseDetails

Namespace Services.OnsiteCourse
    Module OnsiteCourseMapping

        <Extension()>
        Public Function Map(onsiteCourse As OnsiteCourseDto) As OnsiteCourseModel
            Dim newOnsiteCourse = New OnsiteCourseModel()
            newOnsiteCourse.Credits = onsiteCourse.Credits
            newOnsiteCourse.DepartmentID_FK = onsiteCourse.DepartmentID
            newOnsiteCourse.Instructors = onsiteCourse.Instructors
            newOnsiteCourse.Title = onsiteCourse.Title
            newOnsiteCourse.Details = onsiteCourse.Details.Map()
            Return newOnsiteCourse
        End Function

        <Extension()>
        Public Function Map(onsiteCourse As OnsiteCourseModel) As OnsiteCourseDto
            Dim newOnsiteCourse = New OnsiteCourseDto()
            newOnsiteCourse.CourseID = onsiteCourse.CourseID
            newOnsiteCourse.Credits = onsiteCourse.Credits
            newOnsiteCourse.DepartmentID = onsiteCourse.DepartmentID_FK
            newOnsiteCourse.Instructors = onsiteCourse.Instructors
            newOnsiteCourse.Title = onsiteCourse.Title
            newOnsiteCourse.Details = onsiteCourse.Details.Map()
            Return newOnsiteCourse
        End Function

        <Extension()>
        Public Function Map(onsiteCourses As IEnumerable(Of OnsiteCourseModel)) As IEnumerable(Of OnsiteCourseDto)
            Return onsiteCourses.Select(Function(onsiteCourse) onsiteCourse.Map())
        End Function
    End Module
End Namespace