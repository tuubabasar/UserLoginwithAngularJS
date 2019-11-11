(function () {
    'use strict';//kodun katı kurallı olarak çalıştırılacağını belirtir yani bazı görmezden geldiği yanlış kullanımlarda hata verecektir..

    var app = angular.module('app', ["commonService","ngResource","ngRoute"]);//modul tanımı. ilk parametre modulün adı, diğerleri de modül için gerekli olan bağımlılıklar ve commonservice modülü

    //$routeProvider rotaları yapılandırmak için kullanılır
    app.config(function ($routeProvider) {
        $routeProvider        
            .when('/loginpage', {
                template: '<login-page></login-page>',
                templateUrl: 'app/loginPage/loginPage.html'
            })
            .when('/homepage', {
                template: '<home-page></home-page>',
                templateUrl: 'app/homePage/homePage.html'
            })
            .otherwise({ redirectTo: '/loginPage' })//ilk çalıştırdığımızda loginpage i çalıştıracaktır. <ng-view></ng-view> kısmına loginpage.html sayfasını body olarak aktaracaktır ve login-lage.componentteki javascriptleri etkin kılacaktır.
    })
})();