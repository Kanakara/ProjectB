namespace ProjectB {

    angular.module('ProjectB', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/blog.html',
                controller: ProjectB.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('dpc', {
                url: '/dpc',
                templateUrl: '/ngApp/views/dpc.html',
                controller: ProjectB.Controllers.EventController,
                controllerAs: 'controller'
            })
            .state('rere', {
                url: '/rere',
                templateUrl: '/ngApp/views/rere.html',
                controller: ProjectB.Controllers.ReReController,
                controllerAs: 'controller'
            })
            .state('rere.rerehome', {
                url: '/rerehome',
                templateUrl: '/ngApp/views/rerehome.html',
                controller: ProjectB.Controllers.ReReController,
                controllerAs: 'controller',
            })
            .state('rere.rereabout', {
                url: '/rereabout',
                templateUrl: '/ngApp/views/rereabout.html',
                controller: ProjectB.Controllers.ReReController,
                controllerAs: 'controller',
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: ProjectB.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: ProjectB.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: ProjectB.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: ProjectB.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('blog', {
                url: '/blog',
                templateUrl: '/ngApp/views/blog.html',
                controller: ProjectB.Controllers.BlogController,
                controllerAs: 'controller'
            })
            .state('blogcreate', {
                url: '/blogcreate',
                templateUrl: '/ngApp/views/blogcreate.html',
                controller: ProjectB.Controllers.BlogController,
                controllerAs: 'controller'
            })
            .state('rereblog', {
                url: '/rereblog',
                templateUrl: '/ngApp/views/rereblog.html',
                controller: ProjectB.Controllers.ReReController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });


    angular.module('ProjectB').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('ProjectB').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });



}
