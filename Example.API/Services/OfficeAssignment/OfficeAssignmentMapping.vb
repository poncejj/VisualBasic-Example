Imports System.Runtime.CompilerServices
Namespace Services.OfficeAssignment
    Module OfficeAssignmentMapping

        <Extension()>
        Public Function Map(officeAssignment As OfficeAssignmentDto) As OfficeAssignmentModel
            Dim newOfficeAssignment = New OfficeAssignmentModel()
            newOfficeAssignment.InstructorID = officeAssignment.InstructorID
            newOfficeAssignment.Location = officeAssignment.Location
            newOfficeAssignment.Timestamp = officeAssignment.Timestamp
            Return newOfficeAssignment
        End Function

        <Extension()>
        Public Function Map(officeAssignment As OfficeAssignmentModel) As OfficeAssignmentDto
            Dim newOfficeAssignment = New OfficeAssignmentDto()
            newOfficeAssignment.InstructorID = officeAssignment.InstructorID
            newOfficeAssignment.Location = officeAssignment.Location
            newOfficeAssignment.Timestamp = officeAssignment.Timestamp
            Return newOfficeAssignment
        End Function

        <Extension()>
        Public Function Map(officeAssignments As IEnumerable(Of OfficeAssignmentModel)) As IEnumerable(Of OfficeAssignmentDto)
            Return officeAssignments.Select(Function(officeAssignment) officeAssignment.Map())
        End Function
    End Module
End Namespace