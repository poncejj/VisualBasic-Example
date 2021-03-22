Imports System.Runtime.CompilerServices
Namespace Services.Department
    Module DepartmentMapping

        <Extension()>
        Public Function Map(department As DepartmentDto) As DepartmentModel
            Dim newDepartment = New DepartmentModel()
            newDepartment.Administrator = department.Administrator
            newDepartment.Budget = department.Budget
            newDepartment.Courses = department.Courses
            newDepartment.Name = department.Name
            newDepartment.StartDate = department.StartDate
            Return newDepartment
        End Function

        <Extension()>
        Public Function Map(department As DepartmentModel) As DepartmentDto
            Dim newDepartment = New DepartmentDto()
            newDepartment.Administrator = department.Administrator
            newDepartment.Budget = department.Budget
            newDepartment.Courses = department.Courses
            newDepartment.DepartmentID = department.DepartmentID
            newDepartment.Name = department.Name
            newDepartment.StartDate = department.StartDate
            Return newDepartment
        End Function

        <Extension()>
        Public Function Map(departments As IEnumerable(Of DepartmentModel)) As IEnumerable(Of DepartmentDto)
            Return departments.Select(Function(department) department.Map())
        End Function
    End Module
End Namespace