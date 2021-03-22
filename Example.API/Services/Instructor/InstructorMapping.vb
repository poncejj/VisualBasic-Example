Imports System.Runtime.CompilerServices
Imports Example.API.Services.OfficeAssignment

Namespace Services.Instructor
    Module InstructorMapping

        <Extension()>
        Public Function Map(instructor As InstructorDto) As InstructorModel
            Dim newInstructor = New InstructorModel()
            newInstructor.Courses = instructor.Courses
            newInstructor.FirstName = instructor.FirstName
            newInstructor.HireDate = instructor.HireDate
            newInstructor.LastName = instructor.LastName
            newInstructor.OfficeAssignment = instructor.OfficeAssignment.Map()
            Return newInstructor
        End Function

        <Extension()>
        Public Function Map(instructor As InstructorModel) As InstructorDto
            Dim newInstructor = New InstructorDto()
            newInstructor.Courses = instructor.Courses
            newInstructor.FirstName = instructor.FirstName
            newInstructor.HireDate = instructor.HireDate
            newInstructor.LastName = instructor.LastName
            newInstructor.OfficeAssignment = instructor.OfficeAssignment.Map()
            newInstructor.PersonID = instructor.PersonID
            Return newInstructor
        End Function

        <Extension()>
        Public Function Map(instructors As IEnumerable(Of InstructorModel)) As IEnumerable(Of InstructorDto)
            Return instructors.Select(Function(instructor) instructor.Map())
        End Function
    End Module
End Namespace