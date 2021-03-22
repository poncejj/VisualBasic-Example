Imports System.Runtime.CompilerServices
Namespace Services.OnsiteCourseDetails
    Module OnsiteCourseDetailsMapping

        <Extension()>
        Public Function Map(onsiteCourseDetails As OnsiteCourseDetailsDto) As OnsiteCourseDetailsModel
            Dim newOnsiteCourseDetails = New OnsiteCourseDetailsModel()
            newOnsiteCourseDetails.Days = onsiteCourseDetails.Days
            newOnsiteCourseDetails.Location = onsiteCourseDetails.Location
            newOnsiteCourseDetails.Time = onsiteCourseDetails.Time
            Return newOnsiteCourseDetails
        End Function

        <Extension()>
        Public Function Map(onsiteCourseDetails As OnsiteCourseDetailsModel) As OnsiteCourseDetailsDto
            Dim newOnsiteCourseDetails = New OnsiteCourseDetailsDto()
            newOnsiteCourseDetails.Days = onsiteCourseDetails.Days
            newOnsiteCourseDetails.Location = onsiteCourseDetails.Location
            newOnsiteCourseDetails.Time = onsiteCourseDetails.Time
            Return newOnsiteCourseDetails
        End Function

        <Extension()>
        Public Function Map(onsiteCourseDetailss As IEnumerable(Of OnsiteCourseDetailsModel)) As IEnumerable(Of OnsiteCourseDetailsDto)
            Return onsiteCourseDetailss.Select(Function(onsiteCourseDetails) onsiteCourseDetails.Map())
        End Function
    End Module
End Namespace