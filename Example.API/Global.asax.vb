Imports System.Web.Http
Imports System.Web.Optimization
Imports Example.API.Services.Course
Imports Example.API.Services.Department
Imports Example.API.Services.Instructor
Imports Example.API.Services.OfficeAssignment
Imports Example.API.Services.OnlineCourse
Imports Example.API.Services.OnsiteCourse
Imports Unity

Public Class WebApiApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        Dim container = New UnityContainer
        container.RegisterType(Of IDepartmentService, DepartmentService)()
        container.RegisterType(Of IController, DepartmentController)("Department")

        container.RegisterType(Of IInstructorService, InstructorService)()
        container.RegisterType(Of IController, InstructorController)("Instructor")

        container.RegisterType(Of IOfficeAssignmentService, OfficeAssignmentService)()
        container.RegisterType(Of IController, OfficeAssignmentController)("OfficeAssignment")

        container.RegisterType(Of IOnlineCourseService, OnlineCourseService)()
        container.RegisterType(Of IController, OnlineCourseController)("OnlineCourse")

        container.RegisterType(Of IOnsiteCourseService, OnsiteCourseService)()
        container.RegisterType(Of IController, OnsiteCourseController)("OnsiteCourse")


        Dim factory = New UnityControllerFactory(container)
        ControllerBuilder.Current.SetControllerFactory(factory)
    End Sub
End Class
