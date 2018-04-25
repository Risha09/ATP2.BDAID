﻿app.controller('AdminPostController', function ($scope, $http, $timeout) {

    $scope.RootUrl = "";
    $scope.SelectedIndex = -1;
    $scope.ProcessingCount = 0;

    

    //List Page

    $scope.Init = function (url) {
        $scope.RootUrl = url;
        $scope.LoadPosts();
    };

    $scope.EidtPost = function() {

        if ($scope.SelectedIndex == -1) {
            alert('Please Select a row first');
            return;
        }

        window.location.href = $scope.RootUrl + "AdminPost/Detail/?id=" + $scope.Posts[$scope.SelectedIndex].ID;
    };

    $scope.ChangeStatus = function (status) {

        if ($scope.SelectedIndex == -1) {
            alert('Please Select a row first');
            return;
        }

        if ($scope.Posts[$scope.SelectedIndex].StatusID == status) {
            alert('This Post is Already in Same State');
            return;
        }

        if (!confirm("Are you Sure?"))
            return;

        $scope.ProcessingCount++;
        $http({
            method: "GET",
            url: $scope.RootUrl + "api/Post2/UpdateStatus",
            params: { id: $scope.Posts[$scope.SelectedIndex].ID, statusId: status }
        }).then(
					function mySuccess(response) {
					    $scope.ProcessingCount--;
					    var result = response.data;
					    
					    if (result.HasError) {
					        alert(result.Message);
					        return;
					    }

					    $scope.Posts[$scope.SelectedIndex].StatusID = result.Data.StatusID;
					    $scope.Posts[$scope.SelectedIndex].Status = result.Data.Status;

					},
					function myError(response) {
					    $scope.ProcessingCount--;
					    alert(response.statusText);
					}
				);
    };

    $scope.LoadPosts = function () {

        $scope.ProcessingCount++;
        $http({
            method: "GET",
            url: $scope.RootUrl + "api/Post2/getall",
            params: { key: "" }
        }).then(
					function mySuccess(response) {
					    $scope.ProcessingCount--;
					    var result = response.data;
					    $scope.Posts = result;
					    console.log($scope.Posts);
					},
					function myError(response) {
					    $scope.ProcessingCount--;
					    alert(response.statusText);
					}
				);

    };

    $scope.ChangeRow = function(index) {
        $scope.SelectedIndex = index;
    }

});

app.controller('AdminDetailPostController', function ($scope, $http) {

    $scope.RootUrl = "";
    $scope.ProcessingCount = 0;
    $scope.PostID = 0;

    //List Page

    $scope.InitEdit = function (url,id) {
        $scope.RootUrl = url;
        $scope.PostID = id;
        $scope.LoadPost();

    };

    $scope.EditUser = function () {

        window.location.href = $scope.RootUrl + "AdminUser/Detail/?id=" + $scope.Post.UserInfo.ID;
    };

    $scope.LoadPost = function () {

        $scope.ProcessingCount++;
        $http({
            method: "GET",
            url: $scope.RootUrl + "api/Post2/GetByID",
            params: { id: $scope.PostID }
        }).then(
					function mySuccess(response) {
					    $scope.ProcessingCount--;
					    var result = response.data;

					    if (result.HasError) {
					        alert(result.Message);
					        return;
					    }

					    $scope.Post = result.Data;
					    $scope.LoadComments();
					    
					},
					function myError(response) {
					    $scope.ProcessingCount--;
					    alert(response.statusText);
					}
				);

    };

    $scope.LoadComments = function () {

        $scope.ProcessingCount++;
        $http({
            method: "GET",
            url: $scope.RootUrl + "api/PostComment2/GetByPostID",
            params: { pid: $scope.PostID }
        }).then(
					function mySuccess(response) {
					    $scope.ProcessingCount--;

					    $scope.Comments = response.data;
					    $scope.LoadDonations();
					},
					function myError(response) {
					    $scope.ProcessingCount--;
					    alert(response.statusText);
					}
				);

    };

    $scope.LoadDonations = function () {

        $scope.ProcessingCount++;
        $http({
            method: "GET",
            url: $scope.RootUrl + "api/donation2/GetByPostID",
            params: { pid: $scope.PostID }
        }).then(
					function mySuccess(response) {
					    $scope.ProcessingCount--;
					    $scope.Donations = response.data;
					},
					function myError(response) {
					    $scope.ProcessingCount--;
					    alert(response.statusText);
					}
				);

    };
});

app.controller('DashboardController', function ($scope, $http) {

    $scope.RootUrl = "";
    $scope.ProcessingCount = 0;

    $scope.labelUsers = ["Admin", "Employee"];
    $scope.dataUsers = [1, 1];

    $scope.labels1 = ["Sun", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat"];
    $scope.data1 = [10, 15, 5, 25, 3, 8, 2];

    //List Page

    $scope.Init = function (url) {
        $scope.RootUrl = url;
        $scope.LoadCharts();
    };

    $scope.LoadCharts = function () {

        $scope.ProcessingCount++;
        $http({
            method: "GET",
            url: $scope.RootUrl + "api/dashboard2/GetPosts2"
        }).then(
					function mySuccess(response) {

					    var result = response.data;
					    $scope.labelPosts = result.Labels;
					    $scope.dataPosts = result.Datas;

					    $scope.LoadBarCharts();
					},
					function myError(response) {
					    $scope.ProcessingCount--;
					    alert(response.statusText);
					}
				);
    };

    $scope.LoadBarCharts = function() {


        $scope.ProcessingCount++;
        $http({
            method: "GET",
            url: $scope.RootUrl + "api/dashboard2/GetResponses"
        }).then(
					function mySuccess(response) {

					    var result = response.data;
					    $scope.labels1 = result.Labels;
					    $scope.data1 = result.Datas;
					},
					function myError(response) {
					    $scope.ProcessingCount--;
					    alert(response.statusText);
					}
				);

    };
});

app.controller('RDashboardController', function ($scope, $http) {

    $scope.RootUrl = "";
    $scope.ProcessingCount = 0;

    //$scope.labelUsers = ["Admin", "Employee"];
    //$scope.dataUsers = [1, 1];

    //$scope.labelPosts = ["Blood", "Flood", "Winter"];
    //$scope.dataPosts = [1, 1, 2];

    //List Page

    $scope.Init = function (url) {
        $scope.RootUrl = url;
        $scope.LoadCharts();
    };

    $scope.LoadCharts = function () {

        $scope.ProcessingCount++;
        $http({
            method: "GET",
            url: $scope.RootUrl + "api/dashboard2/GetPosts2"
        }).then(
					function mySuccess(response) {

					    var result = response.data;
					    $scope.labelPosts = result.Labels;
					    $scope.dataPosts = result.Datas;

					    $scope.LoadPieCharts();
					},
					function myError(response) {
					    $scope.ProcessingCount--;
					    alert(response.statusText);
					}
				);

    };

    $scope.LoadPieCharts = function () {


        $scope.ProcessingCount++;
        $http({
            method: "GET",
            url: $scope.RootUrl + "api/dashboard2/GetPosts2ByCurrentUser"
        }).then(
					function mySuccess(response) {

					    var result = response.data;
					    $scope.labelCurrentPosts = result.Labels;
					    $scope.dataCurrentPosts = result.Datas;

					    $scope.LoadPieCharts();
					},
					function myError(response) {
					    $scope.ProcessingCount--;
					    alert(response.statusText);
					}
				);

    };
});