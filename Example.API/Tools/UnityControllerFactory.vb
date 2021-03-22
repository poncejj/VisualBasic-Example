Imports Unity

Public Class UnityControllerFactory
    Implements IControllerFactory

    Private _container As IUnityContainer
    Private _innerFactory As IControllerFactory

    Public Sub New(ByVal container As IUnityContainer)
        Me.New(container, New DefaultControllerFactory)
    End Sub

    Protected Sub New(ByVal container As IUnityContainer,
                      ByVal innerFactory As IControllerFactory)

        _container = container
        _innerFactory = innerFactory
    End Sub

    Public Function CreateController(ByVal requestContext As RequestContext,
                                     ByVal controllerName As String
                                     ) As IController Implements IControllerFactory.CreateController

        Try
            Return _container.Resolve(Of IController)(controllerName)
        Catch e1 As Exception
            Return _innerFactory.CreateController(requestContext, controllerName)
        End Try
    End Function

    Public Sub ReleaseController(ByVal controller As IController) Implements IControllerFactory.ReleaseController
        Dim disposable As IDisposable = controller
        If disposable IsNot Nothing Then
            disposable.Dispose()
        End If
    End Sub

    Public Function GetControllerSessionBehavior(ByVal requestContext As RequestContext, ByVal controllerName As String) As System.Web.SessionState.SessionStateBehavior Implements IControllerFactory.GetControllerSessionBehavior
        Return SessionStateBehavior.Default
    End Function

End Class